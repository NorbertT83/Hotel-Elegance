import { describe, it, expect, vi, beforeEach } from 'vitest';
import React from 'react';
import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';

// Mock router modules so tests don't need real react-router packages
vi.mock('react-router-dom', () => ({
  MemoryRouter: ({ children }: { children: React.ReactNode }) => <div>{children}</div>,
  useNavigate: () => vi.fn(),
  useLocation: () => ({ pathname: '/' }),
}));

vi.mock('react-router-hash-link', () => ({
  HashLink: ({ children, to, className }: any) => <a href={to} className={className}>{children}</a>,
}));

// Mock static asset import used by Header
vi.mock('../src/assets/HE-logo.png', () => ({ default: 'logo.png' }));

describe('Header component', () => {
  beforeEach(() => {
    // reset modules so we can re-mock hooks per test if needed
    vi.resetModules();
  });

  it('renders navigation links and Book Now when not logged in', async () => {
    // mock language and guest hooks
    vi.mock('../src/context/LanguageContext', () => ({
      useLanguage: () => ({ language: 'en' }),
    }));

    vi.mock('../src/context/GuestContext', () => ({
      useGuest: () => ({ guest: null, logout: vi.fn() }),
    }));

    const { default: Header } = await import('../src/components/Header');

    render(
      <MemoryRouter>
        <Header />
      </MemoryRouter>
    );

    expect(screen.getByText('Hotel Elegance')).toBeInTheDocument();
    expect(screen.getByText('Rooms')).toBeInTheDocument();
    expect(screen.getByText('Book Now')).toBeInTheDocument();
  });

  it('shows logout controls when a guest is present', async () => {
    vi.mock('../src/context/LanguageContext', () => ({
      useLanguage: () => ({ language: 'en' }),
    }));

    const logoutMock = vi.fn();
    await vi.doMock('../src/context/GuestContext', () => ({
      useGuest: () => ({ guest: { id: 1, email: 'a@b.c' }, logout: logoutMock }),
    }));

    const { default: Header } = await import('../src/components/Header');

    render(
      <MemoryRouter>
        <Header />
      </MemoryRouter>
    );

    // when logged in the Book Now button should not be visible
    expect(screen.queryByText('Book Now')).not.toBeInTheDocument();
  });
});
