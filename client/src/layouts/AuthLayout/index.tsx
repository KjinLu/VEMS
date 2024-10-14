import FloatingShape from '@/components/FloatingShape';
import classNames from 'classnames/bind';
import { ReactElement } from 'react';
import styles from './AuthLayout.module.scss';
import zIndex from '@mui/material/styles/zIndex';

const cx = classNames.bind(styles);

type AuthProps = {
  children: ReactElement;
};

const AuthLayout = ({ children }: AuthProps) => {
  return (
    <>
      <div
        className={cx(
          'auth-container',
          'd-flex justify-content-center align-items-center position-relative overflow-hidden'
        )}
      >
        <div style={{ zIndex: 2 }}>{children}</div>
        <FloatingShape
          color='#00BFFF'
          width='20rem'
          height='20rem'
          top={'-5%'}
          left={'10%'}
          delay={0}
        />
        <FloatingShape
          color='#1E90FF'
          width='16rem'
          height='16rem'
          top={'70%'}
          left={'80%'}
          delay={5}
        />
        <FloatingShape
          color='#87CEEB'
          width='12rem'
          height='12rem'
          top={'40%'}
          left={'-10%'}
          delay={2}
        />
      </div>
    </>
  );
};

export default AuthLayout;
