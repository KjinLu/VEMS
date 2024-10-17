import className from 'classnames/bind';
import styles from './StudentSchedule.module.scss';

import React, { useEffect, useState } from 'react';
import Scheduler, { Resource, View } from 'devextreme-react/scheduler';
import 'devextreme/dist/css/dx.light.css';

import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';

const currentDate = new Date();

// Function to get the current week's Monday
const getCurrentWeekMonday = () => {
  const today = new Date();
  const dayOfWeek = today.getDay(); // Sunday - Saturday : 0 - 6
  const mondayOffset = dayOfWeek === 0 ? -6 : 1; // If Sunday, go back 6 days
  const currentMonday = new Date(today);
  currentMonday.setDate(today.getDate() - (dayOfWeek - mondayOffset));
  currentMonday.setHours(0, 0, 0, 0); // Set time to 00:00:00
  return currentMonday;
};

// Function to generate appointments for the schedule
const generateAppointments = (startDate: any) => {
  const appointments: any[] = [];

  // Assuming classes start from 7:00 AM for 5 periods in the morning and a few in the afternoon
  const classTimes = [
    // Monday (Thứ 2)
    { subject: 'SHDC', period: 1, dayOffset: 0, startHour: 7, startMinute: 0 },
    { subject: 'Toán', period: 2, dayOffset: 0, startHour: 7, startMinute: 50 },
    { subject: 'Toán', period: 3, dayOffset: 0, startHour: 8, startMinute: 40 },
    { subject: 'Văn', period: 4, dayOffset: 0, startHour: 9, startMinute: 30 },
    { subject: 'Lí', period: 5, dayOffset: 0, startHour: 10, startMinute: 20 },
    // Afternoon classes
    { subject: 'Hóa', period: 1, dayOffset: 1, startHour: 13, startMinute: 0 },
    { subject: 'Hóa', period: 2, dayOffset: 1, startHour: 13, startMinute: 50 },
    { subject: 'Địa', period: 3, dayOffset: 1, startHour: 14, startMinute: 40 },

    // Tuesday (Thứ 3)
    { subject: 'Sử', period: 1, dayOffset: 1, startHour: 7, startMinute: 0 },
    { subject: 'Hóa', period: 2, dayOffset: 1, startHour: 7, startMinute: 50 },
    { subject: 'N.Ngữ', period: 3, dayOffset: 1, startHour: 8, startMinute: 40 },
    { subject: 'HĐTN-HN', period: 4, dayOffset: 1, startHour: 9, startMinute: 30 },
    { subject: 'GDQP', period: 5, dayOffset: 1, startHour: 10, startMinute: 20 },

    // Wednesday (Thứ 4)
    { subject: 'TD', period: 1, dayOffset: 2, startHour: 7, startMinute: 0 },
    { subject: 'TD', period: 2, dayOffset: 2, startHour: 7, startMinute: 50 },
    { subject: 'Văn', period: 3, dayOffset: 2, startHour: 8, startMinute: 40 },
    { subject: 'HĐTN-HN', period: 4, dayOffset: 2, startHour: 9, startMinute: 30 },
    { subject: 'N.Ngữ', period: 5, dayOffset: 2, startHour: 10, startMinute: 20 },

    // Thursday (Thứ 5)
    { subject: 'Lí', period: 1, dayOffset: 3, startHour: 7, startMinute: 0 },
    { subject: 'Lí', period: 2, dayOffset: 3, startHour: 7, startMinute: 50 },
    { subject: 'N.Ngữ', period: 3, dayOffset: 3, startHour: 8, startMinute: 40 },
    { subject: 'N.Ngữ', period: 4, dayOffset: 3, startHour: 9, startMinute: 30 },
    { subject: 'GDQP', period: 5, dayOffset: 3, startHour: 10, startMinute: 20 },

    // Friday (Thứ 6)
    { subject: 'Toán', period: 1, dayOffset: 4, startHour: 7, startMinute: 0 },
    { subject: 'Toán', period: 2, dayOffset: 4, startHour: 7, startMinute: 50 },
    { subject: 'N.Ngữ', period: 3, dayOffset: 4, startHour: 8, startMinute: 40 },
    { subject: 'N.Ngữ', period: 4, dayOffset: 4, startHour: 9, startMinute: 30 },
    { subject: 'GDQP', period: 5, dayOffset: 4, startHour: 10, startMinute: 20 }
  ];

  // Generate appointments based on class times
  classTimes.forEach(({ subject, dayOffset, startHour, startMinute }) => {
    const startDateTime = new Date(startDate);
    startDateTime.setDate(startDate.getDate() + dayOffset);
    startDateTime.setHours(startHour, startMinute);

    const endDateTime = new Date(startDateTime);
    endDateTime.setMinutes(endDateTime.getMinutes() + 45); // Assuming each class is 45 minutes

    appointments.push({
      text: subject,
      startDate: startDateTime,
      endDate: endDateTime
    });
  });

  return appointments;
};

