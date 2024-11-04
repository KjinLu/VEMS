import * as yup from 'yup';

import { updateStudentAccount } from './form-schemas';

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
  username: string;
  studentTypeId: string;
  publicStudentID: string;
  classroomId: string;
  password: string;
}

export type StudentTableIndex = {
  index: number;
  studentID: string;
  publicStudentID: string;
  studentName: string;
  studentImage: string;
  studentTypeID: string;
};

export type ClassOptionData = {
  value: string;
  label: string;
};

export type AccountForm = yup.InferType<typeof updateStudentAccount>;
