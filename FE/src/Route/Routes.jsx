import AssetList from "../page/asset/list";
import AssetCategories from "../page/assetCategory/list";
import MaintenanceRecord from "../page/maintenanceRecord/list";
import TransactionRecord from "../page/transactionRecord/list";

export const routes = [
    { path: `/assets`, component: <AssetList /> },
    { path: "/asset-categories", component: <AssetCategories /> },
    { path: "/maintaince-record", component: <MaintenanceRecord /> },
    { path: "/transaction-record", component: <TransactionRecord /> }
]