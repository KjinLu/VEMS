import classNames from 'classnames/bind';

import styles from './Sidebar.module.scss';
import Menu from '../../../components/VemButton';
import { HomeIcon, HomeActiveIcon } from '../../../components/Icons';
import MenuItem from '../Sidebar/Menu/MenuItem';
import configRoutes from '../../../constants/routes';

const cx = classNames.bind(styles);

const Sidebar = () => {
  return (
    <aside className={cx('wrapper')}>
      <Menu>
        <MenuItem
          title='HomePage'
          to={configRoutes.home}
          icon={<HomeIcon />}
          activeIcon={<HomeActiveIcon />}
        />
      </Menu>
    </aside>
  );
};

export default Sidebar;
