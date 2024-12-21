import AssetList from "../page/asset/list";
import AssetCategories from "../page/assetCategory/list";

export const routes = [
    { path: `/assets`, component: <AssetList /> },
    { path: "/asset-categories", component: <AssetCategories /> }
]