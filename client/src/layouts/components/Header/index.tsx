import VemImage from '@/components/VemImage';
import Box from '@mui/material/Box';
import Logo from '@/assets/LogoWhite.png';
import classNames from 'classnames/bind';
import styles from './Header.module.scss';
import Typography from '@mui/material/Typography';
import { Link, useNavigate } from 'react-router-dom';
import { Avatar, Divider, IconButton, ListItemIcon, Menu, MenuItem } from '@mui/material';

import AvatarDefault from '@/assets/images/personal/avatarDefault.jpg';

import { Logout, Settings, PersonRounded } from '@mui/icons-material';
import { useState } from 'react';
import { useLogout } from '@/hooks/logout/useLogout';
import { useSelector } from 'react-redux';
import { RootState } from '@/libs/state/store';

const cx = classNames.bind(styles);

const Header = () => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const navigate = useNavigate();
  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const userInfo = useSelector((state: RootState) => state.auth);

  const handleClose = () => {
    setAnchorEl(null);
    navigate('/profile');
  };

  const logout = useLogout();

  const handleLogout = () => {
    setAnchorEl(null);
    logout();
  };

  return (
    <>
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'row',
          justifyContent: 'space-between',
          width: '100%'
        }}
      >
        <Link
          to='#'
          className={cx('d-flex text-white text-decoration-none align-items-center')}
        >
          <VemImage
            src={Logo}
            alt={''}
            className={cx('IconVems')}
            fallback={''}
          />
          <Typography
            variant='h5'
            noWrap
            component='div'
          ></Typography>
        </Link>

        <div>
          <IconButton
            onClick={handleClick}
            size='small'
            sx={{ ml: 2 }}
            aria-controls={open ? 'account-menu' : undefined}
            aria-haspopup='true'
            aria-expanded={open ? 'true' : undefined}
          >
            <Avatar
              alt='Remy Sharp'
              src={
                userInfo.image && userInfo.image != '' ? userInfo.image : AvatarDefault
              }
            />
          </IconButton>

          <Menu
            anchorEl={anchorEl}
            id='account-menu'
            open={open}
            onClose={handleClose}
            onClick={handleClose}
            slotProps={{
              paper: {
                elevation: 0,
                sx: {
                  overflow: 'visible',
                  filter: 'drop-shadow(0px 2px 8px rgba(0,0,0,0.32))',
                  mt: 1.5,
                  '& .MuiAvatar-root': {
                    width: 32,
                    height: 32,
                    ml: -0.5,
                    mr: 1
                  },
                  '&::before': {
                    content: '""',
                    display: 'block',
                    position: 'absolute',
                    top: 0,
                    right: 14,
                    width: 10,
                    height: 10,
                    bgcolor: 'background.paper',
                    transform: 'translateY(-50%) rotate(45deg)',
                    zIndex: 0
                  }
                }
              }
            }}
            transformOrigin={{ horizontal: 'right', vertical: 'top' }}
            anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
          >
            <MenuItem onClick={handleClose}>
              <ListItemIcon>
                <PersonRounded fontSize='small' />
              </ListItemIcon>
              Hồ sơ của tôi
            </MenuItem>
            {/* <MenuItem onClick={handleClose}>
              <Avatar /> My account
            </MenuItem> */}
            <Divider />
            {/* <MenuItem onClick={handleClose}>
              <ListItemIcon>
                <PersonAdd fontSize='small' />
              </ListItemIcon>
              Add another account
            </MenuItem> */}
            <MenuItem onClick={handleClose}>
              <ListItemIcon>
                <Settings fontSize='small' />
              </ListItemIcon>
              Cài đặt
            </MenuItem>
            <MenuItem onClick={handleLogout}>
              <ListItemIcon>
                <Logout fontSize='small' />
              </ListItemIcon>
              Đăng xuất
            </MenuItem>
          </Menu>
        </div>
      </Box>
    </>
  );
};

export default Header;
