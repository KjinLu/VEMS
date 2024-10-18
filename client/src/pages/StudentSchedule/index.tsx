import className from 'classnames/bind';
import styles from './StudentSchedule.module.scss';
import { useEffect, useState } from 'react';
import { useGetClassScheduleQuery, useGetScheduleDetailQuery } from '@/services/schedule';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { Col, Row } from 'reactstrap';
import { useGetUserMutation } from '@/services/auth';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';
import { UUID } from 'crypto';

const localizer = momentLocalizer(moment);
const cx = className.bind(styles);

type DayInSchedule = {
  title: string;
  start: Date;
  end: Date;
};

function getMonday(d: Date) {
  const date = new Date(d);
  const day = date.getDay();
  const distanceToMonday = day === 0 ? -6 : 1 - day;
  date.setDate(date.getDate() + distanceToMonday);
  return date;
}

function combineDateAndTime(dateInput: string, timeInput: string): Date {
  // Chuyển đổi chuỗi ngày thành đối tượng Date
  const date = new Date(dateInput);

  // Tách chuỗi thời gian thành các thành phần giờ, phút, giây
  const [hours, minutes, seconds] = timeInput.split(':').map(Number);

  // Gán các thành phần giờ, phút, giây cho đối tượng Date
  date.setHours(hours);
  date.setMinutes(minutes);
  date.setSeconds(seconds);

  return date; // Trả về đối tượng Date
}

