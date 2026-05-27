import StandardRoomImage from '../assets/standard_room.png';
import EliteRoomImage from '../assets/elite_room.png';
import SuiteRoomImage from '../assets/suite_room.png';

export const landingPageText = {
    hu: {
        header: {
            navLinks: ['Szobák', 'Szolgáltatások', 'Galéria', 'Rólunk'],
            bookNow: 'Foglalás',
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
            types: {
                standard: {
                    roomType: 'standard',
                    title: 'Standard Elegance',
                    price: '$440',
                    priceSuffix: '/éjszaka',
                    description:
                    'Letisztult, harmonikus szoba elegáns részletekkel, kényelmes enteriőrrel és meleg, nyugodt atmoszférával a pihentető kikapcsolódásért.',
                    linkText: 'Szoba megtekintése',
                    imageURL: StandardRoomImage,
                    imageAlt: 'A Standard Elegance szoba',
                    features: [
                        'Mini bár',
                        'Kávé- és teafőző',
                        'Szobaszéf',
                        'Nagy sebességű Wi-Fi',
                        'Luxus piperecikkek',
                        '24 órás szobaszerviz',
                    ],
                },
                deluxe: {
                    roomType: 'deluxe',
                    title: 'Grand Ivory',
                    price: '$510',
                    priceSuffix: '/éjszaka',
                    description:
                    'Tágas saroklakosztály panorámás kilátással, privát terasszal és egyedi készítésű bútorokkal, lágy pezsgő színekben.',
                    linkText: 'Lakosztály megtekintése',
                    imageURL: EliteRoomImage,
                    imageAlt: 'A Grand Ivory lakosztály',
                    features: [
                        'Privát terasz',
                        'Egyedi készítésű bútorok',
                        'Lágy pezsgő színek',
                    ],
                },
                suite: {
                    roomType: 'suite',
                    title: 'Panorama Penthouse',
                    price: '$720',
                    priceSuffix: '/éjszaka',
                    description:
                    'Magas szintű kényelem körbefutó erkéllyel, külön étkezővel és a visszafogott luxus iránti kivételes figyelemmel.',
                    linkText: 'Lakosztály megtekintése',
                    imageURL: SuiteRoomImage,
                    imageAlt: 'A Teraszos Penthouse lakosztály',
                    features: [
                        'Körbefutó erkély',
                        'Egyedi készítésű bútorok',
                        'Külön étkező',
                        'Luxus iránti kivételes figyelem',
                    ],
                },
            },
        },
        services: {
            sectionTitle: 'Szolgáltatásaink',
            sectionDescription:
                'Fedezze fel a gondtalanság új dimenzióját, ahol minden szolgáltatásunk az Ön kényelmét és testi-lelki felfrissülését szolgálja.',
        },
        aboutus: {
            title: 'Rólunk',
            description1: 'A Hotel Elegance megalkotásakor egyetlen cél vezérelt minket: létrehozni egy olyan teret, ahol az időtlen stílus találkozik a kompromisszumok nélküli kényelemmel. Nálunk a luxus nem a hivalkodásban rejlik, hanem a finom részletekben: a tökéletesen sima lepedőben, a gondosan összeállított menüben és a személyzet észrevétlen, mégis mindig jelenlévő gondoskodásában. Lépj be a rohanó hétköznapokból egy olyan világba, ahol a pihenés valóban művészet.',
            description2: 'A Hotel Elegance az a hely, ahol a stílus és a kényelem találkozik. Nem hiszünk a felesleges bonyodalmakban, csak a hibátlan vendéglátásban. Akár pihenni, akár dolgozni érkezel, nálunk megtalálod a tökéletes egyensúlyt. Tapasztald meg az eleganciát, amit neked teremtettünk!'
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
            addressLine1: 'Üteg u. 123.',
            addressLine2: 'Budapest, HU 1135',
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
            types: {
                    standard: {
                        title: 'Standard Elegance',
                        price: '$440',
                        priceSuffix: '/night',
                        description:
                            'Sleek, harmonious design with elegant touches and cozy interiors, offering a warm and peaceful ambiance for ultimate relaxation.',
                        linkText: 'View room',
                        imageURL: StandardRoomImage,
                        imageAlt: 'The Standard Elegance room',
                        features: [
                            'Mini bar',
                            'Coffee and tea maker',
                            'In-room safe',
                            'High-speed Wi-Fi',
                            'Luxury toiletries',
                            '24-hour room service',
                        ],
                    },
                    deluxe: {
                        title: 'Grand Ivory',
                        image: '../assets/',
                        price: '$850',
                        priceSuffix: '/night',
                        description:
                            'Spacious corner suite with panoramic views, private terrace, and bespoke furnishings in soft champagne tones.',
                        linkText: 'View suite',
                        imageURL: EliteRoomImage,
                        imageAlt: 'The Grand Ivory suite',
                        features: [
                            'Private terrace',
                            'Bespoke furnishings',
                            'Soft champagne tones',
                        ],
                    },
                    suite: {
                        title: 'Panorama Penthouse',
                        price: '$1,200',
                        priceSuffix: '/night',
                        description:
                            'High-level comfort with wrap-around balcony, separate dining area, and exceptional attention to understated luxury.',
                        linkText: 'View suite',
                        imageURL: SuiteRoomImage,
                        imageAlt: 'The Terrace Penthouse suite',
                        features: [
                            'Wrap-around balcony',
                            'Bespoke furnishings',
                            'Separate dining area',
                            'Exceptional attention to understated luxury',
                        ],
                    },
                },
        },
        services: {
            sectionTitle: 'Our services',
            sectionDescription:
                'Discover a new dimension of serenity, where every service is dedicated to your comfort and the complete renewal of your body and soul.',
        },
        aboutus: {
            title: 'About us',
            description1: 'When creating Hotel Elegance, we were guided by a single goal: to create a space where timeless style meets uncompromising comfort. For us, luxury isn\'t about showing off; it\'s found in the fine details: the perfectly crisp linens, the carefully curated menu, and the unobtrusive yet ever-present care of our staff. Step out of the everyday rush and into a world where relaxation is truly an art form.',
            description2: 'Hotel Elegance is where style meets comfort. We don\'t believe in unnecessary complications, only in flawless hospitality. Whether you\'re arriving to relax or to work, you\'ll find the perfect balance here. Experience the elegance we\'ve created for you.'
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
            addressLine1: '123 Üteg str.',
            addressLine2: 'Budapest, HU 1135',
            email: 'info@hotelelegance.hu',
            copyright: '© 2026 Hotel Elegance. All rights reserved.',
        },
    },
};

