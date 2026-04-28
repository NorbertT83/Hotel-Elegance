import { useState, useRef } from 'react';

export default function CustomSelect({ options, label, onChange }) {
    const [isOpen, setIsOpen] = useState(false);
    const [selectedLabel, setSelectedLabel] = useState(label);
    const selectRef = useRef(null);

    const toggleSelect = (event) => {
        event.preventDefault();
        // event.stopPropagation();
        setIsOpen(!isOpen);
    }

    const handleOptionClick = (option) => {
        setSelectedLabel(option.label);
        setIsOpen(false);
        onChange(option.value);
    };

    const handleBlur = (e) => {
        if (!e.currentTarget.contains(e.relatedTarget)) {
            setIsOpen(false);
        }
    };

    return (<>
        <div className={`custom-select ${isOpen ? 'open' : ''}`} ref={selectRef} tabIndex={0} onBlur={handleBlur}>
            <div className="select-trigger" onClick={toggleSelect}>
                <i className="fa-solid fa-sort-amount-down"></i>
                <span>{selectedLabel}</span>
                <i className={`fa-solid fa-chevron-${isOpen ? 'up' : 'down'}`}></i>
            </div>

            {isOpen && (
                <div className="custom-options">
                {options.map((option) => (
                    <div 
                    key={option.value} 
                    className="custom-option"
                    onClick={() => handleOptionClick(option)}
                    >
                    {option.label}
                    </div>
                ))}
                </div>
            )}
        </div>
        <div className='separator'></div>
        </>
    );
}