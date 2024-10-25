import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import {
  FormControlLabel,
  Link,
  MenuItem,
  Paper,
  Radio,
  RadioGroup,
  Select
} from '@mui/material';
import { Form } from 'antd';
import classNames from 'classnames';
import { useLocation, useNavigate } from 'react-router-dom';
import style from './StudentTakeAttendance.module.scss';
import { Col, Row } from 'reactstrap';
import { convertDayOfWeek, formatDate } from '@/utils/dateFormat';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import {
  useGetStatusesQuery,
  useGetStudentInClassQuery,
  useTakeAttendanceForClassMutation
} from '@/services/attendance';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { configRoutes } from '@/constants/routes';

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
  const navigate = useNavigate();
  const location = useLocation();
  const userInfo = useSelector((state: RootState) => state);
  const { scheduleDetailID, time, periodID, className, periodName } =
    location.state || {};
  const [attendance, setAttendance] = useState<any>({});
  const [takeAttendance] = useTakeAttendanceForClassMutation();
  const [createForm] = Form.useForm();

  const handleSubmit = async (values: any) => {
    const defaultAbsentStatusID = attendanceStatus?.find(
      (item: any) => item.optionName === 'Vắng mặt không phép'
    )?.optionID;

    const updatedAttendance = { ...attendance };

    studentList?.forEach((student: any) => {
      if (!updatedAttendance[student.studentID]) {
        updatedAttendance[student.studentID] = defaultAbsentStatusID;
      }
    });

    const attendanceDataRequest: AttendanceData = {
      classID: userInfo.auth.classroomID as string,
      time: values.time,
      note: values.note,
      scheduleDetailID: scheduleDetailID,
      periodID: periodID,
      studentInChargeID: userInfo.auth.accountID as string,
      studentInchargeName: userInfo.auth.fullName as string,
      attendanceData: Object.keys(updatedAttendance).map(studentID => ({
        studentID,
        statusID: updatedAttendance[studentID]
      }))
    };
    console.log(attendanceDataRequest);

    var response = await takeAttendance(attendanceDataRequest).unwrap();
    if (response) {
      toast.success('Điểm danh thành công!');
      navigate(configRoutes.studentAttendanceSchedule);
    } else {
      toast.error('Điểm danh thất bại!');
    }
  };

  useEffect(() => {
    createForm.setFieldsValue({
      time: time.split('T')[0]
    });
  }, [time, createForm]);

  const { data: studentList } = useGetStudentInClassQuery(
    userInfo.auth.classroomID as UUID
  );

  const { data: attendanceStatus } = useGetStatusesQuery(null);

  const handleChange = (id: string, status: string) => {
    setAttendance((prev: any) => ({
      ...prev,
      [id]: status
    }));
  };

  return (
    <Row className='mt-4 p-2'>
      <Paper>
        <h4 className='mt-2 ms-1'>
          Điểm danh cho lớp <b>{className}</b> buổi học{' '}
          <b>
            {periodName} - {formatDate(time)}
          </b>
        </h4>

        <Form
          form={createForm}
          onFinish={handleSubmit}
        >
          <Row className='mt-4'>
            <Col sm={6}>
              <Form.Item
                name={'note'}
                className={cx('mb-3')}
              >
                <VemInput
                  id='note'
                  label='Ghi chú'
                  placeholder='Ghi chú điểm danh'
                  fullWidth
                  variant='outlined'
                  size='medium'
                  autoComplete='off'
                />
              </Form.Item>
            </Col>
            <Col sm={6}>
              <Form.Item
                name={'time'}
                className={cx('mb-2 d-none')}
              >
                <VemInput
                  disabled
                  id='time'
                  label='Buổi điểm danh'
                  type='date'
                  value={time}
                  fullWidth
                  variant='outlined'
                  size='medium'
                  autoComplete='off'
                />
              </Form.Item>
            </Col>
          </Row>

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
                  <RadioGroup
                    aria-label='attendance-status'
                    value={
                      attendance[student.studentID] ||
                      attendanceStatus.find(
                        (item: any) => item.optionName === 'Vắng mặt không phép'
                      ).optionID
                    }
                    onChange={e => handleChange(student.studentID, e.target.value)}
                    row
                  >
                    <FormControlLabel
                      className='me-5'
                      value={
                        attendanceStatus.find(
                          (item: any) => item.optionName === 'Vắng mặt không phép'
                        ).optionID
                      }
                      control={<Radio />}
                      label='Vắng mặt'
                    />
                    <FormControlLabel
                      value={
                        attendanceStatus.find((item: any) => item.optionName === 'Có mặt')
                          .optionID
                      }
                      control={<Radio />}
                      label='Có mặt'
                    />
                  </RadioGroup>
                </Col>
              </Row>
            ))}
          </Row>

          <VemButton
            className={cx('mt-2 mb-3')}
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

// {
//   studentList?.map((student: any, index: number) => (
//     <Row
//       key={student.studentID}
//       className='mt-2 py-2'
//     >
//       <Col sm={2}> {index + 1}</Col>
//       <Col sm={5}> {student.studentName}</Col>

//       <Col sm={5}>
//         <Select
//           required
//           className='w-100'
//           labelId='demo-simple-select-label'
//           id='demo-simple-select'
//           onChange={e => handleChange(student.studentID, e)}
//         >
//           {attendanceStatus.map((item: any) => (
//             <MenuItem value={item.optionID}>{item.optionName}</MenuItem>
//           ))}
//         </Select>
//       </Col>
//     </Row>
//   ));
// }
