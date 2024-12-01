import { Fragment, useState } from "react"
import { useForm } from "react-hook-form";
import { Form } from "react-router-dom";
import { Card, CardBody, Col, Container, FormGroup, Input, Label } from "reactstrap";

const RequestForm = ({ formType }) => {
    var [requestType, setRequestType] = useState("");
    const { register, handleSubmit, formState: { errors } } = useForm();

    return (
        <Fragment>
            <Container fluid={true}>
                <Card>
                    <CardBody>
                        <Form>
                            <Row>
                                <Col sm={4}>
                                    <FormGroup>
                                        <Label>Request Type</Label>
                                        <select name="requestType"
                                            className="form-select" {...register("requestType")} onChange={(e) => setRequestType(e.target.value)}>
                                            <option value="">--None--</option>
                                            <option value="monitor">Loan Request</option>
                                            <option value="keyboard">Keyboard</option>
                                            <option value="mouse">Mouse</option>
                                        </select>
                                    </FormGroup>
                                </Col>
                                <Col sm={4}></Col>
                                <Col sm={4}></Col>
                            </Row>
                            <Row>
                                <Col sm={4}></Col>
                                <Col sm={4}></Col>
                                <Col sm={4}></Col>
                            </Row>
                        </Form>
                    </CardBody>
                </Card>
            </Container>
        </Fragment>
    )
}

export default RequestForm;