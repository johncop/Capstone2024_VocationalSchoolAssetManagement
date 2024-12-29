import React from "react";
import { Menu, Layout } from "antd";
import { LaptopOutlined, NotificationOutlined, UserOutlined } from '@ant-design/icons';
import { MenuItems } from "./menu";
const { Sider } = Layout;
const AppSidebar = () => {
    const items2 = [UserOutlined, LaptopOutlined, NotificationOutlined].map((icon, index) => {
        const key = String(index + 1);
        return {
            key: `sub${key}`,
            icon: React.createElement(icon),
            label: `subnav ${key}`,
            children: new Array(4).fill(null).map((_, j) => {
                const subKey = index * 4 + j + 1;
                return {
                    key: subKey,
                    label: `option${subKey}`,
                };
            }),
        };
    });

    return (
        <>
            <Sider width={200} theme="light">
                <Menu mode="inline" items={MenuItems} />
            </Sider>
        </>
    )
}

export default AppSidebar;