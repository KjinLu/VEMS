import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { useGetAttendanceScheduleOfClassQuery } from '@/services/attendance';
import { UUID } from 'crypto';
import { formatDate } from '@/utils/dateFormat';
import { Paper } from '@mui/material';
import { Col, Row } from 'reactstrap';
import VemInput from '@/components/VemInput';
import { DataGrid } from '@mui/x-data-grid';
import { RootState } from '@/libs/state/store';
import { AttendanceSchedule, AttendanceScheduleWithIndex } from './type';
import { attendanceScheduleColumn } from './table-column';

const TeacherAttendanceManagementPage = () => {
  const navigate = useNavigate();
  const [currentWeek, setCurrentWeek] = useState<string>(
    new Date().toISOString().split('T')[0]
  );
  const userClassInfo = useSelector((state: RootState) => state.auth.classroomID);

  const [attendanceSchedule, setAttendanceSchedule] =
    useState<AttendanceScheduleWithIndex[]>();

  const { data, refetch } = useGetAttendanceScheduleOfClassQuery({
    classID: userClassInfo as UUID,
    time: currentWeek
  });

  useEffect(() => {
    refetch();
  }, [currentWeek]);

  useEffect(() => {
    if (data) {
      setAttendanceSchedule(
        data.map((item: AttendanceSchedule, idx: number) => ({
          ...item,
          index: idx + 1
        }))
      );
    }
  }, [data]);

  return (
    <Paper className='p-3'>
      <h4 className='text-center my-3'>
        Lịch điểm danh tuần hiện tại: {formatDate(currentWeek)}
      </h4>
      <Row>
        <Col sm={9} />

        <Col sm={3}>
          <VemInput
            className='w-100'
            label='Chọn tuần điểm danh'
            placeholder=''
            value={currentWeek}
            id='date'
            type='date'
            onChange={e => setCurrentWeek(e.target.value || '')}
          />
        </Col>
      </Row>
      <DataGrid
        className='w-100'
        rows={attendanceSchedule ?? []}
        columns={attendanceScheduleColumn(navigate)}
        sx={{ border: 0, width: 1 }}
        getRowId={(row: any) => row.scheduleDetailID}
        // hideFooter
        initialState={{
          pagination: {
            paginationModel: { pageSize: 14, page: 0 }
          }
        }}
      />
    </Paper>
  );
};

export default TeacherAttendanceManagementPage;
