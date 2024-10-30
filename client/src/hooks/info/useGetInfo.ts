import { setCredentials } from '@/libs/features/auth/authSlice';
import { useGetUserMutation } from '@/services/auth';
import Cookies from 'js-cookie';
import { useState } from 'react';
import { useDispatch } from 'react-redux';

// Use for login operator
export const useGetInfo = () => {
  const dispatch = useDispatch();
  const [getUserMutation] = useGetUserMutation();
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getInfo = async () => {
    setIsLoading(true);
    setError(null);

    try {
      const userResponse = await getUserMutation({
        accessToken: Cookies.get('accessToken') || ''
      }).unwrap();

      dispatch(setCredentials({ ...userResponse }));
    } catch (err: any) {
      setError(err?.data?.message || 'Login failed');
      console.error('Login failed:', err);
    } finally {
      setIsLoading(false);
    }
  };

  return {
    getInfo,
    isLoading,
    error
  };
};
