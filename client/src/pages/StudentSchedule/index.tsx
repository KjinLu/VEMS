import className from 'classnames/bind';
import styles from './StudentSchedule.module.scss';
import { useEffect, useState } from 'react';
import { useGetClassScheduleQuery, useGetScheduleDetailQuery } from '@/services/schedule';
import { Calendar, momentLocalizer, View, Views } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { Col, Row } from 'reactstrap';
import { useGetUserMutation } from '@/services/auth';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';
import { UUID } from 'crypto';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import { Paper } from '@mui/material';
import { formatDate } from '@/utils/dateFormat';

const localizer = momentLocalizer(moment);
const cx = className.bind(styles);

type DayInSchedule = {
  title: string;
  start: Date;
  end: Date;
};

const getMonday = (date: Date) => {
  const day = date.getDay();
  const diff = day === 0 ? 1 : 1 - day; // Nếu là Chủ Nhật (0), thì diff là 1 để lấy Thứ Hai của tuần hiện tại
  const monday = new Date(date);
  monday.setDate(date.getDate() + diff);
  return monday;
};

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
  const [currentMonday, setCurrentMonday] = useState(getMonday(new Date()));

  // Gọi query khi classroomID có giá trị
  const { data: classSchedule, isLoading: isClassScheduleLoading } =
    useGetClassScheduleQuery(userClassInfo as UUID, {
      skip: !userClassInfo
    });

  useEffect(() => {
    if (classSchedule && classSchedule.length > 0) {
      setClassScheduleID(classSchedule[0].id);
    }
  }, [classSchedule]);

  const {
    data: classScheduleDetails,
    isLoading: isScheduleDetailLoading,
    refetch: refetchSchedule
  } = useGetScheduleDetailQuery(classScheduleID!, {
    skip: !classScheduleID
  });

  useEffect(() => {
    if (classScheduleDetails) {
      setScheduleDetail(classScheduleDetails);
    }
  }, [classScheduleDetails]);

  useEffect(() => {
    if (scheduleDetails) {
      // Tạo lịch cho tuần dựa trên currentMonday
      const generateWeeklyTimeTable = () => {
        const monday = new Date(currentMonday);

        // Nhóm các session theo dayOfWeek
        const groupedByDay = scheduleDetails.sessions.reduce((acc: any, item: any) => {
          if (!acc[item.dayOfWeek]) {
            acc[item.dayOfWeek] = [];
          }
          acc[item.dayOfWeek].push(item);
          return acc;
        }, {});

        // Tạo mảng DayInSchedule[]
        const timeTb: DayInSchedule[] = Object.keys(groupedByDay).flatMap(dayOfWeek => {
          const sessionsForDay = groupedByDay[dayOfWeek];
          const dayDate = new Date(monday);
          dayDate.setDate(monday.getDate() + parseInt(dayOfWeek) - 1); // Điều chỉnh ngày cho từng ngày trong tuần

          // Lặp qua từng session và slot, trả về các đối tượng DayInSchedule
          return sessionsForDay.flatMap((session: any) => {
            return session.slotDetails.map((slot: any) => ({
              title: slot.subjectName,
              start: combineDateAndTime(dayDate.toISOString(), slot.slotStart),
              end: combineDateAndTime(dayDate.toISOString(), slot.slotEnd)
            }));
          });
        });

        setWeeklyTimeTable(timeTb);
      };

      generateWeeklyTimeTable();
    }
  }, [scheduleDetails, currentMonday]);

  const handleNavigate = (date: any, view: any, action: any) => {
    if (view === Views.WEEK) {
      let newMonday;

      if (action === 'NEXT') {
        newMonday = new Date(currentMonday);
        newMonday.setDate(currentMonday.getDate() + 7); // Chuyển tới tuần tiếp theo
      } else if (action === 'PREV') {
        newMonday = new Date(currentMonday);
        newMonday.setDate(currentMonday.getDate() - 7); // Quay lại tuần trước
      } else if (action === 'TODAY') {
        newMonday = getMonday(new Date()); // Lấy ngày thứ Hai của tuần hiện tại
      }

      if (newMonday) {
        setCurrentMonday(newMonday);
        refetchSchedule();
      }
    }
  };

  const eventStyleGetter = (event: any, start: any, end: any, isSelected: boolean) => {
    let backgroundColor = '#1976d2';
    return {
      style: {
        backgroundColor,
        color: 'white', // Màu chữ
        borderRadius: '5px',
        border: '0px',
        display: 'block',
        fontSize: '12px'
      }
    };
  };

  return (
    <Paper className='p-3'>
      <Row className='m-2'>
        <Col
          className='my-2'
          sm={12}
        >
          <h4>Thời khóa biểu lớp: {scheduleDetails ? scheduleDetails.className : ''}</h4>
          <h4>Hiệu lực từ: {scheduleDetails ? formatDate(scheduleDetails.time) : ''}</h4>
        </Col>
        <Calendar
          localizer={localizer}
          events={weeklyTimeTable}
          views={['week']}
          startAccessor='start'
          endAccessor='end'
          style={{ height: 'inherit' }}
          // views={['week']} // Show only the week view
          defaultView='week'
          eventPropGetter={eventStyleGetter}
          // messages={{
          //   today: 'Hôm nay',
          //   previous: 'Trước',
          //   next: 'Tiếp theo',
          //   week: 'Tuần',
          //   day: 'Ngày'
          // }}
          components={{
            toolbar: () => <div />
          }}
          min={new Date(2023, 1, 1, 6, 0, 0)}
          // onNavigate={handleNavigate}
        />
      </Row>
    </Paper>
  );
};

export default StudentSchedulePage;
