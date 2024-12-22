import axiosInstance from "./axiosInstance"

const authApi = {
    login: (email, password) => {
        return axiosInstance.post("/account/login", JSON.stringify({ email, password }));
    },

    verifyCode: (userId, code) => {
        return axiosInstance.get(`/account/verify-code?userId=${userId}&code=${code}`);
    }
}

export default authApi;