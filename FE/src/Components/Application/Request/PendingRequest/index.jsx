import { Fragment, useEffect, useState } from "react";
import { Breadcrumbs } from "../../../../AbstractElements";
import { Container } from "reactstrap";
import RequestDataTable from "../CommonComponent/RequestList/CommonList/RequestDataTable";
import requestApi from "../../../../api/asset/requestApi";

const PendingRequest = () => {
    const [requests, setRequests] = useState([]);

    useEffect(() => {
        requestApi.getAll().then(response => {
            console.log(response);
        })
    })
    return (
        <Fragment>
            <Breadcrumbs parent="Application" title="Pending Request" mainTitle="Pending Request" />
            <Container fluid={true}>
                <RequestDataTable />
            </Container>
        </Fragment>
    )
}

export default PendingRequest;