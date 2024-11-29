export const MENUITEMS = [
  {
    menutitle: 'General',
    menucontent: 'Dashboards,Widgets',
    Items: [
      {
        title: 'Dashboard',
        icon: 'home',
        type: 'sub',
        badge: 'badge badge-light-primary',
        badgetxt: '5',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/dashboard/default`, title: 'Default', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/dashboard/e-commerce`, title: 'E-commerce', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/dashboard/online-course`, title: 'Online Course', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/dashboard/crypto`, title: 'Crypto', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/dashboard/social`, title: 'Social', type: 'link' },
        ],
      },

      {
        title: 'Widgets',
        icon: 'widget',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/widgets/general`, title: 'General', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/widgets/chart`, title: 'Chart', type: 'link' },
        ],
      },
    ],
  },

  {
    menutitle: 'Applications',
    menucontent: 'Ready to use Apps',
    Items: [
      {
        title: 'Asset',
        icon: 'project',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/asset/asset-list`, type: 'link', title: 'Asset-List' },
          { path: `${process.env.PUBLIC_URL}/app/asset/new-asset`, type: 'link', title: 'Create New' },
        ],
      },
      {
        title: 'Mangement',
        icon: 'project',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/manage/home`, type: 'link', title: 'Home' },
        ],
      },
      {
        title: 'Project',
        icon: 'project',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/project/project-list`, type: 'link', title: 'Project-List' },
          { path: `${process.env.PUBLIC_URL}/app/project/new-project`, type: 'link', title: 'Create New' },
        ],
      },
      {
        title: 'Ecommerce',
        icon: 'ecommerce',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/product`, title: 'Products', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-page/1`, title: 'Product-Page', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/product-list`, title: 'Product-List', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/payment-details`, title: 'Payment-Detail', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/orderhistory`, title: 'OrderHistory', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/invoice`, title: 'Invoice', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/cart`, title: 'Cart', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/wishlist`, title: 'Wishlist', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/checkout`, title: 'checkout', type: 'link' },
          { path: `${process.env.PUBLIC_URL}/app/ecommerce/pricing`, title: 'Pricing', type: 'link' },
        ],
      },
      { path: `${process.env.PUBLIC_URL}/app/email-app`, icon: 'email', title: 'Email', type: 'link' },
      {
        title: 'Chat',
        icon: 'chat',
        type: 'sub',
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/chat-app/chats`, type: 'link', title: 'Chats' },
          { path: `${process.env.PUBLIC_URL}/app/chat-app/chat-video-app`, type: 'link', title: 'Video-app' },
        ],
      },
      {
        title: 'Users',
        icon: 'user',
        path: `${process.env.PUBLIC_URL}/app/users/userProfile`,
        type: 'sub',
        bookmark: true,
        active: false,
        children: [
          { path: `${process.env.PUBLIC_URL}/app/users/profile`, type: 'link', title: 'User Profile' },
          { path: `${process.env.PUBLIC_URL}/app/users/edit`, type: 'link', title: 'User Edit' },
          { path: `${process.env.PUBLIC_URL}/app/users/cards`, type: 'link', title: 'User Cards' },
        ],
      },
    ],
  },
];
