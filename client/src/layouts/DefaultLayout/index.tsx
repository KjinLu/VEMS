import { Col, Row } from 'reactstrap';
import Header from '../components/Header';
import Sidebar from '../components/Sidebar';
import styles from './DefaultLayout.module.scss';
import classNames from 'classnames/bind';
import { ReactElement } from 'react';

type DefaultLayoutProps = {
  children: ReactElement;
};

const cx = classNames.bind(styles);

const DefaultLayout = ({ children }: DefaultLayoutProps) => {
  return (
    <div className={cx('wrapper')}>
      <Header />
      <Row className={cx('container')}>
        <Col sm={3}>
          <Sidebar />
        </Col>
        <Col
          md={9}
          className={cx('content')}
        >
          {children}
        </Col>
      </Row>
    </div>
  );
};

export default DefaultLayout;
