import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';

export interface IStudentProfile {
  id: string;
  publicStudentID: string;
  fullName: string;
  citizenID: string;
  username: string;
  password: string;
  email: string;
  dob: string | null;
  address: string;
  image: string;
  phone: string;
  parentPhone: string;
  homeTown: string;
  unionJoinDate: string;
  studentTypeName: string;
  classRoom: string;
}
export interface IUpdateStudentProfile {
  studentId: string;
  fullName: string;
  citizenID: string;
  email: string;
  dob: string;
  address: string;
  phone: string;
  parentPhone: string;
  homeTown: string;
  unionJoinDate: string;
}

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export const adminApi = createApi({
  reducerPath: 'adminApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    // Class -----------------------------------------------------------------------------------
    getAllClass: build.query({
      query: (data?: any) => ({
        url: '/ClassroomService',
        method: 'get',
        params: data
      })
    }),
    // Teacher -----------------------------------------------------------------------------------
    updateTeacherProfile: build.mutation({
      query: (teacherData?: any) => ({
        url: '/AccountManagementService/updateTeacherAccount',
        method: 'put',
        data: teacherData,
        authRequired: true
      })
    }),
    // Student -----------------------------------------------------------------------------------
    getStudentsList: build.query({
      query: ({ PageNumber, PageSize }: { PageNumber: string; PageSize: string }) => ({
        url: `/AccountManagementService/students?PageNumber=${PageNumber}&PageSize=${PageSize}`,
        method: 'get'
      })
    }),
    getStudentInClass: build.query({
      query: (classID: string) => ({
        url: '/ClassroomService/class-students?classID=' + classID,
        method: 'get'
      })
    }),
    getStudentProfile: build.query<IStudentProfile, string>({
      query: (profileId: string) => ({
        url: '/StudentService/profile?id=' + profileId,
        method: 'get'
      })
    }),
    updateStudentProfile: build.mutation({
      query: (profile: IUpdateStudentProfile) => ({
        url: '/AccountManagementService/updateStudentAccount',
        method: 'put',
        authRequired: true,
        data: profile
      })
    })
  }),
  tagTypes: []
});

export const {
  // Class
  useGetAllClassQuery,
  // Teacher
  useUpdateTeacherProfileMutation,
  // Student
  useGetStudentsListQuery,
  useGetStudentInClassQuery,
  useUpdateStudentProfileMutation,
  useGetStudentProfileQuery
} = adminApi;
