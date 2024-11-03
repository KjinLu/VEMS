import VemImage from '@/components/VemImage';
import { StudentTableIndex } from './type';

import AvatarImage from '@/assets/images/avatar-test.jpg';

export const studentColumn = [
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        STT
      </p>
    ),
    cell: (row: StudentTableIndex) => <p style={{ fontSize: '16px' }}>{row.index + 1}</p>,
    width: '100px',
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Ảnh đại diện
      </p>
    ),
    cell: (row: StudentTableIndex) => (
      <div className='p-2'>
        <div
          style={{
            width: '120px',
            borderRadius: '5px',
            border: '1px solid #ccc',
            overflow: 'hidden'
          }}
        >
          <VemImage
            alt=''
            fallback={AvatarImage}
            className='w-100'
            src={row.studentImage}
            key=''
          />
        </div>
      </div>
    ),
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Mã định danh
      </p>
    ),
    cell: (row: StudentTableIndex) => (
      <p style={{ fontSize: '16px' }}>{row.publicStudentID}</p>
    ),
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Họ và Tên
      </p>
    ),
    cell: (row: StudentTableIndex) => (
      <p style={{ fontSize: '16px' }}>{row.studentName}</p>
    ),
    width: '500px',
    center: true
  }
];
