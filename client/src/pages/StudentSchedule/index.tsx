import className from 'classnames/bind';
import styles from './StudentSchedule.module.scss';
import { useEffect } from 'react';
import { useGetClassScheduleQuery, useGetScheduleDetailQuery } from '@/services/schedule';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { Row } from 'reactstrap';
import { useGetUserMutation } from '@/services/auth';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';

const localizer = momentLocalizer(moment);
const cx = className.bind(styles);

const Appointments: any = [];

const StudentSchedulePage = () => {
  const navigate = useNavigate();
  const [getUserMutation] = useGetUserMutation();

  const getUser = async () => {
    const token = Cookies.get('accessToken');

    if (token) {
      const userResponse = await getUserMutation({
        accessToken: token
      }).unwrap();

      console.log('tk', userResponse);
      return userResponse;
    } else {
      navigate('/login');
    }
  };

  useEffect(() => {
    getUser();
  }, []);
  // const userResponse = getUserMutation({
  //   accessToken:
  //     'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdiN…g4Mn0.q3ek_n8xTziKG-OQJQiFqrGjNGv976tppxZdF-etK2I'
  // });

  // const { data: scheduleData } = useGetClassScheduleQuery(
  //   'afab05ef-e3e7-4902-a141-05c3057b92f3'
  // );

  // const { data: detailSchedule } = useGetScheduleDetailQuery(
  //   '829e6f08-9f9b-43c8-128e-08dce2f046a9'
  // );

  // console.log('óahdas');
  // useEffect(() => {
  //   console.log(scheduleData);
  //   console.log(detailSchedule);
  // }, [scheduleData, detailSchedule]);

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
