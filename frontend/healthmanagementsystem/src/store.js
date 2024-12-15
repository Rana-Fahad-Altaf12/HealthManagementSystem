import { createStore, applyMiddleware } from 'redux';
import { thunk } from 'redux-thunk'; // Change to named import
import rootReducer from '../src/reducers/Common';// Adjust the path based on your project structure

const store = createStore(
    rootReducer,
    applyMiddleware(thunk) // Use thunk as a middleware
);

export default store;