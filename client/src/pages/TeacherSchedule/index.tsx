import { RootState } from '@/libs/state/store';
import { useGetUserMutation } from '@/services/auth';
import { useGetTeacherScheduleDetailQuery } from '@/services/schedule';
import { formatDate } from '@/utils/dateFormat';
import { Paper } from '@mui/material';
import { Col, Row } from 'antd';
import { UUID } from 'crypto';
import moment from 'moment';
import { useEffect, useState } from 'react';
import { Calendar, momentLocalizer, Views } from 'react-big-calendar';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';

const localizer = momentLocalizer(moment);

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
const TeacherSchedulePage = () => {
  const navigate = useNavigate();
  const [getUserMutation] = useGetUserMutation();
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  const [weeklyTimeTable, setWeeklyTimeTable] = useState<DayInSchedule[]>([]);
  const userClassInfo = useSelector((state: RootState) => state.auth.accountID);
  const [currentMonday, setCurrentMonday] = useState(getMonday(new Date()));

  const {
    data: teacherScheduleDetails,
    isLoading: teacherScheduleDetailsLoading,
    refetch: refetchSchedule
  } = useGetTeacherScheduleDetailQuery(userClassInfo! as UUID, {
    skip: !userClassInfo
  });

  useEffect(() => {
    if (teacherScheduleDetails) {
      setScheduleDetail(teacherScheduleDetails);
    }
  }, [teacherScheduleDetails]);

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
              title: slot.classname,
              start: combineDateAndTime(dayDate.toISOString(), slot.slotStart),
              end: combineDateAndTime(dayDate.toISOString(), slot.slotEnd)
            }));
          });
        });
        setWeeklyTimeTable(timeTb);
      };

      generateWeeklyTimeTable();
    }
  }, [scheduleDetails]);

  const handleNavigate = (date: any, view: any, action: any) => {
    if (view === Views.WEEK) {
      let newMonday;

      if (action === 'NEXT') {
        newMonday = new Date(currentMonday);
        newMonday.setDate(newMonday.getDate() + 7); // Chuyển sang Thứ Hai của tuần kế tiếp
      } else if (action === 'PREV') {
        newMonday = new Date(currentMonday);
        newMonday.setDate(newMonday.getDate() - 7); // Chuyển về Thứ Hai của tuần trước
      } else if (action === 'TODAY') {
        newMonday = getMonday(new Date()); // Lấy Thứ Hai của tuần hiện tại
      }

      // Đảm bảo rằng newMonday luôn là Thứ Hai
      if (newMonday && newMonday.getDay() !== 1) {
        newMonday = getMonday(newMonday);
      }

      if (newMonday) {
        setCurrentMonday(newMonday);
        refetchSchedule(); // Gọi lại API để lấy dữ liệu lịch của tuần mới
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
      <h4 className='w-100 text-center'>Lịch Giảng Dạy</h4>
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
    </Paper>
  );
};

export default TeacherSchedulePage;
