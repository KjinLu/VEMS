'use client';
import { useGetInfo } from '@/hooks/info/useGetInfo';
import { RootState } from '@/libs/state/store';
import {
  useDeleteAvatarStudentMutation,
  useDeleteAvatarTeacherMutation,
  useSaveAvatarStudentMutation,
  useSaveAvatarTeacherMutation
} from '@/services/profile';
import { ShowNotify } from '@/utils/showNotify';
import { UploadOutlined, UserOutlined } from '@ant-design/icons';
import { Avatar, Button, Modal, Spin, Upload, message } from 'antd';
import Title from 'antd/es/typography/Title';
import { useEffect, useState } from 'react';
import { FaPencilAlt, FaTrashAlt } from 'react-icons/fa';
import { useSelector } from 'react-redux';
import AvatarDefault from '@/assets/images/personal/avatarDefault.jpg';

interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  onReload: () => void;
  imageDefault: string;
}

const ChangeAvatar = ({ isOpen, onClose, onReload, imageDefault }: ModalProps) => {
  const [fileList, setFileList] = useState<any[]>([]);
  const userInfo = useSelector((state: RootState) => state.auth);
  const [imagePreview, setImagePreview] = useState<string>(imageDefault);

  const [isLoading, setIsLoading] = useState<boolean>(false);

  const [uploadAvatarTeacher] = useSaveAvatarTeacherMutation();
  const [deleteAvatarTeacher] = useDeleteAvatarTeacherMutation();
  const [uploadAvatarStudent] = useSaveAvatarStudentMutation();
  const [deleteAvatarStudent] = useDeleteAvatarStudentMutation();

  const { getInfo } = useGetInfo();

  useEffect(() => {
    console.log(imageDefault);
    if (isOpen) {
      setFileList([]);
      setImagePreview(imageDefault && imageDefault != '' ? imageDefault : AvatarDefault);
    } else {
      setImagePreview('');
    }
  }, [isOpen]);

  const handleChange = ({ fileList }: any) => {
    setFileList(fileList);

    if (fileList.length > 0) {
      const file = fileList[0].originFileObj as File;
      const reader = new FileReader();
      reader.onload = e => {
        setImagePreview(e.target?.result as string);
      };
      reader.readAsDataURL(file);
    } else {
      setImagePreview('');
    }
  };

  const handleEventSave = async () => {
    await getInfo();
    setFileList([]);
  };

  const handleEventDelete = async () => {
    await getInfo();
    setFileList([]);
    setImagePreview('');
  };

  const handleSaveAvatar = async () => {
    if (fileList.length > 0) {
      setIsLoading(true);
      const formData = new FormData();
      formData.append('avatar', fileList[0].originFileObj as File);
      try {
        if (userInfo.roleName?.includes('TEACHER')) {
          const res = await uploadAvatarTeacher({
            AccountID: userInfo.accountID || '',
            file: fileList[0].originFileObj as File
          }).unwrap();

          ShowNotify({
            statusCode: res,
            messageSuccess: 'Cập nhật ảnh đại diện thành công',
            messageError: 'Cập nhật ảnh đại diện thất bại',
            OnReLoad: handleEventSave
          });
        } else if (userInfo.roleName?.includes('STUDENT')) {
          const res = await uploadAvatarStudent({
            AccountID: userInfo.accountID || '',
            file: fileList[0].originFileObj as File
          }).unwrap();

          ShowNotify({
            statusCode: res,
            messageSuccess: 'Cập nhật ảnh đại diện thành công',
            messageError: 'Cập nhật ảnh đại diện thất bại',
            OnReLoad: handleEventSave
          });
        }
      } catch (error: any) {
        ShowNotify({
          statusCode: false,
          messageError: 'Cập nhật ảnh đại diện thất bại'
        });
      } finally {
        setIsLoading(false);
      }
    }
  };

  const handleDeleteAvatar = async () => {
    setIsLoading(true);
    try {
      if (userInfo.roleName?.includes('TEACHER')) {
        const res = await deleteAvatarTeacher({
          AccountID: userInfo.accountID || ''
        }).unwrap();

        ShowNotify({
          statusCode: res,
          messageSuccess: 'Xoá ảnh đại diện thành công',
          messageError: 'Xoá ảnh đại diện thất bại',
          OnReLoad: handleEventDelete
        });
      } else if (userInfo.roleName?.includes('STUDENT')) {
        const res = await deleteAvatarStudent({
          AccountID: userInfo.accountID || ''
        }).unwrap();

        ShowNotify({
          statusCode: res,
          messageSuccess: 'Xoá ảnh đại diện thành công',
          messageError: 'Xoá ảnh đại diện thất bại',
          OnReLoad: handleEventDelete
        });
      }
    } catch (error: any) {
      ShowNotify({
        statusCode: false,
        messageError: 'Xoá ảnh đại diện thất bại'
      });
    } finally {
      setIsLoading(false);
      setFileList([]);
    }
  };

  return (
    <>
      <Modal
        open={isOpen}
        width={700}
        closeIcon={true}
        onCancel={onClose}
        cancelText='No'
        closable={false}
        footer={<></>}
      >
        <Spin spinning={isLoading}>
          <div
            className='my-3'
            style={{ textAlign: 'center' }}
          >
            <Title
              level={2}
              className='text-center title'
            >
              Đổi ảnh đại diện
            </Title>
            <Upload
              showUploadList={false}
              beforeUpload={() => false}
              onChange={handleChange}
              maxCount={1}
            >
              <Avatar
                size={200}
                icon={<UserOutlined />}
                src={imagePreview}
                style={{ cursor: 'pointer' }}
              />
            </Upload>
            <div style={{ marginTop: 16 }}>
              {/* <Button
              icon={<UploadOutlined />}
              onClick={() => document.querySelector('input[type="file"]')?.click()}
            >
              Upload Avatar
            </Button> */}
            </div>
          </div>

          <div className='d-flex justify-content-center gap-3'>
            <Button
              type='primary'
              onClick={handleSaveAvatar}
              icon={<FaPencilAlt />}
            >
              Lưu
            </Button>
            <Button
              type='primary'
              onClick={handleDeleteAvatar}
              icon={<FaTrashAlt />}
            >
              Xoá
            </Button>
          </div>
        </Spin>
      </Modal>
    </>
  );
};

export default ChangeAvatar;
