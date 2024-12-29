import React, { useEffect, useState } from "react";
import { Button, Flex, Space, Table, message } from "antd";
import { Link } from "react-router-dom";
import { DeleteOutlined, EditOutlined, PlusOutlined } from "@ant-design/icons";
import { baseApi } from "../../../api/axiosInstance";
import ButtonConfirm from "../../../component/button/buttonConfirm";

function TransactionRecord() {
    const { Column } = Table;
  return (
    <div>
        <>
            <Flex justify="flex-end" style={{
                marginBottom: "10px"
            }}>
                <Button icon={<PlusOutlined />}  type="primary">Create New</Button>
            </Flex>

            <Table>
                <Column title="Id" dataIndex="id" key="id" />
                <Column title="Name" dataIndex="name" key="name" render={(text) => {
                    return (
                        <Link to={""}>{text}</Link>
                    )
                }} />
                <Column title="Transaction Date" dataIndex="transaction-date" key="maintaince-date" />
                <Column title="Description" dataIndex="description" key="description" />
                <Column title="Last Location" dataIndex="last-location" key="last-location" />
                <Column title="New Location" dataIndex="new-location" key="new-location" />    
                <Column title="Create Date" dataIndex="create-date" key="create-date" />    
                <Column title="Update Date" dataIndex="update-date" key="update-date" />    
                <Column title="Action" key="action" render={(_, record) => (
                    <Space size="middle">
                        <Button type="primary" icon={<EditOutlined />}key="edit" />
                        <ButtonConfirm title="Delete category" description="Do you want delete this category ?"  />
                    </Space>)} />
            </Table>
        </>
    </div>
  )
}

export default TransactionRecord
