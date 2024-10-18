import className from 'classnames/bind';
import { FaGraduationCap } from 'react-icons/fa6';
import {
  HiClipboardDocument,
  HiClipboardDocumentCheck,
  HiClipboardDocumentList
} from 'react-icons/hi2';
import { Col, Label, Row } from 'reactstrap';

import styles from './AdminManagement.module.scss';
import MedalImage from '@assets/images/admin/medal-image.jpg';
import VemSelect from '@/components/VemSelect';

const cx = className.bind(styles);

const AdminManagementPage = () => {
  return (
    <>
      {/* Welcome card */}
      <Row>
        <Col md={4}>
          <div className={cx('welcome-card')}>
            <h2 className={cx('title')}>Chào mừng đến với hệ thống</h2>
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
              className={cx('medal-image')}
              src={MedalImage}
              alt='Mô tả ảnh'
              width='180'
            />
          </div>
        </Col>

        <Col md={8}>
          <div className={cx('welcome-card')}>
            <h2
              className={cx('title')}
              style={{ fontSize: '18px' }}
            >
              Thống kê điểm danh lớp chủ nhiệm
            </h2>

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

export default AdminManagementPage;
