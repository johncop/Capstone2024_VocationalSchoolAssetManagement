import { DatabaseOutlined, DesktopOutlined, HddOutlined, ProductOutlined, TagOutlined, SnippetsOutlined } from "@ant-design/icons";
import React from "react";
import { Link } from "react-router-dom";

export const MenuItems = [
    {
        key: 'sub1',
        label: 'Asset',
        icon: React.createElement(ProductOutlined),
        children: [
            {

                key: 'g1',
                label: <Link>Create New</Link>,

            },
            {
                key: 'g2',
                label: <Link to={"assets"}>All</Link>,
            },
        ],
    },
    {
        key: 'sub2',
        label: <Link to={"asset-categories"}>Asset Category</Link>,
        icon: React.createElement(DesktopOutlined),
    },
    {
        key: 'sub3',
        label: 'Asset Type',
        icon: React.createElement(TagOutlined),
        children: [
            {

                key: 'g5',
                label: 'Create New',
            },
            {
                key: 'g6',
                label: 'All',
            },
        ],
    },
    {
        key: 'sub4',
        label: 'Request',
        icon: React.createElement(DatabaseOutlined),
        children: [
            {
                key: 'g7',
                label: 'Create New',
            },
            {
                key: 'g8',
                label: 'All',
            },
        ],
    },
    {
        key: 'sub5',
        label: <Link to={"maintaince-record"}>Maintaince Record</Link>,
        icon: React.createElement(DatabaseOutlined),
        children: [
            {

                key: 'g9',
                label: 'Create New',
            },
            {
                key: 'g10',
                label: 'All',
            },
        ],
    },
    {
        key: 'sub6',
        label: <Link to={"transaction-record"}>Transaction Record</Link>,
        icon: React.createElement(SnippetsOutlined),
        children: [
            {

                key: 'g11',
                label: 'Create New',
            },
            {
                key: 'g12',
                label: 'All',
            },
        ],
    },
];