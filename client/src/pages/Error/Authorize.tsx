import React from 'react';
import { Button, Result } from 'antd';
import { useNavigate } from 'react-router-dom';

const Authorise: React.FC = () => {
  const navigate = useNavigate();

  return (
    <Result
      status='403'
      title='401'
      subTitle='Xin lỗi, bạn không có quyền truy cập trang này.'
      extra={
        <Button
          type='primary'
          onClick={() => navigate('/')}
        >
          Trở lại
        </Button>
      }
    />
  );
};

export default Authorise;
