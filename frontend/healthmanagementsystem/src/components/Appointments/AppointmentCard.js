import React from 'react';

const AppointmentCard = ({ appointment, onEdit, onDelete }) => {
    return (
        <div className="col-md-6 col-lg-4 mb-4">
            <div className="card shadow-sm">
                <div className="card-body">
                    <p className="card-text">
                        <strong>Date:</strong>{' '}
                        {new Date(appointment.appointmentDate).toLocaleString('en-US', {
                            weekday: 'long',
                            year: 'numeric',
                            month: 'short',
                            day: '2-digit',
                            hour: '2-digit',
                            minute: '2-digit',
                            hour12: true,
                        })}
                    </p>
                    <p className="card-text"><strong>Description:</strong> {appointment.description}</p>
                    <div className="d-flex justify-content-between">
                        <button className="btn btn-sm btn-primary" onClick={() => onEdit(appointment.id)}>
                            <i className="fas fa-edit"></i> Update
                        </button>
                        <button className="btn btn-sm btn-danger" onClick={() => onDelete(appointment.id)}>
                            <i className="fas fa-trash-alt"></i> Delete
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AppointmentCard;