import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

interface IRecoveryProps {
  usernameOrEmail: string;
}

interface IValidOTPProps {
  usernameOrEmail: string;
  code: string;
}

interface IChangePasswordProps {
  accountID: string;
  newPassword: string;
}

export const forgetPassword = createApi({
  reducerPath: 'forgetPassword',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    Recovery: build.mutation({
      query: (recoveryProps: IRecoveryProps) => ({
        url: '/AuthService/sendeRecoverPasswordEmail',
        method: 'Post',
        data: recoveryProps
      })
    }),
    ValidOTP: build.mutation({
      query: (validProps: IValidOTPProps) => ({
        url: '/AuthService/validateEmail',
        method: 'Post',
        data: validProps
      })
    }),
    ChangePassword: build.mutation({
      query: (changePassword: IChangePasswordProps) => ({
        url: '/AuthService/changePassword',
        method: 'Post',
        data: changePassword
      })
    })
  })
});

export const { useRecoveryMutation, useValidOTPMutation, useChangePasswordMutation } =
  forgetPassword;
