import { useState } from 'react';
import { useBooking } from '../../context/BookingProcessContext';
import { useLanguage } from '../../context/LanguageContext';
import { bookingPageText } from '../../translations';
import countries from '../../utils/countries';
import s from '../../styles/BookingPage.module.css';


type ValidatedField = 'lname' | 'fname' | 'email' | 'zip' | 'city' | 'street';

const fallbackValidation = {
    required: 'A mező kitöltése kötelező.',
    nameMinLength: 'Legalább 2 karakter hosszú legyen.',
    nameMaxLength: 'Legfeljebb 30 karakter lehet.',
    lettersOnly: 'Csak betűket, szóközt vagy kötőjelet tartalmazhat.',
    emailInvalid: 'Érvénytelen e-mail formátum (pl. nev@pelda.hu).',
    zipMinLength: 'Legalább 4 karakterből kell állnia.',
    zipMaxLength: 'Legfeljebb 10 karakter lehet.',
    zipInvalid: 'Csak betűket, számokat vagy kötőjelet tartalmazhat.',
    streetMinLength: 'Legalább 5 karakter hosszú legyen.',
    streetNeedsNumber: 'Kérjük, adja meg a házszámot is.',
};

function getValidationError(
    field: ValidatedField,
    value: string,
    vText: typeof bookingPageText['hu']['step5']['validation'] = fallbackValidation
): string {
    const trimmed = value.trim();
    if (!trimmed) {
        return vText.required;
    }

    switch (field) {
        case 'lname':
        case 'fname':
            if (value.length < 2) return vText.nameMinLength;
            if (value.length >= 30) return vText.nameMaxLength;
            if (!/^[\p{L}\s-]+$/u.test(value)) return vText.lettersOnly;
            break;
        case 'email':
            if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) return vText.emailInvalid;
            break;
        case 'zip':
            if (value.length < 4) return vText.zipMinLength;
            if (value.length > 10) return vText.zipMaxLength;
            if (!/^[a-zA-Z0-9\s-]+$/.test(value)) return vText.zipInvalid;
            break;
        case 'city':
            if (value.length < 2) return vText.nameMinLength;
            if (!/^[\p{L}\s-]+$/u.test(value)) return vText.lettersOnly;
            break;
        case 'street':
            if (value.length <= 4) return vText.streetMinLength;
            if (!/\d/.test(value)) return vText.streetNeedsNumber;
            break;
    }

    return vText.required;
}

interface ErrorTooltipProps {
    field: ValidatedField;
    value: string;
    isTouched: boolean;
    isValid: boolean;
    vText: typeof bookingPageText['hu']['step5']['validation'];
}

function ErrorTooltip({ field, value, isTouched, isValid, vText }: ErrorTooltipProps) {
    const isHidden = !isTouched || isValid;
    const errorMsg = isHidden ? '' : getValidationError(field, value, vText);
    const [isHovered, setIsHovered] = useState(false);

    return (
        <div className={isHidden ? s.valid : s.errorContainer}>
            <span
                className={`${s.errorIcon} ${s.invalid} material-symbols-outlined`}
                tabIndex={isHidden ? -1 : 0}
                role={isHidden ? undefined : 'alert'}
                aria-label={isHidden ? undefined : errorMsg}
                onMouseEnter={() => setIsHovered(true)}
                onMouseLeave={() => setIsHovered(false)}
                onFocus={() => setIsHovered(true)}
                onBlur={() => setIsHovered(false)}
            >
                error
            </span>
            {!isHidden && (
                <div
                    className={`${s.tooltipBubble} ${isHovered ? s.visible : ''}`}
                    role="tooltip"
                >
                    <span className={`material-symbols-outlined ${s.tooltipIcon}`}>error</span>
                    <span className={s.tooltipText}>{errorMsg}</span>
                </div>
            )}
        </div>
    );
}

