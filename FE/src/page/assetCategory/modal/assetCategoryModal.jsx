import { WarningOutlined } from "@ant-design/icons";
import { Form, Input, Modal } from "antd";
import React, { useEffect, useState } from "react";

const AssetCategoryModal = ({ type, assetCategory, visible, onClose, onSubmit, loading }) => {
    const { confirm } = Modal;
    const [form] = Form.useForm();

    useEffect(() => {
        form.resetFields();
        if (assetCategory) {
            form.setFieldsValue(assetCategory);
        }
    }, [visible, form, assetCategory]);

    const handleSubmit = () => {
        confirm({
            icon: <WarningOutlined />,
            content: `Do you want to ${type} this category ?`,
            onOk() {
                // console.log(form.getFieldsValue());
                onSubmit(form.getFieldsValue());
            },
            onCancel() {
                onClose();
                form.resetFields();
            }
        })
    }

    return (
        <>
            <Modal title={type === "edit" ? "Edit Category" : "Add Category"}
                open={visible}
                onOk={handleSubmit}
                onCancel={onClose}
                confirmLoading={loading}>
                <Form form={form} layout="vertical">
                    {assetCategory.id ? (
                        <Form.Item label="Id" name="id" hidden={true}>
                            <Input hidden={true} />
                        </Form.Item>) : ""}
                    <Form.Item
                        label="Name"
                        name="name"
                        rules={[{ required: true, message: "Input category name" }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Description"
                        name="description">
                        <Input />
                    </Form.Item>
                </Form>
            </Modal>
        </>
    );
}

export default AssetCategoryModal;