import { Modal } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosAdd, IoIosSend, IoMdClose } from 'react-icons/io';
import * as XLSX from 'xlsx';
import { SiMicrosoftexcel } from 'react-icons/si';
import { useEffect, useState } from 'react';
import { FaDownload } from 'react-icons/fa6';

import styles from './ModalUploadSchedule.module.scss';
import VemsButton from '@/components/VemsButtonCustom';
import fs from 'fs';
import { IoRemove } from 'react-icons/io5';
import {
  useCreateNewScheduleMutation,
  useCreateScheduleDetailMutation,
  useGetAllSessionQuery,
  useGetAllSlotsQuery,
  useGetAllSubjectQuery
} from '@/services/schedule';
import { useGetAllClassQuery } from '@/services/classes';
import {
  Classroom,
  CreateScheduleDetailRequest,
  CreateScheduleRequest,
  CreateSessionRequest,
  CreateSlotDetailRequest,
  Session,
  SlotBase,
  Subject
} from '../type';
import { toast } from 'react-toastify';

const cx = className.bind(styles);

type ModalUploadScheduleProps = {
  isCloseModalSchedule: boolean;
  setIsCloseModalSchedule: any;
};

type FileUploadProps = {
  name: string;
  size: string;
  type: string;
};

// Định nghĩa kiểu dữ liệu cho Slot và TimeTableEntry
interface Slot {
  index: number; // Chỉ số tiết
  subject: string; // Tên môn học
}

interface TimeTableEntry {
  dayOfWeek: number; // Thứ trong tuần (1: Thứ 2, 2: Thứ 3, ...)
  period: string; // Thời gian (sáng/chiều)
  slots: Slot[]; // Mảng chứa các môn học cho từng tiết
}

interface DaySchedule {
  dayOfWeek: number; // Thứ trong tuần
  entries: TimeTableEntry[]; // Mảng các thời khóa biểu cho từng buổi
}

interface TimeTable {
  class: string; // Tên lớp
  time: string; // Ngày
  schedule: DaySchedule[]; // Mảng thời khóa biểu theo từng ngày
}

// Hàm chuyển đổi dữ liệu
const convertToJSON = (data: string[][]): TimeTable[] => {
  const timeTables: TimeTable[] = [];
  let currentClass: string | null = null;
  let schedule: DaySchedule[] = [];

  for (const row of data) {
    // Kiểm tra xem hàng có phải là tên lớp không
    if (row.length === 1) {
      if (currentClass) {
        // Nếu có lớp hiện tại, lưu lại trước khi chuyển sang lớp mới
        timeTables.push({
          class: currentClass,
          time: '',
          schedule
        });
      }
      currentClass = row[0].trim(); // Lưu tên lớp
      schedule = []; // Reset lịch cho lớp mới
    } else if (row[0] === 'Buổi') {
      // Bỏ qua hàng tiêu đề
      continue;
    } else {
      const currentPeriod = row[0] === 'S' ? 'Sáng' : 'Chiều';
      const daySlots: Record<number, Slot[]> = {};

      for (let j = 2; j < row.length; j++) {
        const subject = row[j];
        if (subject) {
          const dayOfWeek = j - 1; // Chuyển đổi từ chỉ số cột sang thứ trong tuần
          if (!daySlots[dayOfWeek]) {
            daySlots[dayOfWeek] = [];
          }

          // Ghi lại chỉ số tiết
          const index = parseInt(row[1]); // Lấy chỉ số tiết từ cột 1
          daySlots[dayOfWeek].push({ index, subject });
        }
      }

      // Chuyển đổi sang định dạng theo yêu cầu cho từng ngày
      for (const [dayOfWeek, slots] of Object.entries(daySlots)) {
        const dayIndex = parseInt(dayOfWeek);
        const existingDay = schedule.find(d => d.dayOfWeek === dayIndex);
        if (!existingDay) {
          schedule.push({ dayOfWeek: dayIndex, entries: [] });
        }

        // Thêm các slot vào đúng buổi
        const dayEntry = schedule.find(d => d.dayOfWeek === dayIndex);
        dayEntry?.entries.push({ dayOfWeek: dayIndex, period: currentPeriod, slots });
      }
    }
  }

  // Lưu thời khóa biểu cho lớp cuối cùng
  if (currentClass) {
    timeTables.push({
      class: currentClass,
      time: ' ', // Hoặc bất kỳ ngày nào bạn muốn
      schedule
    });
  }

  return timeTables;
};

