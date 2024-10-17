import InboxIcon from '@mui/icons-material/MoveToInbox';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
// import MailIcon from '@mui/icons-material/Mail';
import Divider from '@mui/material/Divider';
import Toolbar from '@mui/material/Toolbar';
import { DrawerItem } from '@/types/components/drawerType';
import { useSelector } from 'react-redux';
import { Role } from '@/types/auth/type';
import { RootState } from '@/libs/state/store';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import EventAvailableIcon from '@mui/icons-material/EventAvailable';
import PlagiarismIcon from '@mui/icons-material/Plagiarism';
import { useNavigate } from 'react-router-dom';

// add more items to the list
const listItemButtonClasses = (navigate: any): DrawerItem[] => [
  {
    content: 'Lịch học',
    Icon: <CalendarMonthIcon />,
    onClick: () => navigate('/student/schedule')
  },
  {
    content: 'Điểm danh',
    Icon: <EventAvailableIcon />,
    onClick: () => navigate('/student/attendance')
  },
  {
    content: 'Báo cáo điểm danh',
    Icon: <PlagiarismIcon />,
    onClick: () => navigate('/student/attendanceReport')
  }
];

interface DrawerProps {
  showIcon: boolean;
}

const VemDrawer = (props: DrawerProps) => {
  const navigate = useNavigate();
  const allowedRoles = useSelector((state: RootState) => state.auth.role as Role);

  const { showIcon } = props;

  const navItems = listItemButtonClasses(navigate);

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
              {/* Attach the onClick handler here */}
              <ListItemButton
                onClick={item.onClick} // This was missing
                sx={[
                  {
                    minHeight: 48,
                    px: 2.5
                  },
                  showIcon
                    ? { justifyContent: 'initial' }
                    : {
                        justifyContent: 'center'
                      }
                ]}
              >
                <ListItemIcon
                  sx={[
                    {
                      minWidth: 0,
                      justifyContent: 'center'
                    },
                    showIcon
                      ? {
                          mr: 3
                        }
                      : {
                          mr: 'auto'
                        }
                  ]}
                >
                  {item.Icon}
                </ListItemIcon>
                <ListItemText
                  sx={[
                    showIcon
                      ? {
                          opacity: 1
                        }
                      : {
                          opacity: 0
                        }
                  ]}
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
