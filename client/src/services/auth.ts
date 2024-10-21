import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { getUserProps, SignInProps } from '@/types/auth/type';
import { createApi } from '@reduxjs/toolkit/query/react';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const authApi = createApi({
  reducerPath: 'authApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    login: build.mutation({
      query: (userData: SignInProps) => ({
        url: '/api/auth/login',
        method: 'Post',
        // authRequired: true,
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: userData
      })
    }),
    getUser: build.mutation({
      query: (user: getUserProps) => ({
        url: '/api/auth?accessToken=' + user.accessToken,
        method: 'Post'
        // data: user
      })
    })
    // register: build.mutation({
    //   query: userData => ({
    //     url: '/register',
    //     method: 'Post',
    //     body: userData
    //   })
    // })
  })
});

export const { useLoginMutation, useGetUserMutation } = authApi;
