import { Route, Routes } from "react-router-dom";
import { routes } from "./routes";
import { Fragment } from "react";
import AppLayout from "../layout/layout";

const LayoutRoutes = () => {

    return (
        <>
            <Routes>
                {routes.map(({ path, component }, i) => (
                    <Fragment key={i}>
                        <Route path="/" element={<AppLayout />} key={i}>
                            <Route path={path} element={component} />
                        </Route>
                    </Fragment>
                ))}
            </Routes>
        </>
    );
};

export default LayoutRoutes;