import { Fragment } from "react"
import { Breadcrumb, Card, CardBody, Col, Container, Row } from "reactstrap"
import HeaderCard from "../HeaderCard"
import { AssetDataTable } from "./AssetDataTable"

const Request = () => {
    return (
        <Fragment>
            <Breadcrumb parent="Application" title="Asset List" mainTitle="Asset List" />
            <Container fluid={true}>
                <Row>
                    <Col sm="12">
                        <Card>
                            <HeaderCard type='request'/>
                            <CardBody>
                                <AssetDataTable />
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    )
}
export default Request;