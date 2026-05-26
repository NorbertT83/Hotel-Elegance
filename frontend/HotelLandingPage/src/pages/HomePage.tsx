import Hero from '../components/Hero';
import Booking from '../components/Booking';
import Rooms from '../components/Rooms';
import Services from '../components/Services';
import Carousel from '../components/Carousel';
import AboutUs from '../components/AboutUs';
import ScrollBasedAnimation from '../components/ScrollBasedAnimation';
import RoomModal from '../components/RoomModal';
import { useState } from 'react';
import { RoomType } from '../types/booking';

export default function HomePage() {
    const [selectedRoomType, setSelectedRoomType] = useState<RoomType | null>(null);

    function openRoomModal(roomType: RoomType) {
        setSelectedRoomType(roomType);
    }

    function closeRoomModal() {
        setSelectedRoomType(null);
    }

    return <>
        <Hero />
        <Booking />
        <ScrollBasedAnimation>
            <Rooms openRoomModal={openRoomModal} />
        </ScrollBasedAnimation>
        <ScrollBasedAnimation>
            <Services />
        </ScrollBasedAnimation>
        <Carousel />
        <AboutUs />
        {selectedRoomType && (
            <RoomModal 
                roomType={selectedRoomType} 
                isOpen={!!selectedRoomType} 
                onClose={closeRoomModal}
            />
        )}
    </>
}