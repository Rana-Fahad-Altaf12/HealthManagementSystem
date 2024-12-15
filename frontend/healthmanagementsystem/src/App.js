// src/App.js
import React from 'react';
import { Provider } from 'react-redux';
import store from './store';
import Routes from './routes/Routes'; // Import your Routes component
import Navbar from '../src/components/Navbar/Navbar';

const App = () => {
    return (
        <Provider store={store}>
            <Navbar />
            <Routes /> {/* Use the Routes component for routing */}
        </Provider>
    );
};

export default App;