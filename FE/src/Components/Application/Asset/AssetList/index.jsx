import { Fragment } from "react"
import { Breadcrumb, Card, CardBody, Col, Container, Row } from "reactstrap"
import HeaderCard from "../../../Common/Component/HeaderCard"
import { ProductListDesc, ProductListTitle } from "../../../../Constant"
import { AssetDataTable } from "./AssetDataTable"

export const AssetList = () => {
    return (
        <Fragment>
            <Breadcrumb parent="Application" title="Asset List" mainTitle="Asset List" />
            <Container fluid={true}>
                <Row>
                    <Col sm="12">
                        <Card>
                            <HeaderCard title={ProductListTitle} span1={ProductListDesc} />
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