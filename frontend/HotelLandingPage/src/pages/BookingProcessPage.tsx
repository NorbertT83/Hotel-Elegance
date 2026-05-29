import { BookingProcessProvider, useBooking } from "../context/BookingProcessContext";
import Step1BookingDetails from "../components/booking/Step1BookingDetails";
import Step2RoomSelection from "../components/booking/Step2RoomSelection";
import Step3ExtraOptions from "../components/booking/Step3ExtraOptions";
import Step4PersonalData from "../components/booking/Step4PersonalData";
import Step5SuccessCard from "../components/booking/Step5SuccessCard";
import s from '../styles/BookingPage.module.css';

export default function BookingProcessPage() {
    return (
        <BookingProcessProvider>
            <BookingSlider />
        </BookingProcessProvider>
    );
}

function BookingSlider() {
    const { step } = useBooking();
    const sliderStyle = { transform: `translateX(-${(step - 1) * 100}%)` };

    return (
        <section className={s.bookingSection}>
            <div className={s.slider} style={sliderStyle}>
                <Step1BookingDetails />
                <Step2RoomSelection />
                <Step3ExtraOptions />
                <Step4PersonalData />
                <Step5SuccessCard />
            </div>
        </section>
    );
}