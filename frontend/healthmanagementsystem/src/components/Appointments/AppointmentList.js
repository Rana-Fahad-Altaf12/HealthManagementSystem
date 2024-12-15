import React from 'react';
import AppointmentCard from './AppointmentCard';

const AppointmentList = ({ appointments, onEdit, onDelete }) => {
    return (
        <div className="row">
            {appointments.map((appointment) => (
                <AppointmentCard
                    key={appointment.id}
                    appointment={appointment}
                    onEdit={onEdit}
                    onDelete={onDelete}
                />
            ))}
        </div>
    );
};

export default AppointmentList;