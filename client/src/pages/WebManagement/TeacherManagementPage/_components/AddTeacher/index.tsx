import React, { useState } from 'react';
import { Modal, Button, Form, Input } from 'antd';

interface AddTeacherProps {
  open: boolean;
  onClose: () => void;
  onReload: () => void;
}

const AddTeacher = ({ open, onClose, onReload }: AddTeacherProps) => {
  const [form] = Form.useForm();

  //   const handleSubmit = async () => {
  //     try {
  //       const values = await form.validateFields();
  //       form.resetFields();
  //       onReload();
  //       onClose();
  //     } catch (error) {
  //       console.error('Validation failed:', error);
  //     }
  //   };

  return (
    <Modal
      title='Thêm giáo viên mới'
      open={open}
      onCancel={onClose}
      //   onOk={handleSubmit}
      okText='Xác nhận'
      cancelText='Huỷ'
    >
      <Form
        form={form}
        layout='vertical'
      >
        <Form.Item
          label='Tên giáo viên'
          name='name'
          rules={[{ required: true, message: 'Vui lòng nhập tên giáo viên!' }]}
        >
          <Input placeholder='Nhập tên học sinh' />
        </Form.Item>
        <Form.Item
          label='Tuổi'
          name='age'
          rules={[
            { required: true, message: 'Vui lòng nhập tuổi!' },
            {
              type: 'number',
              min: 1,
              message: 'Tuổi phải lớn hơn 0!',
              transform: value => Number(value)
            }
          ]}
        >
          <Input
            type='number'
            placeholder='Nhập tuổi'
          />
        </Form.Item>

        <Form.Item
          label='Địa chỉ'
          name='address'
          rules={[{ required: true, message: 'Vui lòng nhập địa chỉ!' }]}
        >
          <Input placeholder='Nhập địa chỉ' />
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default AddTeacher;
