// import { GridColDef } from '@mui/x-data-grid';
import { AttendanceScheduleWithIndex } from './type';
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
import { configRoutes } from '@/constants/routes';

export const attendanceScheduleColumn = (
  navigate: any
): GridColDef<AttendanceScheduleWithIndex>[] => [
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
        {convertDayOfWeek(params.row.dayOfWeek)} -{params.row.periodName}
      </>
    )
  },
  {
    field: 'attendanceTime',
    headerName: 'Ngày điểm danh',
    width: 150,
    hideable: false,
    sortable: false,
    filterable: false,
    valueGetter: row => formatDate(row)
  },
  {
    field: 'className',
    headerName: 'Lớp',
    width: 130,
    hideable: false,
    sortable: false,
    filterable: false
  },
  {
    field: 'isAttendance',
    headerName: 'Trạng thái',
    sortable: false,
    width: 160,
    filterable: false,
    hideable: false,
    renderCell: (params: any) => (
      <Chip
        label={params.row.isAttendance ? 'Đã điểm danh' : 'Chưa điểm danh'} // Hiển thị trạng thái theo boolean
        color={params.row.isAttendance ? 'success' : 'warning'} // Màu sắc tùy thuộc vào trạng thái
        variant='outlined'
      />
    )
  },
  {
    field: 'actions',
    headerName: 'Thao tác',
    sortable: false,
    width: 260,
    filterable: false,
    hideable: false,
    renderCell: (params: any) =>
      params.row.isAttendance ? (
        <VemButton
          style={{ textTransform: 'none' }}
          size='small'
          type='button'
          color='warning'
          variant='outlined'
          disabled={!isAttendanceDateInThePast(params.row.attendanceTime)}
          startIcon={<EditIcon />}
          onClick={() => {
            // navigate('/student/attendance/' + params.row.scheduleDetailID);
            navigate(configRoutes.studentEditAttendance, {
              state: {
                time: params.row.attendanceTime,
                className: params.row.className,
                periodName: params.row.periodName
              }
            });
          }}
          children={'Sửa điểm danh'}
        />
      ) : (
        <VemButton
          style={{ textTransform: 'none' }}
          size='small'
          type='button'
          color='primary'
          variant='outlined'
          startIcon={<CheckCircleOutlineIcon />}
          disabled={!isAttendanceDateInThePast(params.row.attendanceTime)}
          onClick={() => {
            // navigate('/student/attendance/' + params.row.scheduleDetailID);
            navigate(configRoutes.studentTakeAttendance, {
              state: {
                scheduleDetailID: params.row.scheduleDetailID,
                time: params.row.attendanceTime,
                periodID: params.row.periodID,
                periodName: params.row.periodName,
                className: params.row.className
              }
            });
          }}
          children={'Điểm danh'}
        />
      )
  }
];
