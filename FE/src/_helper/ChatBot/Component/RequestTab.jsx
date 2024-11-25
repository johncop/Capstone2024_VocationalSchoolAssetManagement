import React from 'react';
import { TabContent, Table, TabPane } from 'reactstrap';
import { Image, H6 } from '../../../AbstractElements';
import SvgIcon from '../../../Components/Common/Component/SvgIcon';
const RequestTab = ({ assets, isActive, show }) => {
  return (
    <TabContent activeTab={isActive}>
      {assets.asset_category.map((category, i) => {
        return (
          <TabPane key={i} className={`fade ${isActive === `${i}` ? show : ''}`} tabId={`${i}`}>
            <div className='recent-table table-responsive'>
              <Table>
                <thead>
                  <tr>
                    <th className='f-light'>Item</th>
                    <th className='f-light'>Serial</th>
                    <th className='f-light'>Category</th>
                    <th className='f-light'>Status</th>
                    <th className='f-light'>Condition</th>
                  </tr>
                </thead>
                <tbody>
                  {assets.data.map((item, j) => {
                    if (item.assetType.category.name == category.name) {
                      return (
                        <tr key={j}>
                          <td>
                            <div className='product-content'>
                              <div className='order-image'>
                                {item.assetImages.length > 0 ?
                                  // <Image attrImage={{ src: item.assetImages[0].url, alt: '' }} />
                                  <img src={item.assetImages[0].url} style={{height:40, width:40}} />
                                  :
                                  <Image attrImage={{ src: require(`../../../assets/images/dashboard-2/order/sub-product/10.png`), alt: 't-shirt' }} />
                                }
                                
                              </div>
                              <div>
                                <H6 attrH6={{ className: 'f-14 mb-0' }}>
                                  {item.title}
                                </H6>
                                <span className='f-light f-12'>{item.name}</span>
                              </div>
                            </div>
                          </td>
                          <td className='f-w-500'>{item.serialNumber}</td>
                          <td className='f-w-500'>${item.assetType.category.name}</td>
                          <td className='f-w-500'>
                          {item.status == '1'? 
                            <div className='recent-status font-success'>
                              <SvgIcon iconId='24-hour' className='me-1' />
                            Approved
                            </div>
                            : 
                            <div className='recent-status font-danger'>
                              <SvgIcon iconId='24-hour' className='me-1' />
                              Rejected
                            </div> }                       
                          </td>
                          <td className='f-w-500'>${item.condition}</td>
                        </tr>
                        )    
                  }
                  })}
                </tbody>
              </Table>
            </div>
          </TabPane>
        );
      })}
    </TabContent>
  );
};

export default RequestTab;
