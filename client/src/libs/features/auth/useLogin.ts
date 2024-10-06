import { authApi, useGetUserMutation } from '@/services/auth';
import { SignInProps } from '@/types/auth/type';
import { get } from 'http';
import Cookies from 'js-cookie';
import { useState } from 'react';

// Use for login operator
export const useLogin = () => {
  const [loginMutation] = authApi.endpoints.login.useMutation();
  const [getUserMutation] = useGetUserMutation();
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const login = async (userData: SignInProps) => {
    setIsLoading(true);
    setError(null);

    try {
      const loginRes = await loginMutation(userData).unwrap();

      Cookies.set('accessToken', loginRes.accessToken);
      Cookies.set('refreshToken', loginRes.refreshToken);

      const userResponse = await getUserMutation({
        accessToken: loginRes.accessToken
      }).unwrap();

      console.log('User data:', userResponse);
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
