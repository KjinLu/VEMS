import * as yup from 'yup';

import { phoneNumberRegex } from '@/utils/regexs';

export const updateTeacherAccount = yup.object({
  name: yup.string().required('Vui lòng nhập họ và tên'),
  phone: yup
    .string()
    .required('Vui lòng nhập số điện thoại')
    .matches(phoneNumberRegex, 'Số điện thoại không hợp lệ'),
  idCard: yup.string().required('Vui lòng nhập thẻ căn cước'),
  address: yup.string().required('Vui lòng nhập địa chỉ'),
  dateOfBirth: yup.string().required('Vui lòng chọn ngày sinh'),
  mail: yup.string(),
  class: yup.string()
});
