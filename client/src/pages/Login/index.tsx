import classNames from 'classnames/bind';
import { motion } from 'framer-motion';
import styles from './SignIn.module.scss';
import VemInput from '@/components/VemInput';
import VemButton from '@/components/VemButton';
import VemImage from '@/components/VemImage';
import logo from '@/assets/Logo.png';
import { Divider, Link } from '@mui/material';
import { Form } from 'antd';
import { useLogin } from '@/hooks/login/useLogin';
const cx = classNames.bind(styles);

const Login = () => {
  const { login, isLoading, error } = useLogin();

  const handleSubmit = async (values: any) => {
    const userData = {
      username: values.username,
      password: values.password
    };

    await login(userData);
  };

  const baseURL = import.meta.env.VITE_PUBLIC_API || '';

  console.log(baseURL);

  return (
    <>
      <div className={cx('p-3')}>
        <motion.div
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          className={cx(
            'sign-in-container',
            'overflow-hidden w-100 d-flex justify-content-center align-items-center flex-column'
          )}
        >
          <VemImage
            src={logo}
            alt={'logo'}
            className={cx('logo-image')}
            fallback={logo}
          />

          <div className={cx('w-100')}>
            <div className={cx('d-flex justify-content-center flex-column mb-3')}>
              <h2 className={cx('sign-in-title', 'mb-0')}>Chào mừng trở lại</h2>
              <span className={cx('sign-in-description', 'text-center pt-1')}>
                Nhập thông tin đăng nhập để tiếp tục
              </span>
            </div>

            <Form onFinish={handleSubmit}>
              <Form.Item
                name={'username'}
                className={cx('mb-3')}
                rules={[{ required: true, message: 'Vui lòng nhập tên đăng nhập' }]}
              >
                <VemInput
                  id='username'
                  label='Tên đăng nhập'
                  placeholder='Tên đăng nhập'
                  // required
                  fullWidth
                  variant='outlined'
                  size='medium'
                  autoComplete='off'
                />
              </Form.Item>

              <Form.Item
                name={'password'}
                className={cx('mb-2')}
                rules={[{ required: true, message: 'Vui lòng nhập mật khẩu' }]}
              >
                <VemInput
                  id='password'
                  label='Mật khẩu'
                  type='password'
                  placeholder='Mật khẩu'
                  // required
                  fullWidth
                  variant='outlined'
                  size='medium'
                  autoComplete='off'
                />
              </Form.Item>

              <div className='text-danger'>{error}</div>

              <div className='d-flex justify-content-end py-1'>
                {/* <div style={{ marginLeft: '-10px' }}>
                  <VemCheckbox
                    checked={false}
                    checkedIcon={''}
                  />
                  Keep me logged in
                </div> */}

                <div className={'d-flex align-items-center'}>
                  <Link
                    href='/signUp'
                    color='inherit'
                  >
                    Quên mật khẩu?
                  </Link>
                </div>
              </div>

              <VemButton
                className={cx('mt-2 mb-3')}
                loading={isLoading}
                status={'loading'}
                type={'submit'}
                children={'Đăng nhập'}
                variant={'contained'}
                fullWidth={true}
              />
              <Divider
                color={'#5a5a5a'}
                className={cx('mx-2')}
              />
            </Form>
          </div>

          {/* <div className='mt-3'>
            <Link
              onClick={() => navigate('/signUp')}
              color='inherit'
            >
              Don't have an account
            </Link>
          </div> */}
        </motion.div>
      </div>
    </>
  );
};

export default Login;
