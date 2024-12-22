import AssetList from "../page/asset/list";
import AssetCategories from "../page/assetCategory/list";
import AssetType from "../page/assetType/list";
import Department from "../page/department/list";
import MaintenanceRecord from "../page/maintenanceRecord/list";
import Request from "../page/request/list";
import TransactionRecord from "../page/transactionRecord/list";

export const routes = [
    { path: `/assets`, component: <AssetList /> },
    { path: "/asset-categories", component: <AssetCategories /> },
    { path: "/maintaince-record", component: <MaintenanceRecord /> },
    { path: "/transaction-record", component: <TransactionRecord /> },
    { path: "/assets-type", component: <AssetType /> },
    { path: "/request", component: <Request /> },
    { path: "/department", component: <Department /> }
]