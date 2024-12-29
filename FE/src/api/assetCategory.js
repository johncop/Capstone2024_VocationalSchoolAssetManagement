import axiosInstance from "./axiosInstance";

const assetCategoryApi = {
    getAll: () => axiosInstance.get("/category"),
    get: (assetCateId) => axiosInstance.get(`/category${assetCateId}`),
    update: (assetCateId, assetCategory) => axiosInstance.put(`/category/${assetCateId}`, JSON.stringify(assetCategory)),
    delete: (assetCateId) => axiosInstance.delete(`/category/${assetCateId}`)
}

export default assetCategoryApi;