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

const StudentTakeAttendanceSchedulePage = () => {
  const navigate = useNavigate();
  const userClassInfo = useSelector((state: RootState) => state.auth.classroomID);
  const [attendanceSchedule, setAttendanceSchedule] =
    useState<AttendanceScheduleWithIndex>();

  const { data, refetch } = useGetAttendanceScheduleOfClassQuery({
    classID: userClassInfo as UUID,
    // time: new Date().toISOString().split('T')[0]
    time: '2024-10-18'
  });

  useEffect(() => {
    refetch();
  }, []);

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
    <Paper sx={{ height: 'auto', width: '100%' }}>
      <DataGrid
        rows={attendanceSchedule ?? []}
        columns={attendanceScheduleColumn(navigate)}
        sx={{ border: 0 }}
        getRowId={(row: any) => row.scheduleDetailID}
        hideFooter
        initialState={{
          pagination: {
            paginationModel: { pageSize: 10, page: 0 }
          }
        }}
      />
    </Paper>
  );
};

export default StudentTakeAttendanceSchedulePage;
