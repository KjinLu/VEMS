import { StudentIndex } from './type';

import AvatarImage from '@/assets/images/avatar-test.jpg';

export const studentColumn = [
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        STT
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.id}</p>,
    width: '100px',
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Ảnh đại diện
      </p>
    ),
    cell: (row: StudentIndex) => (
      <div className='p-2'>
        <div
          style={{
            borderRadius: '5px',
            border: '1px solid #ccc',
            overflow: 'hidden'
          }}
        >
          <img
            src={AvatarImage}
            style={{ width: '100px' }}
          ></img>
        </div>
      </div>
    ),
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Họ và Tên
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.name}</p>,
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Mã định danh
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.code}</p>,
    center: true
  }
];
