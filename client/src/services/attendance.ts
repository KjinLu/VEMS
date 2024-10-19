import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const attendanceApi = createApi({
  reducerPath: 'attendance',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getStudentInClass: build.query({
      query: (classID: UUID) => ({
        url: '/api/student-service/class?classID=' + classID,
        method: 'get'
      })
    }),
    getStatuses: build.query({
      query: () => ({
        url: '/api/attendance/attendanceStatusOptions',
        method: 'get'
      })
    }),
    getReasons: build.query({
      query: () => ({
        url: '/api/attendance/attendanceReasonOptions',
        method: 'get'
      })
    }),
    getAttendanceScheduleOfClass: build.query({
      query: ({ classID, time }: { classID: UUID; time: string }) => ({
        url: `/api/attendance/getNeedAttendanceInfo`,
        method: 'get',
        params: {
          ClassID: classID, // Corrected to uppercase
          Time: time // Corrected to uppercase
        }
      })
    }),
    takeAttendanceForClass: build.mutation({
      query: (attendanceData: any) => ({
        url: `/api/attendance/takeAttendanceForClass`,
        method: 'Post',
        // authRequired: true,
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: attendanceData
      })
    }),
    editAttendanceForClasss: build.query({
      query: ({ classID, time }: { classID: UUID; time: string }) => ({
        url: `/api/attendance/getNeedAttendanceInfo`,
        method: 'get',
        params: {
          ClassID: classID, // Corrected to uppercase
          Time: time // Corrected to uppercase
        }
      })
    })
  }),
  tagTypes: []
});

export const {
  useGetAttendanceScheduleOfClassQuery,
  useGetReasonsQuery,
  useGetStatusesQuery,
  useGetStudentInClassQuery,
  useTakeAttendanceForClassMutation
} = attendanceApi;
