import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import { Link, MenuItem, Paper, Select } from '@mui/material';
import { Form } from 'antd';
import classNames from 'classnames';
import { useLocation } from 'react-router-dom';
import style from './StudentTakeAttendance.module.scss';
import { Col, Row } from 'reactstrap';
import { formatDate } from '@/utils/dateFormat';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import {
  useGetStatusesQuery,
  useGetStudentInClassQuery,
  useTakeAttendanceForClassMutation
} from '@/services/attendance';
import { UUID } from 'crypto';
import { useState } from 'react';

const cx = classNames.bind(style);

type AttendanceRecord = {
  studentID: string;
  statusID: string;
};

type AttendanceData = {
  classID: string;
  time: string;
  note: string;
  scheduleDetailID: string;
  studentInChargeID: string;
  periodID: string;
  studentInchargeName: string;
  attendanceData: AttendanceRecord[];
};

const StudentTakeAttendancePage = () => {
  const location = useLocation();
  const userInfo = useSelector((state: RootState) => state);
  const { scheduleDetailID, time, periodID } = location.state || {};
  const [attendance, setAttendance] = useState<any>({});
  const [takeAttendance] = useTakeAttendanceForClassMutation();

  const handleSubmit = async (values: any) => {
    const attendanceDataRequest: AttendanceData = {
      classID: userInfo.auth.classroomID as string,
      time: values.time,
      note: values.note,
      scheduleDetailID: scheduleDetailID,
      periodID: periodID,
      studentInChargeID: userInfo.auth.accountID as string,
      studentInchargeName: userInfo.auth.username as string,
      attendanceData: Object.keys(attendance).map(studentID => ({
        studentID,
        statusID: attendance[studentID]
      }))
    };
    console.log(attendanceDataRequest);

    var response = await takeAttendance(attendanceDataRequest).unwrap();
    console.log('Response: ', response);
  };

  const { data: studentList } = useGetStudentInClassQuery(
    userInfo.auth.classroomID as UUID
  );

  const { data: attendanceStatus } = useGetStatusesQuery(null);

  const handleChange = (id: any, e: any) => {
    console.log(id);
    console.log(e.target);
    setAttendance((prev: any) => ({
      ...prev,
      [id]: e.target.value
    }));
  };

  return (
    <Row className='mt-4 p-2'>
      <Paper>
        <Form onFinish={handleSubmit}>
          <Form.Item
            name={'time'}
            className={cx('mb-2')}
          >
            <VemInput
              id='time'
              // label='Buổi điểm danh'
              type='date'
              placeholder=''
              value={time}
              fullWidth
              // disabled
              variant='outlined'
              size='medium'
              autoComplete='off'
            />
          </Form.Item>

          <Form.Item
            name={'note'}
            className={cx('mb-3')}
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
            {studentList?.map((student: any, index: number) => (
              <Row
                key={student.studentID}
                className='mt-2 py-2'
              >
                <Col sm={2}> {index + 1}</Col>
                <Col sm={5}> {student.studentName}</Col>

                <Col sm={5}>
                  <Select
                    className='w-100'
                    labelId='demo-simple-select-label'
                    id='demo-simple-select'
                    onChange={e => handleChange(student.studentID, e)}
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
            className={cx('mt-2 mb-3')}
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

export default StudentTakeAttendancePage;
