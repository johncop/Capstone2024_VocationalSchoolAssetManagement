import { Layout, Space } from "antd";
import AppHeader from "./header/header";
import AppSidebar from "./sidebar/sidebar";
import { Outlet } from "react-router-dom";
import "./layout.scss";

const { Content } = Layout;
const AppLayout = () => {
    return (
        <>
            <Layout style={{ minWidth: "100vw", minHeight: "100vh" }}>
                <AppHeader />
                <Layout>
                    <AppSidebar />
                    <Layout>
                        <Content>
                            <div className="page-body">
                                <Outlet />
                            </div>
                        </Content>
                    </Layout>
                </Layout>
            </Layout>
        </>
    );
}

export default AppLayout;