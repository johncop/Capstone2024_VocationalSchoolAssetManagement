import axios from "axios";
import queryString from "querystring";

const axiosInstance = axios.create({
    baseURL: "https://assetmanagement-dmd5bng3bcffdpab.southeastasia-01.azurewebsites.net/api",
    headers: {
        "Access-Control-Allow-Origin": "*",
        "Content-Type": "application/json",
    },
    paramsSerializer: (params) => queryString.stringify(params)
});

axiosInstance.interceptors.request.use(
    async (config) => {
        const token = sessionStorage.getItem("token");
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    function (error) {
        return Promise.reject(error);
    },
);

axiosInstance.interceptors.response.use(
    (response) => {
        if (response && response.data) {
            return response.data;
        }
        return response;
    },
    (error) => {
        return Promise.reject(error);
    },
);

export default axiosInstance;