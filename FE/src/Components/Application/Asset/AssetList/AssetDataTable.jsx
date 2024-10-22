import { Fragment } from "react"
import DataTable from "react-data-table-component"
import { productColumns, productData } from '../../../../Data/Ecommerce/ProductList';

export const AssetDataTable = () => {
    return (
        <Fragment>
            <div className='table-responsive product-table'>
                <DataTable noHeader pagination paginationServer columns={productColumns} data={productData} highlightOnHover={true} striped={true} responsive={true} />
            </div>
        </Fragment>
    )
}