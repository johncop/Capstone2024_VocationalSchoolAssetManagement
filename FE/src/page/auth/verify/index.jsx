import { Button, Card, Form, Input } from "antd";
import React, { useState } from "react";
import "../login/login.scss"
import { useParams } from "react-router-dom";
import authApi from "../../../api/authApi";

const VerifyCodePage = () => {
    const [verify, setVerify] = useState(false);
    const { userId } = useParams();
    const onVerify = (formData) => {
        setVerify(true);
        authApi.verifyCode(userId, formData.code).then(response => {
            setVerify(false);
            if (response.accessToken) {
                sessionStorage.setItem("token", response.accessToken.token);
                window.location.href = "/";
            }
        })
    }
    return (
        <div className="login">
            <Card title="Verify Code" bordered={false} className="login-main">
                <Form layout="vertical" onFinish={onVerify}>
                    <Form.Item label="Code" name="code" rules={[{ required: true, message: "Please input your code" }]}>
                        <Input type="number" />
                    </Form.Item>
                    <Button type="primary" loading={verify} htmlType="submit">
                        {verify ? "Verifying...." : "Verify"}
                    </Button>
                </Form>
            </Card>
        </div>
    );
}

export default VerifyCodePage;