import { Divider, Link } from '@mui/material';
import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import OtpInput, { InputProps } from 'react-otp-input';
import classNames from 'classnames/bind';
import styles from '../../ForgetPassword.module.scss';
import { Form, Input } from 'antd';
import {
  useChangePasswordMutation,
  useValidOTPMutation
} from '@/services/forgetPassword';
import { IForgetPasswordProps } from '../..';
import { useState } from 'react';

const cx = classNames.bind(styles);

const ChangePassword = (props: IForgetPasswordProps & { accountID: string }) => {
  const { forgetState, setForgetState, accountID } = props;
  const [getChangePassword] = useChangePasswordMutation();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const [error, setError] = useState<string>('');

  const handleSuccess = () => {
    setForgetState(3);
  };

  const handleSubmit = async (values: any) => {
    const payload = {
      accountID: accountID,
      newPassword: values.newPassword
    };

    setError('');
    setIsLoading(true);
    try {
      const response = await getChangePassword(payload);
      if (response && response.data) {
        handleSuccess();
      } else {
        const errorMessage = (response.error as any)?.data?.message?.toString() ?? '';
        setError(errorMessage);
      }
    } catch (error) {
      setError('Có lỗi xảy ra');
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
            Nhập mật khẩu mới để tiếp tục
          </span>
        </div>

        <Form onFinish={handleSubmit}>
          <div className='col-lg-12 py-1'>
            <Form.Item
              name='newPassword'
              rules={[
                { required: true, message: 'Vui lòng nhập mật khẩu mới' }
                // { min: 8, message: 'M' }
              ]}
            >
              <VemInput
                label='Mật khẩu mới'
                id='newPassword'
                placeholder='Nhập mật khẩu mới'
                variant='outlined'
                type='password'
              />
            </Form.Item>
          </div>

          <div className='col-lg-12 py-1'>
            <Form.Item
              name='confirmPassword'
              dependencies={['newPassword']}
              rules={[
                { required: true, message: 'Vui lòng nhập xác nhận mật khẩu' },
                ({ getFieldValue }) => ({
                  validator(_, value) {
                    if (!value || getFieldValue('newPassword') === value) {
                      return Promise.resolve();
                    }
                    return Promise.reject(new Error('Mật khẩu không khớp'));
                  }
                })
              ]}
            >
              <VemInput
                label='Xác nhận mật khẩu'
                id='confirmPassword'
                placeholder='Xác nhận mật khẩu mới'
                variant='outlined'
                type='password'
              />
            </Form.Item>
          </div>

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

export default ChangePassword;
