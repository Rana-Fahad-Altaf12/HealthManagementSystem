import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAppointments } from '../actions/appointmentActions';

const useAppointments = () => {
    const dispatch = useDispatch();
    const appointments = useSelector((state) => state.appointments.appointments);

    useEffect(() => {
        dispatch(fetchAppointments());
    }, [dispatch]);

    return appointments;
};

export default useAppointments;