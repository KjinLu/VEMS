import { Col, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoMdClose } from 'react-icons/io';

import styles from './ModalTeacherDetails.module.scss';
import AvatarImage from '@/assets/images/avatar-test.jpg';

type ModalStudentDetailsProps = {
  teacherId: string;
  isOpen: boolean;
  toggleModal: () => void;
};

const cx = className.bind(styles);

const ModalTeacherDetails = ({
  teacherId,
  isOpen,
  toggleModal
}: ModalStudentDetailsProps) => {
  teacherId;
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
              <h3 className={cx('title', 'teacher-name')}>Nguyễn Văn A</h3>

              <Row className='mb-3'>
                <Col
                  md={6}
                  className={cx('d-flex align-items-center justify-content-center')}
                >
                  <img
                    src={AvatarImage}
                    alt='avatar'
                    className={cx('teacher-avatar')}
                  />
                </Col>

                <Col
                  md={6}
                  className={cx('teacher-details')}
                >
                  <p>
                    <span>Chủ nhiệm lớp </span>
                    8A1
                  </p>

                  <p>
                    <span>Ngày sinh: </span>
                    01/01/2002
                  </p>

                  <p>
                    <span>Giới tính: </span>
                    Nam
                  </p>

                  <p>
                    <span>CCCD: </span>
                    099999999999999999
                  </p>

                  <p>
                    <span>Địa chỉ nhà: </span>
                    Cần Thơ
                  </p>

                  <p>
                    <span>Địa chỉ thường trú: </span>
                    Cần Thơ
                  </p>

                  <p>
                    <span>Số điện thoại: </span>
                    0909 68 68 68
                  </p>

                  <p>
                    <span>Mail: </span>
                    thanhh@gmail.com
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
