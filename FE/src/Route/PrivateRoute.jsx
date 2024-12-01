import React, { useEffect, useState } from 'react';
import { Navigate, Outlet } from 'react-router-dom';

const PrivateRoute = () => {
  const jwt_token = sessionStorage.getItem('token');

  useEffect(() => {
  }, []);
  return jwt_token ? <Outlet /> : <Navigate exact to={`${process.env.PUBLIC_URL}/login`} />;
};

export default PrivateRoute;
