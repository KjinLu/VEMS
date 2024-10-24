import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import { Link, MenuItem, Paper, Select } from '@mui/material';
import { Form } from 'antd';
import { useLocation } from 'react-router-dom';
import { Col, Row } from 'reactstrap';
import { formatDate } from '@/utils/dateFormat';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import {
  useGetAttendanceOfClassQuery,
  useGetStatusesQuery,
  useUpdateAttendanceForClassMutation
} from '@/services/attendance';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { useForm } from 'antd/es/form/Form';

type AttendanceRecord = {
  attendanceStatusID: string;
  statusID: string;
};

type AttendanceData = {
  attendanceID: string;
  time: string;
  note: string;
  updateBy: string;
  createBy: string;
  createAt: string;
  updateAt: string;
  attendanceData: AttendanceRecord[];
};

const StudentUpdateAttendancePage = () => {
  const location = useLocation();
  const userInfo = useSelector((state: RootState) => state);
  const { time, className, periodName } = location.state || {};
  const [attendance, setAttendance] = useState<any>({});
  const [updateAttendance] = useUpdateAttendanceForClassMutation();

  const [updateFrom] = useForm();

  const handleSubmit = async (values: any) => {
    const attendanceDataRequest: AttendanceData = {
      attendanceID: attendanceData.attendanceID,
      time: time,
      note: values.note ?? '',
      updateBy: userInfo.auth.username as string,
      updateAt: new Date().toISOString(),
      createAt: attendanceData?.attendanceData[0]
        ? attendanceData?.attendanceData[0].createAt
        : '',
      createBy: attendanceData?.attendanceData[0]
        ? attendanceData?.attendanceData[0].createBy
        : '',
      attendanceData: Object.keys(attendance).map(attendanceStatusID => ({
        attendanceStatusID,
        statusID: attendance[attendanceStatusID]
      }))
    };
    var response = await updateAttendance(attendanceDataRequest).unwrap();
  };

  const { data: attendanceData, refetch: refetchAttendanceData } =
    useGetAttendanceOfClassQuery({
      classID: userInfo.auth.classroomID as UUID,
      time: time.split('T')[0]
    });

  useEffect(() => {
    refetchAttendanceData();
  }, []);

  useEffect(() => {
    console.log(attendanceData);
    console.log(attendanceData ? attendanceData.note : '');
    updateFrom.setFieldsValue({ note: attendanceData ? attendanceData.note : '' });
  }, [attendanceData]);

  const { data: attendanceStatus } = useGetStatusesQuery(null);

  const handleChange = (id: any, e: any) => {
    setAttendance((prev: any) => ({
      ...prev,
      [id]: e.target.value
    }));
  };

  return (
    <Row className='mt-4 p-2'>
      <Paper>
        <h4 className='mt-2 ms-1'>
          Chỉnh sửa điểm danh cho lớp <b>{className}</b> buổi học{' '}
          <b>
            {periodName} - {formatDate(time)}
          </b>
        </h4>
        <Form
          form={updateFrom}
          onFinish={handleSubmit}
        >
          <Form.Item
            name={'note'}
            className='mb-3'
          >
            <VemInput
              id='note'
              label='Ghi chú'
              placeholder='Ghi chú điểm danh'
              // required
              fullWidth
              variant='outlined'
              size='medium'
              autoComplete='off'
            />
          </Form.Item>

          <Row className='p-3'>
            <Row className='mb-3'>
              <Col
                sm={2}
                className='text-black-100'
              >
                <h6> STT</h6>
              </Col>
              <Col
                sm={5}
                className='text-black-100'
              >
                <h6> Tên học sinh</h6>
              </Col>

              <Col className='text-black-100'>
                <h6> Trạng thái</h6>
              </Col>
            </Row>
            {attendanceData?.attendanceData.map((item: any, index: number) => (
              <Row
                key={item.studentID}
                className='mt-2 py-2'
              >
                <Col sm={2}> {index + 1}</Col>
                <Col sm={5}> {item.studentName}</Col>

                <Col sm={5}>
                  <Select
                    className='w-100'
                    labelId='demo-simple-select-label'
                    id='demo-simple-select'
                    onChange={e => handleChange(item.attendanceStatusID, e)}
                    value={
                      attendance[item.attendanceStatusID]
                        ? attendance[item.attendanceStatusID]
                        : item.statusID
                    }
                  >
                    {attendanceStatus
                      .filter((i: any) => i.optionName !== 'Chưa điểm danh')
                      .map((item: any) => (
                        <MenuItem value={item.optionID}>{item.optionName}</MenuItem>
                      ))}
                  </Select>
                </Col>
              </Row>
            ))}
          </Row>

          <VemButton
            className='mt-2 mb-3'
            // loading={isLoading}
            status={'loading'}
            type={'submit'}
            children={'Điểm danh'}
            variant={'contained'}
            fullWidth={true}
          />
        </Form>
      </Paper>
    </Row>
  );
};

export default StudentUpdateAttendancePage;