const Appointments: any = [
  {
    dayOfWeek: 1,
    periodName: 'Sáng',
    sessionID: '6fa3d575-2f46-4615-aa63-ab53dc32bd8b',
    slotDetails: [
      {
        subjectID: 'b1d3b555-0cf4-4b41-8131-a4c205d9a6f4',
        subjectName: 'SHDC',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'db1085ce-9ba3-4894-a8a0-d417bc6b0774',
        slotIndex: 1,
        slotStart: '07:00:00',
        slotEnd: '07:45:00'
      },
      {
        subjectID: '107f7c24-e063-4dfd-beb8-d955e1fd0f8a',
        subjectName: 'Toán học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '0811126b-4fb3-4e29-b0f6-94b00bf0b98b',
        slotIndex: 2,
        slotStart: '08:00:00',
        slotEnd: '08:45:00'
      },
      {
        subjectID: '107f7c24-e063-4dfd-beb8-d955e1fd0f8a',
        subjectName: 'Toán học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80',
        slotIndex: 3,
        slotStart: '09:05:00',
        slotEnd: '09:50:00'
      },
      {
        subjectID: '50d08f10-a2b8-4119-8053-e95f00cdf608',
        subjectName: 'Ngữ văn',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'e8b4217f-5a6c-4428-9901-99e62ce1f562',
        slotIndex: 4,
        slotStart: '09:55:00',
        slotEnd: '10:40:00'
      },
      {
        subjectID: '631135bd-81eb-4b70-a779-418af291d138',
        subjectName: 'Vật lý',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '4ebda95f-f406-43d2-a88b-be2b1ddbe1b5',
        slotIndex: 5,
        slotStart: '10:45:00',
        slotEnd: '11:30:00'
      }
    ]
  },
  {
    dayOfWeek: 2,
    periodName: 'Sáng',
    sessionID: '02505d8c-8c01-4734-b79c-a053e9c86f9d',
    slotDetails: [
      {
        subjectID: '77faf4ba-c356-4633-9505-91e4c8402800',
        subjectName: 'Lịch sử',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'db1085ce-9ba3-4894-a8a0-d417bc6b0774',
        slotIndex: 1,
        slotStart: '07:00:00',
        slotEnd: '07:45:00'
      },
      {
        subjectID: '94aa1b88-0fb0-4669-a7d7-73793e453e94',
        subjectName: 'Hóa học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '0811126b-4fb3-4e29-b0f6-94b00bf0b98b',
        slotIndex: 2,
        slotStart: '08:00:00',
        slotEnd: '08:45:00'
      },
      {
        subjectID: '2a739d2f-6b40-4fe4-8cf3-6b2c47967a55',
        subjectName: 'Ngoại ngữ',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80',
        slotIndex: 3,
        slotStart: '09:05:00',
        slotEnd: '09:50:00'
      },
      {
        subjectID: 'c2d3b555-0cf4-4b41-8131-a4c205d9a6f5',
        subjectName: 'HĐTN-HN',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'e8b4217f-5a6c-4428-9901-99e62ce1f562',
        slotIndex: 4,
        slotStart: '09:55:00',
        slotEnd: '10:40:00'
      },
      {
        subjectID: 'd3d3b555-0cf4-4b41-8131-a4c205d9a6f6',
        subjectName: 'GDKT-PL',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '4ebda95f-f406-43d2-a88b-be2b1ddbe1b5',
        slotIndex: 5,
        slotStart: '10:45:00',
        slotEnd: '11:30:00'
      }
    ]
  },
  {
    dayOfWeek: 3,
    periodName: 'Sáng',
    sessionID: '6c6b00cc-1030-4029-aaf5-299019bd303d',
    slotDetails: [
      {
        subjectID: '4e943f72-a5ee-427f-9594-83598d33f411',
        subjectName: 'Thể dục',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'db1085ce-9ba3-4894-a8a0-d417bc6b0774',
        slotIndex: 1,
        slotStart: '07:00:00',
        slotEnd: '07:45:00'
      },
      {
        subjectID: '4e943f72-a5ee-427f-9594-83598d33f411',
        subjectName: 'Thể dục',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '0811126b-4fb3-4e29-b0f6-94b00bf0b98b',
        slotIndex: 2,
        slotStart: '08:00:00',
        slotEnd: '08:45:00'
      },
      {
        subjectID: '50d08f10-a2b8-4119-8053-e95f00cdf608',
        subjectName: 'Ngữ văn',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80',
        slotIndex: 3,
        slotStart: '09:05:00',
        slotEnd: '09:50:00'
      },
      {
        subjectID: '50d08f10-a2b8-4119-8053-e95f00cdf608',
        subjectName: 'Ngữ văn',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'e8b4217f-5a6c-4428-9901-99e62ce1f562',
        slotIndex: 4,
        slotStart: '09:55:00',
        slotEnd: '10:40:00'
      }
    ]
  },
  {
    dayOfWeek: 3,
    periodName: 'Chiều',
    sessionID: '6be09935-4ba1-42e2-9ccc-ab66fe1569a3',
    slotDetails: [
      {
        subjectID: '94aa1b88-0fb0-4669-a7d7-73793e453e94',
        subjectName: 'Hóa học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'c5b67725-545f-4edd-8198-05bedcb5b00f',
        slotIndex: 6,
        slotStart: '14:00:00',
        slotEnd: '14:45:00'
      },
      {
        subjectID: '94aa1b88-0fb0-4669-a7d7-73793e453e94',
        subjectName: 'Hóa học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '9495ef71-051d-4e1b-9de3-31fa6d238252',
        slotIndex: 7,
        slotStart: '14:55:00',
        slotEnd: '13:40:00'
      },
      {
        subjectID: '52e87219-4d5c-4d96-a944-a04292e2f617',
        subjectName: 'Địa lý',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '79e57c6a-fae8-42b4-a460-b48447e3e076',
        slotIndex: 8,
        slotStart: '15:50:00',
        slotEnd: '16:35:00'
      }
    ]
  },
  {
    dayOfWeek: 4,
    periodName: 'Sáng',
    sessionID: '2246a4b5-1dc9-4b8b-a6ea-f4e3d2635249',
    slotDetails: [
      {
        subjectID: '631135bd-81eb-4b70-a779-418af291d138',
        subjectName: 'Vật lý',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'db1085ce-9ba3-4894-a8a0-d417bc6b0774',
        slotIndex: 1,
        slotStart: '07:00:00',
        slotEnd: '07:45:00'
      },
      {
        subjectID: '631135bd-81eb-4b70-a779-418af291d138',
        subjectName: 'Vật lý',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '0811126b-4fb3-4e29-b0f6-94b00bf0b98b',
        slotIndex: 2,
        slotStart: '08:00:00',
        slotEnd: '08:45:00'
      },
      {
        subjectID: 'c2d3b555-0cf4-4b41-8131-a4c205d9a6f5',
        subjectName: 'HĐTN-HN',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80',
        slotIndex: 3,
        slotStart: '09:05:00',
        slotEnd: '09:50:00'
      },
      {
        subjectID: 'a3d3b555-0cf4-4b41-8131-a4c205d9a6f3',
        subjectName: 'Giáo dục quốc phòng',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'e8b4217f-5a6c-4428-9901-99e62ce1f562',
        slotIndex: 4,
        slotStart: '09:55:00',
        slotEnd: '10:40:00'
      }
    ]
  },
  {
    dayOfWeek: 5,
    periodName: 'Sáng',
    sessionID: '5abe297f-e351-4939-bded-ec538c595417',
    slotDetails: [
      {
        subjectID: '107f7c24-e063-4dfd-beb8-d955e1fd0f8a',
        subjectName: 'Toán học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'db1085ce-9ba3-4894-a8a0-d417bc6b0774',
        slotIndex: 1,
        slotStart: '07:00:00',
        slotEnd: '07:45:00'
      },
      {
        subjectID: '107f7c24-e063-4dfd-beb8-d955e1fd0f8a',
        subjectName: 'Toán học',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '0811126b-4fb3-4e29-b0f6-94b00bf0b98b',
        slotIndex: 2,
        slotStart: '08:00:00',
        slotEnd: '08:45:00'
      },
      {
        subjectID: '2a739d2f-6b40-4fe4-8cf3-6b2c47967a55',
        subjectName: 'Ngoại ngữ',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'b2e5cc3b-f6f2-427e-9d9e-1f44ee8d2e80',
        slotIndex: 3,
        slotStart: '09:05:00',
        slotEnd: '09:50:00'
      },
      {
        subjectID: '2a739d2f-6b40-4fe4-8cf3-6b2c47967a55',
        subjectName: 'Ngoại ngữ',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'e8b4217f-5a6c-4428-9901-99e62ce1f562',
        slotIndex: 4,
        slotStart: '09:55:00',
        slotEnd: '10:40:00'
      }
    ]
  },
  {
    dayOfWeek: 5,
    periodName: 'Chiều',
    sessionID: 'd1f42050-c53b-45bf-8473-ebc14c01d4b7',
    slotDetails: [
      {
        subjectID: '52e87219-4d5c-4d96-a944-a04292e2f617',
        subjectName: 'Địa lý',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: 'c5b67725-545f-4edd-8198-05bedcb5b00f',
        slotIndex: 6,
        slotStart: '14:00:00',
        slotEnd: '14:45:00'
      },
      {
        subjectID: 'd3d3b555-0cf4-4b41-8131-a4c205d9a6f6',
        subjectName: 'GDKT-PL',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '9495ef71-051d-4e1b-9de3-31fa6d238252',
        slotIndex: 7,
        slotStart: '14:55:00',
        slotEnd: '13:40:00'
      },
      {
        subjectID: 'e4d3b555-0cf4-4b41-8131-a4c205d9a6f7',
        subjectName: 'SHCN',
        teacherID: 'fc90f501-75fd-4a4e-84bf-cdcbca4e6d5d',
        teacherName: 'Nguyễn Văn A',
        slotID: '79e57c6a-fae8-42b4-a460-b48447e3e076',
        slotIndex: 8,
        slotStart: '15:50:00',
        slotEnd: '16:35:00'
      }
    ]
  }
];

