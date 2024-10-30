import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import VemsSelect from '@/components/VemSelect';
import { configRoutes } from '@/constants/routes';
import { RootState } from '@/libs/state/store';
import {
  useGetAttendanceOfClassQuery,
  useGetReasonsQuery,
  useGetStatusesQuery,
  useGetStudentInClassQuery,
  useTakeAttendanceForClassMutation,
  useUpdateAttendanceForClassMutation
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
  attendanceStatusID: string;
  statusID: string;
  reasonID?: string;
  teacherID?: string;
  description?: string;
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
const TeacherEditAttendancePage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const userInfo = useSelector((state: RootState) => state);
  const { time, className, periodName } = location.state || {};
  const [attendanceData, setAttendanceData] = useState<any>({});
  const [updateAttendance] = useUpdateAttendanceForClassMutation();
  const [updateFrom] = Form.useForm();

  const handleSubmit = async (values: any) => {
    // Tạo bản sao của attendanceData và thiết lập giá trị mặc định nếu chưa có
    const updatedAttendance = { ...attendanceData };
    // Thiết lập "Vắng mặt không phép" cho học sinh không có trạng thái
    attendanceDataResponse?.attendanceData?.forEach((item: any) => {
      if (!updatedAttendance[item.attendanceStatusID]?.statusID) {
        updatedAttendance[item.attendanceStatusID] = {
          ...updatedAttendance[item.attendanceStatusID],
          statusID: item.statusID
        };
      }
    });
    // Chuẩn bị đối tượng dữ liệu để gửi
    const attendanceDataRequest: AttendanceData = {
      attendanceID: attendanceDataResponse.attendanceID,
      time: time,
      note: values.note ?? '',
      updateBy: userInfo.auth.fullName as string,
      updateAt: new Date().toISOString(),
      createAt: attendanceDataResponse?.attendanceData[0]?.createAt ?? '',
      createBy: attendanceDataResponse?.attendanceData[0]?.createBy ?? '',
      attendanceData: Object.keys(updatedAttendance).map(attendanceStatusID => ({
        attendanceStatusID,
        statusID: updatedAttendance[attendanceStatusID].statusID,
        teacherID: userInfo.auth.accountID as string,
        reasonID: updatedAttendance[attendanceStatusID]?.reasonID,
        description: updatedAttendance[attendanceStatusID]?.description
      }))
    };
    var response = await updateAttendance(attendanceDataRequest).unwrap();
    if (response) {
      toast.success('Điểm danh thành công!');
      navigate(configRoutes.teacherAttendanceSchedule);
    } else {
      toast.error('Điểm danh thất bại!');
    }
  };

  const { data: attendanceDataResponse, refetch: refetchAttendanceData } =
    useGetAttendanceOfClassQuery({
      classID: userInfo.auth.classroomID as UUID,
      time: time.split('T')[0]
    });

  // console.log(attendanceDataResponse.attendanceID);

  useEffect(() => {
    refetchAttendanceData();
  }, []);

  useEffect(() => {
    updateFrom.setFieldsValue({
      note: attendanceDataResponse ? attendanceDataResponse.note : ''
    });
  }, [attendanceDataResponse]);

  const { data: attendanceStatus } = useGetStatusesQuery(null);
  const { data: reason } = useGetReasonsQuery(null);

  const handleInputChange = (attendanceStatusID: any, field: any, value: any) => {
    setAttendanceData((prev: any) => ({
      ...prev,
      [attendanceStatusID]: {
        ...prev[attendanceStatusID],
        [field]: value
      }
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
          {attendanceDataResponse?.attendanceData?.map((item: any, index: number) => (
            <Row
              key={item.attendanceStatusID}
              className='mt-2 py-2 d-flex align-items-center'
            >
              <Col sm={1}>{index + 1}</Col>
              <Col sm={5}>{item.studentName}</Col>

              <Col sm={2}>
                <Select
                  variant='outlined'
                  className='w-100'
                  value={
                    attendanceData[item.attendanceStatusID]?.statusID || item.statusID
                  }
                  onChange={e =>
                    handleInputChange(item.attendanceStatusID, 'statusID', e.target.value)
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
                    !attendanceData[item.attendanceStatusID]?.statusID ||
                    attendanceData[item.attendanceStatusID]?.statusID ==
                      attendanceStatus.find((item: any) => item.optionName === 'Có mặt')
                        .optionID ||
                    attendanceData[item.attendanceStatusID]?.statusID ==
                      attendanceStatus.find(
                        (item: any) => item.optionName === 'Vắng mặt không phép'
                      ).optionID
                  }
                  value={
                    attendanceData[item.attendanceStatusID]?.reasonID || item.reasonID
                  }
                  onChange={e =>
                    handleInputChange(item.attendanceStatusID, 'reasonID', e.target.value)
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
                    !attendanceData[item.attendanceStatusID]?.statusID ||
                    attendanceData[item.attendanceStatusID]?.statusID ==
                      attendanceStatus.find((item: any) => item.optionName === 'Có mặt')
                        .optionID ||
                    attendanceData[item.attendanceStatusID]?.statusID ==
                      attendanceStatus.find(
                        (item: any) => item.optionName === 'Vắng mặt không phép'
                      ).optionID
                  }
                  id={item.studentID}
                  type='text'
                  value={
                    attendanceData[item.attendanceStatusID]?.description ||
                    item.description
                  }
                  onChange={e =>
                    handleInputChange(
                      item.attendanceStatusID,
                      'description',
                      e.target.value
                    )
                  }
                />
              </Col>
            </Row>
          ))}

          <VemButton
            type='submit'
            className='mt-2 mb-3'
            children='Cập nhật điểm danh'
            variant='contained'
            fullWidth
          />
        </Form>
      </Paper>
    </Row>
  );
};

export default TeacherEditAttendancePage;
