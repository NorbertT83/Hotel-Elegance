import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay } from "swiper/modules";
import Hotel1 from '../assets/hero_photo.png';
import Hotel2 from '../assets/elite_room.png';
import Hotel3 from '../assets/suite_room.png';

import "swiper/css";
import s from '../styles/Carousel.module.css';

const images = [
    Hotel1,
    Hotel2,
    Hotel3,
    Hotel1,
    Hotel2,
    Hotel3
];

export default function Carousel() {
    return (
        <div className={s.sliderContainer} id="gallery">
            <Swiper
                modules={[Autoplay]}
                loop={true}
                freeMode={true}
                speed={5000}
                autoplay={{
                    delay: 0,
                    disableOnInteraction: false,
                }}
                slidesPerView={3}
                breakpoints={{
                    320: { slidesPerView: 1 },
                    768: { slidesPerView: 2 },
                    1200: { slidesPerView: 3 },
                }}
                className={s.hotelSwiper}
            >
                {images.map((img, index) => (
                    <SwiperSlide key={index}>
                        <div className={s.imageWrapper}>
                            <img
                                src={img}
                                alt={`Hotel ${index + 1}`}
                                className={s.sliderImage}
                            />
                        </div>
                    </SwiperSlide>
                ))}
            </Swiper>
        </div>
    );
}