import React from 'react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import { render, screen, fireEvent } from '@testing-library/react';

vi.mock('react-router-hash-link', () => ({
  HashLink: ({ children, to }: any) => <a href={to}>{children}</a>,
}));

vi.mock('../src/pages/booking/Step3ExtraOptions', () => ({ default: () => <div>Step3</div> }));
vi.mock('../src/pages/booking/Step4Summary', () => ({ default: () => <div>Step4</div> }));
vi.mock('../src/pages/booking/Step5PersonalData', () => ({ default: () => <div>Step5</div> }));
vi.mock('../src/pages/booking/Step6SuccessCard', () => ({ default: () => <div>Step6</div> }));

const mockNavigate = vi.fn();
const defaultLocationState = {
  arrivalDate: '2026-07-01',
  departureDate: '2026-07-05',
  freeRooms: [
    { room_number: 101, room_type: 'standard', has_balcony: 1, has_view: 'garden', extras: ['jacuzzi'] },
    { room_number: 102, room_type: 'deluxe', has_balcony: 0, has_view: 'panorama', extras: [] }
  ]
};

function setupMocks() {
  vi.doMock('react-router-dom', () => ({
    useLocation: () => ({ state: defaultLocationState }),
    useNavigate: () => mockNavigate,
  }));
  vi.doMock('../src/context/LanguageContext', () => ({
    useLanguage: () => ({ language: 'en' }),
  }));
  vi.doMock('../src/context/GuestContext', () => ({
    useGuest: () => ({ guest: null }),
  }));
}

describe('BookingProcessPage UI', () => {
  beforeEach(() => {
    vi.resetModules();
    mockNavigate.mockClear();
  });

  it('renders step 1 and navigates to step 2 when Next is clicked', async () => {
    setupMocks();
    const { default: BookingProcessPage } = await import('../src/pages/BookingProcessPage');

    render(<BookingProcessPage />);

    expect(screen.getByText('Booking details')).toBeInTheDocument();
    expect(screen.getByText('Modify')).toBeInTheDocument();

    const [firstNext] = screen.getAllByRole('button', { name: /next/i });
    fireEvent.click(firstNext);

    expect(await screen.findByText('Select suite')).toBeInTheDocument();
    expect(screen.getByText('Standard Elegance')).toBeInTheDocument();
    expect(screen.getByText('Grand Ivory')).toBeInTheDocument();
  });

  it('allows navigation back to step 1 from step 2', async () => {
    setupMocks();
    const { default: BookingProcessPage } = await import('../src/pages/BookingProcessPage');

    render(<BookingProcessPage />);
    const [firstNext] = screen.getAllByRole('button', { name: /next/i });
    fireEvent.click(firstNext);

    expect(await screen.findByText('Select suite')).toBeInTheDocument();
    fireEvent.click(screen.getByText('Back'));
    expect(await screen.findByText('Booking details')).toBeInTheDocument();
  });

  it('renders all available room types in step 2', async () => {
    setupMocks();
    const { default: BookingProcessPage } = await import('../src/pages/BookingProcessPage');

    render(<BookingProcessPage />);
    const [firstNext] = screen.getAllByText('Next');
    fireEvent.click(firstNext);

    expect(await screen.findByText('Standard Elegance')).toBeInTheDocument();
    expect(screen.getByText('Grand Ivory')).toBeInTheDocument();
  });
});
