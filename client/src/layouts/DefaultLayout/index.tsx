import Header from '../components/Header';
import Sidebar from '../components/Sidebar';
import styles from './DefaultLayout.module.scss';
import classNames from 'classnames/bind';
import { ReactElement } from 'react';

type DefaultLayoutProps = {
  children: ReactElement;
};

const cx = classNames.bind(styles);

function DefaultLayout({ children }: DefaultLayoutProps) {
  return (
    <div className={cx('wrapper')}>
      <Header />
      <div className={cx('container')}>
        <Sidebar />
        <div className={cx('content')}>{children}</div>
      </div>
    </div>
  );
}

export default DefaultLayout;
