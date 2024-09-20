import classNames from 'classnames/bind';
import styles from './Login.module.scss';
import { useEffect, useState } from 'react';
import requestApi from '../../helpers/api';
import {Link, useNavigate} from 'react-router-dom';
import { toast } from 'react-toastify';
const cx = classNames.bind(styles);

type LoginData = {
  username?: string;
  password?: string;
};

const Login = () => {
  const navigate = useNavigate();
  const[loginData, setLoginData] = useState<LoginData>({ username: '', password: '' });
  const [formErrors, setFormErrors] = useState<LoginData>({ username: '', password: '' });
  const [isSubmitted, setIsSubmitted] = useState(false);
  const onChange = (event: { target: any; }) => {
    let target = event.target;
    setLoginData ({
      ...loginData, [target.name]: target.value
    });
  }

  useEffect(() =>{

  })

  const validateForm = () =>{
    let isValid = true;
    const errors: { [key: string]: string } = {};
    if(loginData.username === '' || loginData.username === undefined){
      errors.username = "Vui lòng nhập tài khoản";
    }
    if(loginData.password === '' ||  loginData.password === undefined){
      errors.password = "Vui lòng nhập mật khẩu";
    }

    if(Object.keys(errors).length > 0){
      setFormErrors(errors);
      isValid = false;
    }
    else{
      setFormErrors({});
    }

    return isValid;
  }


  const onSubmit = () =>{
    console.log(loginData);
    let valid = validateForm();
    if(valid){
      console.log("request API");
      requestApi('/login', 'POST', loginData).then((res) => {
        localStorage.setItem('access_token', res.data.dataResponse.accessToken);
        localStorage.setItem('refresh_token', res.data.dataResponse.refreshToken);
       navigate('/');
      }).catch(err =>{
        console.log(err)
        if(typeof err.response !== "undefined"){
          if(err.response.status !== 201){
            toast.error(err.response.data.message, {position: "top-center"})
          }
        }else{
            toast.error("Server is down. Please try again!", {position: "top-center"})
          }
      })
    }
    setIsSubmitted(true);
  }

  return (
    <div className={cx('background-login')}>
      <div className={cx('main-container')}>
        <div className={cx('left-container')}></div>
        <div className={cx('right-container')}>
          <div className={cx('main-login')}>
            <div className={cx('tittle-login')}>
              <h1>ĐĂNG NHẬP</h1>
            </div>
            <div className={cx('user-login')}>
              <h1 className={cx('xin-chao')}>Vicompose, xin chào!</h1>
              <div className={cx('input-login')}>
                <div className={cx('input-container', 'username')}>
                  <div className={cx('i')}>
                    <i className="fas fa-user"></i>
                  </div>
                  <input type="text" name='username' onChange={onChange} placeholder="Tài khoản" />
                </div>
                <div className={cx('input-container', 'password')}>
                  <div className={cx('i')}> 
                    <i className="fas fa-lock"></i>
                 </div>
                  <input type="password" name='password' onChange={onChange} placeholder="Mật khẩu" />
                </div>
              </div>
              <div className={cx('forgot-password')}>
                <a href="">Quên mật khẩu?</a>
              </div>
              <button type='button' className={cx('button-hover')} onClick={onSubmit}>Đăng nhập</button>
            </div>
          </div>
          <div className={cx('info-login')}>
            <p>
              Các thông tin hướng dẫn sử dụng, thông tin liên hệ, quảng cáo thì
              đặt ở đây…
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
