import { useState, useEffect } from 'react';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import { Paper } from '@mui/material';
import { useGetAllTeacherScheduleDetailQuery } from '@/services/schedule';

const localizer = momentLocalizer(moment);

type DayInSchedule = {
  title: string;
  start: Date;
  end: Date;
};

const getMonday = (date: Date) => {
  const day = date.getDay();
  const diff = day === 0 ? 1 : 1 - day;
  const monday = new Date(date);
  monday.setDate(date.getDate() + diff);
  return monday;
};

function combineDateAndTime(dateInput: string, timeInput: string): Date {
  const date = new Date(dateInput);
  const [hours, minutes, seconds] = timeInput.split(':').map(Number);
  date.setHours(hours);
  date.setMinutes(minutes);
  date.setSeconds(seconds);
  return date;
}

const colors = ['#1976d2', '#d29e19', '#d28319', '#cb4953', '#8e24aa'];
const generateRandomColor = () => {
  const randomIndex = Math.floor(Math.random() * colors.length);
  return colors[randomIndex];
};
const getColorForTeacher = (teacherID: string, colorMap: Record<string, string>) => {
  if (!colorMap[teacherID]) {
    const colorIndex = Object.keys(colorMap).length % colors.length;
    colorMap[teacherID] = colors[colorIndex];
  }
  return colorMap[teacherID];
};

const TeacherAllSchedulePage = () => {
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  const [weeklyTimeTable, setWeeklyTimeTable] = useState<DayInSchedule[]>([]);
  const [currentMonday, setCurrentMonday] = useState(getMonday(new Date()));

  const {
    data: teacherAllScheduleDetails,
    isLoading: teacherScheduleDetailsLoading,
    refetch: refetchSchedule
  } = useGetAllTeacherScheduleDetailQuery(null);

  useEffect(() => {
    if (teacherAllScheduleDetails) {
      setScheduleDetail(teacherAllScheduleDetails);
    }
  }, [teacherAllScheduleDetails]);

  useEffect(() => {
    if (scheduleDetails) {
      const monday = new Date(currentMonday);
      const colorMap: Record<string, string> = {};

      // Combine schedules for all teachers
      const timeTb: DayInSchedule[] = scheduleDetails.pageData.flatMap((teacher: any) => {
        return teacher.sessions.flatMap((session: any) => {
          const dayDate = new Date(monday);
          dayDate.setDate(monday.getDate() + session.dayOfWeek - 1);

          return session.slotDetails.map((slot: any) => {
            if (!colorMap[teacher.teacherID]) {
              colorMap[teacher.teacherID] = generateRandomColor();
            }
            const eventColor = colorMap[teacher.teacherID]; // Get the assigned color

            return {
              title: `${teacher.teacherName} - ${slot.classname}`,
              start: combineDateAndTime(dayDate.toISOString(), slot.slotStart),
              end: combineDateAndTime(dayDate.toISOString(), slot.slotEnd),
              teacherID: teacher.teacherID,
              color: eventColor // Add the color to the event
            };
          });
        });
      });
      setWeeklyTimeTable(timeTb);
    }
  }, [scheduleDetails, currentMonday]);

  const eventStyleGetter = (event: any) => {
    const colorMap: Record<string, string> = {};
    const backgroundColor = getColorForTeacher(event.teacherID, colorMap);
    return {
      style: {
        backgroundColor,
        color: 'white',
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
        defaultView='week'
        eventPropGetter={eventStyleGetter}
        components={{ toolbar: () => <div /> }}
        min={new Date(2023, 1, 1, 6, 0, 0)}
      />
    </Paper>
  );
};

export default TeacherAllSchedulePage;
