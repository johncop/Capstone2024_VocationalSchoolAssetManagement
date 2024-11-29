import React, { Fragment } from "react"
import { useForm } from "react-hook-form";
import { Card, CardBody, Col, Container, Form, FormGroup, Input, Label, Row } from "reactstrap";
import { Breadcrumbs, Btn } from "../../../../AbstractElements";
import AssetInformationSection from "./Fields/AssetInformationSection";
import RequestInformationSection from "./Fields/RequestInformationSection";

const FormData = ({module}) => {
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm();

    const AddAsset = (data) => {
        if (data !== "") {
            console.log(data);
        } else {
            errors.showMessages()
        }
    }

    if(module == 'Search'){
        return (
            <Fragment>
                <Breadcrumbs parent="Application" title="home" mainTitle="Search" />
                <Container fluid={true}>
                    <Row>
                        <Col sm="12">
                            <Card>
                                <CardBody>
                                    <Form className="theme-form" onSubmit={handleSubmit(AddAsset)}>
                                        <AssetInformationSection register={register} errors={errors} />
                                        <Row>
                                            <Col>
                                                <div className="text-end">
                                                    <Btn attrBtn={{ color: "success", className: "me-3", type: "submit" }}>Apply</Btn>
                                                </div>
                                            </Col>
                                        </Row>
                                    </Form>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </Fragment >
        )
    } else if(module == 'Create'){
        <Fragment>
                <Breadcrumbs parent="Application" title="home" mainTitle="Create Ticket" />
                <Container fluid={true}>
                    <Row>
                        <Col sm="12">
                            <Card>
                                <CardBody>
                                    <Form className="theme-form" onSubmit={handleSubmit(AddAsset)}>
                                        {/* <RequestInformationSection register={register} errors={errors} /> */}
                                        <Row>
                                            <Btn attrBtn={{ color: "success", className: "me-3", type: "submit" }}>Submit</Btn>
                                        </Row>
                                    </Form>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </Fragment >
    }
}

export default FormData;
