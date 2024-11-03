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
import { useLocation, useNavigate } from 'react-router-dom';
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
import { Form } from 'antd';
import { toast } from 'react-toastify';
import { configRoutes } from '@/constants/routes';

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
  const navigate = useNavigate();
  const userInfo = useSelector((state: RootState) => state);
  const { time, className, periodName } = location.state || {};
  const [attendance, setAttendance] = useState<any>({});
  const [updateAttendance] = useUpdateAttendanceForClassMutation();
  const [updateFrom] = Form.useForm();

  const handleSubmit = async (values: any) => {
    const updatedAttendance = { ...attendance };

    attendanceData?.attendanceData?.forEach((item: any) => {
      if (!updatedAttendance[item.attendanceStatusID]) {
        updatedAttendance[item.attendanceStatusID] = item.statusID;
      }
    });

    const attendanceDataRequest: AttendanceData = {
      attendanceID: attendanceData.attendanceID,
      time: time,
      note: values.note ?? '',
      updateBy: userInfo.auth.fullName as string,
      updateAt: new Date().toISOString(),
      createAt: attendanceData?.attendanceData[0]?.createAt ?? '',
      createBy: attendanceData?.attendanceData[0]?.createBy ?? '',
      attendanceData: Object.keys(updatedAttendance).map(attendanceStatusID => ({
        attendanceStatusID,
        statusID: updatedAttendance[attendanceStatusID]
      }))
    };

    var response = await updateAttendance(attendanceDataRequest).unwrap();
    if (response) {
      toast.success('Sửa điểm danh thành công!');
      navigate(configRoutes.studentAttendanceSchedule);
    } else {
      toast.error('Sửa điểm danh thất bại!');
    }
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
    updateFrom.setFieldsValue({
      note: attendanceData ? attendanceData.note : ''
    });
  }, [attendanceData]);

  const { data: attendanceStatus } = useGetStatusesQuery(null);

  const handleChange = (attendanceStatusID: string, statusID: string) => {
    setAttendance((prevAttendance: any) => ({
      ...prevAttendance,
      [attendanceStatusID]: statusID
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
          className='mt-3'
          form={updateFrom}
          onFinish={handleSubmit}
        >
          <Row>
            <Col sm={6}>
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
            {attendanceData?.attendanceData.map((item: any, index: number) => (
              <Row
                key={item.attendanceStatusID}
                className='mt-2 py-2'
              >
                <Col sm={2}>{index + 1}</Col>
                <Col sm={5}>{item.studentName}</Col>
                <Col sm={5}>
                  <RadioGroup
                    aria-label='attendance-status'
                    value={attendance[item.attendanceStatusID] || item.statusID} // Use state if changed, or existing data
                    onChange={e => handleChange(item.attendanceStatusID, e.target.value)} // Update state on change
                    row
                  >
                    <FormControlLabel
                      className='me-5'
                      value={
                        attendanceStatus.find(
                          (status: any) => status.optionName === 'Vắng mặt không phép'
                        )?.optionID
                      }
                      control={<Radio />}
                      label='Vắng mặt'
                    />
                    <FormControlLabel
                      value={
                        attendanceStatus.find(
                          (status: any) => status.optionName === 'Có mặt'
                        )?.optionID
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
            className='mt-2 mb-3'
            status={'loading'}
            type={'submit'}
            children={'Cập nhật'}
            variant={'contained'}
            fullWidth={true}
          />
        </Form>
      </Paper>
    </Row>
  );
};

export default StudentUpdateAttendancePage;
