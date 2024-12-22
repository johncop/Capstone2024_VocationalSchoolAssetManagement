import axiosInstance from "./axiosInstance"

const assetApi = {
    getAll: () => {
        return axiosInstance.get("/asset")
    }
}

export default assetApi;