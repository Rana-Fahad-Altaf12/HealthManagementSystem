import React from 'react';

const AppointmentForm = ({ appointmentData, setAppointmentData, isEditing, handleSubmit, resetForm }) => {
    return (
        <form className="card p-4 shadow-sm" onSubmit={handleSubmit}>
            <h2 className="text-center mb-4">{isEditing ? 'Update Appointment' : 'Create Appointment'}</h2>
            <div className="mb-3">
                <label htmlFor="appointmentDate" className="form-label">Appointment Date and Time</label>
                <input
                    type="datetime-local"
                    id="appointmentDate"
                    className="form-control"
                    value={appointmentData.appointmentDate ? appointmentData.appointmentDate.split('T')[0] + 'T' + appointmentData.appointmentDate.split('T')[1] : ''}
                    onChange={(e) => setAppointmentData({ ...appointmentData, appointmentDate: e.target.value })}
                    required
                />
            </div>
            <div className="mb-3">
                <label htmlFor="description" className="form-label">Description</label>
                <textarea
                    id="description"
                    className="form-control"
                    value={appointmentData.description}
                    onChange={(e) => setAppointmentData({ ...appointmentData, description: e.target.value })}
                    required
                ></textarea>
            </div>
            <div className="d-flex justify-content-between">
                <button type="submit" className="btn btn-success btn-sm me-2">
                    <i className="fas fa-plus"></i> {isEditing ? 'Update Appointment' : 'Create Appointment'}
                </button>
                {isEditing && (
                    <button
                        type="button"
                        className="btn btn-secondary btn-sm"
                        onClick={resetForm}
                    >
                        Cancel
                    </button>
                )}
            </div>
        </form>
    );
};

export default AppointmentForm;