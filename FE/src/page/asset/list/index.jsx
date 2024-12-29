import React, { useEffect, useState } from "react";
import { Button, Flex, Space, Table, message } from "antd";
import { Link } from "react-router-dom";
import { DeleteOutlined, EditOutlined, PlusOutlined } from "@ant-design/icons";
import { baseApi } from "../../../api/axiosInstance";
import ButtonConfirm from "../../../component/button/buttonConfirm";

const AssetList = () => {


    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(false);

    //State of modal
    const [openModal, setOpenModal] = useState(false);
    const [modalType, setModalType] = useState("");
    const [category, setCategory] = useState({});
    const [submitting, setSubmitting] = useState(false);

    //Other
    const [messageApi, contextHolder] = message.useMessage();

    useEffect(() => {
        fetchCategories();
    }, []);

    const fetchCategories = () => {
        setLoading(true);
        baseApi.get("/category").then(response => {
            if (response.data) {
                setCategories(response.data);
                setLoading(false);
            }
        })
    }

    const onOpenEditModal = (selectedCategory) => {
        setCategory(selectedCategory);
        setModalType("edit");
        setOpenModal(true);
    }

    const onOpenCreateModal = () => {
        setModalType("create");
        setOpenModal(true);
        setCategory({});
    }

    const { Column } = Table;
    return (
        <>
        <Flex justify="flex-end" style={{
            marginBottom: "10px"
        }}>
            <Button icon={<PlusOutlined />}type="primary">Create New</Button>
        </Flex>


        {/* <Table dataSource={{}} loading={{}}> */}
        <Table>
            <Column title="Id" dataIndex="id" key="id" />
            <Column title="Asset Name" dataIndex="asset-name" key="asset-name" render={(text) => {
                return (
                    <Link to={""}>{text}</Link>
                )
            }} />
            <Column title="Description" dataIndex="description" key="description" />
            <Column title="Serial Number" dataIndex="serial-number" key="serial-number" />
            <Column title="Status" dataIndex="status" key="status" />
            <Column title="Create Date" dataIndex="create-date" key="create-date" />
            <Column title="Update Date" dataIndex="update-date" key="update-date" />
            <Column title="Department" dataIndex="department" key="Department" />
            <Column title="Location" dataIndex="location" key="location" />
            <Column title="Action" key="action" render={(_, record) => (
                <Space size="middle">
                    <Button type="primary" icon={<EditOutlined />} onClick={() => onOpenEditModal(record)}  key="edit" />
                    <ButtonConfirm title="Delete category" description="Do you want delete this category ?"  icon={<DeleteOutlined />} />
                </Space>)} />
        </Table>

        <AssetModal type={modalType} visible={openModal} onClose={() => setOpenModal(false)} assetCategory={category} onSubmit={handleSubmit} loading={submitting} />

    </>
    );
}

export default AssetList;