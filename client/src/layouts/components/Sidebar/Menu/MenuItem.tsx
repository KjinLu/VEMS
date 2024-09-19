import { NavLink } from 'react-router-dom';
import classNames from 'classnames/bind';
import styles from './Menu.module.scss';
import { ReactElement } from 'react';

type MenuItemProps = {
  title: string;
  to: string;
  icon: ReactElement;
  activeIcon: ReactElement;
};

const cx = classNames.bind(styles);

function MenuItem({ title, to, icon, activeIcon }: MenuItemProps) {
  return (
    <NavLink
      className={nav =>
        cx('menu-item', {
          active: nav.isActive
        })
      }
      to={to}
    >
      <span className={cx('icon')}>{icon}</span>
      <span className={cx('active-icon')}>{activeIcon}</span>
      <span className={cx('title')}>{title}</span>
    </NavLink>
  );
}

export default MenuItem;
