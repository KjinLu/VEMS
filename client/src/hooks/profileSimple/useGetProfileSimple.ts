import { RootState } from '@/libs/state/store';
import { useGetStudentProfileQuery, useGetTeacherProfileQuery } from '@/services/profile';
import { useSelector } from 'react-redux';
import { useState, useCallback } from 'react';

export interface IProfileSimple {
  image: string;
  fullName: string;
  typeName: string;
}

export const useGetProfileSimple = () => {
  const { roleName, accountID, image } = useSelector((state: RootState) => state.auth);
  const [isLoading, setIsLoading] = useState(true);

  const studentQuery = useGetStudentProfileQuery(accountID || '', {
    skip: !roleName?.includes('STUDENT'),
    // refetchOnMountOrArgChange: true,
    refetchOnFocus: true
  });
  const teacherQuery = useGetTeacherProfileQuery(accountID || '', {
    skip: !roleName?.includes('TEACHER'),
    // refetchOnMountOrArgChange: true,
    refetchOnFocus: true
  });

  const getProfile = useCallback((): IProfileSimple => {
    setIsLoading(false);

    if (roleName?.includes('ADMIN')) {
      return { image: '', fullName: 'Admin', typeName: 'Admin' };
    }

    if (roleName?.includes('TEACHER') && teacherQuery.data) {
      return {
        image: image || '',
        fullName: teacherQuery.data.fullName,
        typeName: teacherQuery.data.teacherTypeName
      };
    }

    if (roleName?.includes('STUDENT') && studentQuery.data) {
      return {
        image: image || '',
        fullName: studentQuery.data.fullName,
        typeName: studentQuery.data.studentTypeName
      };
    }

    return { image: '', fullName: '', typeName: '' };
  }, [roleName, image, teacherQuery.data, studentQuery.data]);

  return {
    getProfile,
    isLoading: teacherQuery.isLoading || studentQuery.isLoading || isLoading
  };
};
