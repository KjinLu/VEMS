import { DeleteOutlined, EditOutlined } from '@mui/icons-material';
import {
  Chip,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from '@mui/material';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Button, Dropdown, MenuProps, Modal, Space, Tag } from 'antd';
import { EllipsisOutlined } from '@ant-design/icons';

const columns: GridColDef[] = [
  { field: 'id', headerName: 'STT', flex: 1 },
  { field: 'fullName', headerName: 'Họ và tên', flex: 2 },
  { field: 'username', headerName: 'Tên đăng nhập', flex: 2 },
  {
    field: 'roles',
    headerName: 'Quyền',
    flex: 3,
    renderCell: params => (
      <>
        {params.row.roles.map((role: any, index: number) => (
          <Tag
            key={index}
            color={getRoleColor(role.roleCode)}
          >
            {role.roleName}
          </Tag>
        ))}
      </>
    )
  },
  {
    field: 'operation',
    headerName: '',
    flex: 1,
    renderCell: params => {
      const renderItems = (
        id: string,
        onRemove: () => void,
        onDisable: () => void,
        onUpdate: () => void
      ): MenuProps['items'] => {
        return [
          {
            label: (
              <a
                onClick={() => {
                  onUpdate?.();
                }}
              >
                <Space>
                  <EditOutlined /> Cập nhật
                </Space>
              </a>
            ),
            key: '0'
          },
          {
            type: 'divider'
          },
          {
            label: (
              <a
                onClick={() => {
                  Modal.confirm({
                    title: 'Xác nhận xóa tài khoản',
                    centered: true,
                    width: '500px',
                    onOk: () => {
                      onRemove?.();
                    },
                    footer: (_, { OkBtn, CancelBtn }) => (
                      <>
                        <CancelBtn />
                        <OkBtn />
                      </>
                    )
                  });
                }}
              >
                <Space>
                  <DeleteOutlined /> Xóa
                </Space>
              </a>
            ),
            key: '2'
          }
        ];
      };
      return (
        <>
          <Dropdown
            menu={{
              items: renderItems(
                params.row.id,
                () => {
                  console.log('delete');
                },
                () => {
                  console.log('disable');
                },
                () => {
                  console.log('update');
                }
              )
            }}
          >
            <a onClick={e => e.preventDefault()}>
              <Space>
                <Button
                  type='text'
                  icon={<EllipsisOutlined />}
                ></Button>
              </Space>
            </a>
          </Dropdown>
        </>
      );
    }
  }
];

const getRoleColor = (roleCode: any) => {
  switch (roleCode) {
    case 'SUPER_ADMIN':
      return 'magenta';
    case 'ADMIN':
      return 'volcano';
    case 'HOME_ROOM_TEACHER':
      return 'gold';
    case 'SUBJECT_TEACHER':
      return 'lime';
    case 'STUDENT':
      return 'cyan';
    case 'ATTENDANCE_STUDENT':
      return 'geekblue';
    default:
      return 'pink';
  }
};

