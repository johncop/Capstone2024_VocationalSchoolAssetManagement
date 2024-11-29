import React, { Fragment } from 'react';
import { Container, Row } from 'reactstrap';
import { Breadcrumbs } from '../../../AbstractElements';
import WidgetsWrapper from './WidgetsWraper';
import Request from './Request';
import Asset from './Asset';
import FormData from './Form';


const Manager = () => {
  return (
    <Fragment>
      <Breadcrumbs mainTitle='Default' parent='Home' title='Home' />
      <Container fluid={true}>
        <Row className='widget-grid'>
          <WidgetsWrapper />
          <Request/>
          {/* <Asset/> */}
          {/* <FormData module={'Create'}/> */}
        </Row>
      </Container>
    </Fragment>
  );
};

export default Manager;
