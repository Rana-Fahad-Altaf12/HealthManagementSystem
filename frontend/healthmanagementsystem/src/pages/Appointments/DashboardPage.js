// Dashboard.js
import React, { useState, useEffect } from 'react';
import { useAppointment } from '../../context/Appointments/AppointmentContext';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import AppointmentForm from '../../components/Appointments/AppointmentForm';
import AppointmentList from '../../components/Appointments/AppointmentList';
import Pagination from '../../components/Pagination/Pagination';

const Dashboard = () => {
    const appointmentContext = useAppointment();
    const { state, fetchAppointments, createAppointment, updateAppointment, deleteAppointment, fetchAppointmentById } = appointmentContext;

    const [appointmentData, setAppointmentData] = useState({
        appointmentDate: '',
        description: '',
        Id: 0
    });

    const [isEditing, setIsEditing] = useState(false);
    const [currentAppointmentId, setCurrentAppointmentId] = useState(null);
    const [currentPage, setCurrentPage] = useState(1);
    const [appointmentsPerPage] = useState(2);

    useEffect(() => {
        fetchAppointments(currentPage, appointmentsPerPage);
    }, [currentPage, appointmentsPerPage, fetchAppointments]);

    const handleCreateAppointment = async () => {
        try {
            const response = await createAppointment(appointmentData);
            await fetchAppointments(currentPage, appointmentsPerPage);
            if (response && response.id > 0) {
                toast.success("Appointment created successfully");
            }
            resetForm();
        } catch (error) {
            console.error(error);
            toast.error("Failed to create appointment: " + error.message);
        }
    };

    const handleUpdateAppointment = async () => {
        try {
            appointmentData.Id = currentAppointmentId;
            const response = await updateAppointment(currentAppointmentId, appointmentData);
            await fetchAppointments(currentPage, appointmentsPerPage);
            resetForm();
            if (response && response.message) {
                toast.success(response.message);
            }
        } catch (error) {
            console.error(error);
            toast.error("Failed to update appointment: " + error.message);
        }
    };

    const handleDeleteAppointment = async (appointmentId) => {
        const confirmDelete = window.confirm("Are you sure you want to delete this appointment?");
        if (confirmDelete) {
            try {
                await deleteAppointment(appointmentId);
                await fetchAppointments(currentPage, appointmentsPerPage);
                toast.success("Appointment deleted successfully.");
                resetForm();
            } catch (error) {
                console.error(error);
                toast.error("Failed to delete appointment: " + error.message);
            }
        }
    };

    useEffect(() => {
        if (state.selectedAppointment) {
            setAppointmentData({
                appointmentDate: state.selectedAppointment.appointmentDate || '',
                description: state.selectedAppointment.description || '',
            });
            setIsEditing(true);
        }
    }, [state.selectedAppointment]);

    const handleEditAppointment = async (appointmentId) => {
        try {
            const response = await fetchAppointmentById(appointmentId);
            if (response && response.message) {
                toast.success(response.message);
            }
            setCurrentAppointmentId(appointmentId);
        } catch (error) {
            toast.error("Failed to load appointment: " + error.message);
        }
    };

    const resetForm = () => {
        setAppointmentData({
            appointmentDate: '',
            description: '',
            Id: 0
        });
        setIsEditing(false);
        setCurrentAppointmentId(null);
    };

    if (state.loading) {
        return (
            <div className="text-center">
                <div className="spinner-border" role="status">
                    <span className="sr-only">Loading...</span>
                </div>
            </div>
        );
    }

    if (state.error) {
        return <p className="text-danger text -center">Error: {state.error}</p>;
    }

    const handlePageChange = (newPage) => {
        setCurrentPage(newPage);
    };

    return (
        <div className="container mt-5">
            <ToastContainer />
            <h1 className="text-center mb-4">Appointments</h1>
            <AppointmentList 
                appointments={state.appointments} 
                onEdit={handleEditAppointment} 
                onDelete={handleDeleteAppointment} 
            />
            <Pagination 
                currentPage={currentPage} 
                totalPages={state.totalPages} 
                onPageChange={handlePageChange} 
            />
            <AppointmentForm 
                appointmentData={appointmentData} 
                setAppointmentData={setAppointmentData} 
                isEditing={isEditing} 
                handleSubmit={(e) => {
                    e.preventDefault();
                    isEditing ? handleUpdateAppointment() : handleCreateAppointment();
                }} 
                resetForm={resetForm} 
            />
        </div>
    );
};

export default Dashboard;