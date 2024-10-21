import className from 'classnames/bind';
import { FaGraduationCap } from 'react-icons/fa6';
import {
  HiClipboardDocument,
  HiClipboardDocumentCheck,
  HiClipboardDocumentList
} from 'react-icons/hi2';
import { Col, Label, Row } from 'reactstrap';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import { useState } from 'react';
import { RiCalendarScheduleLine } from 'react-icons/ri';

import styles from './ScheduleManagementPage.module.scss';
import ScheduleImage from '@assets/images/admin/schedule-image.jpg';
import VemSelect from '@/components/VemSelect';
import VemsButtonCus from '@/components/VemsButtonCus';
import ModalUploadSchedule from './ModalUploadSchedule';
import VemsInputCus from '@/components/VemsInputCus';

const cx = className.bind(styles);

const AdminManagementPage = () => {
  const localizer = momentLocalizer(moment);

  // Modal schedule-----------------------------------------------------
  const [isCloseModalSchedule, setIsCloseModalSchedule] = useState(false);

  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={4}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Hệ thống quản lí lịch học</h2>
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
              className={cx('schedule-image')}
              src={ScheduleImage}
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

      {/* Calendar */}

      <div className={cx('card')}>
        <Row>
          <Col md={12}>
            <h1 className={cx('title', 'mb-4')}>Thông tin lịch học</h1>
          </Col>

          <Col
            md={12}
            className={cx('d-flex justify-content-between', 'mb-4')}
          >
            <VemsButtonCus
              title='Tạo thời khóa biểu'
              leftIcon={
                <FaRegCalendarAlt
                  size={20}
                  style={{ marginRight: '6px' }}
                />
              }
              onClick={() => {
                setIsCloseModalSchedule(true);
              }}
            />

            <div className={cx('d-flex align-items-center')}>
              <Label
                className={cx('me-2')}
                style={{
                  fontWeight: '600',
                  fontSize: '18px',
                  marginBottom: '0'
                }}
              >
                Nhập tên lớp:
              </Label>

              <div
                className={cx('me-4')}
                style={{ width: '180px' }}
              >
                <VemsInputCus name='' />
              </div>

              <VemsButtonCus
                title='Hiển thị thời khóa biểu'
                leftIcon={
                  <RiCalendarScheduleLine
                    size={20}
                    style={{ marginRight: '6px' }}
                  />
                }
              />
            </div>
          </Col>

          <Col
            md={12}
            className={cx('d-flex justify-content-center')}
          >
            <h1 className={cx('title', 'text-center mb-5', 'schedule-title')}>
              Thời khóa biểu lớp 8A1
            </h1>
          </Col>

          <ModalUploadSchedule
            isCloseModalSchedule={isCloseModalSchedule}
            setIsCloseModalSchedule={setIsCloseModalSchedule}
          ></ModalUploadSchedule>

          <Col md={12}>
            <Calendar
              localizer={localizer}
              startAccessor='start'
              endAccessor='end'
              style={{ height: '500px' }}
            ></Calendar>
          </Col>
        </Row>
      </div>
    </>
  );
};

export default AdminManagementPage;
