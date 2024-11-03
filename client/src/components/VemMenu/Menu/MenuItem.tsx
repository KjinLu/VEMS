import classNames from 'classnames/bind';

import styles from './Menu.module.scss';
import VemButton from '../../VemButton';
import { useNavigate } from 'react-router-dom';

type MenuItemProps = {
  data: any;
  onClick?: (event: any) => void;
};

const cx = classNames.bind(styles);

const MenuItem = ({ data, onClick }: MenuItemProps) => {
  const navigate = useNavigate();

  return (
    <VemButton
      className={cx('menu-item', {
        separate: data.separate
      })}
      leftIcon={data.icon}
      onClick={() => {
        navigate(data.to);
        onClick;
      }}
      title={data.title}
    ></VemButton>
  );
};

export default MenuItem;
