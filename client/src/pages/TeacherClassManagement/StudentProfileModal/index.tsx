import VemButton from '@/components/VemButton';
import VemImage from '@/components/VemImage';
import { useAssignStudentMutation, useGetAllStudentTypeQuery } from '@/services/classes';
import { IStudentProfile, useGetStudentProfileQuery } from '@/services/profile';
import { MenuItem, Select } from '@mui/material';
import { UUID } from 'crypto';
import { useEffect, useState } from 'react';
import { set } from 'react-hook-form';
import { FaTimes } from 'react-icons/fa';
import { toast } from 'react-toastify';
import { Col, Modal, ModalBody, ModalHeader, Row } from 'reactstrap';
import AvatarDefault from '@/assets/images/personal/avatarDefault.jpg';

type ModalProps = {
  isOpen: boolean;
  toggleModal: any;
  studentData: IStudentProfile;
  refetchParent: any;
};

const StudentProfileModal = ({
  isOpen,
  toggleModal,
  studentData,
  refetchParent
}: ModalProps) => {
  const { data } = useGetAllStudentTypeQuery(null);
  const [currentType, setCurrentType] = useState<UUID | undefined>(undefined);
  const [assignStudentFC] = useAssignStudentMutation();

  useEffect(() => {
    if (data && studentData?.studentTypeName) {
      const matchingType = data.find(
        (item: any) => item.typeName === studentData.studentTypeName
      );
      if (matchingType) setCurrentType(matchingType.id);
    }
  }, [studentData, data]);

  const handleAssign = async () => {
    try {
      const body = {
        studentID: studentData.id,
        studentTypeID: currentType
      };
      var res = await assignStudentFC(body).unwrap();
      if (res) {
        toast.success('Bổ nhiệm thành công!');
        refetchParent();
      }
    } catch (e: any) {
      toast.error('Bổ nhiệm không thành công! ' + e.data.message);
    }
  };

  return (
    <Row>
      <Modal
        isOpen={isOpen}
        size='md'
      >
        <Row className='align-items-center p-2'>
          <Col
            sm={11}
            className='text-start'
          >
            <h3>Hồ sơ học sinh</h3>
          </Col>
          <Col
            sm={1}
            className='text-end'
          >
            <FaTimes
              onClick={toggleModal}
              style={{ cursor: 'pointer' }}
            />{' '}
          </Col>
        </Row>
        <Row className='p-3'>
          <Row className='mb-4  '>
            <Col
              sm={4}
              className='text-center'
            >
              <VemImage
                alt=''
                className='w-100 rounded'
                fallback={AvatarDefault}
                src={studentData ? studentData.image : ''}
              />
            </Col>
            <Col sm={8}>
              <Row>
                <h4 className='text-bold'>{studentData ? studentData.fullName : ''}</h4>
                <p className='mb-2'>
                  <strong className='text-primary'>Lớp: </strong>{' '}
                  {studentData ? studentData.classRoom : ''}
                </p>

                <p className='mb-3'>
                  <strong className='text-primary'>Chức vụ: </strong>
                  {studentData ? studentData.studentTypeName : ''}
                </p>

                <p className='mb-2'>
                  <strong className='text-primary'>Mã học sinh:</strong>{' '}
                  {studentData ? studentData.publicStudentID : ''}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Tên đăng nhập:</strong>{' '}
                  {studentData ? studentData.username : ''}
                </p>
              </Row>
              <Row>
                <p className='mb-2'>
                  <strong className='text-primary'>Email:</strong>{' '}
                  {studentData ? studentData.email : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Số điện thoại:</strong>{' '}
                  {studentData ? studentData.phone : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Số điện thoại phụ huynh:</strong>{' '}
                  {studentData ? studentData.parentPhone : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>CMND/CCCD:</strong>{' '}
                  {studentData ? studentData.citizenID : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Ngày sinh:</strong>{' '}
                  {studentData ? studentData.dob : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Ngày vào đoàn:</strong>{' '}
                  {studentData ? studentData.unionJoinDate : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Địa chỉ:</strong>{' '}
                  {studentData ? studentData.address : 'N/A'}
                </p>
                <p className='mb-2'>
                  <strong className='text-primary'>Quê quán:</strong>{' '}
                  {studentData ? studentData.homeTown : 'N/A'}
                </p>
              </Row>
              <Row className='d-flex justify-content-center align-items-center mt-5'>
                <p className='mb-2'>
                  <strong className='text-primary'>Bổ nhiệm chức vụ</strong>
                </p>
                <Col sm={6}>
                  <Select
                    variant='standard'
                    className='w-100 p-0'
                    value={currentType || ''}
                    onChange={(e: any) => setCurrentType(e.target.value as UUID)}
                  >
                    {data?.map((r: any) => (
                      <MenuItem
                        key={r.id}
                        value={r.id}
                      >
                        {r.typeName}
                      </MenuItem>
                    ))}
                  </Select>
                </Col>
                <Col sm={6}>
                  <VemButton
                    onClick={() => handleAssign()}
                    disabled={
                      currentType ==
                      data?.find(
                        (item: any) => item.typeName === studentData?.studentTypeName
                      )?.id
                    }
                    id='assign'
                    variant='outlined'
                    type='button'
                    children={'Bổ nhiệm'}
                  />
                </Col>
              </Row>
            </Col>
          </Row>
        </Row>
      </Modal>
    </Row>
  );
};

export default StudentProfileModal;
