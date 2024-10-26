import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import { Box } from '@mui/material';
import { Form } from 'antd';

const ResetPassword = () => {

    

  return (
    <>
      <Box sx={{ padding: { lg: '0 180px', xs: '0' } }}>
        <Form
        //   form={form}
        //   onFinish={onFinish}
        >
          <div className='row'>
            <div className='col-lg-12 px-3 py-2'>{/* <h5>Reset Password</h5> */}</div>

            <div className='col-lg-12 px-3 py-2'>
              <Form.Item
                name='currentPassword'
                rules={[{ required: true, message: 'Current password is required' }]}
              >
                <VemInput
                  label='Current Password'
                  id='currentPassword'
                  placeholder='Enter current password'
                  variant='outlined'
                  type='password'
                />
              </Form.Item>
            </div>

            <div className='col-lg-12 px-3 py-2'>
              <Form.Item
                name='newPassword'
                rules={[
                  { required: true, message: 'New password is required' },
                  { min: 8, message: 'Password must be at least 8 characters' }
                ]}
              >
                <VemInput
                  label='New Password'
                  id='newPassword'
                  placeholder='Enter new password'
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
                  { required: true, message: 'Please confirm your password' },
                  ({ getFieldValue }) => ({
                    validator(_, value) {
                      if (!value || getFieldValue('newPassword') === value) {
                        return Promise.resolve();
                      }
                      return Promise.reject(new Error('Passwords do not match'));
                    }
                  })
                ]}
              >
                <VemInput
                  label='Confirm Password'
                  id='confirmPassword'
                  placeholder='Confirm new password'
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
                children='Reset Password'
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
