import { Divider, Link } from '@mui/material';
import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import OtpInput, { InputProps } from 'react-otp-input';
import classNames from 'classnames/bind';
import styles from '../../ForgetPassword.module.scss';
import { Form, Input } from 'antd';
import { useValidOTPMutation } from '@/services/forgetPassword';
import { IForgetPasswordProps } from '../..';
import { useEffect, useState } from 'react';

const cx = classNames.bind(styles);

const SendOTP = (
  props: IForgetPasswordProps & {
    usenameOrEmail: string;
    setAccountID: (value: string) => void;
  }
) => {
  const { forgetState, setForgetState, usenameOrEmail, setAccountID } = props;
  const [getValidOTP] = useValidOTPMutation();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [otp, setOtp] = useState<string>('');

  const [error, setError] = useState<string>('');

  useEffect(() => {
    setError('');
  }, []);

  const handleSuccess = () => {
    setForgetState(2);
  };

  const handleSubmit = async () => {
    const payload = {
      usernameOrEmail: usenameOrEmail,
      code: otp
    };

    setError('');
    setIsLoading(true);
    try {
      const response = await getValidOTP(payload);
      if (response && response.data) {
        setAccountID(response.data.accountID);
        handleSuccess();
      } else {
        const errorMessage = (response.error as any)?.data?.message?.toString() ?? '';
        setError(errorMessage);
      }
    } catch (error) {
      setError('Mã OTP không đúng');
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
            Chúng tôi đã gửi mã OTP đến email của bạn
          </span>
        </div>

        <Form onFinish={handleSubmit}>
          <Form.Item
            name={'usernameOrEmail'}
            className={cx('my-4 mx-2')}
            rules={[
              { required: true, message: 'Vui lòng nhập đầy đủ OTP' },
              {
                validator: (_, value) =>
                  value && value.length === 6
                    ? Promise.resolve()
                    : Promise.reject(new Error('OTP phải có 6 chữ số'))
              }
            ]}
          >
            <OtpInput
              value={otp}
              onChange={otp => setOtp(otp)}
              numInputs={6}
              renderSeparator={<span>-</span>}
              shouldAutoFocus={true}
              inputStyle={{
                border: '1px solid gray',
                borderRadius: '8px',
                width: '46px',
                height: '46px',
                fontSize: '18px',
                color: '#000',
                fontWeight: '400',
                caretColor: 'blue',
                justifyContent: 'space-between'
              }}
              renderInput={props => <input {...props} />}
              containerStyle={{ justifyContent: 'space-between' }}
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

export default SendOTP;
