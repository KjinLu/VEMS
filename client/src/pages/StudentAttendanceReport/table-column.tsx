// import { GridColDef } from '@mui/x-data-grid';
import {
  convertDayOfWeek,
  formatDate,
  isAttendanceDateInThePast
} from '@/utils/dateFormat';
import { Chip } from '@mui/material';
import VemButton from '@/components/VemButton';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import EditIcon from '@mui/icons-material/Edit';
import { GridColDef } from '@mui/x-data-grid';
import { AttendanceReportWithIndex } from './type';

export const attendanceReportColumn = (): GridColDef<AttendanceReportWithIndex>[] => [
  {
    field: 'index',
    headerName: 'STT',
    width: 70,
    filterable: false,
    hideable: false,
    align: 'left'
  },
  {
    field: 'periodName',
    headerName: 'Buổi',
    sortable: false,
    filterable: false,
    hideable: false,
    width: 200,

    renderCell: (params: any) => (
      <>
        {convertDayOfWeek(params.row.dayOfWeek)} - {params.row.periodName}
      </>
    )
  },
  {
    field: 'dateAttendance',
    headerName: 'Ngày điểm danh',
    width: 150,
    hideable: false,
    sortable: false,
    filterable: false,
    valueGetter: row => formatDate(row)
  },
  {
    field: 'statusName',
    headerName: 'Trạng thái',
    sortable: false,
    width: 180,
    filterable: false,
    hideable: false,
    renderCell: (params: any) => (
      <Chip
        variant='outlined'
        label={params.row.statusName}
        color={params.row.statusName == 'Có mặt' ? 'success' : 'warning'}
      />
    )
  },
  {
    field: 'studentCharge',
    headerName: 'Người phụ trách',
    sortable: false,
    width: 180,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  },
  {
    field: 'reasonName',
    headerName: 'Lý do',
    sortable: false,
    width: 160,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  },

  {
    field: 'teacherCharge',
    headerName: 'Giáo viên phụ trách',
    sortable: false,
    width: 180,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  },
  {
    field: 'description',
    headerName: 'Mô tả',
    sortable: false,
    width: 160,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  }
];
