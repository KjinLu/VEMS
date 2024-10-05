import classNames from 'classnames/bind';
import { motion } from 'framer-motion';
import styles from './SignIn.module.scss';
import VemInput from '@/components/VemInput';
import VemButton from '@/components/VemButton';
import VemImage from '@/components/VemImage';
import logo from '@/assets/Logo.png';
import VemCheckbox from '@/components/VemCheckbox';
import { Divider, Link } from '@mui/material';
import { Form } from 'antd';
import { useNavigate } from 'react-router-dom';
const cx = classNames.bind(styles);

const SignInPage = () => {
  const navigate = useNavigate();
  const handleSubmit = (values: any) => {
    console.log(values);
  };

  return (
    <>
      <div className={cx('p-3')}>
        <motion.div
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          className={cx(
            'signInContainer',
            'overflow-hidden w-100 d-flex justify-content-center align-items-center flex-column'
          )}
        >
          <VemImage
            src={logo}
            alt={'logo'}
            className={cx('logoImage')}
            fallback={logo}
          />

          <div className={cx('w-100')}>
            <div className={cx('d-flex justify-content-center flex-column mb-3')}>
              <h2 className={cx('signInTitle', 'mb-0')}>Hi, Welcome Back</h2>
              <span className={cx('signInDescription', 'text-center pt-1')}>
                Enter your credentials to continue
              </span>
            </div>

            <Form onFinish={handleSubmit}>
              <Form.Item
                name={'username'}
                className={cx('mb-3')}
              >
                <VemInput
                  id='username'
                  label='Username'
                  placeholder='Enter your username'
                  // required
                  fullWidth
                  variant='outlined'
                  size='medium'
                />
              </Form.Item>

              <Form.Item
                name={'password'}
                className={cx('mb-2')}
              >
                <VemInput
                  id='password'
                  label='Password'
                  type='password'
                  placeholder='Enter your password'
                  // required
                  fullWidth
                  variant='outlined'
                  size='medium'
                />
              </Form.Item>

              <div className='d-flex justify-content-between'>
                <div style={{ marginLeft: '-10px' }}>
                  <VemCheckbox
                    checked={false}
                    checkedIcon={''}
                  />
                  Keep me logged in
                </div>

                <div className={'d-flex align-items-center'}>
                  <Link
                    href='/signUp'
                    color='inherit'
                  >
                    Forgot Password?
                  </Link>
                </div>
              </div>

              <VemButton
                className={cx('mt-2 mb-3')}
                // loading={isLoading}
                status={'loading'}
                type={'submit'}
                children={'Submit'}
                variant={'contained'}
                fullWidth={true}
              />
              <Divider
                color={'#5a5a5a'}
                className={cx('mx-2')}
              />
            </Form>
          </div>

          <div className='mt-3'>
            <Link
              onClick={() => navigate('/signUp')}
              color='inherit'
            >
              Don't have an account
            </Link>
          </div>
        </motion.div>
      </div>
    </>
  );
};

export default SignInPage;
