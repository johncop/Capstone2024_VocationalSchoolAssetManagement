import React, {Fragment} from "react";
import {Col, FormGroup, Label, Row} from "reactstrap";
const AssetInformationSection = ({register, errors}) => {
    return (
        <Fragment>
            <Row>
                <Col sm="4">
                    <FormGroup>
                        <Label>Asset Name</Label>
                        <input className="form-control" type="text" name="assetName" placeholder="Asset Name *" {...register("assetName", { required: true })} />
                        <span style={{ color: 'red' }}>{errors.assetName && 'Asset Name is required'}</span>
                    </FormGroup>
                </Col>
                <Col sm="4">
                    <FormGroup>
                        <Label>Status</Label>
                        <select className="form-select" name="status" {...register("status", { required: true })}>
                            <option value="">--None--</option>
                            <option value="ready">Ready</option>
                            <option value="forRent">For Rent</option>
                            <option value="maintenance">Maintenance</option>
                        </select>
                    </FormGroup>
                </Col>
                <Col sm="4">
                    <FormGroup>
                        <Label>Serial Number</Label>
                        <input className="form-control" type="text" name="serialNumber" placeholder="Serial Number *" {...register("serialNumber", { required: true })} />
                        <span style={{ color: 'red' }}>{errors.serialNumber && 'Asset Name is required'}</span>
                    </FormGroup>
                </Col>
            </Row>
        </Fragment>
    )
}

export default AssetInformationSection;