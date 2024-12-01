import { Fragment, useEffect, useState } from "react"
import { Card, CardBody, Col, Container, Row } from "reactstrap";
import RequestDataTable from "./CommonList/RequestDataTable";
import { Breadcrumbs } from "../../../../../AbstractElements";
import requestApi from "../../../../../api/asset/requestApi";

const RequestList = () => {
    const [requests, setRequests] = useState([]);

    useEffect(() => {
        requestApi.getAll().then(response => {
            console.log(response);
        })
    })
    return (
        <Fragment>
            <Breadcrumbs parent="Application" title="Request List" mainTitle="Request List" />
            <Container fluid={true}>
                <Row>
                    <Col sm={12}>
                        <Card>
                            <CardBody>
                                <RequestDataTable />
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    )
}

export default RequestList;