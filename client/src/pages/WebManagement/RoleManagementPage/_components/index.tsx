import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from '@mui/material';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Button } from 'antd';

const columns: GridColDef[] = [
  //   { field: 'roleId', headerName: 'roleID', flex: 1 },
  { field: 'roleName', headerName: 'Tên quyền', flex: 2 },
  { field: 'roleCode', headerName: 'Code quyền', flex: 3 }
];

const rows = [
  {
    roleId: 'c6103b6d-56a3-4d71-b3fc-2af73574f4f9',
    roleName: 'Subject Teacher',
    roleCode: 'SUBJECT_TEACHER'
  },
  {
    roleId: 'ec8a6e55-c91f-4b62-aefd-2f842f987234',
    roleName: 'Student',
    roleCode: 'STUDENT'
  },
  {
    roleId: 'd3f2e7aa-f5ea-4cb6-80af-3ec43c0476b4',
    roleName: 'Home Room Teacher',
    roleCode: 'HOME_ROOM_TEACHER'
  },
  {
    roleId: 'd5172e0f-3e4a-4c3d-a1af-bd35fef62a6b',
    roleName: 'Admin',
    roleCode: 'ADMIN'
  },
  {
    roleId: 'b414993f-4840-4e4a-b9e7-d73126067e88',
    roleName: 'Super Admin',
    roleCode: 'SUPER_ADMIN'
  },
  {
    roleId: '5e2d7a2d-3e4e-43d6-b2ff-dfe5e2a8f7b3',
    roleName: 'Attendance Student',
    roleCode: 'ATTENDANCE_STUDENT'
  }
];

const paginationModel = { page: 0, pageSize: 5 };

const RoleList = () => {
  return (
    <>
      <div className='d-flex justify-content-end mb-3'>
        <Button
          type='dashed'
          disabled
        >
          Thêm Quyền
        </Button>
      </div>
      <Paper sx={{ height: 400, width: '100%' }}>
        <DataGrid
          rows={rows}
          columns={columns}
          initialState={{ pagination: { paginationModel } }}
          pageSizeOptions={[5, 10]}
          //   checkboxSelection
          sx={{ border: 0 }}
          getRowId={row => row.roleId}
        />
      </Paper>
    </>
  );
};

export default RoleList;
