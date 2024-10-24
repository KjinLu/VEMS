import className from 'classnames/bind';
import { FaGraduationCap } from 'react-icons/fa6';
import { PiStudentDuotone } from 'react-icons/pi';
import {
  Row,
  Col,
  DropdownMenu,
  DropdownToggle,
  Label,
  UncontrolledDropdown,
  TabContent,
  TabPane
} from 'reactstrap';
import { lazy, Suspense, useEffect, useState } from 'react';
import { FaTrashAlt } from 'react-icons/fa';
import { FiFilter } from 'react-icons/fi';

import styles from './ClassManagementPage.module.scss';
import ClassImage from '@/assets/images/admin/class-image.jpg';
import VemsButtonCus from '@/components/VemsButtonCustom';
import ModalUploadClass from './ModalUploadClass';
import VemFragment from '@/components/VemFragment';
import VemsInputCus from '@/components/VemsInputCustom';
import VemsNav from '@/components/VemsNav';
import VemsLoader from '@/components/VemsLoader';

const TenThManagementTab = lazy(() => import('./TenThManagementTab'));
const ElevenThManagementTab = lazy(() => import('./ElevenThManagementTab'));
const TwelveThManagementTab = lazy(() => import('./TwelveThManagementTab'));

const cx = className.bind(styles);

const tabData = [
  {
    tabId: 1,
    tabName: 'Khối 10'
  },
  {
    tabId: 2,
    tabName: 'Khối 11'
  },
  {
    tabId: 3,
    tabName: 'Khối 12'
  }
];

const ClassManagementPage = () => {
  // Modal schedule-----------------------------------------------------
  const [isCloseModalClass, setIsCloseModalClass] = useState(false);

  // Change tab
  const [loadedTabs, setLoadedTabs] = useState<number[]>([1]);
  const [activeTabId, setActiveTabId] = useState(1);

  const handleTabChange = (tabId: number) => {
    setActiveTabId(tabId);
    if (!loadedTabs.includes(tabId)) {
      setLoadedTabs([...loadedTabs, tabId]);
    }
  };

  useEffect(() => {
    handleTabChange(activeTabId);
  }, [activeTabId]);

  return (
    <>
      {/* Welcome card */}
      <Row className={cx('mb-5')}>
        <Col md={4}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Hệ thống quản lí lớp học</h2>
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
              className={cx('class-image')}
              src={ClassImage}
              alt='class-management'
              width='230'
            />
          </div>
        </Col>

        <Col md={8}>
          <div className={cx('card')}>
            <h2 className={cx('title')}>Số lượng lớp học của mỗi khối</h2>

            <div
              className={cx('d-flex justify-content-end')}
              style={{ marginBottom: '36px' }}
            >
              <VemsButtonCus
                title='Tạo danh sách lớp học'
                leftIcon={
                  <PiStudentDuotone
                    size={22}
                    style={{ marginRight: '5px' }}
                  />
                }
                onClick={() => {
                  setIsCloseModalClass(true);
                }}
              />
            </div>

            <ModalUploadClass
              isCloseModalClass={isCloseModalClass}
              setIsCloseModalClass={setIsCloseModalClass}
            ></ModalUploadClass>

            <div
              className={cx(
                'd-flex align-items-center justify-content-between mb-3 px-3'
              )}
            >
              {/* Grade 10  */}
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(0, 207, 232, 0.10196078431372549)' }}
                >
                  <div
                    className={cx('icon-round', 'icon-grade')}
                    style={{ border: '3px solid #00cfe8', backgroundColor: '#ccf5fa' }}
                  >
                    <span style={{ color: '#00cfe8' }}>10</span>
                  </div>
                </div>

                <div>
                  <p className={cx('attendance-text')}>0</p>
                  <p>Lớp học</p>
                </div>
              </div>

              {/* Grade 11  */}
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(40,199,111,.10196078431372549)' }}
                >
                  <div
                    className={cx('icon-round', 'icon-grade')}
                    style={{ border: '3px solid #28c76f', backgroundColor: '#d4f4e2' }}
                  >
                    <span style={{ color: '#28c76f' }}>11</span>
                  </div>
                </div>

                <div>
                  <p className={cx('attendance-text')}>0</p>
                  <p>Lớp học</p>
                </div>
              </div>

              {/* Grade 12  */}
              <div className={cx('d-flex align-items-center')}>
                <div
                  className={cx('div-icon-round', 'shadow', 'me-3')}
                  style={{ backgroundColor: 'rgba(234, 84, 85, .10196078431372549)' }}
                >
                  <div
                    className={cx('icon-round', 'icon-grade')}
                    style={{ border: '3px solid #ea5455', backgroundColor: '#fbdddd' }}
                  >
                    <span style={{ color: '#ea5455' }}>12</span>
                  </div>
                </div>

                <div>
                  <p className={cx('attendance-text')}>0</p>
                  <p>Lớp học</p>
                </div>
              </div>
            </div>
          </div>
        </Col>
      </Row>

      {/* Class list  */}
      <div className={cx('card', 'mb-4')}>
        <Col md={12}>
          <h2 className={cx('title', 'mb-4')}>Thông tin lớp học của mỗi khối</h2>

          {/* Button */}
          <Col
            md={12}
            className={cx('mb-4')}
          >
            <div className={cx('class-button-wrapper', 'd-flex justify-content-end')}>
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
                          Lớp:
                        </Label>

                        <VemsInputCus
                          name=''
                          placeholder='Lớp'
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
                          Giáo viên chủ nhiệm:
                        </Label>

                        <VemsInputCus
                          className={cx('mb-3')}
                          name=''
                          placeholder='Giáo viên chủ nhiệm'
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

          {/* List title  */}
          <Col
            md={12}
            className={cx('d-flex justify-content-center')}
          >
            <h1 className={cx('title', 'text-center mb-5', 'class-list-title')}>
              Danh sách lớp học
            </h1>
          </Col>

          <VemsNav
            tabData={tabData}
            handleChangeTab={tabID => setActiveTabId(tabID)}
          >
            <TabContent activeTab={activeTabId}>
              <TabPane tabId={1}>
                {loadedTabs.includes(1) && (
                  <Suspense fallback={<VemsLoader />}>
                    <TenThManagementTab />
                  </Suspense>
                )}
              </TabPane>

              <TabPane tabId={2}>
                {loadedTabs.includes(2) && (
                  <Suspense fallback={<VemsLoader />}>
                    <ElevenThManagementTab />
                  </Suspense>
                )}
              </TabPane>

              <TabPane tabId={3}>
                {loadedTabs.includes(3) && (
                  <Suspense fallback={<VemsLoader />}>
                    <TwelveThManagementTab />
                  </Suspense>
                )}
              </TabPane>
            </TabContent>
          </VemsNav>
        </Col>
      </div>
    </>
  );
};

export default ClassManagementPage;
