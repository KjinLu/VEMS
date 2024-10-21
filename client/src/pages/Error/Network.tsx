import React from 'react';
import { Button, Result } from 'antd';
import { useNavigate } from 'react-router-dom';

const Network: React.FC = () => {
  const navigate = useNavigate();

  return (
    <Result
      status='500'
      title='500'
      subTitle='Xin lỗi, máy chủ đang gặp sự cố.'
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

export default Network;
