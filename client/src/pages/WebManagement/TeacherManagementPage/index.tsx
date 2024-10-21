import className from 'classnames/bind';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { FaGraduationCap } from 'react-icons/fa6';
import { IoPeople } from 'react-icons/io5';
import { Row, Col } from 'reactstrap';

import styles from './TeacherManagementPage.module.scss';
import VemsButtonCus from '@/components/VemsButtonCustom';
import VemSelect from '@/components/VemSelect';
import TeacherImage from '@/assets/images/admin/teacher-image.jpg';

const cx = className.bind(styles);

const TeacherManagementPage = () => {
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
              src={TeacherImage}
              alt='Mô tả ảnh'
              width='200'
            />
          </div>
        </Col>

        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title', 'mb-3')}>Số lượng học sinh của trường</h2>

            <div className={cx('d-flex justify-content-between mb-4')}>
              <VemsButtonCus
                title='Tạo danh sách học sinh'
                leftIcon={
                  <FaRegCalendarAlt
                    size={20}
                    style={{ marginRight: '6px' }}
                  />
                }
                // onClick={() => {
                //   setIsCloseModalStudent(true);
                // }}
              />

              <div style={{ width: '200px' }}>
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
                  <p className={cx('attendance-text')}>0</p>
                  <p>Học sinh</p>
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
    </>
  );
};

export default TeacherManagementPage;
