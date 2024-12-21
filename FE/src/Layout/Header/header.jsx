import { Menu, Layout, Dropdown, Avatar } from "antd";
import "./header.scss";
import logo from "../../assets/images/logo/logo.png";
import { UserOutlined, LogoutOutlined, SettingOutlined } from '@ant-design/icons';

const { Header } = Layout;

const AppHeader = () => {
    const items1 = ['1', '2', '3'].map((key) => ({
        key,
        label: `nav ${key}`,
    }));

    const userMenuItems = [
        {
            key: 'profile',
            label: 'Profile',
            icon: <UserOutlined />,
        },
        {
            key: 'settings',
            label: 'Settings',
            icon: <SettingOutlined />,
        },
        {
            type: 'divider', // Adds a divider line
        },
        {
            key: 'logout',
            label: 'Logout',
            icon: <LogoutOutlined />,
            // onClick: handleLogout,
        },
    ];

    return (
        <>
            <Header className="header-bg-color" style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '0 20px', background: '#fff', boxShadow: '0 2px 8px #f0f1f2' }}>
                <img src={logo} />
                <Dropdown menu={{
                    items: userMenuItems
                }}
                    trigger={['hover']}>
                    <div style={{ cursor: 'pointer', display: 'flex', alignItems: 'center' }}>
                        <Avatar style={{ backgroundColor: '#87d068' }} icon={<UserOutlined />} />
                    </div>
                </Dropdown>
            </Header>
        </>
    )
}

export default AppHeader;