const localizer = momentLocalizer(moment);
const cx = className.bind(styles);
const Appointments = [
  // Monday
  {
    title: 'SHDC',
    start: new Date(2024, 9, 7, 7, 0),
    end: new Date(2024, 9, 7, 7, 50)
  },
  {
    title: 'Toán',
    start: new Date(2024, 9, 7, 7, 50),
    end: new Date(2024, 9, 7, 8, 40)
  },
  {
    title: 'N.Ngữ',
    start: new Date(2024, 9, 7, 8, 40),
    end: new Date(2024, 9, 7, 9, 30)
  },
  {
    title: 'Văn',
    start: new Date(2024, 9, 7, 9, 30),
    end: new Date(2024, 9, 7, 10, 20)
  },
  {
    title: 'Lí',
    start: new Date(2024, 9, 7, 10, 20),
    end: new Date(2024, 9, 7, 11, 10)
  },

  // Tuesday
  {
    title: 'Hóa',
    start: new Date(2024, 9, 8, 7, 0),
    end: new Date(2024, 9, 8, 7, 50)
  },
  {
    title: 'Hóa',
    start: new Date(2024, 9, 8, 7, 50),
    end: new Date(2024, 9, 8, 8, 40)
  },
  {
    title: 'TD',
    start: new Date(2024, 9, 8, 8, 40),
    end: new Date(2024, 9, 8, 9, 30)
  },
  {
    title: 'N.Ngữ',
    start: new Date(2024, 9, 8, 9, 30),
    end: new Date(2024, 9, 8, 10, 20)
  },

  // Wednesday
  {
    title: 'Văn',
    start: new Date(2024, 9, 9, 7, 0),
    end: new Date(2024, 9, 9, 7, 50)
  },
  {
    title: 'N.Ngữ',
    start: new Date(2024, 9, 9, 7, 50),
    end: new Date(2024, 9, 9, 8, 40)
  },
  {
    title: 'HĐTN-HN',
    start: new Date(2024, 9, 9, 9, 30),
    end: new Date(2024, 9, 9, 10, 20)
  },

  // Thursday
  {
    title: 'TD',
    start: new Date(2024, 9, 10, 7, 0),
    end: new Date(2024, 9, 10, 7, 50)
  },
  {
    title: 'HĐTN-HN',
    start: new Date(2024, 9, 10, 8, 40),
    end: new Date(2024, 9, 10, 9, 30)
  },

  // Friday
  {
    title: 'Lí',
    start: new Date(2024, 9, 11, 10, 20),
    end: new Date(2024, 9, 11, 11, 10)
  },

  // Saturday
  {
    title: 'GDQP',
    start: new Date(2024, 9, 12, 8, 0),
    end: new Date(2024, 9, 12, 8, 50)
  },
  {
    title: 'N.Ngữ',
    start: new Date(2024, 9, 12, 9, 0),
    end: new Date(2024, 9, 12, 9, 50)
  },

  // Sunday
  {
    title: 'Địa',
    start: new Date(2024, 9, 13, 8, 0),
    end: new Date(2024, 9, 13, 8, 50)
  },
  {
    title: 'SHCN',
    start: new Date(2024, 9, 13, 9, 0),
    end: new Date(2024, 9, 13, 9, 50)
  }
];

const StudentSchedulePage = () => {
  const currentMonday = getCurrentWeekMonday(); // Get the Monday of the current week
  // const Appointments = generateAppointments(currentMonday);

  const { data, error, isLoading, refetch } = useGetClassScheduleQuery(
    'afab05ef-e3e7-4902-a141-05c3057b92f3'
  );

  useEffect(() => {
    if (data) {
      console.log('Class schedule data:', data);
    }
  }, [data]);

  return (
    // <Scheduler
    //   editing={false}
    //   dataSource={Appointments}
    //   defaultCurrentDate={currentDate}
    //   startDayHour={6}
    //   endDayHour={18}
    //   height='inherit'
    // >
    //   <View
    //     type='week'
    //     name='Weekly View'
    //   />
    //   <View
    //     type='workWeek'
    //     name='Work Week'
    //   />
    // </Scheduler>

    <>
      <button onClick={refetch}>abc</button>
      <Calendar
        localizer={localizer}
        events={Appointments}
        startAccessor='start'
        endAccessor='end'
        style={{ height: 'inherit' }}
        views={['week']} // Show only the week view
        defaultView='week'
        // selectable // Make it selectable
        onSelectEvent={event => alert(event.title)} // Handle event clicks
        onSelectSlot={slotInfo => alert(`Selected slot: ${slotInfo.start}`)} // Handle slot selections
      />
    </>
  );
};

export default StudentSchedulePage;
function useGetClassScheduleQuery(arg0: string): {
  data: any;
  error: any;
  isLoading: any;
  refetch: any;
} {
  throw new Error('Function not implemented.');
}
