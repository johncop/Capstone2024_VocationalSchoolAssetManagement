import { Suspense } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoadingPage from "../layout/loading";
import PrivateRoute from "./privateRoute";
import LayoutRoutes from "./layoutRoute";
import { authRoutes } from "./authRoutes";

export const Routers = () => {
    return (
        <BrowserRouter basename="/">
            <Suspense fallback={<LoadingPage />}>
                <Routes>
                    <Route path={'/'} element={<PrivateRoute />}>
                        <Route path={`/`} element={<LayoutRoutes />} />
                        <Route path={`/*`} element={<LayoutRoutes />} />
                    </Route>
                    {authRoutes.map(({ path, component }, i) => (
                        <Route path={path} element={component} key={i}></Route>
                    ))}
                </Routes>
            </Suspense>
        </BrowserRouter>
    )
}