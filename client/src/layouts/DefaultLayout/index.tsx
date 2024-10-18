import Box from '@mui/material/Box';
import { styled, Theme, CSSObject } from '@mui/material/styles';
import MuiDrawer, { DrawerProps as MuiDrawerProps } from '@mui/material/Drawer';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Toolbar from '@mui/material/Toolbar';
import MenuOpenIcon from '@mui/icons-material/MenuOpen';
import { ReactElement, useEffect, useState } from 'react';
import useMediaQuery from '@mui/material/useMediaQuery';
import className from 'classnames/bind';

import VemDrawer from '../components/Drawer';
import Header from '../components/Header';
import styles from './DefaultLayout.module.scss';

const cx = className.bind(styles);
const drawerWidthDefault = 240;

const openedMixin = (theme: Theme): CSSObject => ({
  width: drawerWidthDefault,
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.enteringScreen
  }),
  overflowX: 'hidden'
});

const closedMixin = (theme: Theme): CSSObject => ({
  transition: theme.transitions.create('width', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen
  }),
  overflowX: 'hidden',
  width: `calc(${theme.spacing(7)} + 1px)`,
  [theme.breakpoints.up('sm')]: {
    width: `calc(${theme.spacing(8)} + 1px)`
  }
});

interface AppBarProps extends MuiAppBarProps {
  openStatus?: boolean;
}

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: prop => prop !== 'open'
})<AppBarProps>(({ theme }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen
  }),
  variants: [
    {
      props: ({ openStatus }) => openStatus,
      style: {
        marginLeft: drawerWidthDefault,
        // width: `calc(100% - ${drawerWidthDefault}px)`,
        transition: theme.transitions.create(['width', 'margin'], {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.enteringScreen
        })
      }
    }
  ]
}));

interface DrawerProps extends MuiDrawerProps {
  openStatus?: boolean;
}

const Drawer = styled(MuiDrawer, {
  shouldForwardProp: prop => prop !== 'openStatus'
})<DrawerProps>(({ theme }) => ({
  width: drawerWidthDefault,
  flexShrink: 0,
  whiteSpace: 'nowrap',
  boxSizing: 'border-box',
  variants: [
    {
      props: ({ openStatus }) => openStatus,
      style: {
        ...openedMixin(theme),
        '& .MuiDrawer-paper': openedMixin(theme)
      }
    },
    {
      props: ({ openStatus }) => !openStatus,
      style: {
        ...closedMixin(theme),
        '& .MuiDrawer-paper': closedMixin(theme)
      }
    }
  ]
}));

type DrawerLayoutProps = {
  children: ReactElement;
};

export default function DrawerLayout({ children }: DrawerLayoutProps) {
  const [mobileOpen, setMobileOpen] = useState(false);
  const [isClosing, setIsClosing] = useState(false);

  // showIcon is used to show/hide the icon in the drawer
  const [showIcon, setShowIcon] = useState<boolean>(true);
  const [drawerWidth, setDrawerWidth] = useState<number>(drawerWidthDefault);

  // check responsive screen
  const isXsScreen = useMediaQuery((theme: Theme) => theme.breakpoints.down('sm'));

  useEffect(() => {
    if (isXsScreen && !showIcon) {
      handleShowIcon();
    }
  }, [isXsScreen]);

  const handleShowIcon = () => {
    setShowIcon(!showIcon);
    setDrawerWidth(!showIcon ? drawerWidthDefault : 56);
  };

  const handleDrawerClose = () => {
    setIsClosing(true);
    setMobileOpen(false);
  };

  const handleDrawerTransitionEnd = () => {
    setIsClosing(false);
  };

  const handleDrawerToggle = () => {
    if (!isClosing) {
      setMobileOpen(!mobileOpen);
    }
  };

  return (
    <>
      <Box sx={{ display: 'flex' }}>
        <AppBar
          position='fixed'
          sx={{ zIndex: theme => theme.zIndex.drawer + 1 }}
          openStatus={showIcon}
        >
          <div className='px-3'>
            <Toolbar>
              <IconButton
                color='inherit'
                aria-label='open drawer'
                edge='start'
                onClick={handleDrawerToggle}
                sx={{ mr: 2, display: { xs: 'block', sm: 'none' } }}
              >
                <MenuIcon />
              </IconButton>

              <IconButton
                color='inherit'
                aria-label='expend icon'
                edge='start'
                onClick={handleShowIcon}
                sx={{ mr: 2, display: { xs: 'none', sm: 'block' } }}
              >
                {showIcon ? <MenuIcon /> : <MenuOpenIcon />}
              </IconButton>

              <Header />
            </Toolbar>
          </div>
        </AppBar>

        <Box
          component='nav'
          sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 1 } }}
          aria-label='mailbox folders'
        >
          <Drawer
            variant='temporary'
            open={mobileOpen}
            onTransitionEnd={handleDrawerTransitionEnd}
            onClose={handleDrawerClose}
            ModalProps={{
              keepMounted: true
            }}
            sx={{
              display: { xs: 'block', sm: 'none' },
              flexShrink: 0,
              '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth }
            }}
          >
            <VemDrawer showIcon={showIcon} />
          </Drawer>

          <Drawer
            variant='permanent'
            sx={{
              display: { xs: 'none', sm: 'block' },
              flexShrink: 0,
              '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth }
            }}
            openStatus={showIcon}
          >
            <VemDrawer showIcon={showIcon} />
          </Drawer>
        </Box>

        <Box
          component='main'
          sx={{ flexGrow: 1, width: { sm: `calc(100% - ${drawerWidth}px)` } }}
        >
          <Toolbar />
          <div className={cx('body', 'p-5')}>{children}</div>
        </Box>
      </Box>
    </>
  );
}
