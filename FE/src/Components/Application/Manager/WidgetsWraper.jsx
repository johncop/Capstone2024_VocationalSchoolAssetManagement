import React from 'react';
import { Col, Row } from 'reactstrap';
import { WidgetsData1, WidgetsData2, WidgetsData3, WidgetsData4 } from './Data';
import WidgetsIcon from './WidgetsIcon';

const WidgetsWrapper = () => {
  return (
    <>
      <Col xxl='auto' xl='3' sm='6' className='box-col-6'>
        <Row>
          <Col xl='12'>
            <WidgetsIcon data={WidgetsData1} />
          </Col>
        </Row>
      </Col>
      <Col xxl='auto' xl='3' sm='6' className='box-col-6'>
        <Row>
          <Col xl='12'>
            <WidgetsIcon data={WidgetsData2} />
          </Col>
        </Row>
      </Col>
      <Col xxl='auto' xl='12' sm='6' className='box-col-6'>
        <Row>
        <Col xl='12'>
            <WidgetsIcon data={WidgetsData3} />
          </Col>
        </Row>
      </Col>
      <Col xxl='auto' xl='12' sm='6' className='box-col-6'>
        <Row>
        <Col xl='12'>
            <WidgetsIcon data={WidgetsData4} />
          </Col>
        </Row>
      </Col>
    </>
  );
};

export default WidgetsWrapper;
