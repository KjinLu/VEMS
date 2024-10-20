import Cookies from 'js-cookie';
import { useDispatch } from 'react-redux';
import { logout } from '@/libs/features/auth/authSlice';
import { useNavigate } from 'react-router-dom';

export const useLogout = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = async () => {
    try {
      await Cookies.remove('accessToken');
      await Cookies.remove('refreshToken');

      await dispatch(logout());

      navigate('/login');
    } catch (err) {
      console.error('Logout failed:', err);
    }
  };

  return handleLogout;
};
