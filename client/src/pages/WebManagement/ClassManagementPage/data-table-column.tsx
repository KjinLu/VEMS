import { ClassIndex } from './type';

export const classColumn = [
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        STT
      </p>
    ),
    cell: (row: ClassIndex) => <p style={{ fontSize: '16px' }}>{row.id}</p>,
    width: '100px',
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>Lớp</p>
    ),
    cell: (row: ClassIndex) => <p style={{ fontSize: '16px' }}>{row.class}</p>,
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Giáo viên chủ nhiệm
      </p>
    ),
    cell: (row: ClassIndex) => <p style={{ fontSize: '16px' }}>{row.teacher}</p>,
    center: true
  },

  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Số lượng học sinh
      </p>
    ),
    cell: (row: ClassIndex) => <p style={{ fontSize: '16px' }}>{row.amount}</p>,
    center: true
  }
];
