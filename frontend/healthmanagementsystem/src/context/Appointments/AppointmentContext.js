// AppointmentContext.js
import React, { createContext, useReducer, useCallback } from 'react';
import appointmentReducer from '../../reducers/Appointments/appointmentReducer';
import {
  fetchAppointmentsAction,
  createAppointmentAction,
  updateAppointmentAction,
  deleteAppointmentAction,
  fetchAppointmentByIdAction,
  fetchUserAppointments
} from '../../actions/Appointments/appointmentActions';

const AppointmentContext = createContext();

const initialState = {
    appointments: [],
    loading: false,
    error: null,
    currentPage: 1,
    totalPages: 1, // Assuming your API will return total pages for pagination
};

export const AppointmentProvider = ({ children }) => {
  const [state, dispatch] = useReducer(appointmentReducer, initialState);

  const fetchAppointments = useCallback(async (pageNumber = 1, pageSize = 10) => {
    dispatch({ type: 'FETCH_APPOINTMENTS_REQUEST' });
    try {
      const { appointments, totalPages } = await fetchUserAppointments(pageNumber, pageSize); // Assuming the API returns these values
      dispatch({ 
        type: 'FETCH_APPOINTMENTS_SUCCESS', 
        payload: { appointments, totalPages } 
      });
    } catch (error) {
      dispatch({ type: 'FETCH_APPOINTMENTS_FAILURE', payload: error.message });
    }
  }, []);

  const createAppointment = useCallback(async (appointmentData) => {
    dispatch({ type: 'CREATE_APPOINTMENT_REQUEST' });
    try {
      const appointment = await createAppointmentAction(appointmentData);
      dispatch({ type: 'CREATE_APPOINTMENT_SUCCESS', payload: appointment });
      return appointment;
    } catch (error) {
      dispatch({ type: 'CREATE_APPOINTMENT_FAILURE', payload: error.message });
    }
  }, []);

  const updateAppointment = useCallback(async (appointmentId, appointmentData) => {
    dispatch({ type: 'UPDATE_APPOINTMENT_REQUEST' });
    try {
      const appointment = await updateAppointmentAction(appointmentId, appointmentData);
      dispatch({ type: 'UPDATE_APPOINTMENT_SUCCESS', payload: appointment });
      return appointment;
    } catch (error) {
      dispatch({ type: 'UPDATE_APPOINTMENT_FAILURE', payload: error.message });
    }
  }, []);

  const deleteAppointment = useCallback(async (appointmentId) => {
    dispatch({ type: 'DELETE_APPOINTMENT_REQUEST' });
    try {
      await deleteAppointmentAction(appointmentId);
      dispatch({ type: 'DELETE_APPOINTMENT_SUCCESS', payload: appointmentId });
    } catch (error) {
      dispatch({ type: 'DELETE_APPOINTMENT_FAILURE', payload: error.message });
    }
  }, []);

  const fetchAppointmentById = useCallback(async (id) => {
    dispatch({ type: 'FETCH_APPOINTMENT_BY_ID_REQUEST' });
    try {
      const appointment = await fetchAppointmentByIdAction(id);
      dispatch({ type: 'FETCH_APPOINTMENT_BY_ID_SUCCESS', payload: appointment });
    } catch (error) {
      dispatch({ type: 'FETCH_APPOINTMENT_BY_ID_FAILURE', payload: error.message });
    }
  }, []);

  return (
    <AppointmentContext.Provider
      value={{
        state,
        fetchAppointments,
        createAppointment,
        updateAppointment,
        deleteAppointment,
        fetchAppointmentById,
      }}
    >
      {children}
    </AppointmentContext.Provider>
  );
};

export const useAppointment = () => {
  return React.useContext(AppointmentContext);
};
