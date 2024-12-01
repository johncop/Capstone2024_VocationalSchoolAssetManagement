import axiosInstance from "../axiosInstance";

const assetApi = {
    getAll: () => {
        const url = "/asset";
        return axiosInstance.get(url);
    }
}

export default assetApi;

