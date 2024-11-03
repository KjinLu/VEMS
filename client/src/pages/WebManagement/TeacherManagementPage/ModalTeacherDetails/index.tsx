import { useEffect, useState } from 'react';
import { Col, Label, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import { yupResolver } from '@hookform/resolvers/yup';
import { SubmitHandler, useForm } from 'react-hook-form';
import { ApolloError } from '@apollo/client';
import { toast } from 'react-toastify';

import styles from './ModalTeacherDetails.module.scss';
import AvatarImage from '@/assets/images/avatar-test.jpg';
import { AccountForm, TeacherIndex } from '../type';
import VemImage from '@/components/VemImage';
import VemsInputCus from '@/components/VemsInputCustom';
import VemFromGroup from '@/components/VemFormGroup';
import { updateTeacherAccount } from '../form-schemas';
import VemsButtonCus from '@/components/VemsButtonCustom';
import { useUpdateTeacherProfileMutation } from '@/services/adminManagement';

type ModalStudentDetailsProps = {
  accountData: TeacherIndex;
  isOpen: boolean;
  toggleModal: () => void;
  updateParentState: any;
};

const cx = className.bind(styles);

const ModalTeacherDetails = ({
  accountData,
  isOpen,
  toggleModal,
  updateParentState
}: ModalStudentDetailsProps) => {
  // useState------------------------------------------------------------------------
  const [accountSelected, setAccountSelected] = useState<TeacherIndex | undefined>(
    undefined
  );

  // Query and Mutation -------------------------------------------------------------
  const [updateTeacherProfile, { isLoading: isUpdateLoading }] =
    useUpdateTeacherProfileMutation();

  // useEffect ----------------------------------------------------------------------
  useEffect(() => {
    setAccountSelected(accountData);
  }, [accountData]);

  // event ----------------------------------------------------------------------------
  const {
    control,
    handleSubmit,
    formState: { errors: updateAccountValidationErrors }
  } = useForm<AccountForm>({
    resolver: yupResolver(updateTeacherAccount),
    values: {
      name: accountSelected?.fullName!,
      phone: accountSelected?.phone!,
      address: accountSelected?.address!,
      dateOfBirth: accountSelected?.dob!,
      idCard: accountSelected?.citizenID!,
      class: accountSelected?.classRoom!,
      mail: accountSelected?.email!
    }
  });

  const onSubmitAccountForm: SubmitHandler<AccountForm> = accountFormData => {
    const { address, dateOfBirth, idCard, name, phone } = accountFormData;

    updateTeacherProfile({
      teacherId: accountSelected?.id,
      publicTeacherID: accountSelected?.publicTeacherID,
      citizenID: idCard,
      username: phone,
      password: accountSelected?.password,
      fullName: name,
      email: accountSelected?.email,
      dob: dateOfBirth,
      address: address,
      phone: phone,
      teacherTypeId: accountSelected?.teacherTypeId
    })
      .then(() => {
        updateParentState();
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
        <h2 className={cx('text-uppercase', 'title', 'modal-teacher-title')}>
          Thông tin chi tiết giáo viên
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

          <div className={cx('content-teacher-wrapper')}>
            <div className={cx('content-teacher')}>
              <h3 className={cx('title', 'teacher-name')}>
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
                    className={cx('teacher-avatar')}
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
                      errors={[updateAccountValidationErrors?.name?.message!]}
                    />
                  </div>

                  {/*----------------------------------phone---------------------------  */}
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
                      Số điện thoại:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='phone'
                      errors={[updateAccountValidationErrors?.phone?.message!]}
                    />
                  </div>

                  {/*----------------------------------class---------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        marginBottom: '0',
                        textAlign: 'left',
                        color: 'rgb(18 88 157)',
                        width: '100%'
                      }}
                      className={cx('mb-1')}
                    >
                      Chủ nhiệm lớp:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='class'
                      disabled
                      errors={[updateAccountValidationErrors?.class?.message!]}
                    />
                  </div>

                  {/*----------------------------------dateOfBirth---------------------------  */}
                  <VemFromGroup>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        marginBottom: '0',
                        color: 'rgb(18 88 157)',
                        textAlign: 'left'
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
                  </VemFromGroup>
                </Col>

                <Col
                  md={5}
                  className={cx('px-5')}
                >
                  {/*----------------------------------idCard---------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        marginBottom: '0',
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
                      name='idCard'
                      errors={[updateAccountValidationErrors?.idCard?.message!]}
                    />
                  </div>

                  {/*----------------------------------address---------------------------  */}
                  <div style={{ marginBottom: '30px' }}>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        marginBottom: '0',
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

                  {/*----------------------------------mail---------------------------  */}
                  <VemFromGroup>
                    <Label
                      style={{
                        fontWeight: '600',
                        fontSize: '18px',
                        marginBottom: '0',
                        color: 'rgb(18 88 157)',
                        textAlign: 'left'
                      }}
                      className={cx('mb-1')}
                    >
                      E-mail:
                    </Label>
                    <VemsInputCus
                      control={control}
                      name='mail'
                      disabled
                      errors={[updateAccountValidationErrors?.mail?.message!]}
                    />
                  </VemFromGroup>
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

export default ModalTeacherDetails;
