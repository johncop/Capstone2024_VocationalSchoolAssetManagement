// dashbaord
import Crypto from '../Components/Dashboard/Crypto';
import Default from '../Components/Dashboard/Default';
import Ecommerce from '../Components/Dashboard/Ecommerce';
import OnlineCourse from '../Components/Dashboard/OnlineCourse';
import Social from '../Components/Dashboard/Social';

// //widgets
import Chart from '../Components/Widgets/Chart';
import General from '../Components/Widgets/General';

//Application
import Products from '../Components/Application/Ecommerce/Products';
import ProductCart from '../Components/Application/Ecommerce/ProductCart';
import WishList from '../Components/Application/Ecommerce/Wishlist';
import CheckOut from '../Components/Application/Ecommerce/CheckOut';
import Invoice from '../Components/Application/Ecommerce/Invoice';
import OrderHistory from '../Components/Application/Ecommerce/OrderHistory';
import ProductPage from '../Components/Application/Ecommerce/ProductPage';
import PricingMemberShip from '../Components/Application/Ecommerce/PricingMemberShip';
import PaymentDetails from '../Components/Application/Ecommerce/PaymentDetails';
import ProductListContain from '../Components/Application/Ecommerce/ProductList';
import Project from '../Components/Application/Project/Project';
import Newproject from '../Components/Application/Project/Newproject';
import AssetList from '../Components/Application/Asset/AssetList';
import NewAsset from '../Components/Application/Asset/NewAsset';
import Manager from '../Components/Application/Manager'

export const routes = [
  //dashboard
  { path: `${process.env.PUBLIC_URL}/dashboard/default`, Component: <Default /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/e-commerce/`, Component: <Ecommerce /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/online-course/`, Component: <OnlineCourse /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/crypto/`, Component: <Crypto /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/social/`, Component: <Social /> },

  // // //widgets
  { path: `${process.env.PUBLIC_URL}/widgets/general/`, Component: <General /> },
  { path: `${process.env.PUBLIC_URL}/widgets/chart/`, Component: <Chart /> },

  // // //Applicatiion
  { path: `${process.env.PUBLIC_URL}/app/project/project-list`, Component: <Project /> },
  { path: `${process.env.PUBLIC_URL}/app/project/new-project`, Component: <Newproject /> },
  { path: `${process.env.PUBLIC_URL}/app/asset/asset-list`, Component: <AssetList /> },
  { path: `${process.env.PUBLIC_URL}/app/asset/new-asset`, Component: <NewAsset /> },
  { path: `${process.env.PUBLIC_URL}/app/manage/home`, Component: <Manager /> },

  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product/`, Component: <Products /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-page//:id`, Component: <ProductPage /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/payment-details/`, Component: <PaymentDetails /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/orderhistory/`, Component: <OrderHistory /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/pricing/`, Component: <PricingMemberShip /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/invoice/`, Component: <Invoice /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/cart/`, Component: <ProductCart /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/wishlist/`, Component: <WishList /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/checkout/`, Component: <CheckOut /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-list/`, Component: <ProductListContain /> }
];
