import React, { useState } from 'react';
import { Container, Row, Col, TabContent, TabPane } from 'reactstrap';
import NavAuth from './Nav';
import LoginTab from './Tabs/LoginTab';
import AuthTab from './Tabs/AuthTab';

const Logins = () => {
  const [selected, setSelected] = useState('jwt');

  const callbackNav = (select) => {
    setSelected(select);
  };

  return (
    <Container fluid={true} className='p-0 login-page'>
      <Row>
        <Col xs='12'>
          <div className='login-card'>
            <div className='login-main login-tab'>
              <LoginTab selected={selected} />
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  );
};

export default Logins;
