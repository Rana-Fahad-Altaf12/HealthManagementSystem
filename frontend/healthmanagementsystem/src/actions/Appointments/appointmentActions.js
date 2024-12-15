import fetchWithAuth from '../../utils/fetchWithAuth';

const API_URL = 'https://localhost:7055/api/appointments'; // Replace with your API URL

export const fetchAppointmentsAction = async () => {
  return await fetchWithAuth(`${API_URL}`);
};

  

export const fetchUserAppointments = async (pageNumber = 1, pageSize = 10) => {
    const response = await fetchWithAuth(`${API_URL}/user?pageNumber=${pageNumber}&pageSize=${pageSize}`);

    const { appointments, totalPages } = response;
    return {
        appointments,
        totalPages,
    };
  };
  
export const fetchAppointmentByIdAction = async (id) => {
  return await fetchWithAuth(`${API_URL}/${id}`);
};

export const createAppointmentAction = async (appointmentData) => {
  return await fetchWithAuth(`${API_URL}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(appointmentData),
  });
};

export const updateAppointmentAction = async (appointmentId, appointmentData) => {
  return await fetchWithAuth(`${API_URL}/${appointmentId}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(appointmentData),
  });
};

export const deleteAppointmentAction = async (appointmentId) => {
  return await fetchWithAuth(`${API_URL}/${appointmentId}`, {
    method: 'DELETE',
  });
};
