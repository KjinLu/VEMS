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
import { useEffect, useState } from 'react';
import { RiCalendarScheduleLine } from 'react-icons/ri';

import styles from './ScheduleManagementPage.module.scss';
import ScheduleImage from '@assets/images/admin/schedule-image.jpg';
import VemSelect from '@/components/VemSelect';
import VemsButtonCus from '@/components/VemsButtonCustom';
import ModalUploadSchedule from './ModalUploadSchedule';
import VemsInputCus from '@/components/VemsInputCustom';
import { UUID } from 'crypto';
import { useGetClassScheduleQuery, useGetScheduleDetailQuery } from '@/services/schedule';
import { useGetAllClassQuery } from '@/services/classes';
import VemsSelect from '@/components/VemSelect';
import ModalUploadTeacherSchedule from './ModalUploadTeacherSchedule';

const cx = className.bind(styles);
type DayInSchedule = {
  title: string;
  start: Date;
  end: Date;
};

type ClassOptionData = {
  value: string;
  label: string;
};

const getMonday = (date: Date) => {
  const day = date.getDay();
  const diff = day === 0 ? 1 : 1 - day; // Nếu là Chủ Nhật (0), thì diff là 1 để lấy Thứ Hai của tuần hiện tại
  const monday = new Date(date);
  monday.setDate(date.getDate() + diff);
  return monday;
};

function combineDateAndTime(dateInput: string, timeInput: string): Date {
  // Chuyển đổi chuỗi ngày thành đối tượng Date
  const date = new Date(dateInput);

  // Tách chuỗi thời gian thành các thành phần giờ, phút, giây
  const [hours, minutes, seconds] = timeInput.split(':').map(Number);

  // Gán các thành phần giờ, phút, giây cho đối tượng Date
  date.setHours(hours);
  date.setMinutes(minutes);
  date.setSeconds(seconds);

  return date; // Trả về đối tượng Date
}

