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
  useCreateTeacherScheduleMutation,
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
  Subject,
  Teacher
} from '../type';
import { toast } from 'react-toastify';
import { useGetAllTeacherQuery } from '@/services/accountManagement';

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

type TeacherScheduleItem = {
  subjectID: string;
  sessionID: string;
  slotID: string;
  classID: string;
  teacherID: string;
};

// Sử dụng hàm

const ModalUploadTeacherSchedule = ({
  isCloseModalSchedule,
  setIsCloseModalSchedule
}: ModalUploadScheduleProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/TKBGV.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'TKBGV.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();
  // const [timeFrom, setTimeFrom] = useState<string>('');
  const { data: subjects } = useGetAllSubjectQuery(null);
  const { data: sessions } = useGetAllSessionQuery(null);
  const { data: slots } = useGetAllSlotsQuery(null);
  const { data: classes } = useGetAllClassQuery({ PageNumber: 1, PageSize: 100 });
  const { data: teachers } = useGetAllTeacherQuery({ PageNumber: 1, PageSize: 100 });
  const [createTeacherScheduleFC] = useCreateTeacherScheduleMutation();

  const handleFileUpload = (e: any) => {
    const file = e.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = (event: any) => {
        const data = new Uint8Array(event.target.result);
        const workbook = XLSX.read(data, { type: 'buffer' });
        const sheetName = workbook.SheetNames[1];
        const worksheet = workbook.Sheets[sheetName];
        const jsonData = XLSX.utils.sheet_to_json(worksheet);

        const formatData = jsonData.map((item: any, index: number) => {
          var rowValue = Object.values(item);
          return rowValue;
        });

        setFileData(formatData);

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

  const handleToTimeTable = async () => {
    if (fileData) {
      const result = extractTeachers(fileData);

      const data = mapTeacherScheduleDirect(
        result,
        subjects,
        classes.pageData,
        teachers.pageData,
        sessions,
        slots
      );

      var createTeacherSchedule = await createTeacherScheduleFC(data).unwrap();
      if (createTeacherSchedule) {
        toast.success('Nhập lịch giảng dạy thành công!');
        clearFile();
      }
    }
  };

  function extractTeachers(data: any) {
    const result = [];
    let teacherInfo: any = {};

    for (let i = 0; i < data.length; i++) {
      const row = data[i];

      // Nếu hàng chứa thông tin giáo viên
      if (row[0] && row[0].includes('-')) {
        // Lưu thông tin giáo viên
        const [name, phone] = row[0].split(' - ');
        teacherInfo = {
          teacherName: name.trim(),
          teacherPhone: phone.trim()
        };
      } else if (i > 1 && row[0] !== 'Buổi' && row[0] !== 'Tiết') {
        // Bỏ qua hai hàng đầu tiên và các tiêu đề
        const [periodCode, slotIndex, ...classrooms] = row;
        const period = periodCode.trim() === 'S' ? 'Sáng' : 'Chiều';

        for (let j = 0; j < classrooms.length; j++) {
          if (classrooms[j] !== '#') {
            result.push({
              dayOfWeek: j + 1,
              period: period.trim(),
              classroom: classrooms[j].trim(),
              subject: classrooms[j].trim(),
              slotIndex: parseInt(slotIndex),
              teacherName: teacherInfo.teacherName,
              teacherPhone: teacherInfo.teacherPhone
            });
          }
        }
      }
    }

    return result;
  }

  function mapTeacherScheduleDirect(
    teacherData: any[], // Kết quả từ extractTeachers
    subjects: Subject[], // Danh sách môn học
    classes: Classroom[], // Danh sách lớp học
    teachers: Teacher[], // Danh sách giáo viên
    sessions: Session[],
    slots: SlotBase[]
  ): TeacherScheduleItem[] {
    const teacherSchedule: TeacherScheduleItem[] = [];

    for (const entry of teacherData) {
      const { dayOfWeek, period, classroom, teacherName, slotIndex, teacherPhone } =
        entry;

      // Tìm subjectID từ subjects
      const subjectID = subjects.find(
        subj => subj.subjectName === classroom.split('-')[1]
      )?.id;

      // Tìm classID từ classes
      const classID = classes.find(
        cls => cls.className === classroom.split('-')[0].trim()
      )?.id;

      // Tìm teacherID từ teachers
      const teacherID = teachers.find(teacher => teacher.fullName === teacherName)?.id;

      const sessionID = sessions.find(
        s => s.dayOfWeek == dayOfWeek && s.periodName == period
      )?.sessionID;

      const slotID = slots.find(s => s.slotIndex == slotIndex)?.id;

      // Chỉ thêm vào danh sách nếu tất cả các ID đã tìm được
      if (subjectID && classID && teacherID && sessionID && slotID) {
        teacherSchedule.push({
          subjectID,
          sessionID,
          slotID,
          classID,
          teacherID
        });
      }
    }

    return teacherSchedule;
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
          Tạo lịch giảng dạy
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
              title='Nhập lịch giảng dạy'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadTeacherSchedule;
