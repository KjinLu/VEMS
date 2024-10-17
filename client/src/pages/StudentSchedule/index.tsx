import className from 'classnames/bind';
import styles from './StudentSchedule.module.scss';
import { useEffect, useState } from 'react';
import { useGetClassScheduleQuery, useGetScheduleDetailQuery } from '@/services/schedule';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { Row } from 'reactstrap';
import { useGetUserMutation } from '@/services/auth';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';
import { UUID } from 'crypto';

const localizer = momentLocalizer(moment);
const cx = className.bind(styles);

const Appointments: any = [];

const StudentSchedulePage = () => {
  const navigate = useNavigate();
  const [getUserMutation] = useGetUserMutation();
  const [classroomID, setClassroomID] = useState<UUID>();
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  // const [classroomID, setClassroomID] = useState<UUID>();

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

  console.log(classroomID);

  useEffect(() => {
    if (classroomID) {
      const { data: scheduleData } = useGetClassScheduleQuery(classroomID);
      console.log(scheduleData);
    }
  }, [classroomID]);

  return (
    <Row className='m-2'>
      <Calendar
        localizer={localizer}
        events={Appointments}
        startAccessor='start'
        endAccessor='end'
        style={{ height: 'inherit' }}
        views={['week']} // Show only the week view
        defaultView='week'
        // // selectable // Make it selectable
        // onSelectEvent={event => alert(event)} // Handle event clicks
        // onSelectSlot={slotInfo => alert(`Selected slot: ${slotInfo.start}`)} // Handle slot selections
      />
    </Row>
  );
};

export default StudentSchedulePage;
