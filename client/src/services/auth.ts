import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';

// const NEXT_PUBLIC_API = process.env.NEXT_PUBLIC_API || '';
const NEXT_PUBLIC_API = 'https://reqres.in/';

export const authApi = createApi({
  baseQuery: axiosBaseQuery({
    baseUrl: 'https://reqres.in/'
  }),
  endpoints: build => ({
    login: build.query({
      query: () => ({
        url: 'api/users?page=1',
        method: 'get',
        authRequired: true,
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000
      })
    }),
    register: build.mutation({
      query: userData => ({
        url: '/register',
        method: 'Post',
        body: userData
      })
    })
  })
});

export const { useLoginQuery, useRegisterMutation } = authApi;
