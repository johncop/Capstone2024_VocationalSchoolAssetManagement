import { DeleteOutlined, EditOutlined, SearchOutlined } from "@ant-design/icons";
import { Button, Tag } from "antd";

export const AssetListCols = [
    {
        title: 'Id',
        dataIndex: 'id',
        key: 'id'
    },
    {
        title: 'Name',
        dataIndex: 'name',
        key: 'name',
        render: (text) => <a>{text}</a>,
    },
    {
        title: 'Serial Number',
        dataIndex: 'serialNumber',
        key: 'serialNumber'
    },
    {
        title: 'Status',
        dataIndex: 'status',
        key: 'status',
        render: (text) => {
            let color = "";
            switch (text) {
                case "available":
                case "pending-approval":
                    color = "success";
                    break;
                case "in-use":
                    color = "processing";
                    break;
                case "lost":
                    color = "error";
                    break;
                case "inactive":
                case "maintenance":
                case "expired":
                    color = "warning";
                    break;
            }

            return (
                <Tag color={color} key={text}>
                    {text.toUpperCase()}
                </Tag>
            )
        },
    },
    {
        title: 'Condition',
        dataIndex: 'condition',
        key: 'condition'
    },
    {
        title: 'Action',
        key: 'action',
        render: (_, record) => (
            <Space size="middle">
                <Button icon={<EditOutlined />} />
                <Button icon={<DeleteOutlined />} />
            </Space>
        ),
    },
]