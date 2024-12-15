import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import { AuthProvider } from '../src/context/User/AuthContext';
import { AppointmentProvider } from '../src/context/Appointments/AppointmentContext';
import './styles/index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <BrowserRouter>
    <AuthProvider>
    <AppointmentProvider>
      <App />
      </AppointmentProvider>
    </AuthProvider>
  </BrowserRouter>
);