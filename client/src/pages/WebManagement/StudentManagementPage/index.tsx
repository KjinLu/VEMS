import className from 'classnames/bind';
import {
  HiClipboardDocument,
  HiClipboardDocumentCheck,
  HiClipboardDocumentList
} from 'react-icons/hi2';
import {
  Col,
  DropdownMenu,
  DropdownToggle,
  Label,
  Row,
  UncontrolledDropdown
} from 'reactstrap';
import { FaGraduationCap, FaRegFaceFrownOpen } from 'react-icons/fa6';
import { IoPeople } from 'react-icons/io5';
import { FaTrashAlt } from 'react-icons/fa';
import { FiFilter } from 'react-icons/fi';
import { useState } from 'react';
import { RiCalendarScheduleLine } from 'react-icons/ri';
import DataTable from 'react-data-table-component';
import { PiStudentDuotone } from 'react-icons/pi';

import styles from './StudentManagementPage.module.scss';
import StudentImage from '@assets/images/admin/student-image.jpg';
import VemsButtonCus from '@/components/VemsButtonCustom';
import ModalUploadStudent from './ModalUploadStudentList';
import VemsInputCus from '@/components/VemsInputCustom';
import VemFragment from '@/components/VemFragment';
import VemSelect from '@/components/VemSelect';
import NoRecord from '@/components/NoRecord';
import VemsLoader from '@/components/VemsLoader';
import { studentColumn } from './data-table-column';
import { StudentIndex } from './type';
import ModalStudentDetails from './ModalStudentDetails';

const cx = className.bind(styles);

const StudentManagementPage = () => {
  // Modal Create student list
  const [isCloseModalStudent, setIsCloseModalStudent] = useState(false);

  // Modal detail student
  const [studentId, setStudentId] = useState<string>('');
  const [isOpenStudentDetail, setIsOpenStudentDetail] = useState<boolean>(false);

  const students: StudentIndex[] = [
    { id: '1', avatar: 'Nguyễn Văn A', name: 'Nguyễn Văn A', code: 'HS0001' },
    { id: '2', avatar: 'Trần Thị B', name: 'Nguyễn Văn B', code: 'HS0002' },
    { id: '3', avatar: 'Lê Văn C', name: 'Nguyễn Văn C', code: 'HS0003' }
  ];

  // Show student detail
  const handleShowStudentDetail = (item: StudentIndex) => {
    setStudentId(item.id);
    setIsOpenStudentDetail(true);
  };

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
              alt='student-image'
              width='200'
            />
          </div>
        </Col>

        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title', 'mb-3')}>Số lượng học sinh</h2>

            <div className={cx('d-flex justify-content-between mb-4')}>
              <VemsButtonCus
                title='Tạo danh sách học sinh'
                leftIcon={
                  <PiStudentDuotone
                    size={22}
                    style={{ marginRight: '5px' }}
                  />
                }
                onClick={() => {
                  setIsCloseModalStudent(true);
                }}
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
                  <p>Học sinh</p>
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

      {/* Button & Filter */}
      <div className={cx('card', 'mb-4')}>
        <Col md={12}>
          <h2 className={cx('title', 'mb-4')}>Thông tin học sinh của lớp</h2>

          {/* Button */}
          <Col
            md={12}
            className={cx('mb-4')}
          >
            <div
              className={cx('student-button-wrapper', 'd-flex justify-content-between')}
            >
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
                  title='Hiển thị danh sách'
                  leftIcon={
                    <RiCalendarScheduleLine
                      size={20}
                      style={{ marginRight: '6px' }}
                    />
                  }
                />
              </div>

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
                          Mã định danh:
                        </Label>

                        <VemsInputCus
                          className={cx('mb-3')}
                          name=''
                          placeholder='Nhập mã định danh'
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

          <div className={cx('d-flex justify-content-center mb-3')}>
            <div
              className={cx('d-flex align-items-center justify-content-between')}
              style={{ width: '880px' }}
            >
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
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
                  className={cx('div-icon-round', 'shadow', 'me-3')}
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
                  className={cx('div-icon-round', 'shadow', 'me-3')}
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

      {/* Student List */}
      <div className={cx('card')}>
        {/* Student title  */}
        <Col
          md={12}
          className={cx('d-flex justify-content-center')}
        >
          <h1 className={cx('title', 'text-center mb-5', 'student-list-title')}>
            Danh sách học sinh lớp 8A1
          </h1>
        </Col>

        <DataTable
          data={students}
          columns={studentColumn}
          striped={true}
          highlightOnHover={true}
          persistTableHead
          pagination
          paginationComponentOptions={{
            rowsPerPageText: 'Số dòng trên trang'
          }}
          paginationServer
          onRowClicked={item => handleShowStudentDetail(item)}
          noDataComponent={<NoRecord />}
          progressComponent={<VemsLoader />}
        />
      </div>

      <ModalStudentDetails
        studentId={studentId}
        isOpen={isOpenStudentDetail}
        toggleModal={() => {
          setIsOpenStudentDetail(!isOpenStudentDetail);
        }}
      />
    </>
  );
};

export default StudentManagementPage;
