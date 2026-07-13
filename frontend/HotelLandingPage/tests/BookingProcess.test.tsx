import { describe, it, expect, vi, beforeEach } from 'vitest';
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';

const mockNavigate = vi.fn();
const defaultLocationState = {
  arrivalDate: '2026-07-01',
  departureDate: '2026-07-05',
  freeRooms: [
    { room_number: 101, room_type: 'standard', has_balcony: 1, has_view: 'garden', extras: ['jacuzzi'] },
    { room_number: 102, room_type: 'deluxe', has_balcony: 0, has_view: 'panorama', extras: [] }
  ]
};

function buildProviderTestModule() {
  vi.doMock('react-router-dom', () => ({
    useLocation: () => ({ state: defaultLocationState }),
    useNavigate: () => mockNavigate,
  }));
  vi.doMock('../src/context/GuestContext', () => ({
    useGuest: () => ({ guest: null }),
  }));
  return import('../src/context/BookingProcessContext');
}

describe('BookingProcess', () => {
  beforeEach(() => {
    vi.resetModules();
    vi.restoreAllMocks();
    mockNavigate.mockClear();
  });

  it('roomSupportsExtra returns true for supported and false for unsupported extras', async () => {
    const { roomSupportsExtra } = await buildProviderTestModule();
    const room = { room_number: 100, room_type: 'standard', has_balcony: 1, has_view: 'garden', extras: ['jacuzzi', 'kitchen'] };

    expect(roomSupportsExtra(room as any, 'balcony')).toBe(true);
    expect(roomSupportsExtra(room as any, 'garden')).toBe(true);
    expect(roomSupportsExtra(room as any, 'panorama')).toBe(false);
    expect(roomSupportsExtra(room as any, 'jacuzzi')).toBe(true);
    expect(roomSupportsExtra(room as any, 'kitchen')).toBe(true);
    expect(roomSupportsExtra(room as any, 'latecheckout')).toBe(true);
    expect(roomSupportsExtra(room as any, 'transfer')).toBe(true);
    expect(roomSupportsExtra(room as any, 'champagne')).toBe(true);
  });

  it('nextStep and prevStep update the current step', async () => {
    const { BookingProcessProvider, useBooking } = await buildProviderTestModule();

    function TestConsumer() {
      const { step, nextStep, prevStep } = useBooking();
      return (
        <div>
          <span data-testid="step">{step}</span>
          <button onClick={nextStep}>next</button>
          <button onClick={prevStep}>prev</button>
        </div>
      );
    }

    render(
      <BookingProcessProvider>
        <TestConsumer />
      </BookingProcessProvider>
    );

    expect(screen.getByTestId('step').textContent).toBe('1');
    fireEvent.click(screen.getByText('next'));
    expect(screen.getByTestId('step').textContent).toBe('2');
    fireEvent.click(screen.getByText('prev'));
    expect(screen.getByTestId('step').textContent).toBe('1');
  });

  it('handleCheckboxChange toggles extrasChosen', async () => {
    const { BookingProcessProvider, useBooking } = await buildProviderTestModule();

    function TestConsumer() {
      const { bookingState, handleCheckboxChange } = useBooking();
      return (
        <div>
          <span data-testid="extras">{bookingState.extrasChosen.join(',')}</span>
          <button onClick={() => handleCheckboxChange({ target: { id: 'latecheckout' } } as any)}>toggle</button>
        </div>
      );
    }

    render(
      <BookingProcessProvider>
        <TestConsumer />
      </BookingProcessProvider>
    );

    expect(screen.getByTestId('extras').textContent).toBe('');
    fireEvent.click(screen.getByText('toggle'));
    expect(screen.getByTestId('extras').textContent).toBe('latecheckout');
    fireEvent.click(screen.getByText('toggle'));
    expect(screen.getByTestId('extras').textContent).toBe('');
  });

  it('handleInputChange updates form data and sets touched state', async () => {
    const { BookingProcessProvider, useBooking } = await buildProviderTestModule();

    function TestConsumer() {
      const { bookingState, handleInputChange, isFormValid } = useBooking();
      return (
        <div>
          <span data-testid="lname">{bookingState.formData.lname.value}</span>
          <span data-testid="touched">{String(bookingState.formData.lname.isTouched)}</span>
          <span data-testid="valid">{String(isFormValid.lname)}</span>
          <button onClick={() => handleInputChange({ target: { name: 'lname', value: 'Jane' } } as any)}>set-name</button>
        </div>
      );
    }

    render(
      <BookingProcessProvider>
        <TestConsumer />
      </BookingProcessProvider>
    );

    expect(screen.getByTestId('lname').textContent).toBe('');
    expect(screen.getByTestId('touched').textContent).toBe('false');
    expect(screen.getByTestId('valid').textContent).toBe('false');

    fireEvent.click(screen.getByText('set-name'));

    expect(screen.getByTestId('lname').textContent).toBe('Jane');
    expect(screen.getByTestId('touched').textContent).toBe('true');
    expect(screen.getByTestId('valid').textContent).toBe('true');
  });

  it('finishBooking sends payload and advances to step 6 on success', async () => {
    const createData = vi.fn().mockResolvedValue({ success: true });

    await vi.doMock('react-router-dom', () => ({
      useLocation: () => ({ state: defaultLocationState }),
      useNavigate: () => mockNavigate,
    }));
    await vi.doMock('../src/context/GuestContext', () => ({
      useGuest: () => ({ guest: null }),
    }));
    await vi.doMock('../src/services/apiService', () => ({ createData }));
    const { BookingProcessProvider, useBooking } = await import('../src/context/BookingProcessContext');

    function TestConsumer() {
      const { bookingState, finishBooking, step } = useBooking();
      return (
        <div>
          <span data-testid="step">{step}</span>
          <span data-testid="bookingId">{bookingState.bookingId}</span>
          <button onClick={finishBooking}>finish</button>
        </div>
      );
    }

    render(
      <BookingProcessProvider>
        <TestConsumer />
      </BookingProcessProvider>
    );

    fireEvent.click(screen.getByText('finish'));
    await waitFor(() => expect(screen.getByTestId('step').textContent).toBe('6'));
    expect(screen.getByTestId('bookingId').textContent).toContain('HE-2026-');
    expect(createData).toHaveBeenCalled();
  });
});
