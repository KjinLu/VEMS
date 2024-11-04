import { RootState } from '@/libs/state/store';
import {
  IStudentProfile,
  ITeacherProfile,
  useGetStudentProfileQuery,
  useGetTeacherProfileQuery
} from '@/services/profile';
import { useSelector } from 'react-redux';
import { useState, useCallback } from 'react';

export interface IAdminProfile {
  image: string;
  fullName: string;
}

export const useGetProfile = () => {
  const { roleName, accountID, image } = useSelector((state: RootState) => state.auth);
  const [isLoading, setIsLoading] = useState(true);

  const studentQuery = useGetStudentProfileQuery(accountID || '', {
    skip: !roleName?.includes('STUDENT'),
    refetchOnMountOrArgChange: true,
    refetchOnFocus: true
  });
  const teacherQuery = useGetTeacherProfileQuery(accountID || '', {
    skip: !roleName?.includes('TEACHER'),
    refetchOnMountOrArgChange: true,
    refetchOnFocus: true
  });

  const getProfile = useCallback(():
    | IAdminProfile
    | ITeacherProfile
    | IStudentProfile => {
    setIsLoading(false);

    if (roleName?.includes('ADMIN')) {
      return { image: '', fullName: 'Admin' };
    }

    if (roleName?.includes('TEACHER') && teacherQuery.data) {
      return teacherQuery.data as ITeacherProfile;
    }

    if (roleName?.includes('STUDENT') && studentQuery.data) {
      return studentQuery.data as IStudentProfile;
    }

    return { image: '', fullName: '' };
  }, [roleName, image, teacherQuery.data, studentQuery.data]);

  const refetchStudentProfile = () => {
    studentQuery.refetch();
  };

  const refetchTeacherProfile = () => {
    teacherQuery.refetch();
  };

  return {
    getProfile,
    refetchStudentProfile,
    refetchTeacherProfile,
    isLoading: teacherQuery.isLoading || studentQuery.isLoading || isLoading
  };
};
