import { useEffect, useRef, useState } from "react";
import s from '../styles/ScrollBasedAnimation.module.css'

type Props = {
    children: React.ReactNode;
};

export default function ScrollBasedAnimation({ children }: Props) {
    const [ isVisible, setIsVisible ] = useState(false);

    const domRef =  useRef<HTMLDivElement>(null);

    useEffect(() => {
        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    setIsVisible(true);
                    if (currentElement) observer.unobserve(currentElement);
                }
            });
        }, {
            threshold: 0.2
        });


        const currentElement = domRef.current;

        if (currentElement) {
            observer.observe(currentElement);
        }

        return () => {
            if (currentElement) observer.unobserve(currentElement);
        }
    }, []);

    return <div ref={domRef} className={ `${s.slideInRight} ${isVisible ? s.visible : ''}` }>
        {children}
    </div>
}