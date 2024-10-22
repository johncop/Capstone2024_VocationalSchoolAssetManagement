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

export const routes = [
  //dashboard
  { path: `${process.env.PUBLIC_URL}/dashboard/default/:layout`, Component: <Default /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/e-commerce/:layout`, Component: <Ecommerce /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/online-course/:layout`, Component: <OnlineCourse /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/crypto/:layout`, Component: <Crypto /> },
  { path: `${process.env.PUBLIC_URL}/dashboard/social/:layout`, Component: <Social /> },

  // // //widgets
  { path: `${process.env.PUBLIC_URL}/widgets/general/:layout`, Component: <General /> },
  { path: `${process.env.PUBLIC_URL}/widgets/chart/:layout`, Component: <Chart /> },

  // // //Applicatiion
  { path: `${process.env.PUBLIC_URL}/app/project/project-list`, Component: <Project /> },
  { path: `${process.env.PUBLIC_URL}/app/project/new-project`, Component: <Newproject /> },
  // { path: `${process.env.PUBLIC_URL}/app/chat-app/chats/:layout`, Component: <Chat /> },
  // { path: `${process.env.PUBLIC_URL}/app/chat-app/chat-video-app/:layout`, Component: <VideoChat /> },
  // { path: `${process.env.PUBLIC_URL}/app/contact-app/contacts/:layout`, Component: <Contact /> },

  // { path: `${process.env.PUBLIC_URL}/app/task/:layout`, Component: <Task /> },
  // { path: `${process.env.PUBLIC_URL}/app/bookmark/:layout`, Component: <BookmarksContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/todo-app/todo/:layout`, Component: <TodoContain /> },

  // { path: `${process.env.PUBLIC_URL}/app/users/profile/:layout`, Component: <UsersProfileContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/users/edit/:layout`, Component: <UsersEditContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/users/cards/:layout`, Component: <UsersCardssContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/social-app/:layout`, Component: <SocialAppContain /> },

  // { path: `${process.env.PUBLIC_URL}/app/calendar/draggable-calendar/:layout`, Component: <DraggableContain /> },

  // { path: `${process.env.PUBLIC_URL}/app/email-app/:layout`, Component: <MailInboxContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/file-manager/:layout`, Component: <FileManagerContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/search/:layout`, Component: <SearchResultContain /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product/:layout`, Component: <Products /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-page/:layout/:id`, Component: <ProductPage /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/payment-details/:layout`, Component: <PaymentDetails /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/orderhistory/:layout`, Component: <OrderHistory /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/pricing/:layout`, Component: <PricingMemberShip /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/invoice/:layout`, Component: <Invoice /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/cart/:layout`, Component: <ProductCart /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/wishlist/:layout`, Component: <WishList /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/checkout/:layout`, Component: <CheckOut /> },
  { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-list/:layout`, Component: <ProductListContain /> },
  // { path: `${process.env.PUBLIC_URL}/app/kanban-board/:layout`, Component: <KanbanBoardContain /> },
];
