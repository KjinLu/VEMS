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
    getAllStudentType: build.query({
      query: () => ({
        url: '/ClassroomService/student-types',
        method: 'get'
      })
    }),
    assignStudent: build.mutation({
      query: (body: any) => ({
        url: '/ClassroomService/assign-student',
        method: 'post',
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: body
      })
    }),
    getAllGrade: build.query({
      query: () => ({
        url: '/GradeService',
        method: 'get'
      })
    }),
    getAllClass: build.query({
      query: () => ({
        url: '/ClassroomService',
        method: 'get'
      })
    })
  }),
  tagTypes: []
});

export const {
  useGetAllStudentTypeQuery,
  useGetStudentInClassQuery,
  useAssignStudentMutation,
  useGetAllGradeQuery,
  useGetAllClassQuery
} = classApi;
