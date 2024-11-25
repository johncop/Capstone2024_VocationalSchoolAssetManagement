import React from 'react';
import { H6, H5 } from '../../../AbstractElements';
import SvgIcon from '../../../Components/Common/Component/SvgIcon';

const TabWidget = ({ data }) => {
  return (
    <div className='currency-widget primary'>
      <div className='d-flex'>
        <div className='currency-icon-widget'>
          <SvgIcon iconId='category' />
        </div>
        <div>
          <H6>
            {data.name}
          </H6>
        </div>
      </div>
    </div>
  );
};

export default TabWidget;
