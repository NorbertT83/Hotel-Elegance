import { describe, it, expect, vi, beforeEach, afterEach } from 'vitest';
import { setFetchSequence, restoreFetch, getFetchCalls } from './utils/fetchMock';

describe('apiService', () => {
  beforeEach(() => {
    vi.resetModules();
    vi.restoreAllMocks();
    restoreFetch();
  });

  afterEach(() => {
    restoreFetch();
  });

  it('getData returns parsed JSON on success', async () => {
    const body = { hello: 'world' };

    setFetchSequence([{ ok: true, status: 200, headers: { get: () => 'application/json' }, json: async () => body }]);

    const api = await import('../src/services/apiService');
    const res = await api.getData('test');
    expect(res).toEqual(body);
  });

  it('getData returns null on 404', async () => {
    setFetchSequence([{ ok: false, status: 404, headers: { get: () => '' }, text: async () => '' }]);
    const api = await import('../src/services/apiService');
    const res = await api.getData('missing');
    expect(res).toBeNull();
  });

  it('createData returns JSON error body when response not ok and json', async () => {
    const errorBody = { success: false, error: 'bad' };
    setFetchSequence([{ ok: false, status: 400, headers: { get: () => 'application/json' }, json: async () => errorBody }]);
    const api = await import('../src/services/apiService');
    const res = await api.createData('auth', { a: 1 });
    expect(res).toEqual(errorBody);
  });

  it('createData returns parsed body when ok', async () => {
    const body = { id: 1 };
    setFetchSequence([{ ok: true, status: 201, headers: { get: () => 'application/json' }, json: async () => body }]);
    const api = await import('../src/services/apiService');
    const res = await api.createData('item', { name: 'x' });
    expect(res).toEqual(body);
  });

  it('updateData throws when response not ok', async () => {
    setFetchSequence([{ ok: false, status: 500, headers: { get: () => '' }, text: async () => 'server error' }]);
    const api = await import('../src/services/apiService');
    await expect(api.updateData('item', '1', { a: 1 })).rejects.toThrow(/HTTP error: 500/);
  });

  it('deleteData returns success on 204', async () => {
    setFetchSequence([{ ok: true, status: 204, headers: { get: () => '' }, text: async () => '' }]);
    const api = await import('../src/services/apiService');
    const res = await api.deleteData('item', '1');
    expect(res).toEqual({ success: true });
  });

  it('baseRequest triggers logout when 401 and refresh fails', async () => {
    // first fetch returns 401
    setFetchSequence([{ ok: false, status: 401, headers: { get: () => '' }, text: async () => '' }]);

    const api = await import('../src/services/apiService');

    const logoutMock = vi.fn();
    api.apiServiceConfig.setLogoutCallback(logoutMock);

    // spy on tryToRefreshToken to return null
    vi.spyOn(api, 'tryToRefreshToken').mockResolvedValue(null as unknown as string);

    await expect(api.getData('protected')).rejects.toThrow('Session expired');
    expect(logoutMock).toHaveBeenCalled();
  });

  it('baseRequest retries after refresh when tryToRefreshToken returns new token', async () => {
    // first fetch -> 401 for protected
    // second fetch -> auth/refresh returns new token
    // third fetch -> protected returns ok
    setFetchSequence([
      { ok: false, status: 401, headers: { get: () => '' }, text: async () => '' },
      { ok: true, status: 200, headers: { get: () => 'application/json' }, json: async () => ({ accessToken: 'new-token' }) },
      { ok: true, status: 200, headers: { get: () => 'application/json' }, json: async () => ({ ok: true }) },
    ]);

    const api = await import('../src/services/apiService');

    const res = await api.getData('protected');
    expect(res).toEqual({ ok: true });
  });

  it('getData handles non-JSON text responses', async () => {
    setFetchSequence([{ ok: true, status: 200, headers: { get: () => 'text/plain' }, text: async () => 'plain text' }]);

    const api = await import('../src/services/apiService');
    const res = await api.getData('text-endpoint');
    expect(res).toBe('plain text');
  });

  it('getData times out and throws Request timed out when fetch aborts', async () => {
    const abortErr = new Error('aborted');
    abortErr.name = 'AbortError';
    setFetchSequence([() => Promise.reject(abortErr)]);

    const api = await import('../src/services/apiService');
    await expect(api.getData('will-timeout')).rejects.toThrow('Request timed out');
  });

  it('builds query parameters into the request URL', async () => {
    setFetchSequence([{ ok: true, status: 200, headers: { get: () => 'application/json' }, json: async () => ({ ok: true }) }]);

    const api = await import('../src/services/apiService');
    await api.getData('search', { q: 'term', page: '2' });

    const calls = getFetchCalls();
    expect(calls.length).toBeGreaterThan(0);
    const calledUrl = calls[0][0] as string;
    expect(calledUrl).toContain('/search?q=term&page=2');
  });
});
