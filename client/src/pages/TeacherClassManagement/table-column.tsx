import { GridColDef } from '@mui/x-data-grid';
import { ClassStudentWithIndex } from './type';
import VemImage from '@/components/VemImage';

export const classTableColumn = (): GridColDef<ClassStudentWithIndex>[] => [
  {
    field: 'index',
    headerName: 'STT',
    width: 70,
    filterable: false,
    hideable: false,
    align: 'left'
  },
  {
    field: 'studentImage',
    headerName: 'Ảnh',
    sortable: false,
    filterable: false,
    hideable: false,
    width: 100,
    renderCell: (params: any) => (
      <VemImage
        className='w-50 rounded'
        alt='studentAvatar'
        src={params.row.studentImage}
        fallback={''}
      ></VemImage>
    )
  },
  {
    field: 'publicStudentID',
    headerName: 'Mã định danh học sinh',
    width: 180,
    hideable: false,
    sortable: false,
    filterable: false,
    valueGetter: row => row
  },
  {
    field: 'studentName',
    headerName: 'Họ và Tên',
    width: 250,
    hideable: false,
    sortable: false,
    filterable: false,
    valueGetter: row => row
  },
  {
    field: 'studentPhone',
    headerName: 'SDT',
    sortable: false,
    width: 250,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  },
  {
    field: 'studentType',
    headerName: 'Vai trò',
    sortable: false,
    width: 160,
    filterable: false,
    hideable: false,
    valueGetter: row => row
  }
];
