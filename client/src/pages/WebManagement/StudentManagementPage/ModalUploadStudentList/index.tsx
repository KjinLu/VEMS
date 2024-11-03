import { Modal } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import * as XLSX from 'xlsx';
import { SiMicrosoftexcel } from 'react-icons/si';
import { useState } from 'react';
import { FaDownload } from 'react-icons/fa6';

import styles from './ModalUploadStudentList.module.scss';
import VemsButton from '@/components/VemsButtonCustom';
import { useGetAllClassQuery } from '@/services/classes';
import { IoRemove } from 'react-icons/io5';
import { useImportStudentMutation } from '@/services/accountManagement';
import { toast } from 'react-toastify';

const cx = className.bind(styles);

type ModalUploadStudentProps = {
  isCloseModalStudent: boolean;
  setIsCloseModalStudent: any;
  // refetchParent: any;
};

type FileUploadProps = {
  name: string;
  size: string;
  type: string;
};

const ModalUploadStudent = ({
  isCloseModalStudent,
  setIsCloseModalStudent
  // refetchParent
}: ModalUploadStudentProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/STUDENT_INPUT.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'STUDENT_INPUT.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();
  const { data: classes } = useGetAllClassQuery({ PageNumber: 1, PageSize: 100 });
  const [importStudentFC] = useImportStudentMutation();

  const handleFileUpload = (e: any) => {
    const file = e.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = (event: any) => {
        const data = new Uint8Array(event.target.result);
        const workbook = XLSX.read(data, { type: 'array' });

        const formattedData: { [className: string]: any[] } = {};

        // Loop through each sheet and parse data
        workbook.SheetNames.forEach(sheetName => {
          const worksheet = workbook.Sheets[sheetName];
          const jsonData = XLSX.utils.sheet_to_json(worksheet);

          formattedData[sheetName] = jsonData.map((item: any) => ({
            no: item['STT'],
            code: item['Mã định danh'],
            name: item['Họ và tên'],
            class: sheetName
          }));
        });

        setFileData(formattedData);

        setFileInfo({
          name: file.name,
          size: (file.size / 1024).toFixed(2) + ' KB',
          type: file.type
        });
      };

      reader.readAsArrayBuffer(file);
    }
  };

  const clearFile = () => {
    setFileInfo(undefined);
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  };

  const handleImportStudents = async () => {
    if (fileData && classes?.pageData) {
      const res = Object.entries(fileData).flatMap(([className, students]) => {
        return (students as any)
          .map((item: any) => {
            const classId = classes.pageData.find(
              (c: any) => c.className === className
            )?.id;
            if (classId) {
              return {
                publicStudentID: item.code,
                fullName: item.name,
                classroomId: classId
              };
            }
            return null;
          })
          .filter((item: any) => item !== null);
      });

      // Uncomment and modify this section based on your import function
      if (res.length > 0) {
        var importRes = await importStudentFC(res).unwrap();
        if (importRes) {
          // refetchParent();
          toast.success('Nhập danh sách học sinh thành công');
        }
      }
    }
  };
  return (
    <>
      <Modal
        isOpen={isCloseModalStudent}
        className={cx('modal-wrapper')}
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-student-title')}>
          Tạo danh sách học sinh
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={() => {
            setIsCloseModalStudent(false);
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
                <IoIosSend
                  className={cx('me-1')}
                  size={20}
                />
              }
              onClick={handleImportStudents}
              title='Cập nhật'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadStudent;