export const bookingPageText = {
    hu:{
        step1: {
            header: 'Foglalási adatok',
            description: 'Az Ön által eddig rögzített adatok',
            arrival: 'Érkezés',
            departure: 'Távozás',
            adults: 'Felnőttek',
            children: 'Gyerekek',
            person: 'fő',
            modifyButton: 'Módosít',
            nextButton: 'Tovább',
        },
        step2: {
            header: 'Lakosztály kiválasztása',
            description: 'Válassza ki az Önnek megfelelő lakosztályunk egyikét',
            prevButton: 'Vissza',
            nextButton: 'Tovább',
        },
        step3: {
            header: 'Extra igények',
            description: 'Válasszon igényei szerint extra szolgáltatásainkból',
            extraInfo: 'Teljeskörű szolgáltatásainkból a nálunk tartózkodása alatt igényei szerint választhat majd.',
            catering: 'Étkezés',
            breakfast: 'Reggeli',
            breakfastNote: '(Az ár tartalmazza)',
            halfboard: 'Félpanzió',
            halfboardNote: '(+10% felár)',
            fullboard: 'Teljes ellátás',
            fullboardNote: '(+20% felár)',
            extras: 'Egyebek',
            balcony: 'Erkélyes szoba',
            garden: 'Udvarra néző szoba',
            panorama: 'Szoba panorámás kilátással',
            kitchen: 'Saját konyhatér',
            jacuzzi: 'Jacuzzi a teraszon',
            champagne: 'Pezsgő bekészítés',
            latecheckout: 'Késői kijelentkezés',
            transfer: 'Repülőtéri transzfer',
            prevButton: 'Vissza',
            nextButton: 'Tovább',
        },
        step4: {
            header: 'Személyes adatok',
            description: 'A foglalás rögzítéséhez szükséges személyes adatok',
            lname: 'Vezetéknév',
            fname: 'Keresztnév',
            email: 'E-mail cím',
            address: 'Lakcím',
            countryPlaceholder: 'Válasszon országot...',
            cityPlaceholder: 'Város',
            streetPlaceholder: 'Utca / házszám',
            zipPlaceholder: 'Irányítószám',
            prevButton: 'Vissza',
            finishButton: 'Befejezés',
        },
        step5: {
            header: 'Sikeres foglalás!',
            description: 'Köszönjük, hogy a Hotel Elegance-t választotta.',
            bookingId: 'Foglalás azonosítója: ',
            emailInfo: 'A visszaigazoló dokumentumokat és a részletes tájékoztatót elküldtük a megadott',
            emailInfo2: 'e-mail címre.',
            spamNotice: '*Amennyiben pár percen belül nem érkezik meg a levél, kérjük, ellenőrizze a Spam/Promóciók mappát is.',
            backButton: 'Vissza a főoldalra',
        }
    },
    en: {
        step1: {
            header: 'Booking details',
            description: 'The details you have entered so far',
            arrival: 'Arrival',
            departure: 'Departure',
            adults: 'Adults',
            children: 'Children',
            person: 'person',
            modifyButton: 'Modify',
            nextButton: 'Next',
        },
        step2: {
            header: 'Select suite',
            description: 'Choose one of our suites that suits you best',
            prevButton: 'Back',
            nextButton: 'Next',
        },
        step3: {
            header: 'Extra options',
            description: 'Choose from our extra services according to your needs',
            extraInfo: 'You can choose from our wide variety of additional services during your stay as you wish.',
            catering: 'Catering',
            breakfast: 'Breakfast',
            breakfastNote: '(Included in price)',
            halfboard: 'Half board',
            halfboardNote: '(+10% surcharge)',
            fullboard: 'Full board',
            fullboardNote: '(+20% surcharge)',
            extras: 'Extras',
            balcony: 'Room with balcony',
            garden: 'Room with courtyard view',
            panorama: 'Room with panoramic view',
            kitchen: 'Private kitchen',
            jacuzzi: 'Jacuzzi on the terrace',
            champagne: 'Champagne setup',
            latecheckout: 'Late checkout',
            transfer: 'Airport transfer',
            prevButton: 'Back',
            nextButton: 'Next',
        },
        step4: {
            header: 'Personal Information',
            description: 'Personal information required to confirm your booking',
            lname: 'Last Name',
            fname: 'First Name',
            email: 'Email Address',
            address: 'Address',
            countryPlaceholder: 'Select a country...',
            cityPlaceholder: 'City',
            streetPlaceholder: 'Street / Number',
            zipPlaceholder: 'ZIP Code',
            prevButton: 'Back',
            finishButton: 'Finish'
        },
        step5: {
            header: 'Successful Booking!',
            description: 'Thank you for choosing Hotel Elegance.',
            bookingId: 'Your booking ID: ',
            emailInfo: 'The confirmation documents and detailed information have been sent to the email address ',
            emailInfo2: ' you provided before.',
            spamNotice: '*If you do not receive the email within a few minutes, please check your Spam/Promotion folder as well.',
            backButton: 'Back to Homepage'
        }
    }
};

