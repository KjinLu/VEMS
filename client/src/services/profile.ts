import { axiosBaseQuery } from '@/libs/axios/axiosBase';
import { createApi } from '@reduxjs/toolkit/query/react';
import { UUID } from 'crypto';

const baseUrl = import.meta.env.VITE_PUBLIC_API || '';

interface StudentProfile {
  id: string;
  publicStudentID: string;
  fullName: string;
  citizenID: string;
  username: string;
  password: string;
  email: string;
  dob: null;
  address: string;
  image: string;
  phone: string;
  parentPhone: string;
  homeTown: string;
  unionJoinDate: string;
  studentTypeName: string;
  classRoom: string;
}

export const profileApi = createApi({
  reducerPath: 'profileApi',
  baseQuery: axiosBaseQuery({
    baseUrl
  }),
  endpoints: build => ({
    getStudentProfile: build.query<StudentProfile, string>({
      query: (profileId: string) => ({
        url: '/api/student-service/profile?id=' + profileId,
        method: 'get'
      })
    }),
    getTeacherProfile: build.query({
      query: (profileId: string) => ({
        url: '/api/teacher-service/profile?id' + profileId,
        method: 'get'
      })
    })
  }),
  tagTypes: []
});

export const { useGetStudentProfileQuery, useGetTeacherProfileQuery } = profileApi;