// Sử dụng hàm

const ModalUploadSchedule = ({
  isCloseModalSchedule,
  setIsCloseModalSchedule
}: ModalUploadScheduleProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/TKB.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'TKB.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();
  const [timeFrom, setTimeFrom] = useState<string>('');
  const { data: subjects } = useGetAllSubjectQuery(null);
  const { data: sessions } = useGetAllSessionQuery(null);
  const { data: slots } = useGetAllSlotsQuery(null);
  const { data: classes } = useGetAllClassQuery({ PageNumber: 1, PageSize: 100 });
  const [createScheduleFC] = useCreateNewScheduleMutation();
  const [createScheduleDetailFC] = useCreateScheduleDetailMutation();

  const handleFileUpload = (e: any) => {
    const file = e.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = (event: any) => {
        const data = new Uint8Array(event.target.result);
        const workbook = XLSX.read(data, { type: 'array' });
        const sheetName = workbook.SheetNames[0];
        const worksheet = workbook.Sheets[sheetName];
        const jsonData = XLSX.utils.sheet_to_json(worksheet);
        setFileData(jsonData);

        setFileInfo({
          name: file.name,
          size: (file.size / 1024).toFixed(2) + ' KB',
          type: file.type
        });
      };
      reader.readAsArrayBuffer(file);
    }
  };

  const handleCreateSchedule = () => {
    handleToTimeTable();
  };
  // Xử lý xóa file
  const clearFile = () => {
    setFileInfo(undefined);
    setFileData(undefined);
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  };

  ////////////////////////////////////////////////////////////////////////////
  //////////?????????????????????????????????????????????/////////////////////
  // TKB mỗi lớp cách nhau 13 record

  useEffect(() => {
    if (fileData) handleToTimeTable;
  }, [fileData]);

  const handleToTimeTable = () => {
    if (fileData) {
      var res = fileData.map((item: any, index: number) => {
        var rowValue = Object.values(item);
        return rowValue;
      });

      setTimeFrom(Object.keys(fileData[0])[0].split(' ')[2]);

      const result = convertToJSON(res);

      result.forEach(async (item: any, index: number) => {
        const request: CreateScheduleRequest = {
          classroomId: classes?.pageData?.find(
            (c: Classroom) => c.className == item.class
          )?.id,
          time: timeFrom || new Date().toISOString().split('T')[0]
        };

        console.log(request);

        if (request.classroomId && request.time) {
          var res = await createScheduleFC(request).unwrap();
          const scheduleID = res.id;

          var createScheduleDetailResponse = await createScheduleDetailFC(
            mapScheduleData(item.schedule, scheduleID, subjects, sessions, slots)
          ).unwrap();

          if (createScheduleDetailResponse) {
            toast.success('Nhập thời khóa biểu thành công!');
            clearFile();
          }
        }
      });
    }
  };

  function mapScheduleData(
    scheduleData: any,
    scheduleID: string,
    subjects: Subject[],
    sessions: Session[],
    slots: SlotBase[]
  ): CreateScheduleDetailRequest {
    const result: CreateScheduleDetailRequest = {
      scheduleID: scheduleID,
      sessions: []
    };

    scheduleData.forEach((day: any) => {
      // Separate morning ('sáng') and afternoon ('chiều') entries
      const morningEntries = day.entries.filter((e: any) => e.period === 'Sáng');
      const afternoonEntries = day.entries.filter((e: any) => e.period === 'Chiều');

      // Helper function to create session objects
      const createSession = (
        entries: any,
        period: string
      ): CreateSessionRequest | null => {
        // console.table(sessions);

        const sessionID = sessions.find(
          (s: Session) => s.dayOfWeek == day.dayOfWeek && s.periodName === period
        )?.sessionID;

        if (!sessionID) {
          return null; // Skip if sessionID is not found
        }

        const slotDetails: CreateSlotDetailRequest[] = entries.flatMap((entry: any) =>
          entry.slots
            .map((slot: any) => {
              const slotID = slots.find(s => {
                if (period === 'Sáng') {
                  if (s.slotIndex === slot.index) {
                    return s;
                  }
                } else if (period === 'Chiều')
                  if (s.slotIndex === Number(slot.index + 5)) {
                    return s;
                  }
              })?.id;

              const subjectID = subjects.find(
                subj => subj.subjectName === slot.subject
              )?.id;

              if (!subjectID || !slotID) {
                return null; // Skip if subjectID or slotID is not found
              }

              return {
                subjectID,
                slotID
              } as CreateSlotDetailRequest;
            })
            .filter((detail: CreateSlotDetailRequest | null) => detail !== null)
        );

        // return {
        //   sessionID,
        //   slotDetails
        // } as CreateSessionRequest;

        return slotDetails.length > 0 ? { sessionID, slotDetails } : null;
      };

      // Add morning and afternoon sessions if they exist
      const morningSession = createSession(morningEntries, 'Sáng');
      if (morningSession) result.sessions.push(morningSession);

      const afternoonSession = createSession(afternoonEntries, 'Chiều');
      if (afternoonSession) result.sessions.push(afternoonSession);
    });

    return result;
  }

  ////////////////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////////////////

  return (
    <>
      <Modal
        isOpen={isCloseModalSchedule}
        className={cx('modal-wrapper')}
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-schedule-title')}>
          Tạo thời khóa biểu
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={() => {
            setIsCloseModalSchedule(false);
          }}
        >
          <IoMdClose
            size={30}
            color='#ccc'
          />
        </div>

        {/* Modal content */}
        <div className={cx('modal-content')}>
          <div className={cx('line-break')}></div>
          <div className={cx('content-file-upload-wrapper')}>
            <div className={cx('content-file-upload')}>
              <div>
                <h3 className={cx('title', 'upload-file-title', 'mb-4')}>
                  Cập nhật tập tin Excel
                </h3>

                <div className='custom-file-upload'>
                  <input
                    type='file'
                    id='file-upload'
                    accept='.xlsx, .xls'
                    onChange={handleFileUpload}
                  />
                  <label
                    htmlFor='file-upload'
                    className={cx('upload-file-btn')}
                  >
                    {' '}
                    <SiMicrosoftexcel
                      size={20}
                      className={cx('me-2')}
                    />
                    Chọn tệp
                  </label>
                </div>

                {fileInfo && (
                  <div style={{ marginTop: '20px' }}>
                    <p style={{ wordWrap: 'break-word' }}>
                      <strong>File Name:</strong> {fileInfo.name}
                    </p>
                    <p>
                      <strong>File Size:</strong> {fileInfo.size}
                    </p>
                    <p>
                      <strong>File Type:</strong> {fileInfo.type}
                    </p>
                    <VemsButton
                      color='danger'
                      leftIcon={
                        <IoRemove
                          className={cx('me-1')}
                          size={20}
                        />
                      }
                      onClick={clearFile}
                      title='Xóa file'
                    />
                  </div>
                )}
              </div>
            </div>
          </div>
          <div className={cx('line-break')}></div>

          <div
            className={cx('d-flex justify-content-end mt-3')}
            style={{
              paddingRight: '30px'
            }}
          >
            <VemsButton
              leftIcon={<FaDownload className={cx('me-2')} />}
              onClick={handleDownload}
              title='Tải tập tin Excel mẫu'
              className={cx('me-3')}
            />

            <VemsButton
              leftIcon={
                <IoIosAdd
                  className={cx('me-1')}
                  size={20}
                />
              }
              onClick={handleCreateSchedule}
              title='Nhập lịch học'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadSchedule;
