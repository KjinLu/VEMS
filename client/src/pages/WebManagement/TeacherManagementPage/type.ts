import * as yup from 'yup';

import { updateTeacherAccount } from './form-schemas';

export type TeacherIndex = {
  index: number;
  id: string;
  publicTeacherID: string;
  citizenID: string;
  username: string;
  fullName: string;
  email: string;
  dob: string;
  address: string;
  image: string;
  phone: string;
  teacherTypeId: string;
  teacherType: any;
  roleId: string;
  classroomId: string;
  classRoom: any;
  password: string;
};

export type AccountForm = yup.InferType<typeof updateTeacherAccount>;
