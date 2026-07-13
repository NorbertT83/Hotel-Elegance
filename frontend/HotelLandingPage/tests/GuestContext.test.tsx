import { describe, it, expect, vi, beforeEach } from 'vitest';
import React from 'react';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';

describe('GuestContext login', () => {
  beforeEach(() => {
    vi.resetModules();
  });
  
  // Provide safe globals for tests (GuestContext uses localStorage and navigator)
  beforeEach(() => {
    (global as any).localStorage = {
      getItem: () => null,
      setItem: () => undefined,
      removeItem: () => undefined,
    };
    (global as any).navigator = {
      onLine: true,
      addEventListener: () => undefined,
      // removeEventListener not required for these tests
    } as any;
  });

  it('successful login sets guest in context and returns success', async () => {
    // Mock language hook
    await vi.doMock('../src/context/LanguageContext', () => ({
      useLanguage: () => ({ language: 'en' }),
    }));

    // Mock JWT parsing
    await vi.doMock('../src/utils/utils', () => ({
      parseJwt: (token: string) => ({ guest_id: 1, booking_id: 'b1' }),
    }));

    // Mock api service functions used by GuestContext
    const createData = vi.fn().mockResolvedValue({ success: true, accessToken: 'token' });
    const getData = vi.fn((path: string) => {
      if (path.startsWith('guest/')) return Promise.resolve({ id: 1, email: 'a@b.c' });
      if (path.startsWith('booking/')) return Promise.resolve({ id: 'b1', room_number: 101, room_type: 'standard', guest1_id: 1, beginning_of_stay: '2026-07-01', end_of_stay: '2026-07-05', checkin: null, checkout: null, catering_level: 'none' });
      if (path.startsWith('room/')) return Promise.resolve({ room_number: 101 });
      if (path.startsWith('service/all')) return Promise.resolve([]);
      if (path.startsWith('booking/services')) return Promise.resolve([]);
      return Promise.resolve(null);
    });
    const tryToRefreshToken = vi.fn().mockResolvedValue(null);
    const apiServiceConfig = { setLogoutCallback: vi.fn(), setTokenRefreshCallback: vi.fn(), setToken: vi.fn() };

    await vi.doMock('../src/services/apiService', () => ({ createData, getData, tryToRefreshToken, updateData: vi.fn(), apiServiceConfig }));

    const { GuestProvider, useGuest } = await import('../src/context/GuestContext');

    function TestComp() {
      const { login, guest } = useGuest();
      return (
        <div>
          <button onClick={async () => {
            const res = await login('a@b.c', '123');
            const el = document.getElementById('result');
            if (el) el.textContent = res.success ? 'OK' : 'NO';
          }}>do-login</button>
          <div data-testid="guest">{guest ? guest.email : 'no'}</div>
          <div id="result"></div>
        </div>
      );
    }

    render(
      // GuestProvider depends on LanguageContext which we mocked above
      <GuestProvider>
        <TestComp />
      </GuestProvider>
    );

    fireEvent.click(screen.getByText('do-login'));

    await waitFor(() => expect(screen.getByTestId('guest')).toHaveTextContent('a@b.c'));
    expect(screen.getByText('OK')).toBeInTheDocument();
  });

  it('network error during login returns network errorType', async () => {
    await vi.doMock('../src/context/LanguageContext', () => ({
      useLanguage: () => ({ language: 'en' }),
    }));

    const createData = vi.fn().mockRejectedValue(new Error('network')); // simulate network failure
    const tryToRefreshToken = vi.fn().mockResolvedValue(null);
    const apiServiceConfig = { setLogoutCallback: vi.fn(), setTokenRefreshCallback: vi.fn(), setToken: vi.fn() };

    await vi.doMock('../src/services/apiService', () => ({ createData, getData: vi.fn(), tryToRefreshToken, updateData: vi.fn(), apiServiceConfig }));

    // parseJwt won't be reached but provide a safe mock
    await vi.doMock('../src/utils/utils', () => ({ parseJwt: () => null }));

    const { GuestProvider, useGuest } = await import('../src/context/GuestContext');

    function TestComp() {
      const { login } = useGuest();
      return (
        <div>
          <button onClick={async () => {
            const res = await login('a@b.c', '123');
            const el = document.getElementById('result');
            if (el) el.textContent = res.success ? 'OK' : `ERR:${res.errorType}`;
          }}>do-login</button>
          <div id="result"></div>
        </div>
      );
    }

    render(
      <GuestProvider>
        <TestComp />
      </GuestProvider>
    );

    fireEvent.click(screen.getByText('do-login'));

    await waitFor(() => expect(screen.getByText(/ERR:/)).toBeInTheDocument());
    expect(screen.getByText(/ERR:network/)).toBeInTheDocument();
  });
});
