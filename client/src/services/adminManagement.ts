import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const classApi = createApi({
  reducerPath: 'classApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getStudentsList: build.query({
      query: ({ PageNumber, PageSize }: { PageNumber: string; PageSize: string }) => ({
        url: `/AccountManagementService/students?PageNumber=${PageNumber}&PageSize=${PageSize}`,
        method: 'get'
      })
    }),
    getSInClass: build.query({
      query: (classID: UUID) => ({
        url: '/StudentService/student-service/class?classID=' + classID,
        method: 'get'
      })
    })
  }),
  tagTypes: []
});

export const { useGetStudentsListQuery, useGetSInClassQuery } = classApi;
