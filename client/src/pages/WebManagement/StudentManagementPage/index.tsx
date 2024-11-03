import className from 'classnames/bind';
import {
  Col,
  DropdownMenu,
  DropdownToggle,
  Label,
  Row,
  UncontrolledDropdown
} from 'reactstrap';
import { FaGraduationCap } from 'react-icons/fa6';
import { IoPeople } from 'react-icons/io5';
import { FaTrashAlt } from 'react-icons/fa';
import { FiFilter } from 'react-icons/fi';
import { lazy, Suspense, useEffect, useState } from 'react';
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
import { ClassOptionData, StudentTableIndex } from './type';
import {
  useGetAllClassQuery,
  useGetStudentInClassQuery
} from '@/services/adminManagement';
import { useGetAllStudentQuery } from '@/services/accountManagement';

const ModalStudentDetails = lazy(() => import('./ModalStudentDetails'));

const cx = className.bind(styles);

const StudentManagementPage = () => {
  // useState-------------------------------------------------------------------------------------------------
  // Modal Create student list
  const [isCloseModalStudent, setIsCloseModalStudent] = useState(false);

  // List class
  const [classOptions, setClassOptions] = useState<ClassOptionData[]>();

  // Modal detail student
  const [isOpenStudentDetail, setIsOpenStudentDetail] = useState<boolean>(false);
  const [studentsTable, setStudentsTable] = useState<StudentTableIndex[]>([]);
  const [studentsSelected, setStudentsSelected] = useState<StudentTableIndex>();

  // Get student list by class id
  const [classNameSelected, setClassNameSelected] = useState<string>('');
  const [classIdSelected, setClassIdSelected] = useState<string>('');

  // Function and Mutation -------------------------------------------------------------------------------------
  // Get all class
  const { data: classes, isLoading: getAllClassLoading } = useGetAllClassQuery({
    PageNumber: 1,
    PageSize: 100
  });

  // Get student list
  const { data: ListStudentInClass } = useGetStudentInClassQuery(classIdSelected);

  // useEffect -----------------------------------------------------------------------------------------------------
  // List class
  useEffect(() => {
    if (classes?.pageData && classes) {
      setClassOptions(
        classes?.pageData.map(
          (item: any) => ({ value: item.id, label: item.className }) as ClassOptionData
        )
      );
    }
  }, [classes]);

  // Get student list
  useEffect(() => {
    if (ListStudentInClass) {
      setStudentsTable(
        ListStudentInClass?.students?.map((item: any, index: number) => ({
          index,
          ...item
        }))
      );
    } else {
      setStudentsTable([]);
    }
  }, [ListStudentInClass]);

  //Event ------------------------------------------------------------------------------------------------------
  // List class
  const handleChangeClass = (e: any) => {
    setClassIdSelected(e.value);
    setClassNameSelected(e.label);
  };

  const { data: response, refetch } = useGetAllStudentQuery(
    { PageNumber: 1, PageSize: 100 },
    {
      refetchOnMountOrArgChange: true,
      refetchOnFocus: true
    }
  );

  // Show student detail
  const handleShowStudentDetail = (item: StudentTableIndex) => {
    setStudentsSelected(item);
    setIsOpenStudentDetail(true);
  };

  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={6}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Quản lí học sinh</h2>
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
            <h2 className={cx('title', 'mb-1')}>Số lượng học sinh</h2>

            <div className={cx('d-flex align-items-center justify-content-end mb-2')}>
              <div className={cx('d-flex justify-content-between mb-4')}>
                <VemsButtonCus
                  title='Nhập danh sách học sinh'
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
              </div>
            </div>

            <ModalUploadStudent
              // refetchParent={refetch}
              isCloseModalStudent={isCloseModalStudent}
              setIsCloseModalStudent={setIsCloseModalStudent}
            ></ModalUploadStudent>

            <div className={cx('d-flex align-items-center px-3')}>
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
                <p className={cx('attendance-text')}>
                  {response?.pageData?.length || '0'}
                </p>
                <p>Học sinh</p>
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
                  className={cx('me-3')}
                  style={{
                    fontWeight: '600',
                    fontSize: '18px',
                    marginBottom: '0'
                  }}
                >
                  Chọn lớp:
                </Label>

                {/* <div
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
                /> */}

                <div style={{ width: '160px' }}>
                  <VemSelect
                    options={classOptions}
                    placeholder='Chọn lớp'
                    onChange={e => {
                      handleChangeClass(e);
                    }}
                    isLoading={getAllClassLoading}
                  />
                </div>
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

          {/* <div className={cx('d-flex justify-content-center mb-3')}>
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
          </div> */}
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
            Danh sách học sinh{' '}
            <>{classNameSelected !== '' && `lớp ${classNameSelected}`}</>
          </h1>
        </Col>

        <DataTable
          data={studentsTable}
          columns={studentColumn}
          striped={true}
          highlightOnHover={true}
          persistTableHead
          pagination
          paginationComponentOptions={{
            rowsPerPageText: 'Số dòng trên trang'
          }}
          // paginationServer
          onRowClicked={item => handleShowStudentDetail(item)}
          noDataComponent={<NoRecord />}
          progressComponent={<VemsLoader />}
        />
      </div>
      <Suspense fallback={<VemsLoader />}>
        <ModalStudentDetails
          accountData={studentsSelected!}
          isOpen={isOpenStudentDetail}
          toggleModal={() => {
            setIsOpenStudentDetail(!isOpenStudentDetail);
          }}
        />
      </Suspense>
    </>
  );
};

export default StudentManagementPage;
