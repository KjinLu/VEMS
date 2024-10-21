import className from 'classnames/bind';
import {
  HiClipboardDocument,
  HiClipboardDocumentCheck,
  HiClipboardDocumentList
} from 'react-icons/hi2';
import { Col, Row } from 'reactstrap';
import { FaGraduationCap } from 'react-icons/fa6';
import { IoPeople } from 'react-icons/io5';
import { FaRegCalendarAlt, FaFilter } from 'react-icons/fa';
import { useState } from 'react';

import styles from './StudentManagementPage.module.scss';
import StudentImage from '@assets/images/admin/student-image.jpg';
import VemsButtonCus from '@/components/VemsButtonCus';
import ModalUploadStudent from './ModalUploadStudentList';

const cx = className.bind(styles);

const StudentManagementPage = () => {
  const [isCloseModalStudent, setIsCloseModalStudent] = useState(false);

  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Hệ thống quản lí học sinh</h2>
            <div className={cx('d-flex align-items-center my-5')}>
              <FaGraduationCap
                color={'#4496e8'}
                size={18}
              />
              <p className={cx('text', 'text-uppercase mx-3')}>Vems 4.0</p>
              <FaGraduationCap
                color={'#4496e8'}
                size={18}
              />
            </div>
            <img
              className={cx('student-image')}
              src={StudentImage}
              alt='Mô tả ảnh'
              width='200'
            />
          </div>
        </Col>

        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title', 'mb-2')}>Số lượng học sinh của trường</h2>

            <div className={cx('d-flex justify-content-end mb-4')}>
              <VemsButtonCus
                title='Tạo danh sách học sinh'
                leftIcon={
                  <FaRegCalendarAlt
                    size={20}
                    style={{ marginRight: '6px' }}
                  />
                }
                onClick={() => {
                  setIsCloseModalStudent(true);
                }}
              />
            </div>

            <ModalUploadStudent
              isCloseModalStudent={isCloseModalStudent}
              setIsCloseModalStudent={setIsCloseModalStudent}
            ></ModalUploadStudent>

            <div
              className={cx(
                'd-flex align-items-center justify-content-between mb-3 px-5'
              )}
            >
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: '#e0f7fa' }}
                >
                  <IoPeople
                    size={28}
                    color='rgba(0, 121, 107, 0.68888)'
                    className={cx('icon-round')}
                  />
                </div>

                <div>
                  <p className={cx('attendance-text')}>
                    <span>0</span>/0
                  </p>
                  <p>Có mặt</p>
                </div>
              </div>

              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgb(209 197 200 / 69%)' }}
                >
                  <IoPeople
                    size={28}
                    color='rgb(133 70 88 / 69%)'
                    className={cx('icon-round')}
                  />
                </div>

                <div>
                  <p className={cx('attendance-text')}>
                    <span>0</span>/0
                  </p>
                  <p>Vắng mặt</p>
                </div>
              </div>
            </div>
          </div>
        </Col>
      </Row>

      {/* Student List */}
      <div className={cx('card')}>
        <Col md={12}>
          <h2 className={cx('title', 'mb-4')}>Thông tin học sinh của lớp</h2>

          {/* Button */}
          <Col
            md={12}
            className={cx('mb-4')}
          >
            <div className={cx('student-button-wrapper', 'd-flex justify-content-end')}>
              <div className={cx('d-flex align-items-center')}>
                <VemsButtonCus
                  title='Tìm kiếm thông tin lớp'
                  leftIcon={
                    <FaFilter
                      size={16}
                      style={{ marginRight: '6px' }}
                    />
                  }
                />
              </div>
            </div>
          </Col>

          {/* Student title  */}
          <Col
            md={12}
            className={cx('d-flex justify-content-center')}
          >
            <h1 className={cx('title', 'text-center mb-5', 'student-list-title')}>
              Danh sách học sinh lớp 8A1
            </h1>
          </Col>

          <div className={cx('d-flex justify-content-center')}>
            <div
              className={cx('d-flex align-items-center justify-content-between mb-2')}
              style={{ width: '880px' }}
            >
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(0, 207, 232, 0.10196078431372549)' }}
                >
                  <HiClipboardDocumentList
                    size={28}
                    color='#00cfe8'
                    className={cx('icon-round')}
                  />
                </div>

                <div>
                  <p className={cx('attendance-text')}>
                    <span>0</span>/0
                  </p>
                  <p>Có mặt</p>
                </div>
              </div>

              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(40,199,111,.10196078431372549)' }}
                >
                  <HiClipboardDocumentCheck
                    size={28}
                    color='#28c76f'
                    className={cx('icon-round')}
                  />
                </div>

                <div>
                  <p className={cx('attendance-text')}>
                    <span>0</span>/0
                  </p>
                  <p>Nghỉ có phép</p>
                </div>
              </div>

              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(234, 84, 85, .10196078431372549)' }}
                >
                  <HiClipboardDocument
                    size={28}
                    color='#ea5455'
                    className={cx('icon-round')}
                  />
                </div>

                <div>
                  <p className={cx('attendance-text')}>
                    <span>0</span>/0
                  </p>
                  <p>Nghỉ không phép</p>
                </div>
              </div>
            </div>
          </div>
        </Col>
      </div>
    </>
  );
};

export default StudentManagementPage;
