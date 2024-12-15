const initialState = {
    appointments: [],
    loading: false,
    error: null,
    selectedAppointment: null,
    currentPage: 1,
    totalPages: 1,
};

const appointmentReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'FETCH_APPOINTMENTS_REQUEST':
            return {
                ...state,
                loading: true, // Track loading for appointments
            };
        case 'FETCH_APPOINTMENTS_SUCCESS':
            return {
                ...state,
                appointments: action.payload.appointments, // Make sure to get the 'appointments' array
                totalPages: action.payload.totalPages, // Store totalPages separately
                loading: false,
            };
        case 'FETCH_APPOINTMENTS_FAILURE':
            return {
                ...state,
                error: action.payload, // Store error message
                loading: false,
            };
        case 'FETCH_APPOINTMENT_BY_ID_REQUEST':
            return {
                ...state,
                loading: true, // Set loading to true when fetching a single appointment
            };
        case 'FETCH_APPOINTMENT_BY_ID_SUCCESS':
            return {
                ...state,
                selectedAppointment: action.payload, // Store the selected appointment
                loading: false,
            };
        case 'FETCH_APPOINTMENT_BY_ID_FAILURE':
            return {
                ...state,
                error: action.payload, // Store any error that occurs
                loading: false,
            };
        // Handle other actions as necessary (create, update, delete, etc.)
        default:
            return state;
    }
};

export default appointmentReducer;
