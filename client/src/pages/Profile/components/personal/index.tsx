import VemButton from '@/components/VemButton';
import VemDatePicker from '@/components/VemDatePicker';
import VemInput from '@/components/VemInput';
import { IAdminProfile, useGetProfile } from '@/hooks/profile/useGetProfile';
import { RootState } from '@/libs/state/store';
import {
  IStudentProfile,
  ITeacherProfile,
  useUpdateStudentProfileMutation,
  useUpdateTeacherProfileMutation
} from '@/services/profile';
import { Box } from '@mui/material';
import { Form } from 'antd';
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import dayjs from 'dayjs';
import { toast } from 'react-toastify';
import { ShowNotify } from '@/utils/showNotify';

const Personal = () => {
  const [form] = Form.useForm();
  const user = useSelector((state: RootState) => state.auth);

  const { getProfile, refetchStudentProfile, refetchTeacherProfile, isLoading } =
    useGetProfile();
  const [updateStudent] = useUpdateStudentProfileMutation();
  const [updateTeacher] = useUpdateTeacherProfileMutation();

  const [profile, setProfile] = useState<
    IAdminProfile | ITeacherProfile | IStudentProfile | null
  >(null);

  useEffect(() => {
    const fetchProfile = async () => {
      const profileData = getProfile();
      setProfile(profileData);
    };

    fetchProfile();
  }, [getProfile]);

  useEffect(() => {
    if (profile) {
      if ('publicStudentID' in profile) {
        form.setFieldsValue({
          ID: profile.publicStudentID,
          name: profile.fullName ?? '',
          email: profile.email,
          phone: profile.phone,
          classRoom: profile.classRoom,
          citizenID: profile.citizenID,
          dob: profile.dob,
          address: profile.address,
          parentPhone: profile.parentPhone,
          homeTown: profile.homeTown,
          unionJoinDate: profile.unionJoinDate
        });
      } else if ('publicTeacherID' in profile) {
        form.setFieldsValue({
          ID: profile.publicTeacherID,
          name: profile.fullName ?? '',
          email: profile.email,
          phone: profile.phone,
          classRoom: profile.classRoom,
          citizenID: profile.citizenID,
          dob: profile.dob,
          address: profile.address
        });
      }
    }
  }, [profile, form]);

  const onFinish = async (values: any) => {
    try {
      if (profile) {
        if ('publicStudentID' in profile) {
          const res = await updateStudent({
            studentId: profile.id,
            fullName: values.name,
            citizenID: values.citizenID,
            email: values.email,
            dob: dayjs(values.dob).format('YYYY-MM-DD'),
            address: values.address,
            phone: values.phone,
            parentPhone: values.parentPhone,
            homeTown: values.homeTown,
            unionJoinDate: dayjs(values.unionJoinDate).format('YYYY-MM-DD')
          }).unwrap();

          ShowNotify({
            statusCode: res,
            messageSuccess: 'Cập nhật thông tin thành công',
            messageError: 'Cập nhật thông tin thất bại',
            OnReLoad: refetchStudentProfile
          });
        } else if ('publicTeacherID' in profile) {
          const res = await updateTeacher({
            teacherId: profile.id,
            publicTeacherID: '',
            fullName: values.name,
            citizenID: values.citizenID,
            email: values.email,
            dob: dayjs(values.dob).format('YYYY-MM-DD'),
            address: values.address
          }).unwrap();

          ShowNotify({
            statusCode: res,
            messageSuccess: 'Cập nhật thông tin thành công',
            messageError: 'Cập nhật thông tin thất bại',
            OnReLoad: refetchTeacherProfile
          });
        }
      }
    } catch (err) {
      toast.error('Cập nhật thông tin thất bại');
    }
  };

  return (
    <>
      <Box>
        <Form
          form={form}
          onFinish={onFinish}
        >
          <div className='row'>
            <div className='col-lg-6 px-3 py-2'>
              <Form.Item name='ID'>
                <VemInput
                  label='ID'
                  id={'ID'}
                  placeholder='Nhập ID'
                  disabled
                  variant='outlined'
                />
              </Form.Item>
            </div>

            <div className='col-lg-6 px-3 py-2'>
              <Form.Item name='classRoom'>
                <VemInput
                  label='Lớp'
                  id={'classRoom'}
                  placeholder='Nhập lớp'
                  disabled
                  variant='outlined'
                />
              </Form.Item>
            </div>

            <div className='col-lg-12 px-3 py-2'>
              <h5>Thông tin cá nhân</h5>
            </div>

            <div className='col-lg-6 px-3 py-2'>
              <Form.Item
                name='name'
                rules={[{ required: true, message: 'Họ và tên không được để trống' }]}
              >
                <VemInput
                  label='Họ và tên'
                  id='name'
                  placeholder='Nhập họ và tên'
                  variant='outlined'
                  disabled
                />
              </Form.Item>
            </div>

            <div className='col-lg-6 px-3 py-2'>
              <Form.Item
                name='dob'
                rules={[{ required: true, message: 'Ngày sinh không được để trống' }]}
              >
                <VemDatePicker
                  label='Ngày sinh'
                  id={'dob'}
                  placeholder='Nhập ngày sinh'
                />
              </Form.Item>
            </div>

            <div className='col-lg-12 px-3 py-2'>
              <h5>Thông tin liên hệ</h5>
            </div>
            <div className='col-lg-6 px-3 py-2'>
              <Form.Item
                name='email'
                rules={[
                  { required: true, message: 'Email không được để trống' },
                  { type: 'email', message: 'Email không hợp lệ' }
                ]}
              >
                <VemInput
                  label='Email'
                  id={'email'}
                  placeholder='Nhập email'
                  variant='outlined'
                />
              </Form.Item>
            </div>

            <div className='col-lg-6 px-3 py-2'>
              <Form.Item
                name='phone'
                rules={[
                  { required: true, message: 'Số điện thoại không được để trống' },
                  { pattern: /^[0-9]{10}$/, message: 'Số điện thoại phải gồm 10 chữ số' }
                ]}
              >
                <VemInput
                  label='Số điện thoại'
                  id={'phone'}
                  placeholder='Nhập số điện thoại'
                  variant='outlined'
                />
              </Form.Item>
            </div>

            {/* Student Specific Fields */}
            {profile && 'publicStudentID' in profile && (
              <>
                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='citizenID'>
                    <VemInput
                      label='Số CCCD'
                      id={'citizenID'}
                      placeholder='Nhập số CCCD'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>

                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='address'>
                    <VemInput
                      label='Địa chỉ'
                      id={'address'}
                      placeholder='Nhập địa chỉ'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>

                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item
                    name='parentPhone'
                    rules={[
                      {
                        required: true,
                        message: 'Số điện thoại phụ huynh không được để trống'
                      },
                      {
                        pattern: /^[0-9]{10}$/,
                        message: 'Số điện thoại phải gồm 10 chữ số'
                      }
                    ]}
                  >
                    <VemInput
                      label='Số điện thoại phụ huynh'
                      id={'parentPhone'}
                      placeholder='Nhập số điện thoại phụ huynh'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>

                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='homeTown'>
                    <VemInput
                      label='Quê quán'
                      id={'homeTown'}
                      placeholder='Nhập quê quán'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>

                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='unionJoinDate'>
                    <VemDatePicker
                      label='Ngày tham gia đoàn'
                      id={'unionJoinDate'}
                      placeholder='Nhập ngày tham gia đoàn'
                    />
                  </Form.Item>
                </div>
              </>
            )}

            {/* Teacher Specific Fields */}
            {profile && 'publicTeacherID' in profile && (
              <>
                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='citizenID'>
                    <VemInput
                      label='Số CCCD'
                      id={'citizenID'}
                      placeholder='Nhập số CCCD'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>

                <div className='col-lg-6 px-3 py-2'>
                  <Form.Item name='address'>
                    <VemInput
                      label='Địa chỉ'
                      id={'address'}
                      placeholder='Nhập địa chỉ'
                      variant='outlined'
                    />
                  </Form.Item>
                </div>
              </>
            )}

            <Box
              sx={{
                display: 'flex',
                justifyContent: { xs: 'center', md: 'flex-end' },
                alignItems: { xs: 'center', md: 'flex-start' }
              }}
            >
              <VemButton
                className={'mt-2 mb-3'}
                loading={isLoading}
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
