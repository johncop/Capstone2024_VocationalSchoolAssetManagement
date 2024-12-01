import { Fragment } from "react";
import { Breadcrumbs } from "../../../../AbstractElements";
import { Container } from "reactstrap";
import RequestDataTable from "../CommonComponent/RequestList/CommonList/RequestDataTable";

const RequestHistory = () => {
    return (
        <Fragment>
            <Breadcrumbs parent="Application" title="Request History" mainTitle="Request History" />
            <Container fluid={true}>
                <RequestDataTable />
            </Container>
        </Fragment>
    );
}

export default RequestHistory;