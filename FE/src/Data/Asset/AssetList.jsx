export const assetColumns = [
    {
        name: 'Name',
        selector: (row) => row.name,
        sortable: true,
        minWidth: '100px'
    },
    {
        name: 'Serial Number',
        selector: (row) => row.serialNumber,
        sortable: true,
        center: true,
        wrap: true,
        minWidth: '100px',
        maxWidth: "160px"
    },
    {
        name: 'Condition',
        selector: (row) => row.condition,
        sortable: true,
        center: true,
        minWidth: '100px',
        maxWidth: '150px',
    },
    {
        name: 'Status',
        selector: (row) => row.status,
        sortable: true,
        center: true,
        minWidth: '120px',
        maxWidth: '150px',
    },
    {
        name: 'Description',
        selector: (row) => row.description,
        sortable: true,
        center: true,
        minWidth: '120px',
        maxWidth: '150px',
    },
    {
        name: 'Action',
        selector: (row) => row.action,
        sortable: true,
        center: true,
        minWidth: '160px',
    },
];