const AdminManagementPage = () => {
  const localizer = momentLocalizer(moment);

  const [isCloseModalSchedule, setIsCloseModalSchedule] = useState(false);
  const [isCloseModalTeacherSchedule, setIsCloseModalTeacherSchedule] = useState(false);
  const [classScheduleID, setClassScheduleID] = useState<UUID>();
  const [classSelectedID, setClassSelectedID] = useState<UUID>();
  const [classOptions, setClassOptions] = useState<ClassOptionData[]>();
  const [scheduleDetails, setScheduleDetail] = useState<any>();
  const [classSchedule, setClassSchedule] = useState<any>();
  const [currentMonday, setCurrentMonday] = useState(getMonday(new Date()));
  const [weeklyTimeTable, setWeeklyTimeTable] = useState<DayInSchedule[]>([]);
  const { data: classes } = useGetAllClassQuery({ PageNumber: 1, PageSize: 100 });

  const { data: classScheduleData, refetch } = useGetClassScheduleQuery(
    classSelectedID!,
    {
      skip: !classSelectedID,
      refetchOnMountOrArgChange: true,
      refetchOnFocus: true
    }
  );

  useEffect(() => {
    if (classScheduleData) {
      setClassSchedule(classScheduleData);
    }
  }, [classScheduleData]);

  const { data: classScheduleDetails, refetch: refetchSchedule } =
    useGetScheduleDetailQuery(classScheduleID!, {
      skip: !classScheduleID,
      refetchOnMountOrArgChange: true,
      refetchOnFocus: true
    });

  useEffect(() => {
    if (classes?.pageData && classes) {
      setClassOptions(
        classes?.pageData.map(
          (item: any) => ({ value: item.id, label: item.className }) as ClassOptionData
        )
      );
    }
  }, [classes]);

  useEffect(() => {
    if (classSchedule && classSchedule.length > 0) {
      setClassScheduleID(classSchedule[0].id);
    }
  }, [classSchedule]);

  useEffect(() => {
    if (classScheduleDetails) {
      setScheduleDetail(classScheduleDetails);
    }
  }, [classScheduleDetails]);

  useEffect(() => {
    if (scheduleDetails) {
      const generateWeeklyTimeTable = () => {
        const monday = new Date(currentMonday);
        const groupedByDay = scheduleDetails.sessions.reduce((acc: any, item: any) => {
          if (!acc[item.dayOfWeek]) {
            acc[item.dayOfWeek] = [];
          }
          acc[item.dayOfWeek].push(item);
          return acc;
        }, {});

        const timeTb: DayInSchedule[] = Object.keys(groupedByDay).flatMap(dayOfWeek => {
          const sessionsForDay = groupedByDay[dayOfWeek];
          const dayDate = new Date(monday);
          dayDate.setDate(monday.getDate() + parseInt(dayOfWeek) - 1);

          return sessionsForDay.flatMap((session: any) => {
            return session.slotDetails.map((slot: any) => ({
              title: slot.subjectName,
              start: combineDateAndTime(dayDate.toISOString(), slot.slotStart),
              end: combineDateAndTime(dayDate.toISOString(), slot.slotEnd)
            }));
          });
        });

        setWeeklyTimeTable(timeTb);
      };

      generateWeeklyTimeTable();
    }
  }, [scheduleDetails, currentMonday]);

  const handleChange = (e: any) => {
    setClassSelectedID(e.value);
    setWeeklyTimeTable([]);
  };

  const eventStyleGetter = (event: any, start: any, end: any, isSelected: boolean) => {
    let backgroundColor = '#1976d2';
    return {
      style: {
        backgroundColor,
        color: 'white', // Màu chữ
        borderRadius: '5px',
        border: '0px',
        display: 'block',
        fontSize: '12px'
      }
    };
  };

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
              alt='schedule-image'
              width='150'
            />
          </div>
        </Col>

        <Col md={8}>
          <div className={cx('card')}>
            <h2 className={cx('title', 'mb-4')}>Thống kê điểm danh học sinh</h2>

            <div className={cx('d-flex justify-content-end', 'attendance-select')}>
              <div style={{ width: '30%' }}>
                {/* <VemSelect
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
                /> */}
              </div>
            </div>

            <div
              className={cx(
                'd-flex align-items-center justify-content-between mb-2 px-3'
              )}
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
      </Row>

      {/* Calendar */}
      <div className={cx('card')}>
        <Row>
          <Col md={12}>
            <h1 className={cx('title', 'mb-4')}>Thông tin lịch học</h1>
          </Col>

          {/* Button  */}
          <Col
            md={12}
            className={cx('mb-4')}
          >
            <div
              className={cx('schedule-button-wrapper', 'd-flex justify-content-between')}
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

              <VemsButtonCus
                title='Tạo lịch giảng dạy'
                leftIcon={
                  <FaRegCalendarAlt
                    size={20}
                    style={{ marginRight: '6px' }}
                  />
                }
                onClick={() => {
                  setIsCloseModalTeacherSchedule(true);
                }}
              />

              <ModalUploadSchedule
                isCloseModalSchedule={isCloseModalSchedule}
                setIsCloseModalSchedule={setIsCloseModalSchedule}
              ></ModalUploadSchedule>

              <ModalUploadTeacherSchedule
                isCloseModalSchedule={isCloseModalTeacherSchedule}
                setIsCloseModalSchedule={setIsCloseModalTeacherSchedule}
              ></ModalUploadTeacherSchedule>

              <div className={cx('d-flex align-items-center')}>
                <Label
                  className={cx('me-2')}
                  style={{
                    fontWeight: '600',
                    fontSize: '18px',
                    marginBottom: '0'
                  }}
                ></Label>

                <div
                  className={cx('me-4')}
                  style={{ width: '180px' }}
                >
                  {/* <VemsInputCus name='' /> */}
                  <VemSelect
                    // value={classSelectedID}
                    options={classOptions!}
                    placeholder='Chọn lớp'
                    onChange={handleChange}
                  />
                </div>

                {/* <VemsButtonCus
                  title='Hiển thị thời khóa biểu'
                  leftIcon={
                    <RiCalendarScheduleLine
                      size={20}
                      style={{ marginRight: '6px' }}
                    />
                  }
                /> */}
              </div>
            </div>
          </Col>

          {/* Schedule title  */}
          <Col
            md={12}
            className={cx('d-flex justify-content-center')}
          >
            <h1 className={cx('title', 'text-center mb-5', 'schedule-title')}>
              Thời khóa biểu lớp{' '}
              {classSelectedID
                ? classOptions?.find(c => c.value === classSelectedID)?.label
                : ''}
            </h1>
          </Col>

          <Col md={12}>
            <Calendar
              localizer={localizer}
              events={weeklyTimeTable}
              startAccessor='start'
              endAccessor='end'
              defaultView='week'
              style={{ height: '500px' }}
              components={{
                toolbar: () => <div />
              }}
              min={new Date(2023, 1, 1, 6, 0, 0)}
              eventPropGetter={eventStyleGetter}
              // onNavigate={handleNavigate}
              // localizer={localizer}
              // events={weeklyTimeTable}
              views={['week']}
            ></Calendar>
          </Col>
        </Row>
      </div>
    </>
  );
};

export default AdminManagementPage;
