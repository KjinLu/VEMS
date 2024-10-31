import classNames from 'classnames/bind';
import VemImage from '@/components/VemImage';
import { motion } from 'framer-motion';
import styles from './ForgetPassword.module.scss';
import logo from '@/assets/Logo.png';
import { useEffect, useState } from 'react';
import SendRecoveredPassword from './components/SendRecoveredPassword';
import { Divider } from '@mui/material';
import SendOTP from './components/SendOTP';
import ChangePassword from './components/ChangePassword';
import { Link } from 'react-router-dom';
import SuccessComp from './components/Success';

const cx = classNames.bind(styles);

export interface IForgetPasswordProps {
  forgetState: number;
  setForgetState: (value: number) => void;
}

const ForgetPassword = () => {
  const [forgetState, setForgetState] = useState<number>(0);
  const [usernameOrEmail, setUsernameOrEmail] = useState<string>('');
  const [accountID, setAccountID] = useState<string>('');

  return (
    <>
      <div className={cx('p-3')}>
        <motion.div
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          className={cx(
            'forget-password-container',
            'overflow-hidden w-100 d-flex justify-content-center align-items-center flex-column'
          )}
        >
          <VemImage
            src={logo}
            alt={'logo'}
            className={cx('logo-image')}
            fallback={logo}
          />
          {forgetState === 0 && (
            <SendRecoveredPassword
              setUsernameOrEmail={setUsernameOrEmail}
              forgetState={forgetState}
              setForgetState={setForgetState}
            />
          )}
          {forgetState === 1 && (
            <SendOTP
              setAccountID={setAccountID}
              usenameOrEmail={usernameOrEmail}
              forgetState={forgetState}
              setForgetState={setForgetState}
            />
          )}
          {forgetState === 2 && (
            <ChangePassword
              accountID={accountID}
              forgetState={forgetState}
              setForgetState={setForgetState}
            />
          )}
          {forgetState === 3 && <SuccessComp />}
          {/* <div className='mt-3'>
            <Link
              onClick={() => navigate('/signUp')}
              color='inherit'
            >
              Don't have an account
            </Link>
          </div> */}
          <span className='mt-2'>
            Trở lại <Link to={'/login'}>đăng nhập</Link>
          </span>
        </motion.div>
      </div>
    </>
  );
};

export default ForgetPassword;
