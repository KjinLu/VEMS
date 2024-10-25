import className from 'classnames/bind';
import { FaChalkboardTeacher, FaTrashAlt } from 'react-icons/fa';
import { FaGraduationCap, FaRegFaceFrownOpen } from 'react-icons/fa6';
import { IoPeople } from 'react-icons/io5';
import {
  Row,
  Col,
  DropdownMenu,
  DropdownToggle,
  Label,
  UncontrolledDropdown
} from 'reactstrap';
import { useState } from 'react';
import DataTable from 'react-data-table-component';
import { FiFilter } from 'react-icons/fi';

import styles from './TeacherManagementPage.module.scss';
import VemsButtonCus from '@/components/VemsButtonCustom';
import TeacherImage from '@/assets/images/admin/teacher-image.jpg';
import ModalUploadTeacher from './ModalUploadTeacherList';
import VemsInputCus from '@/components/VemsInputCustom';
import VemFragment from '@/components/VemFragment';
import NoRecord from '@/components/NoRecord';
import VemLoader from '@/components/VemsLoader';
import { teacherColumn } from './data-table-column';
import { TeacherIndex } from './type';
import ModalTeacherDetails from './ModalTeacherDetails';

const cx = className.bind(styles);

const TeacherManagementPage = () => {
  // Modal Create teacher list
  const [isCloseModalTeacher, setIsCloseModalTeacher] = useState(false);

  // Modal detail student
  const [teacherId, setTeacherId] = useState<string>('');
  const [isOpenTeacherDetail, setIsOpenTeacherDetail] = useState<boolean>(false);

  const teachers = [
    {
      id: '1',
      name: 'Nguyễn Văn A',
      avatar: 'https://example.com/avatar1.jpg',
      phone: '0901234567',
      class: '10A1'
    },
    {
      id: '2',
      name: 'Trần Thị B',
      avatar: 'https://example.com/avatar2.jpg',
      phone: '0902345678',
      class: '11B2'
    },
    {
      id: '3',
      name: 'Lê Văn C',
      avatar: 'https://example.com/avatar3.jpg',
      phone: '0903456789',
      class: '12C3'
    },
    {
      id: '4',
      name: 'Phạm Thị D',
      avatar: 'https://example.com/avatar4.jpg',
      phone: '0904567890',
      class: '10A2'
    },
    {
      id: '5',
      name: 'Đỗ Văn E',
      avatar: 'https://example.com/avatar5.jpg',
      phone: '0905678901',
      class: '11B1'
    }
  ];

  // Show teacher detail
  const handleShowTeacherDetail = (item: TeacherIndex) => {
    setTeacherId(item.id);
    setIsOpenTeacherDetail(true);
  };

  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Hệ thống quản lí giáo viên</h2>
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
              className={cx('teacher-image')}
              src={TeacherImage}
              alt='teacher-management'
              width='200'
            />
          </div>
        </Col>

        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title', 'mb-3')}>Số lượng giáo viên</h2>

            <div className={cx('d-flex justify-content-end mb-4')}>
              <VemsButtonCus
                title='Tạo danh sách giáo viên'
                leftIcon={
                  <FaChalkboardTeacher
                    size={20}
                    style={{ marginRight: '6px' }}
                  />
                }
                onClick={() => {
                  setIsCloseModalTeacher(true);
                }}
              />
            </div>

            <ModalUploadTeacher
              isCloseModalTeacher={isCloseModalTeacher}
              setIsCloseModalTeacher={setIsCloseModalTeacher}
            />

            <div
              className={cx(
                'd-flex align-items-center justify-content-between mb-3 px-5'
              )}
            >
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
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
                  <p>Giáo viên</p>
                </div>
              </div>

              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgb(209 197 200 / 69%)' }}
                >
                  <FaRegFaceFrownOpen
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

      {/* Teacher list  */}
      <div className={cx('card', 'mb-4')}>
        <Col md={12}>
          <h2 className={cx('title', 'mb-4')}>Thông tin giáo viên</h2>

          {/* Button */}
          <Col
            md={12}
            className={cx('mb-4')}
          >
            <div className={cx('teacher-button-wrapper', 'd-flex justify-content-end')}>
              {/* Filter  */}
              <div className={cx('d-flex align-items-center')}>
                <UncontrolledDropdown>
                  <DropdownToggle
                    caret
                    className={'filter-btn ms-3'}
                    color='primary'
                  >
                    <FiFilter
                      size={18}
                      style={{ marginRight: '8px' }}
                    />
                    <p className={cx('me-1')}>Tìm kiếm</p>
                  </DropdownToggle>

                  <DropdownMenu end>
                    <div className={cx('filter-wrapper')}>
                      <VemFragment>
                        <Label
                          className={cx('mb-1')}
                          style={{
                            fontWeight: '600',
                            fontSize: '16px',
                            marginBottom: '0',
                            color: '#1976d2'
                          }}
                        >
                          Họ và Tên:
                        </Label>

                        <VemsInputCus
                          name=''
                          placeholder='Nhập Họ & Tên'
                        />
                      </VemFragment>

                      <VemFragment>
                        <Label
                          className={cx('mt-3 mb-1')}
                          style={{
                            fontWeight: '600',
                            fontSize: '16px',
                            marginBottom: '0',
                            color: '#1976d2'
                          }}
                        >
                          Số điện thoại:
                        </Label>

                        <VemsInputCus
                          name=''
                          placeholder='Số điện thoại'
                        />
                      </VemFragment>

                      <VemFragment>
                        <Label
                          className={cx('mt-3 mb-1')}
                          style={{
                            fontWeight: '600',
                            fontSize: '16px',
                            marginBottom: '0',
                            color: '#1976d2'
                          }}
                        >
                          Lớp:
                        </Label>

                        <VemsInputCus
                          className={cx('mb-3')}
                          name=''
                          placeholder='Lớp'
                        />
                      </VemFragment>

                      <div className={cx('d-flex justify-content-between')}>
                        <VemsButtonCus
                          style={{ width: '100px' }}
                          title=''
                          leftIcon={<FiFilter size={18} />}
                        />

                        <VemsButtonCus
                          style={{ width: '100px' }}
                          title=''
                          leftIcon={<FaTrashAlt />}
                        />
                      </div>
                    </div>
                  </DropdownMenu>
                </UncontrolledDropdown>
              </div>
            </div>
          </Col>
        </Col>

        {/* Student title  */}
        <Col
          md={12}
          className={cx('d-flex justify-content-center')}
        >
          <h1 className={cx('title', 'text-center mb-5', 'teacher-list-title')}>
            Danh sách giáo viên của trường
          </h1>
        </Col>

        <DataTable
          data={teachers}
          columns={teacherColumn}
          striped={true}
          highlightOnHover={true}
          persistTableHead
          pagination
          paginationComponentOptions={{
            rowsPerPageText: 'Số dòng trên trang'
          }}
          paginationServer
          onRowClicked={item => handleShowTeacherDetail(item)}
          noDataComponent={<NoRecord />}
          progressComponent={<VemLoader />}
        />
      </div>

      <ModalTeacherDetails
        teacherId={teacherId}
        isOpen={isOpenTeacherDetail}
        toggleModal={() => {
          setIsOpenTeacherDetail(!isOpenTeacherDetail);
        }}
      />
    </>
  );
};

export default TeacherManagementPage;
