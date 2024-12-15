// src/components/Navbar.js
import React from 'react';
import { useAuth } from '../../context/User/AuthContext';
import { useNavigate } from 'react-router-dom';

const Navbar = () => {
  const { state, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/login'); // Redirect to login page after logout
  };

  const handleSignIn = () => {
    navigate('/login'); // Redirect to the login page
  };

  return (
    <nav className="navbar navbar-dark bg-dark">
  <div className="container-fluid">
    <h2 className="navbar-brand">Health Management System</h2>
    <div className="d-flex justify-content-end">
      {state.user ? (
        <>
          <button className="nav-link text-white me-2" type="button" onClick={() => navigate('/dashboard')}>Dashboard</button>
          <button className="nav-link text-white" type="button" onClick={handleLogout}><i className='fa fa-sign-out-alt'></i></button>
        </>
      ) : (
        <>
        </>
      )}
    </div>
  </div>
</nav>
  );
};

export default Navbar;