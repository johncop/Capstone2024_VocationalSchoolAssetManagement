import React from 'react'
import { Button, Flex, Space, Table, message } from "antd";
import { Link } from "react-router-dom";
import { DeleteOutlined, EditOutlined, PlusOutlined } from "@ant-design/icons";
import { baseApi } from "../../../api/axiosInstance";
import ButtonConfirm from "../../../component/button/buttonConfirm";

function Request() {
    const { Column } = Table;
  return (
    <>
    <Flex justify="flex-end" style={{
        marginBottom: "10px"
    }}>
        <Button icon={<PlusOutlined />}  type="primary">Create New</Button>
    </Flex>


    <Table>
        <Column title="Id" dataIndex="id" key="id" />
        <Column title="Request Type" dataIndex="request-type" key="request-type" render={(text) => {
            return (
                <Link to={""}>{text}</Link>
            )
        }} />
        <Column title="Request Code" dataIndex="request-code" key="request-code" />
        <Column title="Request Date" dataIndex="request-date" key="request-date" />
        <Column title="Status" dataIndex="update-date" key="update-date" />    
        <Column title="Description" dataIndex="description" key="description" />
        <Column title="Create Date" dataIndex="create-date" key="create-date" />
        <Column title="Update Date" dataIndex="update-date" key="create-date" />
        <Column title="Action" key="action" render={(_, record) => (
            <Space size="middle">
                <Button type="primary" icon={<EditOutlined />}key="edit" />
                <ButtonConfirm title="Delete category" description="Do you want delete this category ?"  />
            </Space>)} />
    </Table>
</>
  )
}

export default Request
