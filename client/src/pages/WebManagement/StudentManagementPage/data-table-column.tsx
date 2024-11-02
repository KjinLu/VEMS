import VemImage from '@/components/VemImage';
import { StudentIndex } from './type';

import AvatarImage from '@/assets/images/avatar-test.jpg';

export const studentColumn = [
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        STT
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.index + 1}</p>,
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
            width: '80px',
            height: '80px',
            borderRadius: '5px',
            border: '1px solid #ccc',
            overflow: 'hidden'
          }}
        >
          <VemImage
            alt=''
            fallback={AvatarImage}
            className='w-100'
            src={row.image}
            key=''
          />
        </div>
      </div>
    ),
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Mã định danh
      </p>
    ),
    cell: (row: StudentIndex) => (
      <p style={{ fontSize: '16px' }}>{row.publicStudentID}</p>
    ),
    center: false
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Họ và Tên
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.fullName}</p>,
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Email
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.email}</p>,
    center: false
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Số điên thoại
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.phone}</p>,
    center: false
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Lớp
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{row.classRoom}</p>,
    center: false
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Tùy chọn
      </p>
    ),
    cell: (row: StudentIndex) => <p style={{ fontSize: '16px' }}>{}</p>,
    center: true
  }
];
