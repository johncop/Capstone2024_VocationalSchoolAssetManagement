import { Button, Popconfirm } from "antd";
import React from "react";

const ButtonConfirm = ({ title, description, onConfirm, onCancel, okText = "Yes", cancelText = "No", buttonText, icon }) => {
    return (
        <>
            <Popconfirm
                title={title}
                description={description}
                onConfirm={onConfirm}
                onCancel={onCancel}
                okText={okText}
                cancelText={cancelText}>
                <Button danger icon={icon}>{buttonText}</Button>
            </Popconfirm>
        </>
    );
}

export default ButtonConfirm;