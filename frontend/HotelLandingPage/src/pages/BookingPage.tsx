import { useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from 'react';
import { useLanguage } from '../context/LanguageContext';
import s from '../styles/BookingPage.module.css';
import countries from "../utils/countries";
import { BookingState, RoomType, CateringType, FormData, ExtraOption } from '../types/booking';

import Step1BookingDetails from "../components/booking/Step1BookingDetails";
import Step2RoomSelection from "../components/booking/Step2RoomSelection";
import Step3ExtraOptions from "../components/booking/Step3ExtraOptions";
import Step4PersonalData from "../components/booking/Step4PersonalData";
import Step5SuccessCard from "../components/booking/Step5SuccessCard";

const EXTRA_OPTIONS: ExtraOption[] = [
    { id: "view", label: "Udvarra néző szoba" },
    { id: "jacuzzi", label: "Jacuzzi a teraszon" },
    { id: "champagne", label: "Pezsgő bekészítés" },
    { id: "latecheckout", label: "Késői kijelentkezés" },
    { id: "transfer", label: "Reptéri transzfer" },
];

const CATERING_OPTIONS = [
    { id: "breakfast", label: "Reggeli", info: "(Az ár tartalmazza)" },
    { id: "halfboard", label: "Félpanzió", info: "(+10% felár)" },
    { id: "fullboard", label: "Teljes ellátás", info: "(+20% felár)" },
];

const validate = {
    name: (val: string) => val.length > 2 && val.length <= 30 && /^[\p{L}\s-]+$/u.test(val),
    email: (val: string) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(val),
    zip: (val: string) => /^[a-zA-Z0-9\s-]{4,10}$/.test(val),
    city: (val: string) => val.length > 1 && /^[\p{L}\s-]+$/u.test(val),
    street: (val: string) => val.length > 4 && /^(?=.*\d).+$/.test(val)
};

export default function BookingPage() {
    const { language } = useLanguage();
    const location = useLocation();
    const navigate = useNavigate();
    
    const [step, setStep] = useState(1);
    const [isFormValid, setIsFormValid] = useState(false);
    const [roomType, setRoomType] = useState<RoomType>("standard"); // <--- ÚJ szoba state!
    const [catering, setCatering] = useState<CateringType>("breakfast");
    const [extras, setExtras] = useState<Record<string, boolean>>({});
    const [formData, setFormData] = useState<FormData>({
        lname: "", fname: "", email: "", country: "HU", zip: "", city: "", street: ""
    });

    useEffect(() => {
        if (!location.state) navigate("/");
    }, [location, navigate]);

    useEffect(() => {
        const { lname, fname, email, zip, city, street } = formData;
        const isValid = validate.name(lname) && validate.name(fname) && validate.email(email) && validate.zip(zip) && validate.city(city) && validate.street(street);
        setIsFormValid(isValid);
    }, [formData]);

    if (!location.state) return null;
    const { guests, arrivalDate, departureDate } = location.state as BookingState;
    const sliderStyle = { transform: `translateX(-${(step - 1) * 100}%)` };

    // Handler függvények
    const handleCheckboxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, checked } = e.target;
        setExtras(prev => ({ ...prev, [id]: checked }));
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    const handleBookingFinish = () => {
        // Itt fogod majd meghívni a korábban megírt `createData` API-t!
        console.log("Foglalás elküldése:", { formData, roomType, catering, extras, guests, arrivalDate, departureDate });
        setStep(5); // Pl. egy sikeres visszaigazoló kártyára lépés
    };

    return (
        <section className={s.bookingSection}>
            <div className={s.slider} style={sliderStyle}>
                
                <Step1BookingDetails 
                    arrivalDate={arrivalDate} departureDate={departureDate} language={language} guests={guests} 
                    onNext={() => setStep(2)} 
                />

                <Step2RoomSelection 
                    roomType={roomType} setRoomType={setRoomType} 
                    onBack={() => setStep(1)} onNext={() => setStep(3)} 
                />

                <Step3ExtraOptions 
                    catering={catering} setCatering={setCatering} extras={extras} handleCheckboxChange={handleCheckboxChange} 
                    cateringOptions={CATERING_OPTIONS} extraOptions={EXTRA_OPTIONS} 
                    onBack={() => setStep(2)} onNext={() => setStep(4)} 
                />

                <Step4PersonalData 
                    formData={formData} isFormValid={isFormValid} countries={countries} handleInputChange={handleInputChange} 
                    onBack={() => setStep(3)} onFinish={handleBookingFinish} 
                />

                <Step5SuccessCard email={formData.email} />

            </div>
        </section>
    );
}