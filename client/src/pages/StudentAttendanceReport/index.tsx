import { Paper } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import { Row } from 'reactstrap';
import { attendanceReportColumn } from './table-column';
import { useGetStudentAttendanceReportQuery } from '@/services/attendance';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import { UUID } from 'crypto';
import { AttendanceReport, AttendanceReportWithIndex } from './type';
import { useEffect, useState } from 'react';

const StudentAttendanceReportPage = () => {
  const userInfo = useSelector((state: RootState) => state);
  const [attendanceReport, setAttendanceReport] = useState<AttendanceReportWithIndex[]>();

  const { data, refetch } = useGetStudentAttendanceReportQuery(
    userInfo.auth.accountID as UUID
  );

  useEffect(() => {
    refetch();
  }, []);

  useEffect(() => {
    if (data) {
      setAttendanceReport(
        data.map((item: AttendanceReport, idx: number) => ({
          ...item,
          index: idx + 1
        }))
      );
    }
  }, [data]);

  return (
    <Row className='m-2'>
      <Paper className='p-3'>
        <DataGrid
          className='w-100'
          rows={(attendanceReport as AttendanceReportWithIndex[]) || []}
          columns={attendanceReportColumn()}
          sx={{ border: 0, width: 1 }}
          getRowId={(row: AttendanceReportWithIndex) => row.attendanceStatusID}
          pageSizeOptions={[5, 10, 15, 20]}
          // hideFooter
          initialState={{
            pagination: {
              paginationModel: { pageSize: 5, page: 0 }
            }
          }}
        />
      </Paper>
    </Row>
  );
};

export default StudentAttendanceReportPage;
