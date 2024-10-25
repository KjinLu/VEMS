import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import VemsSelect from '@/components/VemSelect';
import { configRoutes } from '@/constants/routes';
import { RootState } from '@/libs/state/store';
import {
  useGetReasonsQuery,
  useGetStatusesQuery,
  useGetStudentInClassQuery,
  useTakeAttendanceForClassMutation
} from '@/services/attendance';
import { formatDate } from '@/utils/dateFormat';
import {
  FormControlLabel,
  MenuItem,
  Paper,
  Radio,
  RadioGroup,
  Select
} from '@mui/material';
import { Form } from 'antd';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { Col, Row } from 'reactstrap';

type AttendanceRecord = {
  studentID: string;
  statusID: string;
  reasonID?: string;
  teacherID?: string;
  description?: string;
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

const TeacherTakeAttendancePage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const userInfo = useSelector((state: RootState) => state);
  const { scheduleDetailID, time, periodID, className, periodName } =
    location.state || {};
  const [attendanceData, setAttendanceData] = useState<any>({});
  const [takeAttendance] = useTakeAttendanceForClassMutation();
  const [createForm] = Form.useForm();

  const handleSubmit = async (values: any) => {
    // Lấy optionID cho trạng thái "Vắng mặt không phép"
    const defaultAbsentStatusID = attendanceStatus?.find(
      (item: any) => item.optionName === 'Vắng mặt không phép'
    )?.optionID;

    // Tạo bản sao của attendanceData và thiết lập giá trị mặc định nếu chưa có
    const updatedAttendance = { ...attendanceData };

    // Thiết lập "Vắng mặt không phép" cho học sinh không có trạng thái
    studentList?.forEach((student: any) => {
      if (!updatedAttendance[student.studentID]?.statusID) {
        updatedAttendance[student.studentID] = {
          ...updatedAttendance[student.studentID],
          statusID: defaultAbsentStatusID
        };
      }
    });

    // Chuẩn bị đối tượng dữ liệu để gửi
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
        statusID: updatedAttendance[studentID].statusID,
        teacherID: userInfo.auth.accountID as string,
        reasonID: updatedAttendance[studentID]?.reasonID,
        description: updatedAttendance[studentID]?.description
      }))
    };

    var response = await takeAttendance(attendanceDataRequest).unwrap();
    if (response) {
      toast.success('Điểm danh thành công!');
      navigate(configRoutes.teacherAttendanceSchedule);
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
  const { data: reason } = useGetReasonsQuery(null);

  const handleInputChange = (studentID: any, field: any, value: any) => {
    setAttendanceData((prev: any) => ({
      ...prev,
      [studentID]: {
        ...prev[studentID],
        [field]: value
      }
    }));
  };

  useEffect(() => {
    // Assuming initial attendance data, like date, comes from somewhere
    createForm.setFieldsValue({
      /* default values */
    });
  }, [createForm]);

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
                className='mb-3'
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
                className='mb-2 d-none'
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

          <Row className='mb-3'>
            <Col
              sm={1}
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

            <Col
              sm={2}
              className='text-black-100'
            >
              <h6> Trạng thái</h6>
            </Col>
            <Col
              sm={2}
              className='text-black-100'
            >
              <h6> Lý do</h6>
            </Col>
            <Col
              sm={2}
              className='text-black-100'
            >
              <h6> Mô tả</h6>
            </Col>
          </Row>
          {studentList?.map((student: any, index: number) => (
            <Row
              key={student.studentID}
              className='mt-2 py-2 d-flex align-items-center'
            >
              <Col sm={1}>{index + 1}</Col>
              <Col sm={5}>{student.studentName}</Col>

              <Col sm={2}>
                <Select
                  variant='outlined'
                  className='w-100'
                  value={attendanceData[student.studentID]?.statusID || ''}
                  onChange={e =>
                    handleInputChange(student.studentID, 'statusID', e.target.value)
                  }
                >
                  {attendanceStatus
                    .filter((item: any) => item.optionName != 'Chưa điểm danh')
                    .map((status: any) => (
                      <MenuItem
                        key={status.optionID}
                        value={status.optionID}
                      >
                        {status.optionName}
                      </MenuItem>
                    ))}
                </Select>
              </Col>

              <Col sm={2}>
                <Select
                  variant='outlined'
                  className='w-100'
                  disabled={
                    !attendanceData[student.studentID]?.statusID ||
                    attendanceData[student.studentID]?.statusID ==
                      attendanceStatus.find((item: any) => item.optionName === 'Có mặt')
                        .optionID ||
                    attendanceData[student.studentID]?.statusID ==
                      attendanceStatus.find(
                        (item: any) => item.optionName === 'Vắng mặt không phép'
                      ).optionID
                  }
                  value={attendanceData[student.studentID]?.reasonID || ''}
                  onChange={e =>
                    handleInputChange(student.studentID, 'reasonID', e.target.value)
                  }
                >
                  {reason.map((r: any) => (
                    <MenuItem
                      key={r.optionID}
                      value={r.optionID}
                    >
                      {r.optionName}
                    </MenuItem>
                  ))}
                </Select>
              </Col>

              <Col sm={2}>
                <VemInput
                  disabled={
                    !attendanceData[student.studentID]?.statusID ||
                    attendanceData[student.studentID]?.statusID ==
                      attendanceStatus.find((item: any) => item.optionName === 'Có mặt')
                        .optionID ||
                    attendanceData[student.studentID]?.statusID ==
                      attendanceStatus.find(
                        (item: any) => item.optionName === 'Vắng mặt không phép'
                      ).optionID
                  }
                  id={student.studentID}
                  type='text'
                  value={attendanceData[student.studentID]?.description || ''}
                  onChange={e =>
                    handleInputChange(student.studentID, 'description', e.target.value)
                  }
                />
              </Col>
            </Row>
          ))}

          <VemButton
            type='submit'
            className='mt-2 mb-3'
            children='Điểm danh'
            variant='contained'
            fullWidth
          />
        </Form>
      </Paper>
    </Row>
  );
};

export default TeacherTakeAttendancePage;
