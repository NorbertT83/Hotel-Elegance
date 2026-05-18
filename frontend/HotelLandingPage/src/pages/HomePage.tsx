import Hero from '../components/Hero';
import Booking from '../components/Booking';
import Rooms from '../components/Rooms';
import Services from '../components/Services';
import Carousel from '../components/Carousel';
import ScrollBasedAnimation from '../components/ScrollBasedAnimation';

export default function HomePage() {
return <>
    <Hero />
    <Booking />
    <ScrollBasedAnimation>
        <Rooms />
    </ScrollBasedAnimation>
    <ScrollBasedAnimation>
        <Services />
    </ScrollBasedAnimation>
    <Carousel />
</>
}