export const guestPageText = {
    hu: {
        loginPage: {
            h1Text: "Bejelentkezés",
            emailPlaceholder: "Email-cím...",
            passPlaceholder: "Jelszó...",
            buttonText: "Belépés"
        },
        guestPage: {
            sidebarMenuItems: [ 
                "Áttekintés",
                "Szobaszerviz",
                "Wellness",
                "Kényelmi",
                "Logisztika",
            ],
            menuOverview: {
                guestCard: {
                    headerText: "Az Ön adatai",
                    nameText: "Név:",
                    emailText: "E-mail:",
                    addressText: "Cím:",
                },
                roomCard: {
                    headerText: "Szobája jellemzői",
                },
            },
            menuRoomservice: "",
            menuWellness: "",
            menuExtras: "",
            menuLogistics: "",
        }
    },

    en:{
        loginPage: {
            h1Text: "Authentication",
            emailPlaceholder: "Email...",
            passPlaceholder: "Password...",
            buttonText: "Login"
        },
        guestPage: {
            sidebarMenuItems: [ 
                "Overview",
                "Roomservice",
                "Wellness",
                "Extras",
                "Logistics",
            ],
            menuOverview: {
                guestCard: {
                    headerText: "Your personal data",
                    nameText: "Name:",
                    emailText: "E-mail:",
                    addressText: "Address:",
                },
                roomCard: {
                    headerText: "Your Room\'s preferences",
                },
            },
            menuRoomservice: "",
            menuWellness: "",
            menuExtras: "",
            menuLogistics: "",
        }
    }
};