import React from 'react';
import {Col, FormGroup, Label, Row} from "reactstrap";

const DropdownSection = ({register, errors}) => {
	return (
		<Row>
			<Col sm="4">
				<FormGroup>
					<Label>Serial Number</Label>
					<input className="form-control" type="text" name="serialNumber" placeholder="Serial Number *" {...register("serialNumber", { required: true })} />
					<span style={{ color: 'red' }}>{errors.serialNumber && 'Asset Name is required'}</span>
				</FormGroup>
			</Col>
			<Col sm="4">
				<FormGroup>
					<Label>Condition</Label>
					<input className="form-control" type="text" name="condition" placeholder="Condition *" {...register("condition", { required: true })} />
					<span style={{ color: 'red' }}>{errors.condition && 'Asset Name is required'}</span>
				</FormGroup>
			</Col>
			<Col sm="4">
				<FormGroup>
					<Label>Department</Label>
					<select name="department"
							className="form-select" {...register("department")}>
						<option value="">--None--</option>
						<option value="department1">Department 1</option>
						<option value="department2">Department 2</option>
						<option value="department3">Department 3</option>
					</select>
				</FormGroup>
			</Col>
		</Row>
	)
}

export default DropdownSection;
