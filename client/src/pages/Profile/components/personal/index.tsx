import VemButton from '@/components/VemButton';
import VemInput from '@/components/VemInput';
import { RootState } from '@/libs/state/store';
import { useGetStudentProfileQuery } from '@/services/profile';
import { Box } from '@mui/material';
import { Form } from 'antd';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

const Personal = () => {
  const [form] = Form.useForm();
  const user = useSelector((state: RootState) => state.auth);

  const { data: dataStudent } = useGetStudentProfileQuery(user.accountID || '');

  useEffect(() => {
    if (dataStudent) {
      console.log('User:', dataStudent);
      form.setFieldsValue({
        ID: dataStudent.publicStudentID,
        name: dataStudent.fullName,
        email: dataStudent.email,
        phone: dataStudent.phone,
        classRoom: dataStudent.classRoom
      });
    }
  }, [dataStudent]);

  return (
    <>
      <Box>
        <Form form={form}>
          <div className='row'>
            <div className='col-md-6 px-3'>
              <Form.Item name='ID'>
                <VemInput
                  label='ID'
                  id={'ID'}
                  placeholder='Nhập ID'
                  disabled
                  variant='standard'
                  value={form.getFieldValue('name')}
                  onChange={e => form.setFieldsValue({ ID: e.target.value })}
                />
              </Form.Item>
            </div>

            <div className='col-md-6 px-3'>
              <Form.Item name='classRoom'>
                <VemInput
                  label='Lớp'
                  id={'phone'}
                  placeholder='Nhập lớp'
                  disabled
                  variant='standard'
                  value={form.getFieldValue('classRoom')}
                  onChange={e => form.setFieldsValue({ phone: e.target.value })}
                />
              </Form.Item>
            </div>

            <div className='col-md-6 px-3'>
              <Form.Item name='name'>
                <VemInput
                  label='Họ và tên'
                  id={'name'}
                  placeholder='Nhập họ và tên'
                  variant='standard'
                  value={form.getFieldValue('name')}
                  onChange={e => form.setFieldsValue({ name: e.target.value })}
                />
              </Form.Item>
            </div>

            <div className='col-md-6 px-3'>
              <Form.Item name='email'>
                <VemInput
                  label='Email'
                  id={'email'}
                  placeholder='Nhập họ và tên'
                  variant='standard'
                  value={form.getFieldValue('email')}
                  onChange={e => form.setFieldsValue({ email: e.target.value })}
                />
              </Form.Item>
            </div>

            <div className='col-md-6 px-3'>
              <Form.Item name='phone'>
                <VemInput
                  label='Số điện thoại'
                  id={'phone'}
                  placeholder='Nhập số điện thoại'
                  variant='standard'
                  value={form.getFieldValue('phone')}
                  onChange={e => form.setFieldsValue({ phone: e.target.value })}
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
                className={'mt-2 mb-3'}
                // loading={isLoading}
                status={'loading'}
                type={'submit'}
                children={'Cập nhật'}
                variant={'contained'}
              />
            </Box>
          </div>
        </Form>
      </Box>
    </>
  );
};

export default Personal;
