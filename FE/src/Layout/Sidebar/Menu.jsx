import { DatabaseOutlined, DesktopOutlined, HomeOutlined, ProductOutlined, TagOutlined, SnippetsOutlined, CopyOutlined } from "@ant-design/icons";
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
        label: 'Asset Category',
        icon: React.createElement(DesktopOutlined),
        children: [
            {
                key: 'g3',
                label: 'Create New',
            },
            {
                key: 'g4',
                label: <Link to={"asset-categories"}>All</Link>,
            },
        ],
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
                label: <Link to={"assets-type"}>All</Link>,
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
                label: <Link to={"request"}>All</Link>,
            },
        ],
    },
    {
        key: 'sub5',
        label: 'Maintaince Record',
        icon: React.createElement(CopyOutlined),
        children: [
            {

                key: 'g9',
                label: 'Create New',
            },
            {
                key: 'g10',
                label: <Link to={"maintaince-record"}>All</Link>,
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
    {
        key: 'sub7',
        label: <Link to={"department"}>Department</Link>,
        icon: React.createElement(HomeOutlined),
        children: [
            {

                key: 'g11',
                label: 'Create New',
            },
            {
                key: 'g12',
                label: <Link to={"department"}>All</Link>,
            },
        ],
    },
];