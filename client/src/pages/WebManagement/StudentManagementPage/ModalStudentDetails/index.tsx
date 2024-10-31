import { Col, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoMdClose } from 'react-icons/io';

import styles from './ModalStudentDetails.module.scss';
import AvatarImage from '@/assets/images/avatar-test.jpg';
import { StudentIndex } from '../type';
import VemImage from '@/components/VemImage';

type ModalStudentDetailsProps = {
  student: StudentIndex;
  isOpen: boolean;
  toggleModal: () => void;
};

const cx = className.bind(styles);

const ModalStudentDetails = ({
  student,
  isOpen,
  toggleModal
}: ModalStudentDetailsProps) => {
  console.log(student);
  return (
    <>
      <Modal
        isOpen={isOpen}
        className={cx('modal-wrapper')}
        size='lg'
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
                {student?.fullName || 'N/A'}
              </h3>

              <Row className='mb-3'>
                <Col
                  md={6}
                  className={cx('d-flex align-items-center justify-content-center')}
                >
                  <VemImage
                    alt=''
                    fallback={AvatarImage}
                    className='w-100'
                    src={student?.image}
                    key=''
                  />
                </Col>

                <Col
                  md={6}
                  className={cx('student-details')}
                >
                  <p>
                    <span>Mã định danh: </span>
                    {student?.publicStudentID || 'N/A'}
                  </p>

                  <p>
                    <span>Lớp: </span>
                    {student?.classRoom || 'N/A'}
                  </p>

                  <p>
                    <span>Chức vụ: </span>
                    {student?.studentTypeName || 'N/A'}
                  </p>

                  <p>
                    <span>Số điện thoại: </span>
                    {student?.phone || 'N/A'}
                  </p>
                  <p>
                    <span>Số điện thoại phụ huynh: </span>
                    {student?.parentPhone || 'N/A'}
                  </p>

                  <p>
                    <span>Email: </span>
                    {student?.email || 'N/A'}
                  </p>

                  <p>
                    <span>Ngày sinh: </span>
                    {student?.dob || 'N/A'}
                  </p>

                  <p>
                    <span>CCCD: </span>
                    {student?.citizenID || 'N/A'}
                  </p>

                  <p>
                    <span>Địa chỉ: </span>
                    {student?.address || 'N/A'}
                  </p>
                </Col>
              </Row>
            </div>
          </div>

          <div className={cx('line-break')}></div>
        </div>
      </Modal>
    </>
  );
};

export default ModalStudentDetails;
