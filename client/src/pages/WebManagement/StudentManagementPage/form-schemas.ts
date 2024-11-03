import * as yup from 'yup';

import { phoneNumberRegex } from '@/utils/regexs';

export const updateStudentAccount = yup.object({
  name: yup.string().required('Vui lòng nhập họ và tên'),
  studentId: yup.string().required('Vui lòng nhập mã định danh'),
  studentType: yup.string(),
  studentPhone: yup
    .string()
    .required('Vui lòng nhập số điện thoại')
    .matches(phoneNumberRegex, 'Số điện thoại không hợp lệ'),
  parentPhone: yup
    .string()
    .required('Vui lòng nhập số điện thoại')
    .matches(phoneNumberRegex, 'Số điện thoại không hợp lệ'),
  cardId: yup.string().required('Vui lòng nhập thẻ căn cước'),
  dateOfBirth: yup.string().required('Vui lòng chọn ngày sinh'),
  dateOfUnion: yup.string().required('Vui lòng chọn ngày gia nhập đoàn'),
  address: yup.string().required('Vui lòng nhập địa chỉ'),
  hometown: yup.string().required('Vui lòng nhập quê quán'),
  mail: yup.string()
});
