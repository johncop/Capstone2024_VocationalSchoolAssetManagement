import axiosInstance from "../axiosInstance"

const requestApi = {
    getAll: () => {
        return axiosInstance.get("/request");
    }
}

export default requestApi;