const StudentSchedulePage = () => {
  const navigate = useNavigate();
  const [getUserMutation] = useGetUserMutation();
  const [classroomID, setClassroomID] = useState<UUID>();
  const [classScheduleID, setClassScheduleID] = useState<UUID>();
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  const [weeklyTimeTable, setWeeklyTimeTable] = useState<DayInSchedule[]>([]);

  const someDate = new Date();
  const monday = getMonday(someDate);

  const getUser = async () => {
    const token = Cookies.get('accessToken');
    if (token) {
      const userResponse = await getUserMutation({
        accessToken: token
      }).unwrap();
      setClassroomID(userResponse.classroomID);
      return userResponse;
    } else {
      navigate('/login');
    }
  };

  useEffect(() => {
    getUser();
  }, []);

  // const { data: classScheduleDetails } = useGetScheduleDetailQuery(getScheduleDetailId());

  // Call the class schedule query when classroomID is available
  const { data: classSchedule, isLoading: isClassScheduleLoading } =
    useGetClassScheduleQuery(classroomID!, {
      skip: !classroomID // Skip the query until classroomID is available
    });

  useEffect(() => {
    if (classSchedule && classSchedule.length > 0) {
      setClassScheduleID(classSchedule[0].id);
    }
  }, [classSchedule]); // Run when classSchedule is updated

  // Call the schedule detail query when classScheduleID is available
  const { data: classScheduleDetails, isLoading: isScheduleDetailLoading } =
    useGetScheduleDetailQuery(classScheduleID!, {
      skip: !classScheduleID // Skip the query until classScheduleID is available
    });

  // console.log(classScheduleID);

  useEffect(() => {
    if (classScheduleDetails) {
      setScheduleDetail(classScheduleDetails);
    }
  }, [classScheduleDetails]);

  useEffect(() => {
    if (scheduleDetails) {
      const currentMonday = getMonday(new Date());

      // Nhóm các session theo dayOfWeek
      const groupedByDay = scheduleDetails.sessions.reduce((acc: any, item: any) => {
        if (!acc[item.dayOfWeek]) {
          acc[item.dayOfWeek] = [];
        }
        acc[item.dayOfWeek].push(item);
        return acc;
      }, {});

      // Tạo mảng DayInSchedule[] và làm phẳng
      const timeTb: DayInSchedule[] = Object.keys(groupedByDay).flatMap(dayOfWeek => {
        const sessionsForDay = groupedByDay[dayOfWeek];

        // Lặp qua từng session và slot, trả về các đối tượng DayInSchedule
        const res = sessionsForDay.flatMap((session: any) => {
          return session.slotDetails.map((slot: any) => {
            const item: DayInSchedule = {
              title: slot.subjectName,
              start: combineDateAndTime(currentMonday.toISOString(), slot.slotStart),
              end: combineDateAndTime(currentMonday.toISOString(), slot.slotEnd)
            };
            return item;
          });
        });
        currentMonday.setDate(currentMonday.getDate() + 1);

        return res;
      });

      setWeeklyTimeTable(timeTb);
    }
  }, [scheduleDetails]);
  const eventStyleGetter = (event: any, start: any, end: any, isSelected: boolean) => {
    let backgroundColor = '#3f51b5'; // Default color
    // if (event.title === 'Toán học') {
    //   backgroundColor = '#f57c00'; // Màu cam cho môn Toán
    // } else if (event.title === 'Lịch sử') {
    //   backgroundColor = '#3f51b5'; // Màu xanh cho môn Lịch sử
    // }

    return {
      style: {
        backgroundColor,
        color: 'white', // Màu chữ
        borderRadius: '5px',
        border: '0px',
        display: 'block',
        fontSize: '10px'
      }
    };
  };

  const EventComponent = ({ event }: { event: any }) => (
    <span>
      <strong>{event.title}</strong>
      <br />
      {moment(event.start).format('HH:mm')} - {moment(event.end).format('HH:mm')}{' '}
    </span>
  );

  return (
    <Row className='m-2'>
      <Col
        className='my-2'
        sm={12}
      >
        <h4>Thời khóa biểu lớp: {scheduleDetails ? scheduleDetails.className : ''}</h4>
      </Col>
      <Calendar
        localizer={localizer}
        events={weeklyTimeTable}
        startAccessor='start'
        endAccessor='end'
        style={{ height: 'inherit' }}
        views={['week']} // Show only the week view
        defaultView='week'
        eventPropGetter={eventStyleGetter} // Sử dụng eventPropGetter để áp dụng style
        messages={{
          today: 'Hôm nay',
          previous: 'Tuần trước',
          next: 'Tuần tiếp theo'
        }}
        min={new Date(2023, 1, 1, 6, 0, 0)}
        // components={{
        //   event: EventComponent // Áp dụng component tùy chỉnh cho sự kiện
        // }}
      />
    </Row>
  );
};

export default StudentSchedulePage;
