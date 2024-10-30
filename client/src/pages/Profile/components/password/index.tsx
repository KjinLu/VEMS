import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import { RootState } from '@/libs/state/store';
import {
  useChangeStudentPasswordMutation,
  useChangeTeacherPasswordMutation
} from '@/services/profile';
import { Box } from '@mui/material';
import { Form } from 'antd';
import { useSelector } from 'react-redux';
import { toast } from 'react-toastify';

const ResetPassword = () => {
  const userInfo = useSelector((state: RootState) => state.auth);
  const [form] = Form.useForm();
  const [changeTeacherPassword] = useChangeTeacherPasswordMutation();
  const [changeStudentPassword] = useChangeStudentPasswordMutation();

  const handleSubmit = async () => {
    try {
      const formData = {
        accountID: userInfo.accountID,
        oldPassword: form.getFieldValue('currentPassword'),
        newPassword: form.getFieldValue('newPassword')
      };

      if (userInfo.roleName === 'STUDENT') {
        const res = await changeStudentPassword(formData).unwrap();
        if (res) {
          toast.success('Đổi mật khẩu thành công!');
        }
      } else if (userInfo.roleName === 'TEACHER') {
        const res = await changeTeacherPassword(formData).unwrap();
        if (res) {
          toast.success('Đổi mật khẩu thành công!');
        }
      }
    } catch (e: any) {
      toast.error('Đổi mật khẩu thất bại! \n' + e.data.message);
    }
  };

  return (
    <>
      <Box sx={{ padding: { lg: '0 180px', xs: '0' } }}>
        <Form
          form={form}
          onFinish={handleSubmit}
        >
          <div className='row'>
            <div className='col-lg-12 px-3 py-2'>{/* <h5>Đặt lại mật khẩu</h5> */}</div>

            <div className='col-lg-12 px-3 py-2'>
              <Form.Item
                name='currentPassword'
                rules={[{ required: true, message: 'Vui lòng nhập mật khẩu hiện tại' }]}
              >
                <VemInput
                  label='Mật khẩu hiện tại'
                  id='currentPassword'
                  placeholder='Nhập mật khẩu hiện tại'
                  variant='outlined'
                  type='password'
                />
              </Form.Item>
            </div>

            <div className='col-lg-12 px-3 py-2'>
              <Form.Item
                name='newPassword'
                rules={[
                  { required: true, message: 'Vui lòng nhập mật khẩu mới' },
                  { min: 8, message: 'Mật khẩu phải có ít nhất 8 ký tự' }
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

            <div className='col-lg-12 px-3 py-2'>
              <Form.Item
                name='confirmPassword'
                dependencies={['newPassword']}
                rules={[
                  { required: true, message: 'Vui lòng xác nhận mật khẩu mới' },
                  ({ getFieldValue }) => ({
                    validator(_, value) {
                      if (!value || getFieldValue('newPassword') === value) {
                        return Promise.resolve();
                      }
                      return Promise.reject(new Error('Mật khẩu không trùng khớp'));
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

            <Box
              sx={{
                display: 'flex',
                justifyContent: { xs: 'center', md: 'flex-end' },
                alignItems: { xs: 'center', md: 'flex-start' }
              }}
            >
              <VemButton
                className='mt-2 mb-3'
                // loading={isLoading}
                type='submit'
                children='Đổi mật khẩu'
                variant='contained'
              />
            </Box>
          </div>
        </Form>
      </Box>
    </>
  );
};

export default ResetPassword;
