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
    }),
    getAllSession: build.query({
      query: () => ({
        url: '/ScheduleService/get-class-session-of-week',
        method: 'get'
      })
    }),
    getAllSubject: build.query({
      query: () => ({
        url: '/ScheduleService/get-class-subject',
        method: 'get'
      })
    }),
    getAllSchedule: build.query({
      query: () => ({
        url: '/ScheduleService/get-all-schedule',
        method: 'get'
      })
    }),
    getAllSlots: build.query({
      query: () => ({
        url: '/SlotService/all',
        method: 'get'
      })
    }),
    createNewSchedule: build.mutation({
      query: (data: any) => ({
        url: '/ScheduleService/create-new-schedule',
        method: 'post',
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: data
      })
    }),
    createNewListSchedule: build.mutation({
      query: (data: any) => ({
        url: '/ScheduleService/create-new-list-schedule',
        method: 'post',
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: data
      })
    }),
    createScheduleDetail: build.mutation({
      query: (data: any) => ({
        url: '/ScheduleService/create-schedule-detail',
        method: 'post',
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: data
      })
    }),
    createTeacherSchedule: build.mutation({
      query: (data: any) => ({
        url: '/ScheduleService/create-teacher-schedule',
        method: 'post',
        keepUnusedDataFor: 0,
        refetchOnFocus: true,
        refetchOnReconnect: true,
        pollingInterval: 5000,
        data: data
      })
    })
  }),
  tagTypes: []
});

export const {
  useGetClassScheduleQuery,
  useGetScheduleDetailQuery,
  useGetTeacherScheduleDetailQuery,
  useGetAllTeacherScheduleDetailQuery,
  useGetAllSubjectQuery,
  useGetAllSessionQuery,
  useGetAllScheduleQuery,
  useCreateNewListScheduleMutation,
  useCreateScheduleDetailMutation,
  useCreateNewScheduleMutation,
  useGetAllSlotsQuery,
  useCreateTeacherScheduleMutation
} = scheduleApi;
