import React, { useState } from 'react';

import { Card, CardBody, CardHeader, Nav } from 'reactstrap';
import { Image, H5 } from '../../../AbstractElements';
import RecentOrderContentTab from './RequestTab';
import useShowClass from '../../../Hooks/useShowClass';
import { assets } from '../Data';
import TabWidget from './CategoryTab';

const MyRequests = () => {
  const [isActive, setIsActive] = useState('0');
  const [show, setShow] = useShowClass('show');

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
            {assets.asset_category.map((item, k) => (
              <button key={k} onClick={(e) => activeHandle(k)} className={`frame-box ${isActive === `${k}` && 'active'}`}>
              <TabWidget data={item}></TabWidget>
            </button>
            ))}
          </Nav>
          <RecentOrderContentTab show={show} isActive={isActive} assets={assets} />
        </div>
      </CardBody>
    </Card>
  );
};

export default MyRequests;
