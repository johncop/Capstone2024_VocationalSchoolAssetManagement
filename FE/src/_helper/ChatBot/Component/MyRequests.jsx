import React, { useState } from 'react';

import { Card, CardBody, CardHeader, Nav } from 'reactstrap';
import { Image, H5 } from '../../../AbstractElements';
import RecentOrderContentTab from './RequestTab';
import useShowClass from '../../../Hooks/useShowClass';

const MyRequests = () => {
  const [isActive, setIsActive] = useState('0');
  const [show, setShow] = useShowClass('show');
  const RecentOrdersNav = ['1', '2', '3', '4', '5'];

  const activeHandle = (i) => {
    setIsActive(`${i}`);
    setShow('');
  };

  return (
    <Card className='recent-order'>
      <CardHeader className='card-no-border'>
        <div className='header-top'>
          <H5 attrH5={{ className: 'm-0' }}>Your Request</H5>
        </div>
      </CardHeader>
      <CardBody className='pt-0'>
        <div className='recent-sliders'>
          <Nav tag='div' pills={true} tabs>
            {RecentOrdersNav.map((item, j) => (
              <button key={j} onClick={(e) => activeHandle(j)} className={`frame-box ${isActive === `${j}` && 'active'}`}>
              <span className='frame-image'>
                <Image attrImage={{ src: require(`../../../assets/images/dashboard-2/order/${item}.png`), alt: 'vector T-shirt' }} />
              </span>
            </button>
            ))}
          </Nav>
          <RecentOrderContentTab show={show} isActive={isActive} RecentOrdersNav={RecentOrdersNav} />
        </div>
      </CardBody>
    </Card>
  );
};

export default MyRequests;
