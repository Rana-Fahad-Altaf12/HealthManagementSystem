// src/routes/Routes.js
import React from 'react';
import { Route, Routes, Navigate } from 'react-router-dom'; // Import Navigate
import LoginPage from '../pages/User/LoginPage';
import DashboardPage from '../pages/Appointments/DashboardPage';

const AppRoutes = () => {
    return (
        <Routes> {/* Use Routes without another Router */}
            <Route path="/login" element={<LoginPage />} />
            <Route path="/dashboard" element={<DashboardPage />} />
            <Route path="/" element={<Navigate to="/login" />} /> {/* Use Navigate instead of Redirect */}
        </Routes>
    );
};

export default AppRoutes;