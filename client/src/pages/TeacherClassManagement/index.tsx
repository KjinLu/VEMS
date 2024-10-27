import { DataGrid } from '@mui/x-data-grid';
import { classTableColumn } from './table-column';
import { Paper } from '@mui/material';
import { Col, Modal, Row } from 'reactstrap';
import { useGetStudentInClassQuery } from '@/services/classes';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { ClassStudent, ClassStudentWithIndex } from './type';
import StudentProfileModal from './StudentProfileModal';

const TeacherClassManagementPage = () => {
  const userInfo = useSelector((state: RootState) => state.auth);
  const [classStudents, setClassStudent] = useState<ClassStudentWithIndex[]>();
  const [studentSelected, setStudentSelected] = useState<UUID>();
  const [isOpenModal, setIsOpenModal] = useState<boolean>(false);

  const { data } = useGetStudentInClassQuery(userInfo.classroomID as UUID);
  useEffect(() => {
    if (data.students) {
      setClassStudent(
        data.students.map((item: ClassStudent, idx: number) => ({
          ...item,
          index: idx + 1
        }))
      );
    }
  }, [data]);

  const handleRowClick = (params: any) => {
    const studentID = params.row.studentID;
    setIsOpenModal(true);
    setStudentSelected(studentID);
  };

  const toggleModal = () => {
    setIsOpenModal(!isOpenModal);
  };

  console.log('Student ID:', studentSelected);

  return (
    <>
      <Paper className='p-3'>
        <h2 className='text-center'>Quản lí lớp chủ nhiệm</h2>

        <Row className='ms-2'>
          <Col
            className='mt-2'
            sm={12}
          >
            <h3>Lớp: {data ? data.className : ''}</h3>
          </Col>
          <Col
            className='mt-2'
            sm={12}
          >
            <h3>Sĩ số: {data ? data.numberOfStudent : ''}</h3>
          </Col>
        </Row>

        <DataGrid
          className='w-100'
          rows={classStudents ?? []}
          columns={classTableColumn()}
          sx={{ border: 0, width: 1 }}
          getRowId={(row: any) => row.studentID}
          hideFooter
          initialState={{
            pagination: {
              paginationModel: { pageSize: 14, page: 0 }
            }
          }}
          onRowClick={handleRowClick}
        />
      </Paper>
      <StudentProfileModal
        isOpen={isOpenModal}
        toggleModal={toggleModal}
      />
    </>
  );
};

export default TeacherClassManagementPage;