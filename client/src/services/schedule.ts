import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const scheduleApi = createApi({
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getClassSchedule: build.query({
      query: (classID: UUID) => ({
        url: '/api/schedule-service/get-class-schedule?classID=' + classID,
        method: 'Get'
      })
    }),
    getScheduleDetail: build.query({
      query: (scheduleDetailID: UUID) => ({
        url: '/api/schedule-service/get-schedule-detail?ScheduleID=' + scheduleDetailID,
        method: 'Get'
      })
    })
  })
});

export const { useGetClassScheduleQuery, useGetScheduleDetailQuery } = scheduleApi;
