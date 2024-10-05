import VemImage from '@/components/VemImage';
import Box from '@mui/material/Box';
import Icon from '@/assets/Icon.png';
import classNames from 'classnames/bind';
import styles from './Header.module.scss';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';
import { Avatar } from '@mui/material';

const cx = classNames.bind(styles);

const Header = () => {
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
            src={Icon}
            alt={''}
            className={cx('IconVems')}
            fallback={''}
          />
          <Typography
            variant='h6'
            noWrap
            component='div'
          >
            Vems
          </Typography>
        </Link>

        <div>
          <Avatar
            alt='Remy Sharp'
            src='/static/images/avatar/1.jpg'
          />
        </div>
      </Box>
    </>
  );
};

export default Header;
