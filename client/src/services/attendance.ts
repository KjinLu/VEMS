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
        url: '/StudentService/student-service/class?classID=' + classID,
        method: 'get'
      })
    }),
    getStudentAttendanceReport: build.query({
      query: (studentID: UUID) => ({
        url: '/AttendanceService/getHistoryAttendanceForStudent?id=' + studentID,
        method: 'get'
      })
    }),
    getStatuses: build.query({
      query: () => ({
        url: '/AttendanceService/attendanceStatusOptions',
        method: 'get'
      })
    }),
    getReasons: build.query({
      query: () => ({
        url: '/AttendanceService/attendanceReasonOptions',
        method: 'get'
      })
    }),
    getAttendanceScheduleOfClass: build.query({
      query: ({ classID, time }: { classID: UUID; time: string }) => ({
        url: `/AttendanceService/getNeedAttendanceInfo`,
        method: 'get',
        params: {
          ClassID: classID, // Corrected to uppercase
          Time: time // Corrected to uppercase
        }
      })
    }),
    takeAttendanceForClass: build.mutation({
      query: (attendanceData: any) => ({
        url: `/AttendanceService/takeAttendanceForClass`,
        method: 'Post',
        // authRequired: true,
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: attendanceData
      })
    }),
    getAttendanceOfClass: build.query({
      query: ({ classID, time }: { classID: UUID; time: string }) => ({
        url: `/AttendanceService/getAttendanceForClass`,
        method: 'get',
        params: {
          ClassID: classID, // Corrected to uppercase
          Time: time // Corrected to uppercase
        }
      })
    }),
    updateAttendanceForClass: build.mutation({
      query: (attendanceData: any) => ({
        url: `/AttendanceService/updateAttendanceForClass`,
        method: 'Post',
        // authRequired: true,
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: attendanceData
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
  useTakeAttendanceForClassMutation,
  useGetAttendanceOfClassQuery,
  useUpdateAttendanceForClassMutation,
  useGetStudentAttendanceReportQuery
} = attendanceApi;
