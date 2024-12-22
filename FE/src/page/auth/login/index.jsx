import { Button, Card, Form, Input } from "antd";
import { useState } from "react";
import "./login.scss";
import authApi from "../../../api/authApi";
import { LockOutlined, UserOutlined } from "@ant-design/icons";

const Login = () => {
    const [signing, setSigning] = useState(false);

    const login = (loginData) => {
        setSigning(true);
        authApi.login(loginData.email, loginData.password).then(response => {
            console.log(response);
            if (response.userId) {
                window.location.href = `/verify-code/${response.userId}`;
            }
        })
    }

    return (
        <div className="login">
            <Card title="Login"
                size="default"
                className="login-main">
                <Form
                    layout="vertical"
                    style={{
                        maxWidth: "100vw"
                    }}
                    autoCapitalize="off" onFinish={login}>

                    <Form.Item
                        label="Email"
                        name="email"
                        rules={[{ required: true, message: "Input your email" }]}>
                        <Input prefix={<UserOutlined />} />
                    </Form.Item>
                    <Form.Item
                        label="Password"
                        name="password"
                        rules={[{ required: true, message: "Input your password" }]}>
                        <Input.Password prefix={<LockOutlined />} />
                    </Form.Item>
                    <Button type="primary" htmlType="submit" loading={signing}>
                        {signing ? "Loading..." : "Login"}
                    </Button>
                </Form>
            </Card>

        </div>
    )
}
export default Login;