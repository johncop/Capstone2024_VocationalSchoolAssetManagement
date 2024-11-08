import React, { Fragment } from "react"
import { useForm } from "react-hook-form";
import { Card, CardBody, Col, Container, Form, FormGroup, Input, Label, Row } from "reactstrap";
import { Breadcrumbs, Btn } from "../../../../AbstractElements";
import Dropzone from "react-dropzone-uploader";
import AssetInformationSection from "./Fields/AssetInformationSection";

const NewAsset = () => {
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

    return (
        <Fragment>
            <Breadcrumbs parent="Application" title="Asset Create" mainTitle="Asset Create" />
            <Container fluid={true}>
                <Row>
                    <Col sm="12">
                        <Card>
                            <CardBody>
                                <Form className="theme-form" onSubmit={handleSubmit(AddAsset)}>
                                    <AssetInformationSection register={register} errors={errors} />

                                    <Row>
                                        <Col sm="4">
                                            <FormGroup>
                                            <Label>Asset Type</Label>
                                                <select name="assetType"
                                                        className="form-select" {...register("assetType")}>
                                                    <option value="">--None--</option>
                                                    <option value="monitor">Monitor</option>
                                                    <option value="keyboard">Keyboard</option>
                                                    <option value="mouse">Mouse</option>
                                                </select>
                                            </FormGroup>
                                        </Col>
                                        <Col sm="4">
                                            <FormGroup>
                                                <Label>Location</Label>
                                                <select name="location" className="form-select" {...register("location")}>
                                                    <option value="">--None--</option>
                                                    <option value="department1">Department 1</option>
                                                    <option value="department2">Department 2</option>
                                                    <option value="department3">Department 3</option>
                                                </select>
                                            </FormGroup>
                                        </Col>
                                        <Col sm="4"></Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                        <FormGroup>
                                                <Label>Description</Label>
                                                <textarea className="form-control" name="description" placeholder="Description *" {...register("description", { required: true })}/>
                                                <span style={{ color: 'red' }}>{errors.description && 'Description is required'}</span>
                                            </FormGroup>

                                        </Col>
                                    </Row>
                                    {/* Upload Asset Image */}
                                    <Row>
                                        <Col>
                                            <FormGroup>
                                                <Label>Upload Asset Image</Label>
                                                <Dropzone
                                                    className='dropzone dz-clickable'
                                                    maxFiles={1}
                                                    multiple={false}
                                                    canCancel={false}
                                                    inputContent='Drop A File'
                                                    styles={{
                                                        dropzone: { width: '100%', height: 150 },
                                                        dropzoneActive: { borderColor: 'green' },
                                                    }}
                                                />
                                            </FormGroup>
                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                            <div className="text-end">
                                                <Btn attrBtn={{ color: "success", className: "me-3", type: "submit" }}>Add</Btn>
                                                <Btn attrBt={{ color: 'danger' }}>Cancel</Btn>
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
}

export default NewAsset;
