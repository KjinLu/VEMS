import { Col, Modal, Row } from 'reactstrap';
import className from 'classnames/bind';
import { IoMdClose } from 'react-icons/io';

import styles from './ModalStudentDetails.module.scss';
import AvatarImage from '@/assets/images/avatar-test.jpg';

type ModalStudentDetailsProps = {
  studentId: string;
  isOpen: boolean;
  toggleModal: () => void;
};

const cx = className.bind(styles);

const ModalStudentDetails = ({
  studentId,
  isOpen,
  toggleModal
}: ModalStudentDetailsProps) => {
  studentId;
  return (
    <>
      <Modal
        isOpen={isOpen}
        className={cx('modal-wrapper')}
        size='lg'
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-Student-title')}>
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
              <h3 className={cx('title', 'student-name')}>Nguyễn Văn A</h3>

              <Row className='mb-3'>
                <Col
                  md={6}
                  className={cx('d-flex align-items-center justify-content-center')}
                >
                  <img
                    src={AvatarImage}
                    alt='avatar'
                    className={cx('student-avatar')}
                  />
                </Col>

                <Col
                  md={6}
                  className={cx('student-details')}
                >
                  <p>
                    <span>Mã định danh: </span>
                    HS0001
                  </p>

                  <p>
                    <span>GVCN: </span>
                    Nguyễn Văn C
                  </p>

                  <p>
                    <span>Lớp: </span>
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

export default ModalStudentDetails;
