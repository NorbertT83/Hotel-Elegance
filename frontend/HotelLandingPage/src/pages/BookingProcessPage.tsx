import { BookingProcessProvider, useBooking } from "../context/BookingProcessContext";
import Step1BookingDetails from "./booking/Step1BookingDetails";
import Step2RoomSelection from "./booking/Step2RoomSelection";
import Step3ExtraOptions from "./booking/Step3ExtraOptions";
import Step4PersonalData from "./booking/Step4PersonalData";
import Step5SuccessCard from "./booking/Step5SuccessCard";
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
    const progressStepStyle = { width: `calc(${(step - 1) * 25}% + 2px)` };

    return (
        <section className={s.bookingSection}>
            <div className={s.progressBar}>
                <div className={s.progressStep} style={progressStepStyle}></div>
            </div>
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