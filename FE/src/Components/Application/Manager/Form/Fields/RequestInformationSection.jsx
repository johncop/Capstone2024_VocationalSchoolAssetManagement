import React, {Fragment} from "react";
import {Col, FormGroup, Label, Row} from "reactstrap";
import { Btn } from "../../../../../AbstractElements";
const RequestInformationSection = ({register, errors}) => {
    return (
        <Fragment>
            <Row>
                <Col>
                <FormGroup>
                        <Label>Description</Label>
                        <textarea className="form-control" name="description" placeholder="Description *" {...register("description", { required: true })}/>
                        <span style={{ color: 'red' }}>{errors.description && 'Description is required'}</span>
                    </FormGroup>

                </Col>
            </Row>
            <Row>
            <Col sm="4">
				<FormGroup>
					<Label>Asset ID</Label>
					<input className="form-control" type="text" name="condition" placeholder="Condition *" {...register("condition", { required: true })} />
					<span style={{ color: 'red' }}>{errors.condition && 'Asset Name is required'}</span>
				</FormGroup>
			</Col>
			<Col sm="4">
				<FormGroup>
					<Label>Location</Label>
					<select name="department" className="form-select" {...register("department")}>
						<option value="">--None--</option>
						<option value="department1">Location 1</option>
						<option value="department2">Location 2</option>
						<option value="department3">Location 3</option>
					</select>
				</FormGroup>
			</Col>
            <Col sm="4">
                <Btn attrBtn={{ color: "success", className: "me-3", type: "submit" }}>Add Another</Btn>
			</Col>
            </Row>
        </Fragment>
    )
}

export default RequestInformationSection;