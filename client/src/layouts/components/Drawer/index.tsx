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

// add more items to the list
const listItemButtonClasses: DrawerItem[] = [
  {
    content: 'Inbox',
    Icon: <InboxIcon />,
    onClick: () => {}
  }
];

interface DrawerProps {
  showIcon: boolean;
}

const VemDrawer = (props: DrawerProps) => {
  const { showIcon } = props;

  return (
    <>
      <div>
        <Toolbar />
        <Divider />
        <List>
          {listItemButtonClasses.map((item, index) => (
            <ListItem
              key={item.content}
              disablePadding
            >
              <ListItemButton
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
