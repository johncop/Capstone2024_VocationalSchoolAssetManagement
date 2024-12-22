import React, { useEffect, useState } from "react";
import { Button, Flex, Space, Table, message } from "antd";
import { Link } from "react-router-dom";
import { DeleteOutlined, EditOutlined, PlusOutlined } from "@ant-design/icons";
import { baseApi } from "../../../api/axiosInstance";
import AssetCategoryModal from "../modal/assetCategoryModal";
import ButtonConfirm from "../../../component/button/buttonConfirm";

const AssetCategories = () => {
    //State of list
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(false);

    //State of modal
    const [openModal, setOpenModal] = useState(false);
    const [modalType, setModalType] = useState("");
    const [category, setCategory] = useState({});
    const [submitting, setSubmitting] = useState(false);
    const { Column } = Table;

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

    const handleSubmit = (values) => {
        setSubmitting(true);
        try {
            if (values.id) {
                baseApi.put(`/category/${values.id}`, JSON.stringify(values)).then(response => {
                    if (response.statusCode === 200) {
                        setSubmitting(false);
                        setOpenModal(false);
                        fetchCategories();
                        message.open({
                            type: "success",
                            content: "Update category success"
                        });
                    }
                })
            } else {
                baseApi.post("/category", JSON.stringify(values)).then(response => {
                    if (response.statusCode === 200) {
                        setSubmitting(false);
                        setOpenModal(false);
                        fetchCategories();
                        message.open({
                            type: "success",
                            content: "Create category success"
                        });
                    }
                })
            }
        } catch (ex) {
            message.open({
                type: "error",
                content: "Something wrong"
            });
        }
    }

    const handleDelete = (recordId) => {
        try {
            baseApi.delete(`/category/${recordId}`).then(response => {
                if (response.statusCode === 200) {
                    fetchCategories();
                    message.open({
                        type: "success",
                        content: "Delete category success"
                    });
                }
            })
        } catch (ex) {
            message.open({
                type: "error",
                content: "Something wrong"
            })
        }
    }

    return (
        <>
            <Flex justify="flex-end" style={{
                marginBottom: "10px"
            }}>
                <Button icon={<PlusOutlined />} onClick={onOpenCreateModal} type="primary">Create New</Button>
            </Flex>


            <Table dataSource={categories} loading={loading}>
                <Column title="Id" dataIndex="id" key="id" />
                <Column title="Name" dataIndex="name" key="name" render={(text) => {
                    return (
                        <Link to={""}>{text}</Link>
                    )
                }} />
                <Column title="Description" dataIndex="description" key="description" />
                <Column title="Action" key="action" render={(_, record) => (
                    <Space size="middle">
                        <Button type="primary" icon={<EditOutlined />} onClick={() => onOpenEditModal(record)} key="edit" />
                        <ButtonConfirm title="Delete category" description="Do you want delete this category ?" onConfirm={() => handleDelete(record.id)} icon={<DeleteOutlined />} />
                    </Space>)} />
            </Table>

            <AssetCategoryModal type={modalType} visible={openModal} onClose={() => setOpenModal(false)} assetCategory={category} onSubmit={handleSubmit} loading={submitting} />
        </>
    )
}

export default AssetCategories;