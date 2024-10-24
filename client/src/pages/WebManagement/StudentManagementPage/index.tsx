import className from 'classnames/bind';
import {
  HiClipboardDocument,
  HiClipboardDocumentCheck,
  HiClipboardDocumentList
} from 'react-icons/hi2';
import { Col, Row } from 'reactstrap';
import { FaGraduationCap } from 'react-icons/fa6';

import styles from './StudentManagementPage.module.scss';
import VemSelect from '@/components/VemSelect';
import StudentImage from '@assets/images/admin/student-image.jpg';

const cx = className.bind(styles);

const StudentManagementPage = () => {
  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={4}>
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
              width='180'
            />
          </div>
        </Col>

        <Col md={8}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Thống kê điểm danh học sinh</h2>

            <div className={cx('d-flex justify-content-end', 'attendance-select')}>
              <div style={{ width: '30%' }}>
                <VemSelect
                  options={[
                    {
                      label: 'Sáng',
                      value: 'Sáng'
                    },
                    {
                      label: 'Chiều',
                      value: 'Chiều'
                    }
                  ]}
                  placeholder='Chọn thời gian'
                />
              </div>
            </div>

            <div className={cx('d-flex align-items-center justify-content-between mb-2')}>
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
      </Row>
    </>
  );
};

export default StudentManagementPage;
