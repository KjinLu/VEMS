import { Divider, Link } from '@mui/material';
import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import classNames from 'classnames/bind';
import styles from '../../ForgetPassword.module.scss';
import { Form } from 'antd';
import { useRecoveryMutation } from '@/services/forgetPassword';
import { IForgetPasswordProps } from '../..';
import { useEffect, useState } from 'react';
import { set } from 'react-hook-form';

const cx = classNames.bind(styles);

const SendRecoveredPassword = (
  props: IForgetPasswordProps & { setUsernameOrEmail: (value: string) => void }
) => {
  const { forgetState, setForgetState, setUsernameOrEmail } = props;

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');

  const [getForgetPassword] = useRecoveryMutation();

  useEffect(() => {
    setError('');
  }, []);

  const handleSuccess = () => {
    setForgetState(1);
  };

  const handleSubmit = async (values: any) => {
    const payload = {
      usernameOrEmail: values.usernameOrEmail
    };

    setIsLoading(true);
    setError('');

    try {
      const response = await getForgetPassword(payload);
      if (response && response.data) {
        setUsernameOrEmail(values.usernameOrEmail);
        handleSuccess();
      } else {
        const errorMessage = (response.error as any)?.data?.message?.toString() ?? '';
        setError(errorMessage);
      }
    } catch (error) {
      setError('Tên đăng nhập không tồn tại');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <>
      <div className={cx('w-100')}>
        <div className={cx('d-flex justify-content-center flex-column mb-3')}>
          <h2 className={cx('forget-password-title', 'mb-0')}>Quên mật khẩu</h2>
          <span className={cx('forget-password-description', 'text-center pt-1')}>
            Nhập email hoặc username để lấy lại mật khẩu
          </span>
        </div>

        <Form onFinish={handleSubmit}>
          <Form.Item
            name={'usernameOrEmail'}
            className={cx('mb-3')}
            rules={[{ required: true, message: 'Vui lòng nhập tên đăng nhập' }]}
          >
            <VemInput
              id='usernameOrEmail'
              label='Tên đăng nhập'
              placeholder='Tên đăng nhập'
              // required
              fullWidth
              variant='outlined'
              size='medium'
              autoComplete='off'
            />
          </Form.Item>

          <div className='text-danger'>{error}</div>

          <VemButton
            className={cx('mt-2 mb-3')}
            loading={isLoading}
            status={'loading'}
            type={'submit'}
            children={'Xác nhận'}
            variant={'contained'}
            fullWidth={true}
          />
          <Divider
            color={'#5a5a5a'}
            className={cx('mx-2')}
          />
        </Form>
      </div>
    </>
  );
};

export default SendRecoveredPassword;
