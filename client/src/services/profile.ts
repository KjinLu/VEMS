import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

export interface ITeacherProfile {
  id: string;
  publicTeacherID: string | null;
  fullName: string;
  citizenID: string;
  username: string;
  password: string;
  email: string;
  dob: string | null;
  address: string;
  image: string;
  phone: string;
  teacherTypeName: string;
  classRoom: string;
}

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

export interface IUpdateTeacherProfile {
  teacherId: string;
  publicTeacherID: string;
  fullName: string;
  citizenID: string;
  email: string;
  dob: string;
  address: string;
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

export interface ISaveAvatar {
  AccountID: string;
  file: File;
}

export interface IDeleteAvatar {
  AccountID: string;
}

export const profileApi = createApi({
  reducerPath: 'profileApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getAdminProfile: build.query({
      query: () => ({
        url: '/admin-service/profile',
        method: 'get'
      })
    }),
    getTeacherProfile: build.query<ITeacherProfile, string>({
      query: (profileId: string) => ({
        url: '/teacher-service/profile',
        method: 'get',
        params: {
          id: profileId
        }
      })
    }),
    getStudentProfile: build.query<IStudentProfile, string>({
      query: (profileId: string) => ({
        url: '/StudentService/profile',
        method: 'get',
        params: {
          id: profileId
        }
      })
    }),
    updateTeacherProfile: build.mutation({
      query: (profile: IUpdateTeacherProfile) => ({
        url: '/teacher-service/update-profile',
        method: 'put',
        authRequired: true,
        data: profile
      })
    }),
    updateStudentProfile: build.mutation({
      query: (profile: IUpdateStudentProfile) => ({
        url: '/studentService/update-profile',
        method: 'put',
        authRequired: true,
        data: profile
      })
    }),
    saveAvatarTeacher: build.mutation<boolean, ISaveAvatar>({
      query: (formData: ISaveAvatar) => ({
        url: '/teacher-service/upload-avatar',
        method: 'post',
        authRequired: true,
        data: formData,
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      })
    }),
    deleteAvatarTeacher: build.mutation<boolean, IDeleteAvatar>({
      query: (formData: IDeleteAvatar) => ({
        url: '/teacher-service/delete-avatar',
        method: 'delete',
        authRequired: true,
        data: formData
      })
    }),
    saveAvatarStudent: build.mutation<boolean, ISaveAvatar>({
      query: (formData: ISaveAvatar) => ({
        url: '/studentService/upload-avatar',
        method: 'post',
        authRequired: true,
        data: formData,
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      })
    }),
    deleteAvatarStudent: build.mutation<boolean, IDeleteAvatar>({
      query: (formData: IDeleteAvatar) => ({
        url: '/studentService/delete-avatar',
        method: 'delete',
        authRequired: true,
        data: formData
      })
    }),
    changeStudentPassword: build.mutation({
      query: (data: any) => ({
        url: '/StudentService/update-password',
        method: 'put',
        authRequired: true,
        data
      })
    }),
    changeTeacherPassword: build.mutation({
      query: (data: any) => ({
        url: '/teacher-service/update-password',
        method: 'put',
        authRequired: true,
        data
      })
    })
  }),
  tagTypes: []
});

export const {
  useGetStudentProfileQuery,
  useGetTeacherProfileQuery,
  useUpdateTeacherProfileMutation,
  useUpdateStudentProfileMutation,
  useSaveAvatarTeacherMutation,
  useDeleteAvatarTeacherMutation,
  useSaveAvatarStudentMutation,
  useDeleteAvatarStudentMutation,
  useChangeStudentPasswordMutation,
  useChangeTeacherPasswordMutation
} = profileApi;
