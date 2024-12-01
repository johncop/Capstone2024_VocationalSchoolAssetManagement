import { Fragment, useEffect, useState } from "react"
import DataTable from "react-data-table-component"
import { productColumns, productData } from '../../../../Data/Ecommerce/ProductList';
import assetApi from "../../../../api/asset/assetApi";
import { assetColumns } from "../../../../Data/Asset/AssetList";
import { Button } from "reactstrap";
import { UserPlus } from "react-feather";

export const AssetDataTable = () => {
    const [assets, setAssets] = useState([]);

    useEffect(() => {
        assetApi.getAll().then(response => {
            const assets = response.data.map(item => {
                item["action"] = (
                    <div>
                        <span className="mr-2">
                            <Button color="success" size="sm" style={{ marginRight: "5px" }}><UserPlus size={20} /></Button>
                        </span>
                    </div>
                )

                return item;
            })
            setAssets(assets);
        })
    }, []);

    return (
        <Fragment>
            <div className='table-responsive product-table'>
                <DataTable noHeader pagination columns={assetColumns} data={assets} highlightOnHover={true} striped={true} responsive={true} />
            </div>
        </Fragment>
    )
}