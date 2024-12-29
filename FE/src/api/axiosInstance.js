import axios from "axios";
import queryString from "querystring";

const API_BASE_URL = "https://assetmanagement-dmd5bng3bcffdpab.southeastasia-01.azurewebsites.net/api";

/**
 * Get the token from sessionStorage or any other storage mechanism.
 */
const getToken = () => sessionStorage.getItem("token");

const createAxiosInstance = () => {
    const instance = axios.create({
        baseURL: API_BASE_URL,
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Content-Type": "application/json",
        },
        paramsSerializer: (params) => queryString.stringify(params)
    });

    instance.interceptors.request.use(
        async (config) => {
            const token = getToken();
            if (token) {
                config.headers.Authorization = `Bearer ${token}`;
            }
            return config;
        },
        function (error) {
            return Promise.reject(error);
        },
    );

    instance.interceptors.response.use(
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

    return instance;
}

const baseApiMethod = (axiosInstance) => ({
    /**
     * Get (Read) data from an endpoint.
     * @param {string} url - The endpoint URL.
     * @param {Object} params - Query parameters.
     */
    get: (url, params = {}) => axiosInstance.get(url, { params }),

    /**
     * Post (Create) data to an endpoint.
     * @param {string} url - The endpoint URL.
     * @param {Object} data - The data payload.
     */
    post: (url, data) => axiosInstance.post(url, data),

    /**
     * Put (Update) data at an endpoint.
     * @param {string} url - The endpoint URL.
     * @param {Object} data - The data payload.
     */
    put: (url, data) => axiosInstance.put(url, data),

    /**
     * Delete data from an endpoint.
     * @param {string} url - The endpoint URL.
     * @param {Object} params - Query parameters.
     */
    delete: (url, params = {}) => axiosInstance.delete(url, { params }),
});

const axiosInstance = createAxiosInstance();
const baseApi = baseApiMethod(axiosInstance);

export { createAxiosInstance, baseApiMethod, baseApi }
export default axiosInstance;