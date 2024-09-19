import classNames from 'classnames/bind';
import styles from './VemMenu.module.scss';

type WrapperProps = {
  children: React.ReactNode;
  className: string;
};

const cx = classNames.bind(styles);

function Wrapper({ children, className }: WrapperProps) {
  return <div className={cx('wrapper', className)}>{children}</div>;
}

export default Wrapper;
