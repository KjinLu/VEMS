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
    getStudentInClass: build.query({
      query: (classID: UUID) => ({
        url: '/ClassroomService/class-students?classID=' + classID,
        method: 'get'
      })
    }),
    getAllStudenType: build.query({
      query: () => ({
        url: '/ClassroomService/student-types',
        method: 'get'
      })
    })
  }),
  tagTypes: []
});

export const { useGetAllStudenTypeQuery, useGetStudentInClassQuery } = classApi;
