import React, { useState } from 'react';
import { Card, CardBody, CardHeader, Nav } from 'reactstrap';
import RecentOrderContentTab from './RequestTab';
import useShowClass from '../../../Hooks/useShowClass';
import { assets } from '../Data';
import { H6, H5 } from '../../../AbstractElements';
import SvgIcon from '../../../Components/Common/Component/SvgIcon';

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
              <div className='currency-widget primary'>
                <div className='d-flex'>
                  <div>
                    <H6>
                      {item.name}
                    </H6>
                  </div>
                </div>
              </div>
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
