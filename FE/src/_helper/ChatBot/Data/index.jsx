import { useState } from "react";

// Recent Order Table //
export const MyRequestList = [
  [
    {
      image: '4.png',
      title: 'AMD Zyren 5000',
      id: '#CFDE-2163',
      qty: 'X1',
      status: 'Verified',
      statusCode: 'success',
      price: 56.0,
      total: 100.0,
      iconName: '24-hour',
    },
    {
      image: '3.png',
      title: 'Asus Thunder 3',
      id: '#CFDE-2780',
      qty: 'X2',
      status: 'Rejected',
      statusCode: 'danger',
      price: 156.0,
      total: 870.0,
      iconName: '24-hour',
    },
  ],
  [
    {
      image: '5.png',
      title: 'Playstation 5',
      id: '#CFDE-2163',
      qty: 'X1',
      status: 'Rejected',
      statusCode: 'danger',
      price: 56.0,
      total: 390.0,
      iconName: '24-hour',
    },
    {
      image: '6.png',
      title: 'Samsung Galaxy S23',
      id: '#CFDE-2780',
      qty: 'X2',
      status: 'Verified',
      statusCode: 'success',
      price: 100.0,
      total: 870.0,
      iconName: '24-hour',
    },
  ],
  [
    {
      image: '1.png',
      title: 'Sony Experia',
      id: '#CFDE-2163',
      qty: 'X1',
      status: 'Verified',
      statusCode: 'success',
      price: 56.0,
      total: 100.0,
      iconName: '24-hour',
    },
    {
      image: '2.png',
      title: 'Sennheiser',
      id: '#CFDE-2780',
      qty: 'X2',
      status: 'Rejected',
      statusCode: 'danger',
      price: 156.0,
      total: 100.0,
      iconName: '24-hour',
    },
  ],
  [
    {
      image: '7.png',
      title: 'Gaming Chair',
      id: '#CFDE-2163',
      qty: 'X1',
      status: 'Verified',
      statusCode: 'success',
      price: 48.0,
      total: 50.0,
      iconName: '24-hour',
    },
    {
      image: '8.png',
      title: 'Office 365',
      id: '#CFDE-2780',
      qty: 'X2',
      status: 'Rejected',
      statusCode: 'danger',
      price: 73.0,
      total: 75.0,
      iconName: '24-hour',
    },
  ],
  [
    {
      image: '9.png',
      title: 'Lamp',
      id: '#CFDE-2163',
      qty: 'X1',
      status: 'Verified',
      statusCode: 'success',
      price: 20.0,
      total: 25.0,
      iconName: '24-hour',
    },
    {
      image: '10.png',
      title: 'Bedside lamp',
      id: '#CFDE-2780',
      qty: 'X2',
      status: 'Rejected',
      statusCode: 'danger',
      price: 70.0,
      total: 88.0,
      iconName: '24-hour',
    },
  ],
];

export const ExpiredRequestListData = [
  {
    title: 'Asus Rock',
    image: '4.jpg',
    icon: 'bag',
    icon2: 'clock',
    date: 'January 3, 2022',
    date2: '09.00 - 12.00 AM',
    color: 'primary',
  },
  {
    title: 'Nvidia RTX 4070',
    image: '2.jpg',
    icon: 'bag',
    icon2: 'clock',
    date: 'Febuary 10, 2022',
    date2: '11.00 - 1.00 PM',
    color: 'warning',
  },
];

async function fetchData(params) {
  try {
    const response = await fetch('https://assetmanagement-dmd5bng3bcffdpab.southeastasia-01.azurewebsites.net/api/asset', {
      method: "GET",
      headers: {
        "Accept": "application/json"
      }
    })
    const result = await response.json(); 
    
    result.asset_category = [];
 
    result.data.map((item) => {
      result.asset_category.push({name: item.assetType.category.name})
    });

    const countsByName = {};
    result.asset_category.forEach(({ name }) => {
      countsByName[name] = (countsByName[name] || 0) + 1;
    });
    const finalArray = Object.entries(countsByName)
      .map(([name, count]) => ({ name, count }))

    result.asset_category = finalArray;
    return result;
  } catch (error) {
    return [];
  }
}

export const assets = await fetchData('');




