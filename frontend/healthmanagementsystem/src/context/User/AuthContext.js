import React, { useContext, createContext, useReducer, useEffect } from 'react';
import authReducer from '../../reducers/User/authReducer';
import { loginUserAction } from '../../actions/User/authActions';

const AuthContext = createContext();

const initialState = {
  user: null,
  token: null,
  loading: false,
  error: null,
};

export const AuthProvider = ({ children }) => {
  const [state, dispatch] = useReducer(authReducer, initialState);

  // Load user from localStorage on app load
  useEffect(() => {
    const token = localStorage.getItem('token');
    const userInfo = localStorage.getItem('user');
    if (token && userInfo) {
      dispatch({
        type: 'LOGIN_SUCCESS',
        payload: { token, userInfo: JSON.parse(userInfo) },
      });
    }
  }, []);

  const login = async (credentials) => {
    dispatch({ type: 'LOGIN_REQUEST' });
    try {
      const { token, userInfo } = await loginUserAction(credentials);
      localStorage.setItem('token', token);
      localStorage.setItem('user', JSON.stringify(userInfo)); // Persist user data
      dispatch({ type: 'LOGIN_SUCCESS', payload: { token, userInfo } });
    } catch (error) {
      dispatch({ type: 'LOGIN_FAILURE', payload: error.message });
    }
  };

  const logout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    dispatch({ type: 'LOGOUT' });
  };

  return (
    <AuthContext.Provider value={{ state, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  return useContext(AuthContext);
};
