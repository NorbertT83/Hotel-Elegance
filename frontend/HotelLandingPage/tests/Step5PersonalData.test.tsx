import React from 'react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import { render, screen, fireEvent } from '@testing-library/react';

const mockNavigate = vi.fn();
const defaultLocationState = {
  arrivalDate: '2026-07-01',
  departureDate: '2026-07-05',
  freeRooms: [
    { room_number: 101, room_type: 'standard', has_balcony: 1, has_view: 'garden', extras: [] }
  ]
};

let currentLanguage: 'hu' | 'en' = 'en';

function setupMocks() {
  vi.doMock('react-router-dom', () => ({
    useLocation: () => ({ state: defaultLocationState }),
    useNavigate: () => mockNavigate,
  }));
  vi.doMock('../src/context/LanguageContext', () => ({
    useLanguage: () => ({ language: currentLanguage }),
  }));
  vi.doMock('../src/context/GuestContext', () => ({
    useGuest: () => ({ guest: null }),
  }));
}

describe('Step5PersonalData validation error tooltips', () => {
  beforeEach(() => {
    vi.resetModules();
    vi.restoreAllMocks();
    mockNavigate.mockClear();
    currentLanguage = 'en';
  });

  it('initially hides all error tooltips when fields are untouched', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    expect(screen.queryByRole('tooltip')).not.toBeInTheDocument();
  });

  it('shows email format error tooltip when invalid email is entered in English', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const input = document.querySelector('input[name="email"]') as HTMLInputElement;
    expect(input).toBeInTheDocument();

    fireEvent.change(input, { target: { value: 'not-an-email' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip).toBeInTheDocument();
    expect(tooltip).toHaveTextContent('Please enter a valid email address');
  });

  it('shows localized error tooltip in Hungarian when language is hu', async () => {
    currentLanguage = 'hu';
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const emailInput = document.querySelector('input[name="email"]') as HTMLInputElement;
    fireEvent.change(emailInput, { target: { value: 'rossz-email' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip).toBeInTheDocument();
    expect(tooltip).toHaveTextContent('Érvénytelen e-mail formátum');
  });

  it('shows required message when input is cleared after being touched', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const lnameInput = document.querySelector('input[name="lname"]') as HTMLInputElement;
    fireEvent.change(lnameInput, { target: { value: 'Smith' } });
    fireEvent.change(lnameInput, { target: { value: '' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip).toBeInTheDocument();
    expect(tooltip).toHaveTextContent('This field is required.');
  });

  it('shows letters-only error when name contains numbers', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const fnameInput = document.querySelector('input[name="fname"]') as HTMLInputElement;
    fireEvent.change(fnameInput, { target: { value: 'John123' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip).toBeInTheDocument();
    expect(tooltip).toHaveTextContent('Only letters, spaces, and hyphens are allowed.');
  });

  it('shows street number required error when street name has no digits', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const streetInput = document.querySelector('input[name="street"]') as HTMLInputElement;
    fireEvent.change(streetInput, { target: { value: 'Main Street' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip).toBeInTheDocument();
    expect(tooltip).toHaveTextContent('Please include the house/building number.');
  });

  it('hides error tooltip when field is corrected and valid', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const streetInput = document.querySelector('input[name="street"]') as HTMLInputElement;
    // Invalid
    fireEvent.change(streetInput, { target: { value: 'Main Street' } });
    expect(screen.getByRole('tooltip')).toBeInTheDocument();

    // Fix: add number
    fireEvent.change(streetInput, { target: { value: 'Main Street 42' } });
    expect(screen.queryByRole('tooltip')).not.toBeInTheDocument();
  });

  it('triggers tooltip visibility strictly on hovering the error symbol, not the input field', async () => {
    setupMocks();
    const { BookingProcessProvider } = await import('../src/context/BookingProcessContext');
    const { default: Step5PersonalData } = await import('../src/pages/booking/Step5PersonalData');

    render(
      <BookingProcessProvider>
        <Step5PersonalData />
      </BookingProcessProvider>
    );

    const emailInput = document.querySelector('input[name="email"]') as HTMLInputElement;
    fireEvent.change(emailInput, { target: { value: 'bad' } });

    const tooltip = screen.getByRole('tooltip');
    expect(tooltip.className).not.toMatch(/visible/);

    // Hovering the input field does NOT show the tooltip
    fireEvent.mouseEnter(emailInput);
    expect(tooltip.className).not.toMatch(/visible/);

    // Hovering the error material symbol triggers visibility
    const errorSymbol = screen.getByRole('alert');
    fireEvent.mouseEnter(errorSymbol);
    expect(tooltip.className).toMatch(/visible/);

    // Leaving the error symbol hides it
    fireEvent.mouseLeave(errorSymbol);
    expect(tooltip.className).not.toMatch(/visible/);
  });
});
