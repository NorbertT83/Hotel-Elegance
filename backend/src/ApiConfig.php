<?php

function getApiEndpoints(): array {
    return [
        'room' => [
            'table'   => 'rooms',
            'id'      => 'room_number',
            'filters' => ['room_type', 'status', 'bed_type', 'has_balcony'],
            'sorts'   => ['room_number', 'price_per_night', 'floorspace'],
            'enums'   => [
                'status' => ['available','occupied','under_maintenance','unavailable'],
                'room_type' => ['standard','deluxe','suite'],
                'bed_type' => ['single', 'twin', 'kingsize'],
                'has_view' => ['city', 'garden', 'panorama']
            ],
            'update_fields' => ['room_type','floorspace','bed_type','has_balcony','has_view','max_adults','extras','status','door_locked','needs_cleaning','is_cleaning','dont_disturb','ac_temp','price_per_night'],
        ],
        'guest' => [
            'table'   => 'guests',
            'id'      => 'id',
            'filters' => ['city', 'country', 'loyalty_level', 'email'],
            'sorts'   => ['fname', 'lname', 'country', 'loyalty_level'],
            'insert_fields' => ['email','fname','lname','zip_code','country','city','street'],
        ],
        'employee' => [
            'table'   => 'employees',
            'id'      => 'id',
            'filters' => ['role'],
            'sorts'   => ['fname', 'lname', 'salary', 'date_of_birth', 'date_of_hiring'],
        ],
        'service' => [
            'table'   => 'services',
            'id'      => 'id',
            'filters' => ['service_type_hu', 'service_type_en'],
            'sorts'   => ['name_hu', 'name_en', 'price', 'service_type_hu', 'service_type_en'],
            'insert_fields' => ['name_hu','name_en','price','service_type_hu','service_type_en'],
        ],
        'booking' => [
            'table'   => 'bookings',
            'id'      => 'id',
            'filters' => ['room_number', 'guest1_id','end_of_stay_after'],
            'sorts'   => ['beginning_of_stay', 'room_number', 'guest1_id'],
            'enums'   => [
                'room_type'  => ['standard','deluxe','suite'],
                'needs_view' => ['city', 'garden', 'panorama'],
            ],
        ],
        'servicebooking' => [
            'table'   => 'servicebookings',
            'id'      => 'id',
            'filters' => ['status', 'booking_id'],
            'sorts'   => ['status', 'updated_at'],
            'enums'   => ['status' => ['created', 'pending', 'completed', 'deleted']],
            'insert_fields' => ['booking_id','service_id','quantity','status','price_at_booking'],
        ],
        'foodbeverage' => [
            'table'   => 'food_and_beverage',
            'id'      => 'id',
            'filters' => ['category'],
            'sorts'   => ['category', 'price', 'name_hu', 'name_en'],
            'enums'   => ['category' => ['breakfast','starter','soup','main_course','dessert','hot_drink','soft_drink','alcoholic_drink']],
        ],
        'freerooms' => [
            'filters' => ['end_of_stay_after'],
        ],
    ];
}
