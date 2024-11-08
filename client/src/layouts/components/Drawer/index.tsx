import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Divider from '@mui/material/Divider';
import Toolbar from '@mui/material/Toolbar';
import { DrawerItem } from '@/types/components/drawerType';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import EventAvailableIcon from '@mui/icons-material/EventAvailable';
import SupervisorAccountIcon from '@mui/icons-material/SupervisorAccount';
import PlagiarismIcon from '@mui/icons-material/Plagiarism';
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { configRoutes } from '@/constants/routes';
import { PiStudentBold } from 'react-icons/pi';
import MeetingRoomIcon from '@mui/icons-material/MeetingRoom';
import DateRangeIcon from '@mui/icons-material/DateRange';
import { GiTeacher } from 'react-icons/gi';
import { SiGoogleclassroom } from 'react-icons/si';
import { GrSchedules } from 'react-icons/gr';

// add more items to the list
const studentNavBar = (navigate: any): DrawerItem[] => [
  {
    id: 'STUDENT-SCHEDULE',
    content: 'Lịch học',
    Icon: <DateRangeIcon />,
    onClick: () => navigate(configRoutes.studentSchedule)
  },
  {
    id: 'STUDENT-TAKE-ATTENDANCE',
    content: 'Điểm danh',
    Icon: <EventAvailableIcon />,
    onClick: () => navigate(configRoutes.studentAttendanceSchedule)
  },
  {
    id: 'STUDENT-ATTENDANCE-REPORT',
    content: 'Báo cáo điểm danh',
    Icon: <PlagiarismIcon />,
    onClick: () => navigate(configRoutes.studentViewAttendance)
  }
];

const teacherNavBar = (navigate: any): DrawerItem[] => [
  {
    id: 'TEACHER-SCHEDULE',
    content: 'Lịch giảng dạy',
    Icon: <DateRangeIcon />,
    onClick: () => navigate(configRoutes.teacherSchedule)
  },
  {
    id: 'TEACHER-TAKE-ATTENDANCE',
    content: 'Điểm danh lớp',
    Icon: <EventAvailableIcon />,
    onClick: () => navigate(configRoutes.teacherAttendanceSchedule)
  },
  {
    id: 'TEACHER-CLASS-MANAGEMENT',
    content: 'Quản lí lớp chủ nhiệm',
    Icon: <SupervisorAccountIcon />,
    onClick: () => navigate(configRoutes.teacherClassManagement)
  }
  // {
  //   id: 'TEACHER-SCHEDULE-ALL',
  //   content: 'Lịch giảng dạy tổng',
  //   Icon: <CalendarMonthIcon />,
  //   onClick: () => navigate(configRoutes.teacherAllSchedule)
  // },
  // {
  //   id: 'TEACHER-CLASSES-LIST',
  //   content: 'Xem lớp',
  //   Icon: <MeetingRoomIcon />,
  //   onClick: () => navigate(configRoutes.teacherAllSchedule)
  // }
];

const adminNavBar = (navigate: any): DrawerItem[] => [
  {
    id: 'ADMIN-TEACHER-MANAGEMENT',
    content: 'Quản lí giáo viên',
    Icon: <GiTeacher />,
    onClick: () => navigate(configRoutes.TeacherManagementPage)
  },
  {
    id: 'ADMIN-STUDENT-MANAGEMENT',
    content: 'Quản lí học sinh',
    Icon: <PiStudentBold />,
    onClick: () => navigate(configRoutes.StudentManagementPage)
  },
  {
    id: 'ADMIN-CLASS-MANAGEMENT',
    content: 'Quản lí lớp',
    Icon: <SiGoogleclassroom />,
    onClick: () => navigate(configRoutes.ClassManagementPage)
  },
  {
    id: 'ADMIN-SCHEDULE-MANAGEMENT',
    content: 'Quản lí lịch học',
    Icon: <GrSchedules />,
    onClick: () => navigate(configRoutes.ScheduleManagementPage)
  }
];

interface DrawerProps {
  showIcon: boolean;
}

const VemDrawer = (props: DrawerProps) => {
  const navigate = useNavigate();
  const userAuth = useSelector((state: RootState) => state.auth);
  const { showIcon } = props;

  const navItems =
    userAuth.roleName === 'ADMIN'
      ? adminNavBar(navigate)
      : userAuth.roleName === 'TEACHER'
        ? teacherNavBar(navigate).filter(item => {
            if (userAuth.teacherType === 'PRIMARY_TEACHER') {
              return true;
            } else if (userAuth.teacherType != 'PRIMARY_TEACHER') {
              if (
                item.id === 'TEACHER-CLASS-MANAGEMENT' ||
                item.id === 'TEACHER-TAKE-ATTENDANCE'
              )
                return false;
              return true;
            }
          })
        : studentNavBar(navigate).filter(item => {
            if (
              userAuth.studentType === 'NORMAL_STUDENT' &&
              item.id === 'STUDENT-TAKE-ATTENDANCE'
            ) {
              return false;
            }
            return true;
          });

  // State for active nav item
  const [activeItem, setActiveItem] = useState(navItems[0].id); // Default to the first item

  return (
    <>
      <div>
        <Toolbar />
        <Divider />
        <List>
          {navItems.map((item, index) => (
            <ListItem
              key={item.content}
              disablePadding
            >
              <ListItemButton
                onClick={() => {
                  item.onClick();
                  setActiveItem(item.id);
                }}
                sx={[
                  {
                    minHeight: 48,
                    px: 2.5,
                    ...(activeItem === item.id && {
                      color: '#2473c2'
                    }) // Highlight active item
                  },
                  showIcon ? { justifyContent: 'initial' } : { justifyContent: 'center' }
                ]}
              >
                <ListItemIcon
                  sx={[
                    {
                      minWidth: 0,
                      justifyContent: 'center',
                      ...(activeItem === item.id && {
                        color: '#2473c2'
                      })
                    },
                    showIcon ? { mr: 3 } : { mr: 'auto' }
                  ]}
                >
                  {item.Icon}
                </ListItemIcon>
                <ListItemText
                  sx={[showIcon ? { opacity: 1 } : { opacity: 0 }]}
                  primary={item.content}
                />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </div>
    </>
  );
};

export default VemDrawer;
