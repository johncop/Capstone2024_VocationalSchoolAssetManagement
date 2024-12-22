import React from 'react';
import { Spin, Typography } from 'antd';

const { Text } = Typography;

const LoadingPage = () => {
    return (
        <div
            style={{
                minHeight: '100vh',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                backgroundColor: '#f0f2f5',
                flexDirection: 'column',
            }}
        >
            <Spin size="large" />
            <Text style={{ marginTop: 20, fontSize: 16, color: '#595959' }}>
                Loading, please wait...
            </Text>
        </div>
    );
};

export default LoadingPage;