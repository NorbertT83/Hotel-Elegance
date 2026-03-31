import { useState, useEffect, useRef } from 'react';

export default function CustomSelect({ options, label, onChange }) {
    const [isOpen, setIsOpen] = useState(false);
    const [selectedLabel, setSelectedLabel] = useState(label);
    const selectRef = useRef(null);

    const toggleSelect = (event) => {
        event.stopPropagation();
        setIsOpen(!isOpen);
    }

    const handleOptionClick = (option) => {
        setSelectedLabel(option.label);
        setIsOpen(false);
        onChange(option.value);
    };

    useEffect(() => {
        const handleClickOutside = (event) => {
        if (isOpen && selectRef.current && !selectRef.current.contains(event.target)) {
            setIsOpen(false);
        }
        };
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, [isOpen]);

    return (
        <div className={`custom-select ${isOpen ? 'open' : ''}`} ref={selectRef} tabIndex={0} >
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
    );
}