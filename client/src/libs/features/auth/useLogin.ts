import { authApi } from '@/services/auth';
import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { setCredentials } from './authSlice';
import { LoginResult, UserData } from './type';

// Use for login operator
export const useLogin = (): LoginResult => {
  const dispatch = useDispatch();
  const [loginMutation] = authApi.endpoints.login.useMutation();
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const login = async (userData: UserData) => {
    setIsLoading(true);
    setError(null);

    try {
      const { data } = await loginMutation(userData).unwrap();

      //Save the access token and refresh token to the Redux store
      dispatch(
        setCredentials({
          accessToken: data.accessToken,
          refreshToken: data.refreshToken
        })
      );
    } catch (err: any) {
      setError(err?.data?.message || 'Login failed');
      console.error('Login failed:', err);
    } finally {
      setIsLoading(false);
    }
  };

  return {
    login,
    isLoading,
    error
  };
};
