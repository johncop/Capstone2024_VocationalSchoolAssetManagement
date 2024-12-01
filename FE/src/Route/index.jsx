import React from 'react';
import { Suspense, useEffect, useState } from 'react';
import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import { configureFakeBackend, authHeader, handleResponse } from '../Services/fack.backend';
import Callback from '../Auth/Callback';
import Loader from '../Layout/Loader';
import { authRoutes } from './AuthRoutes';
import LayoutRoutes from '../Route/LayoutRoutes';
import Signin from '../Auth/Signin';
import PrivateRoute from './PrivateRoute';

// setup fake backend
configureFakeBackend();
const Routers = () => {
  const jwt_token = sessionStorage.getItem('token');

  useEffect(() => {
    let abortController = new AbortController();
    console.ignoredYellowBox = ['Warning: Each', 'Warning: Failed'];
    console.disableYellowBox = true;
    return () => {
      abortController.abort();
    };
  }, []);

  return (
    <BrowserRouter basename={'/'}>
      <Suspense fallback={<Loader />}>
        <Routes>
          <Route path={'/'} element={<PrivateRoute />}>
            {jwt_token ? (
              <>
                <Route exact path={`${process.env.PUBLIC_URL}`} element={<Navigate to={`${process.env.PUBLIC_URL}/dashboard/default/`} />} />
                <Route exact path={`/`} element={<Navigate to={`${process.env.PUBLIC_URL}/dashboard/default/`} />} />
              </>
            ) : (
              ""
            )}

            <Route path={`/*`} element={<LayoutRoutes />} />
          </Route>
          <Route path={`${process.env.PUBLIC_URL}/callback`} render={() => <Callback />} />
          <Route exact path={`${process.env.PUBLIC_URL}/login`} element={<Signin />} />
          {authRoutes.map(({ path, Component }, i) => (
            <Route path={path} element={Component} key={i} />
          ))}
        </Routes>
      </Suspense>
    </BrowserRouter>
  );
};

export default Routers;
