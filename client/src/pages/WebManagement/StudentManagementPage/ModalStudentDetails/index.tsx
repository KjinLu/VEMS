import { Col, Label, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import { SubmitHandler, useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { useEffect, useState } from 'react';

import styles from './ModalStudentDetails.module.scss';
import { AccountForm, IStudentProfile, StudentTableIndex } from '../type';
import {
  useGetStudentProfileQuery,
  useUpdateStudentProfileMutation
} from '@/services/adminManagement';
import VemImage from '@/components/VemImage';
import AvatarImage from '@/assets/images/avatar-test.jpg';
import VemsInputCus from '@/components/VemsInputCustom';
import { updateStudentAccount } from '../form-schemas';
import VemsButtonCus from '@/components/VemsButtonCustom';
import { toast } from 'react-toastify';
import { ApolloError } from '@apollo/client';

type ModalStudentDetailsProps = {
  accountData: StudentTableIndex;
  isOpen: boolean;
  toggleModal: () => void;
};

const cx = className.bind(styles);

const ModalStudentDetails = ({
  accountData,
  isOpen,
  toggleModal
}: ModalStudentDetailsProps) => {
  // console.log(accountData);
  // useState------------------------------------------------------------------------
  const [accountSelected, setAccountSelected] = useState<IStudentProfile | undefined>(
    undefined
  );

  // Query and Mutation -------------------------------------------------------------
  const { data: studentProfileData } = useGetStudentProfileQuery(accountData?.studentID);
  const [updateStudentProfile, { isLoading: isUpdateLoading }] =
    useUpdateStudentProfileMutation();

  //useEffect ----------------------------------------------------------------------
  useEffect(() => {
    setAccountSelected(studentProfileData);
  }, [studentProfileData]);

  console.log(accountSelected);
  // event ----------------------------------------------------------------------------
  const {
    control,
    handleSubmit,
    formState: { errors: updateAccountValidationErrors }
  } = useForm<AccountForm>({
    resolver: yupResolver(updateStudentAccount),
    values: {
      name: accountSelected?.fullName!,
      studentId: accountSelected?.publicStudentID!,
      studentType: accountSelected?.studentTypeName!,
      studentPhone: accountSelected?.phone!,
      parentPhone: accountSelected?.parentPhone!,
      cardId: accountSelected?.citizenID!,
      dateOfBirth: accountSelected?.dob!,
      dateOfUnion: accountSelected?.unionJoinDate!,
      address: accountSelected?.address!,
      hometown: accountSelected?.homeTown!,
      mail: accountSelected?.email!
    }
  });

  const onSubmitAccountForm: SubmitHandler<AccountForm> = accountFormData => {
    const {
      name,
      address,
      cardId,
      dateOfBirth,
      dateOfUnion,
      hometown,
      parentPhone,
      studentId,
      studentPhone,
      mail
    } = accountFormData;

    updateStudentProfile({
      fullName: name,
      citizenID: cardId,
      address: address,
      dob: dateOfBirth,
      email: mail!,
      homeTown: hometown,
      parentPhone,
      phone: studentPhone,
      studentId: studentId,
      unionJoinDate: dateOfUnion
    })
      .then(() => {
        // updateParentState();
        toggleModal();
        toast.success('Lưu thông tin thành công!');
      })
      .catch((error: ApolloError) => {
        toast.error(`Lưu thông tin thất bại!, ${error.message}`);
      });
  };

  return (
    <>
      <Modal
        isOpen={isOpen}
        className={cx('modal-wrapper')}
        size='xl'
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-student-title')}>
          Thông tin chi tiết học sinh
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={toggleModal}
        >
          <IoMdClose
            size={30}
            color='#ccc'
          />
        </div>

        {/* Modal content */}
        <div className={cx('modal-content')}>
          <div className={cx('line-break')}></div>

          <div className={cx('content-student-wrapper')}>
            <div className={cx('content-student')}>
              <h3 className={cx('title', 'student-name')}>
                Xem chi tiết hoặc chỉnh sửa thông tin
              </h3>

              <Row className='mb-3'>
                <Col
                  md={2}
                  className={cx(
                    'd-flex flex-column align-items-center justify-content-start'
                  )}
                >
                  <Label
                    style={{
                      fontWeight: '600',
                      fontSize: '18px',
                      color: 'rgb(18 88 157)',
                      marginBottom: '10px'
                    }}
                  >
                    Ảnh đại diện:
                  </Label>
                  <VemImage
                    alt=''
                    fallback={AvatarImage}
                    className={cx('student-avatar')}
                    src={accountSelected?.image ?? ''}
                    key=''
                  />
                </Col>

                <Col
                  md={5}
                  className={cx('px-5')}
                >
                  {/* ------------------------------Name-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Họ và Tên:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='name'
                      placeholder='Họ và Tên'
                      errors={[updateAccountValidationErrors?.name?.message!]}
                    />
                  </div>

                  {/* ------------------------------Student Id-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Mã định danh:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='studentId'
                      placeholder='Mã định danh'
                      errors={[updateAccountValidationErrors?.studentId?.message!]}
                    />
                  </div>

                  {/* ------------------------------Student type-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Chức vụ:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='studentType'
                      placeholder='Chức vụ'
                      disabled
                      errors={[updateAccountValidationErrors?.studentType?.message!]}
                    />
                  </div>

                  {/* ------------------------------Student phone-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Số điện thoại học sinh:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='studentPhone'
                      placeholder='Số điện thoại học sinh'
                      errors={[updateAccountValidationErrors?.studentPhone?.message!]}
                    />
                  </div>

                  {/* ------------------------------Parent phone-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Số điện thoại phụ huynh:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='parentPhone'
                      placeholder='Số điện thoại phụ huynh'
                      errors={[updateAccountValidationErrors?.parentPhone?.message!]}
                    />
                  </div>

                  {/* ------------------------------Mail-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      E-mail:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='mail'
                      placeholder='E-mail'
                      errors={[updateAccountValidationErrors?.mail?.message!]}
                    />
                  </div>
                </Col>

                <Col
                  md={5}
                  className={cx('px-5')}
                >
                  {/* ------------------------------Card Id-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Thẻ căn cước:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='cardId'
                      placeholder='Thẻ căn cước'
                      errors={[updateAccountValidationErrors?.cardId?.message!]}
                    />
                  </div>

                  {/* ------------------------------date of birth-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Ngày sinh:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='dateOfBirth'
                      type='date'
                      errors={[updateAccountValidationErrors?.dateOfBirth?.message!]}
                    />
                  </div>

                  {/* ------------------------------date of union-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Ngày gia nhập đoàn:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='dateOfUnion'
                      type='date'
                      errors={[updateAccountValidationErrors?.dateOfUnion?.message!]}
                    />
                  </div>

                  {/* ------------------------------address-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Địa chỉ:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='address'
                      errors={[updateAccountValidationErrors?.address?.message!]}
                    />
                  </div>

                  {/* ------------------------------hometown-------------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Quê quán:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='hometown'
                      errors={[updateAccountValidationErrors?.hometown?.message!]}
                    />
                  </div>
                </Col>
              </Row>
            </div>
          </div>

          <div className={cx('line-break')}></div>

          <div
            className={cx('d-flex justify-content-end mt-3')}
            style={{
              paddingRight: '30px'
            }}
          >
            <VemsButtonCus
              leftIcon={
                <IoIosSend
                  className={cx('me-1')}
                  size={20}
                />
              }
              style={{ width: '150px', height: '38px' }}
              disabled={isUpdateLoading}
              onClick={handleSubmit(onSubmitAccountForm)}
              title='Cập nhật'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalStudentDetails;
