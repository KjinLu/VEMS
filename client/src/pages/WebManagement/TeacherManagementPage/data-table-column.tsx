import VemImage from '@/components/VemImage';
import { TeacherIndex } from './type';

import AvatarImage from '@/assets/images/avatar-test.jpg';

export const teacherColumn = [
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        STT
      </p>
    ),
    cell: (row: TeacherIndex) => <p style={{ fontSize: '16px' }}>{row.index + 1}</p>,
    width: '100px',
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Ảnh đại diện
      </p>
    ),
    cell: (row: TeacherIndex) => (
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
            className='w-100 rounded'
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
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Họ và Tên
      </p>
    ),
    cell: (row: TeacherIndex) => <p style={{ fontSize: '16px' }}>{row.fullName}</p>,
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(97 177 255)', fontWeight: '600' }}>
        Số điện thoại
      </p>
    ),
    cell: (row: TeacherIndex) => <p style={{ fontSize: '16px' }}>{row.phone}</p>,
    center: true
  },
  {
    name: (
      <p style={{ fontSize: '18px', color: 'rgb(25, 118, 210)', fontWeight: '600' }}>
        Chủ nhiệm lớp
      </p>
    ),
    cell: (row: TeacherIndex) => <p style={{ fontSize: '16px' }}>{row.classRoom}</p>,
    center: true
  }
];
