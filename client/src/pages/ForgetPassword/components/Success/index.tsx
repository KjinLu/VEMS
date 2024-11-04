import { Button, Result } from 'antd';

const SuccessComp = () => {
  return (
    <>
      <Result
        status='success'
        title='Đổi mật khẩu thành công'
        subTitle='Vui lòng đăng nhập để tiếp tục'
      />
    </>
  );
};

export default SuccessComp;
