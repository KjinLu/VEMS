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
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';

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

const StudentSchedulePage = () => {
  const navigate = useNavigate();
  const [getUserMutation] = useGetUserMutation();
  const [classScheduleID, setClassScheduleID] = useState<UUID>();
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  const [weeklyTimeTable, setWeeklyTimeTable] = useState<DayInSchedule[]>([]);
  const userClassInfo = useSelector((state: RootState) => state.auth.classroomID);

  const someDate = new Date();
  const monday = getMonday(someDate);

  // const { data: classScheduleDetails } = useGetScheduleDetailQuery(getScheduleDetailId());

  // Call the class schedule query when classroomID is available
  const { data: classSchedule, isLoading: isClassScheduleLoading } =
    useGetClassScheduleQuery(userClassInfo as UUID, {
      skip: !userClassInfo // Skip the query until classroomID is available
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
