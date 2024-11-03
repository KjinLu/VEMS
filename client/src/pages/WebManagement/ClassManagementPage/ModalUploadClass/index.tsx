import { Modal } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import * as XLSX from 'xlsx';
import { SiMicrosoftexcel } from 'react-icons/si';
import { useState } from 'react';
import { FaDownload } from 'react-icons/fa6';

import styles from './ModalUploadClass.module.scss';
import VemsButton from '@/components/VemsButtonCustom';
import { IoRemove } from 'react-icons/io5';
import { Grade } from '@mui/icons-material';
import {
  useGetAllClassQuery,
  useGetAllGradeQuery,
  useImportClassMutation
} from '@/services/classes';
import { toast } from 'react-toastify';

const cx = className.bind(styles);

type ModalUploadClassProps = {
  isCloseModalClass: boolean;
  setIsCloseModalClass: any;
  refetchParent: any;
};

type FileUploadProps = {
  name: string;
  size: string;
  type: string;
};

const ModalUploadClass = ({
  isCloseModalClass,
  setIsCloseModalClass,
  refetchParent
}: ModalUploadClassProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/CLASS_INPUT.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'CLASS_INPUT.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();
  const [importClassFC] = useImportClassMutation();
  const { data: gradeResponse } = useGetAllGradeQuery(
    { PageNumber: 1, PageSize: 100 },
    {
      refetchOnMountOrArgChange: true,
      refetchOnFocus: true
    }
  );

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

        const formattedData = jsonData.map((item: any) => ({
          no: item['STT'],
          classroom: item['Lớp'],
          grade: item['Khối']
        }));

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

  const handleImportClass = async () => {
    try {
      if (fileData && gradeResponse?.pageData) {
        var res = fileData.map((item: any) => {
          const gradeId = gradeResponse.pageData.find((c: any) => {
            return c.gradeName == item.grade;
          })?.id;

          if (gradeId) {
            return {
              className: item.classroom,
              gradeID: gradeId
            };
          }
        });

        // Uncomment and modify this section based on your import function
        if (res) {
          await importClassFC(res).unwrap();
          refetchParent();
          toast.success('Nhập lớp học thành công');
        }
      }
    } catch (e: any) {
      toast.error('Nhập lớp học thất bại');
    }
  };

  const clearFile = () => {
    setFileInfo(undefined);
    setFileData(undefined);
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  };

  return (
    <>
      <Modal
        isOpen={isCloseModalClass}
        className={cx('modal-wrapper')}
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-class-title')}>
          Tạo danh sách lớp học
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={() => {
            setIsCloseModalClass(false);
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
              onClick={handleImportClass}
              title='Cập nhật'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadClass;
