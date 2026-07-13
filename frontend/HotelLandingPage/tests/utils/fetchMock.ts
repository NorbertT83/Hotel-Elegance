import { vi } from 'vitest';

type FetchResponse = any;

let fetchSpy: any = null;

export function setFetchSequence(responses: FetchResponse[]) {
  restoreFetch();
  fetchSpy = vi.fn();
  responses.forEach((resp) => {
    if (typeof resp === 'function') {
      fetchSpy.mockImplementationOnce(resp as any);
    } else {
      fetchSpy.mockImplementationOnce(() => Promise.resolve(resp));
    }
  });
  (global as any).fetch = fetchSpy;
}

export function getFetchCalls() {
  return fetchSpy ? fetchSpy.mock.calls : [];
}

export function restoreFetch() {
  if ((global as any).fetch && fetchSpy) {
    try { delete (global as any).fetch; } catch {}
  }
  fetchSpy = null;
}
