import classNames from 'classnames/bind';
import styles from './Menu.module.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronLeft } from '@fortawesome/free-solid-svg-icons';

type HeaderProps = {
  title: string;
  onClick?: (event: any) => void;
};

const cx = classNames.bind(styles);

const Header = ({ title, onClick }: HeaderProps) => {
  return (
    <header
      className={cx('header')}
      onClick={onClick}
    >
      <button className={cx('back-btn')}>
        <FontAwesomeIcon icon={faChevronLeft} />
      </button>
      <h4 className={cx('header-title')}>{title}</h4>
    </header>
  );
};

export default Header;
