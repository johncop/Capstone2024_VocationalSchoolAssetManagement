import React, { Fragment } from 'react';
import { CardHeader, Col, Row, FormGroup, Label, Card, CardBody, Container } from 'reactstrap';
import { SmallWidgetsData } from './Data';
import SmallWidgets from './SmallWidgets';
import FormData from './Form';

const HeaderCard = ({ mainClasses, type }) => {

  if(type == 'request'){
    return (
      <Fragment>
        <CardHeader className={`${mainClasses ? mainClasses : ''}`}>
  
          <Col xxl='auto' xl='8' className='box-col-12'>
              <Row>
                  {SmallWidgetsData.map((data, i) => {
                    if(i != 3 && i != 4){
                      return(
                        <Col sm='2' key={i}>
                          <SmallWidgets mainClass='mb-sm-0' data={data} />
                        </Col> 
                      )} else {
                        return(
                        <Col sm='2' key={i}>
                        </Col> 
                      )
                    } 
                  })} 
              </Row>
          </Col>      
        </CardHeader>
      </Fragment>
    );
  } else if(type == 'asset'){
    return (
      <Fragment>
        <CardHeader className={`${mainClasses ? mainClasses : ''}`}>
          <FormData module='Search'/>     
        </CardHeader>
      </Fragment>
    );
  }
  
};

export default HeaderCard;
