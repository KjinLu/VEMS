import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const scheduleApi = createApi({
  reducerPath: 'scheduleApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getClassSchedule: build.query({
      query: (classID: UUID) => ({
        url: '/ScheduleService/get-class-schedule?classID=' + classID,
        method: 'get'
      })
    }),
    getScheduleDetail: build.query({
      query: (scheduleDetailID: UUID) => ({
        url: '/ScheduleService/get-schedule-detail?ScheduleID=' + scheduleDetailID,
        method: 'get'
      })
    }),
    getTeacherScheduleDetail: build.query({
      query: (teacherID: UUID) => ({
        url: '/ScheduleService/get-teacher-schedule-detail?TeacherID=' + teacherID,
        method: 'get'
      })
    }),
    getAllTeacherScheduleDetail: build.query({
      query: () => ({
        url: '/ScheduleService/get-all-teacher-schedule-detail',
        method: 'get'
      })
    })
  }),
  tagTypes: []
});

export const {
  useGetClassScheduleQuery,
  useGetScheduleDetailQuery,
  useGetTeacherScheduleDetailQuery,
  useGetAllTeacherScheduleDetailQuery
} = scheduleApi;