const rows = [
  {
    accountId: '11111111-1111-1111-1111-111111111111',
    fullName: 'Alice Super Admin',
    username: 'alice_admin',
    roles: [
      {
        roleId: 'd3f2e7aa-f5ea-4cb6-80af-3ec43c0476b4',
        roleName: 'Home Room Teacher',
        roleCode: 'HOME_ROOM_TEACHER'
      },
      {
        roleId: 'b414993f-4840-4e4a-b9e7-d73126067e88',
        roleName: 'Super Admin',
        roleCode: 'SUPER_ADMIN'
      }
    ],
    permissions: [
      {
        permissionId: 'a2f08a17-07f6-46b6-8e8a-1df7b6e2f62b',
        permissionName: 'Manage Attendance',
        permissionCode: 'MANAGE_ATTENDANCE'
      },
      {
        permissionId: 'cc98bfe6-88c9-4625-90fc-6e5a7e212c4e',
        permissionName: 'Access Parent Communication',
        permissionCode: 'ACCESS_PARENT_COMMUNICATION'
      },
      {
        permissionId: '0c7fa70b-d2f2-4cdd-b6e3-d1b212e40d41',
        permissionName: 'Access Student Records',
        permissionCode: 'ACCESS_STUDENT_RECORDS'
      },
      {
        permissionId: 'bb8b8422-7458-4d15-8122-9580d1f4bc53',
        permissionName: 'Manage Grades',
        permissionCode: 'MANAGE_GRADES'
      },
      {
        permissionId: 'f1a0f857-0123-4ec5-9b0f-e723adcfb713',
        permissionName: 'Manage Users',
        permissionCode: 'MANAGE_USERS'
      }
    ]
  },
  {
    accountId: '22222222-2222-2222-2222-222222222222',
    fullName: 'Bob Admin',
    username: 'bob_admin',
    roles: [
      {
        roleId: 'd5172e0f-3e4a-4c3d-a1af-bd35fef62a6b',
        roleName: 'Admin',
        roleCode: 'ADMIN'
      }
    ],
    permissions: [
      {
        permissionId: 'cc98bfe6-88c9-4625-90fc-6e5a7e212c4e',
        permissionName: 'Access Parent Communication',
        permissionCode: 'ACCESS_PARENT_COMMUNICATION'
      }
    ]
  },
  {
    accountId: '33333333-3333-3333-3333-333333333333',
    fullName: 'Charlie Teacher',
    username: 'charlie_teacher',
    roles: [
      {
        roleId: 'c6103b6d-56a3-4d71-b3fc-2af73574f4f9',
        roleName: 'Subject Teacher',
        roleCode: 'SUBJECT_TEACHER'
      }
    ],
    permissions: [
      {
        permissionId: 'bb8b8422-7458-4d15-8122-9580d1f4bc53',
        permissionName: 'Manage Grades',
        permissionCode: 'MANAGE_GRADES'
      },
      {
        permissionId: '0c7fa70b-d2f2-4cdd-b6e3-d1b212e40d41',
        permissionName: 'Access Student Records',
        permissionCode: 'ACCESS_STUDENT_RECORDS'
      },
      {
        permissionId: 'aa9c1c30-efb1-4bf8-bb77-ef833206ff8f',
        permissionName: 'Create and Edit Courses',
        permissionCode: 'CREATE_EDIT_COURSES'
      }
    ]
  },
  {
    accountId: '44444444-4444-4444-4444-444444444444',
    fullName: 'David Home Room',
    username: 'david_homeroom',
    roles: [
      {
        roleId: 'd3f2e7aa-f5ea-4cb6-80af-3ec43c0476b4',
        roleName: 'Home Room Teacher',
        roleCode: 'HOME_ROOM_TEACHER'
      }
    ],
    permissions: [
      {
        permissionId: 'a2f08a17-07f6-46b6-8e8a-1df7b6e2f62b',
        permissionName: 'Manage Attendance',
        permissionCode: 'MANAGE_ATTENDANCE'
      },
      {
        permissionId: 'cc98bfe6-88c9-4625-90fc-6e5a7e212c4e',
        permissionName: 'Access Parent Communication',
        permissionCode: 'ACCESS_PARENT_COMMUNICATION'
      },
      {
        permissionId: '0c7fa70b-d2f2-4cdd-b6e3-d1b212e40d41',
        permissionName: 'Access Student Records',
        permissionCode: 'ACCESS_STUDENT_RECORDS'
      }
    ]
  },
  {
    accountId: '55555555-5555-5555-5555-555555555555',
    fullName: 'Eve Attendance',
    username: 'eve_attendance',
    roles: [
      {
        roleId: '5e2d7a2d-3e4e-43d6-b2ff-dfe5e2a8f7b3',
        roleName: 'Attendance Student',
        roleCode: 'ATTENDANCE_STUDENT'
      }
    ],
    permissions: [
      {
        permissionId: 'e6b4c6ab-69a0-4b4f-b5a8-781bb04fcd6d',
        permissionName: 'View Reports',
        permissionCode: 'VIEW_REPORTS'
      },
      {
        permissionId: 'bb8b8422-7458-4d15-8122-9580d1f4bc53',
        permissionName: 'Manage Grades',
        permissionCode: 'MANAGE_GRADES'
      }
    ]
  },
  {
    accountId: '66666666-6666-6666-6666-666666666666',
    fullName: 'Frank Student',
    username: 'frank_student',
    roles: [
      {
        roleId: 'ec8a6e55-c91f-4b62-aefd-2f842f987234',
        roleName: 'Student',
        roleCode: 'STUDENT'
      }
    ],
    permissions: []
  }
];

const processedRows = rows.map((row, index) => ({
  id: `${index + 1}`,
  fullName: row.fullName,
  username: row.username,
  roles: row.roles
}));

const paginationModel = { page: 0, pageSize: 5 };

const AccountRole = () => {
  return (
    <>
      <div className='d-flex justify-content-end mb-3'>
        <Button type='primary'>Thêm tài khoản</Button>
      </div>
      <Paper sx={{ height: 400, width: '100%' }}>
        <DataGrid
          rows={processedRows}
          columns={columns}
          initialState={{ pagination: { paginationModel } }}
          pageSizeOptions={[5, 10]}
          //   checkboxSelection
          sx={{ border: 0 }}
          getRowId={row => row.id}
        />
      </Paper>
    </>
  );
};

export default AccountRole;
