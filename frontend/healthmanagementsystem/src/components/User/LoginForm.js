// src/components/LoginForm.js
import React, { useState } from 'react';
import { useAuth } from '../../context/User/AuthContext';
import '../../styles/User/LoginForm.css';
import { useNavigate, Navigate } from 'react-router-dom';

const LoginForm = () => {
  const { state, login } = useAuth();
  const [credentials, setCredentials] = useState({ username: '', password: '' });
  const navigate = useNavigate();

  if (state.user) {
    return <Navigate to="/dashboard" />;
  }

  const handleChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await login(credentials);
    navigate('/dashboard');
  };

  return (
    <div className="container mt-5">
  <div className="row justify-content-center">
    <div className="col-md-4">
      <div className="card">
        <div className="card-body">
          <h2 className="card-title text-center">Login</h2>
          {state.error && <p className="text-danger text-center">{state.error}</p>}
          <form onSubmit={handleSubmit} className="needs-validation">
            <div className="form-group">
              <label htmlFor="username" className="form-label">Username</label>
              <input
                type="text"
                name="username"
                value={credentials.username}
                onChange={handleChange}
                required
                className="form-control"
              />
            </div>
            <div className="form-group">
              <label htmlFor="password" className="form-label">Password</label>
              <input
                type="password"
                name="password"
                value={credentials.password}
                onChange={handleChange}
                required
                className="form-control"
              />
            </div>
            <button type="submit" className="btn btn-primary w-100" disabled={state.loading}>
              {state.loading ? 'Logging in...' : 'Login'}
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</div>
  );
};

export default LoginForm;