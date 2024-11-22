import React from 'react';
import { Card, CardBody, CardHeader } from 'reactstrap';
import { H5, Btn } from '../../../AbstractElements';
import { ExpiredRequestListData } from '../Data';
import RequestListBox from './RequestListBox';

const UpcomingExpiredRequest = () => {
  return (
    <Card className='schedule-card'>
      <CardHeader className='card-no-border'>
        <div className='header-top'>
          <H5 attrH5={{ className: 'm-0' }}>Upcoming Expired Request</H5>
          <div className='card-header-right-icon'>
            <Btn attrBtn={{ color: 'light-primary', className: 'btn badge-light-primary' }}>+ Extend</Btn>
          </div>
        </div> 
      </CardHeader>
      <CardBody className='pt-0'>
        <RequestListBox data={ExpiredRequestListData} />
      </CardBody>
    </Card>
  );
};

export default UpcomingExpiredRequest;