export default function Step5PersonalData() {
    const { language } = useLanguage();
    const { bookingState, handleInputChange, isFormValid, prevStep, finishBooking } = useBooking();
    const labels = bookingPageText[language].step5;
    const validationText = labels.validation || fallbackValidation;

    return (
        <div className={s.cardContainer}>
            <div className={s.card}>
                <h2>{labels.header}</h2>
                <h3>{labels.description}</h3>
                <div className={s.personalData}>
                    <div className={s.inputGroup}>
                        <span>{labels.lname}:</span>
                        <div className={s.colSpan2}>
                            <ErrorTooltip
                                field="lname"
                                value={bookingState.formData.lname.value}
                                isTouched={bookingState.formData.lname.isTouched}
                                isValid={isFormValid.lname}
                                vText={validationText}
                            />
                            <input
                                type="text"
                                name="lname"
                                maxLength={30}
                                value={bookingState.formData.lname.value}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span>{labels.fname}:</span>
                        <div className={s.colSpan2}>
                            <ErrorTooltip
                                field="fname"
                                value={bookingState.formData.fname.value}
                                isTouched={bookingState.formData.fname.isTouched}
                                isValid={isFormValid.fname}
                                vText={validationText}
                            />
                            <input
                                type="text"
                                name="fname"
                                value={bookingState.formData.fname.value}
                                maxLength={30}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span>{labels.email}:</span>
                        <div className={s.colSpan2}>
                            <ErrorTooltip
                                field="email"
                                value={bookingState.formData.email.value}
                                isTouched={bookingState.formData.email.isTouched}
                                isValid={isFormValid.email}
                                vText={validationText}
                            />
                            <input
                                type="email"
                                name="email"
                                value={bookingState.formData.email.value}
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>

                    <div className={s.addressGroup}>
                        <span>{labels.address}:</span>
                        <select name="country" id="countrySelect" value={bookingState.formData.country.value} onChange={handleInputChange}>
                            <option value="" disabled>{labels.countryPlaceholder}</option>
                            {countries.map(country => (
                                <option key={country.code} value={country.code}>{country.name}</option>
                            ))}
                        </select>
                        <div>
                            <ErrorTooltip
                                field="zip"
                                value={bookingState.formData.zip.value}
                                isTouched={bookingState.formData.zip.isTouched}
                                isValid={isFormValid.zip}
                                vText={validationText}
                            />
                            <input
                                type="text"
                                name="zip"
                                maxLength={10}
                                placeholder={labels.zipPlaceholder}
                                value={bookingState.formData.zip.value}
                                onChange={handleInputChange}
                            />
                        </div>

                        <span></span>
                        <div className={s.colSpan2}>
                            <ErrorTooltip
                                field="city"
                                value={bookingState.formData.city.value}
                                isTouched={bookingState.formData.city.isTouched}
                                isValid={isFormValid.city}
                                vText={validationText}
                            />
                            <input
                                type="text"
                                name="city"
                                placeholder={labels.cityPlaceholder}
                                value={bookingState.formData.city.value}
                                onChange={handleInputChange}
                            />
                        </div>
                        
                        <span></span>
                        <div className={s.colSpan2}>
                            <ErrorTooltip
                                field="street"
                                value={bookingState.formData.street.value}
                                isTouched={bookingState.formData.street.isTouched}
                                isValid={isFormValid.street}
                                vText={validationText}
                            />
                            <input
                                type="text"
                                name="street"
                                value={bookingState.formData.street.value}
                                placeholder={labels.streetPlaceholder}
                                onChange={handleInputChange}
                            />
                        </div>

                    </div>
                </div>
                <div className={s.buttonContainer}>
                    <button className="btn btn-secondary" onClick={prevStep}>
                        {labels.prevButton}
                    </button>
                    <button className={`btn btn-primary ${Object.values(isFormValid).every(v => v) ? "" : "btn-inactive"}`} onClick={finishBooking}>
                        <span>{labels.finishButton}</span><span className="material-symbols-outlined">arrow_forward</span>
                    </button>
                </div>
            </div>
        </div>
    );
}
