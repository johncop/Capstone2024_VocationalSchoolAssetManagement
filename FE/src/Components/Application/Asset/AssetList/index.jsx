import { Fragment, useState } from "react"
import { Breadcrumb, Card, CardBody, Col, Container, Row, TabContent, TabPane, Nav, NavItem, NavLink } from "reactstrap"
import HeaderCard from "../../../Common/Component/HeaderCard"
import { ProductListDesc, ProductListTitle } from "../../../../Constant"
import { AssetDataTable } from "./AssetDataTable"

const AssetList = () => {
    const [activeTab, setActiveTab] = useState('1');
    return (
        <Fragment>
            <Breadcrumb parent="Application" title="Asset List" mainTitle="Asset List" />
            <Container fluid={true}>
                <Row>
                    <Col sm="12">
                        <Card>
                            <CardBody>
                                <Card>
                                    <div className='product-page-main'>
                                        <Row className='m-0'>
                                            <Col sm='12'>
                                                <Nav tabs className='border-tab nav-primary mb-0 '>
                                                    <NavItem id='myTab' role='tablist'>
                                                        <NavLink href='#' className={activeTab === '1' ? 'active' : ''} onClick={() => setActiveTab('1')}>
                                                            Asset
                                                        </NavLink>
                                                        <div className='material-border'></div>
                                                    </NavItem>
                                                    <NavItem id='myTab' role='tablist'>
                                                        <NavLink href='#' className={activeTab === '2' ? 'active' : ''} onClick={() => setActiveTab('2')}>
                                                            Maintenance Asset
                                                        </NavLink>
                                                        <div className='material-border'></div>
                                                    </NavItem>
                                                    <NavItem id='myTab' role='tablist'>
                                                        <NavLink href='#' className={activeTab === '3' ? 'active' : ''} onClick={() => setActiveTab('3')}>
                                                            Outdate Asset
                                                        </NavLink>
                                                        <div className='material-border'></div>
                                                    </NavItem>
                                                </Nav>
                                                <TabContent activeTab={activeTab}>
                                                    <TabPane tabId='1'>
                                                        <div className="mt-3">
                                                            <AssetDataTable />
                                                        </div>

                                                    </TabPane>
                                                    <TabPane tabId='2'>
                                                        <p>Tab 2</p>
                                                    </TabPane>
                                                    <TabPane tabId='3'>
                                                        <p>Maintenance Asset</p>
                                                    </TabPane>

                                                </TabContent>
                                            </Col>
                                        </Row>
                                    </div>
                                </Card>
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </Fragment>
    )
}
export default AssetList;