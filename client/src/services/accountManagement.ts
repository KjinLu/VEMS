import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { getUserProps, SignInProps } from '@/types/auth/type';
import { createApi } from '@reduxjs/toolkit/query/react';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

type PaginationModel = {
  PageNumber: number;
  PageSize: number;
};

export const accountManagementApi = createApi({
  reducerPath: 'accountManagementApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getAllTeacher: build.query({
      query: (model: PaginationModel | null) => ({
        url: '/AccountManagementService/teachers',
        method: 'get',
        authRequired: true,
        params: model
        // keepUnusedDataFor: 0,
        // refetchOnFocus: true,
        // refetchOnReconnect: true,
        // pollingInterval: 5000,
        // data: userData
      })
    }),
    getAllStudent: build.query({
      query: (model: PaginationModel | null) => ({
        url: '/AccountManagementService/students',
        method: 'get',
        authRequired: true,
        params: model
      })
    }),
    getUser: build.mutation({
      query: (user: getUserProps) => ({
        url: '/AuthService?accessToken=' + user.accessToken,
        method: 'get'
        // data: user
      })
    }),
    importTeacher: build.mutation({
      query: (userData: any) => ({
        url: '/AccountManagementService/registerTeachers',
        method: 'post',
        data: userData,
        authRequired: true
      })
    })
  })
});

export const { useGetAllTeacherQuery, useGetAllStudentQuery, useImportTeacherMutation } =
  accountManagementApi;
