import { Col, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoMdClose } from 'react-icons/io';

import styles from './ModalTeacherDetails.module.scss';
import AvatarImage from '@/assets/images/avatar-test.jpg';
import { TeacherIndex } from '../type';
import VemImage from '@/components/VemImage';

type ModalStudentDetailsProps = {
  teacher: TeacherIndex;
  isOpen: boolean;
  toggleModal: () => void;
};

const cx = className.bind(styles);

const ModalTeacherDetails = ({
  teacher,
  isOpen,
  toggleModal
}: ModalStudentDetailsProps) => {
  return (
    <>
      <Modal
        isOpen={isOpen}
        className={cx('modal-wrapper')}
        size='lg'
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
                {teacher?.fullName || 'N/A'}
              </h3>

              <Row className='mb-3'>
                <Col
                  md={6}
                  className={cx('d-flex align-items-center justify-content-center')}
                >
                  <VemImage
                    alt=''
                    fallback={AvatarImage}
                    className='w-100 rounded'
                    src={teacher?.image}
                    key=''
                  />
                </Col>

                <Col
                  md={6}
                  className={cx('teacher-details')}
                >
                  <p>
                    <span>Tên người dùng: </span>
                    {teacher?.username || 'N/A'}
                  </p>
                  <p>
                    <span>Chủ nhiệm lớp </span>
                    {teacher?.classRoom || 'N/A'}
                  </p>

                  <p>
                    <span>Ngày sinh: </span>
                    {teacher?.dob || 'N/A'}
                  </p>
                  <p>
                    <span>CCCD: </span>
                    {teacher?.citizenID || 'N/A'}
                  </p>

                  <p>
                    <span>Địa chỉ: </span>
                    {teacher?.address || 'N/A'}
                  </p>

                  <p>
                    <span>Số điện thoại: </span>
                    {teacher?.phone || 'N/A'}
                  </p>

                  <p>
                    <span>Mail: </span>
                    {teacher?.email || 'N/A'}
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

export default ModalTeacherDetails;
