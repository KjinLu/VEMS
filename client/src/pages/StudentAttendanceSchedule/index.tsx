import { DataGrid, GridEventListener } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { attendanceScheduleColumn } from './table-column';
import { AttendanceSchedule, AttendanceScheduleWithIndex } from './type';
import { useNavigate } from 'react-router-dom';
import { useGetAttendanceScheduleOfClassQuery } from '@/services/attendance';
import VemInput from '@/components/VemInput';
import { formatDate } from '@/utils/dateFormat';
import { Col, Row } from 'reactstrap';

const StudentTakeAttendanceSchedulePage = () => {
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

export default StudentTakeAttendanceSchedulePage;
