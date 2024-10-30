import { Modal } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import * as XLSX from 'xlsx';
import { SiMicrosoftexcel } from 'react-icons/si';
import { useState } from 'react';
import { FaDownload } from 'react-icons/fa6';

import styles from './ModalUploadTeacherList.module.scss';
import VemsButton from '@/components/VemsButtonCustom';
import { IoRemove } from 'react-icons/io5';
import { useGetAllClassQuery } from '@/services/classes';
import { useImportTeacherMutation } from '@/services/accountManagement';
import { toast } from 'react-toastify';

const cx = className.bind(styles);

type ModalUploadTeacherProps = {
  isCloseModalTeacher: boolean;
  setIsCloseModalTeacher: any;
  refetchParent: any;
};

type TeacherRequest = {
  fullName: string;
  phone: string;
  classID?: string; // Optional classID
};

type FileUploadProps = {
  name: string;
  size: string;
  type: string;
};

const convertToJSON = (data: string[][], classes: any): TeacherRequest[] => {
  return data.map(entry => {
    const [index, fullName, phone, className] = entry;

    const classID = classes.find((item: any) => item.className === className)?.id;

    return classID
      ? {
          fullName,
          phone,
          classID
        }
      : {
          fullName,
          phone
        };
  });
};

const ModalUploadTeacher = ({
  isCloseModalTeacher,
  setIsCloseModalTeacher,
  refetchParent
}: ModalUploadTeacherProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/TEACHER_INPUT.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'TEACHER_INPUT.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();
  const { data: classes } = useGetAllClassQuery({ PageNumber: 1, PageSize: 100 });
  const [importTeacherFC] = useImportTeacherMutation();

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

  const clearFile = () => {
    setFileInfo(undefined);
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  };

  const handleImportTeachers = async () => {
    if (fileData) {
      var res = fileData.map((item: any, index: number) => {
        var rowValue = Object.values(item);
        return rowValue;
      });

      if (classes?.pageData) {
        const result = convertToJSON(res, classes?.pageData);
        var res = await importTeacherFC(result).unwrap();
        if (res) {
          refetchParent();
          toast.success('Nhập danh sách giáo viên thành công');
        }
      }
    }
  };

  return (
    <>
      <Modal
        isOpen={isCloseModalTeacher}
        className={cx('modal-wrapper')}
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-teacher-title')}>
          Tạo danh sách giáo viên
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={() => {
            setIsCloseModalTeacher(false);
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
              onClick={handleImportTeachers}
              title='Cập nhật'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadTeacher;
