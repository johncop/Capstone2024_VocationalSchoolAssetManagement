import Login from "../page/auth/login";
import VerifyCodePage from "../page/auth/verify";

export const authRoutes = [
    { path: `/login`, component: <Login /> },
    { path: `/verify-code/:userId`, component: <VerifyCodePage /> }
]