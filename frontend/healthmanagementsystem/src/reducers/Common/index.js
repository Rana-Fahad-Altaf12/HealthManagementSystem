import { combineReducers } from 'redux';
import appointmentReducer from '../Appointments/appointmentReducer';
import authReducer from '../User/authReducer';

const rootReducer = combineReducers({
    appointment: appointmentReducer,
    auth: authReducer,
    // Add other reducers here
});

export default rootReducer;