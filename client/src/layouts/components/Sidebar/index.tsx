import classNames from 'classnames/bind';

import styles from './Sidebar.module.scss';
import Menu from './Menu/Menu';
import { HomeIcon, HomeActiveIcon } from '../../../components/Icons';
import MenuItem from '../Sidebar/Menu/MenuItem';
import configRoutes from '../../../constants/routes';

const cx = classNames.bind(styles);

const Sidebar = () => {
  return (
    <aside className={cx('sidebarWrapper')}>
      <Menu>
        <MenuItem
          title='Trang chủ'
          to={configRoutes.home}
          icon={<HomeIcon />}
          activeIcon={<HomeActiveIcon />}
        />
      </Menu>
    </aside>
  );
};

export default Sidebar;
