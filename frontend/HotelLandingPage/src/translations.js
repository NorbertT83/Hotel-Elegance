import StandardRoomImage from './assets/standard_room.png';
import EliteRoomImage from './assets/elite_room.png';
import SuiteRoomImage from './assets/suite_room.png';

export const landingPageText = {
    hu: {
        header: {
            navLinks: ['Szobák', 'Szolgáltatások', 'Galéria', 'Rólunk'],
            bookNow: 'Foglalás most',
        },
        hero: {
            title: 'Elegancia minden részletben',
            subtitle:
                'Tapasztalja meg a nyugalom és a visszafogott luxus szentélyét, ahol a kifogástalan kiszolgálás időtlen dizájnnal párosul.',
            imageAlt: 'Luxus hotel szoba belső tere',
        },
        booking: {
            arrival: 'Érkezés',
            departure: 'Távozás',
            guests: 'Vendégek',
            guestOptions: ['2 felnőtt, 0 gyermek', '1 felnőtt, 0 gyermek', '2 felnőtt, 1 gyermek'],
            submit: 'Szobafoglalás',
        },
        rooms: {
            sectionTitle: 'Lakosztályaink',
            sectionDescription:
                'Gondosan kialakított terek a tökéletes kikapcsolódásért és a kifinomult kényelemért.',
            cards: [
                {
                    title: 'The Standard Elegance',
                    price: '$440',
                    priceSuffix: '/éjszaka',
                    description:
                    'Letisztult, harmonikus szoba elegáns részletekkel, kényelmes enteriőrrel és meleg, nyugodt atmoszférával a pihentető kikapcsolódásért.',
                    linkText: 'Szoba megtekintése',
                    imageURL: StandardRoomImage,
                    imageAlt: 'A Standard Elegance szoba',
                },
                {
                    title: 'The Grand Ivory',
                    price: '$510',
                    priceSuffix: '/éjszaka',
                    description:
                    'Tágas saroklakosztály panorámás kilátással, privát terasszal és egyedi készítésű bútorokkal, lágy pezsgő színekben.',
                    linkText: 'Lakosztály megtekintése',
                    imageURL: EliteRoomImage,
                    imageAlt: 'A Grand Ivory lakosztály',
                },
                {
                    title: 'The Terrace Penthouse',
                    price: '$720',
                    priceSuffix: '/éjszaka',
                    description:
                    'Magas szintű kényelem körbefutó erkéllyel, külön étkezővel és a visszafogott luxus iránti kivételes figyelemmel.',
                    linkText: 'Lakosztály megtekintése',
                    imageURL: SuiteRoomImage,
                    imageAlt: 'A Teraszos Penthouse',
                },
            ],
        },
        footer: {
            brandDescription:
                'A csendes luxus menedéke, amely kifogástalan kiszolgálást és időtlen élményeket nyújt az igényes utazók számára.',
            legalTitle: 'Jogi tudnivalók',
            privacyPolicy: 'Adatvédelmi irányelvek',
            terms: 'Felhasználási feltételek',
            contactTitle: 'Kapcsolat',
            contact: 'Kapcsolatfelvétel',
            press: 'Sajtóanyagok',
            locationTitle: 'Helyszín',
            addressLine1: '123 Serenity Lane',
            addressLine2: 'Metropolis, NY 10001',
            email: 'info@hotelelegance.hu',
            copyright: '© 2026 Hotel Elegance. Minden jog fenntartva.',
        },
    },


    en: {
        header: {
            navLinks: ['Rooms', 'Services', 'Gallery', 'About'],
            bookNow: 'Book Now',
        },
        hero: {
            title: 'Elegance in every detail',
            subtitle:
                'Discover a sanctuary of calm and understated luxury, where impeccable service meets timeless design.',
            imageAlt: 'Luxury hotel room interior',
        },
        booking: {
            arrival: 'Arrival',
            departure: 'Departure',
            guests: 'Guests',
            guestOptions: ['2 adults, 0 children', '1 adult, 0 children', '2 adults, 1 child'],
            submit: 'Reserve Room',
        },
        rooms: {
            sectionTitle: 'Our Suites',
            sectionDescription:
                'Thoughtfully designed spaces for perfect relaxation and refined comfort.',
            cards: [
                    {
                        title: 'The Standard Elegance',
                        price: '$440',
                        priceSuffix: '/night',
                        description:
                            'Sleek, harmonious design with elegant touches and cozy interiors, offering a warm and peaceful ambiance for ultimate relaxation.',
                        linkText: 'View room',
                        imageURL: StandardRoomImage,
                        imageAlt: 'The Standard Elegance room',
                    },
                    {
                        title: 'The Grand Ivory',
                        image: '../assets/',
                        price: '$850',
                        priceSuffix: '/night',
                        description:
                            'Spacious corner suite with panoramic views, private terrace, and bespoke furnishings in soft champagne tones.',
                        linkText: 'View suite',
                        imageURL: EliteRoomImage,
                        imageAlt: 'The Grand Ivory suite',
                    },
                    {
                        title: 'The Terrace Penthouse',
                        price: '$1,200',
                        priceSuffix: '/night',
                        description:
                            'High-level comfort with wrap-around balcony, separate dining area, and exceptional attention to understated luxury.',
                        linkText: 'View suite',
                        imageURL: SuiteRoomImage,
                        imageAlt: 'The Terrace Penthouse',
                    },
            ],
        },
        footer: {
            brandDescription:
                'A peaceful luxury retreat delivering flawless service and timeless experiences for discerning travelers.',
            legalTitle: 'Legal',
            privacyPolicy: 'Privacy Policy',
            terms: 'Terms of Use',
            contactTitle: 'Contact',
            contact: 'Contact Us',
            press: 'Press',
            locationTitle: 'Location',
            addressLine1: '123 Serenity Lane',
            addressLine2: 'Metropolis, NY 10001',
            email: 'info@hotelelegance.hu',
            copyright: '© 2026 Hotel Elegance. All rights reserved.',
        },
    },
};