import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

const PrivateRoute = () => {
    const token = sessionStorage.getItem('token');

    return token ? <Outlet /> : <Navigate exact to={`/login`} />;
};

export default PrivateRoute;
