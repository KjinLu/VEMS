import { Modal } from 'reactstrap';
import className from 'classnames/bind';
import { IoIosSend, IoMdClose } from 'react-icons/io';
import * as XLSX from 'xlsx';
import { SiMicrosoftexcel } from 'react-icons/si';
import { useEffect, useState } from 'react';
import { FaDownload } from 'react-icons/fa6';

import styles from './ModalUploadSchedule.module.scss';
import VemsButton from '@/components/VemsButtonCustom';
import fs from 'fs';
import { IoRemove } from 'react-icons/io5';

const cx = className.bind(styles);

type ModalUploadScheduleProps = {
  isCloseModalSchedule: boolean;
  setIsCloseModalSchedule: any;
};

type FileUploadProps = {
  name: string;
  size: string;
  type: string;
};

const sampleData = [
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'N.Ngữ',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Sử',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'GDQP',
    __EMPTY_5: 'GDKT-PL',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'GDKT-PL',
    __EMPTY_3: 'TD',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Địa',
    __EMPTY_3: 'TD',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Văn',
    __EMPTY_2: 'HĐTN-HN',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'Địa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'HĐTN-HN',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A3 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Hóa',
    __EMPTY_2: 'Tin',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'HĐTN-HN',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Tin',
    __EMPTY_2: 'Văn',
    __EMPTY_3: 'Địa',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'Địa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Sử',
    __EMPTY_2: 'Văn',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'GDQP',
    __EMPTY_4: '',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: '',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A4 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Văn',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'GDQP',
    __EMPTY_3: 'Lí',
    __EMPTY_4: 'Văn',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Sử',
    __EMPTY_3: 'Lí',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'N.Ngữ',
    __EMPTY_3: 'Tin',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Tin',
    __EMPTY_2: 'Địa',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Địa',
    __EMPTY_4: '',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A5 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Lí',
    __EMPTY_3: 'TD',
    __EMPTY_4: 'Văn',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Lí',
    __EMPTY_3: 'TD',
    __EMPTY_4: 'Văn',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Văn',
    __EMPTY_3: 'Sử',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'GDQP',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Hóa',
    __EMPTY_2: 'GDKT-PL',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Hóa',
    __EMPTY_2: 'Tin',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Tin',
    __EMPTY_4: '',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'GDKT-PL',
    __EMPTY_4: '',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'HĐTN-HN',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A6 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'Tin',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'GDKT-PL',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Sử',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'N.Ngữ',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'GDQP',
    __EMPTY_4: 'N.Ngữ',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'GDKT-PL',
    __EMPTY_2: 'Tin',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'TD',
    __EMPTY_4: '',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'TD',
    __EMPTY_4: '',
    __EMPTY_5: 'Toán',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A7 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Tin',
    __EMPTY_3: 'GDQP',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'HĐTN-HN',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Sử',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'Lí',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Sinh',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'Tin',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'Lí',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'Sinh',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'Sinh',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A8 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'GDQP',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Sử',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Hóa',
    __EMPTY_2: 'Sinh',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'Sinh',
    __EMPTY_3: 'Lí',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'TD',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: 'Sinh',
    __EMPTY_4: 'Tin',
    __EMPTY_5: 'TD',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Hóa',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Tin',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A9 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'N.Ngữ',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'CNghệ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'N.Ngữ',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'GDQP',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Sinh',
    __EMPTY_3: 'Sinh',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Lí',
    __EMPTY_3: 'Sử',
    __EMPTY_4: 'TD',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'Lí',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'CNghệ',
    __EMPTY_4: '',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'Lí',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A10 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'Sinh',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'TD',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Toán',
    __EMPTY_3: 'Sinh',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'TD',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'N.Ngữ',
    __EMPTY_2: 'Sử',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'Hóa',
    __EMPTY_5: 'GDKT-PL',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'HĐTN-HN',
    __EMPTY_2: 'GDKT-PL',
    __EMPTY_3: 'Hóa',
    __EMPTY_4: 'N.Ngữ',
    __EMPTY_5: 'Địa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Văn',
    __EMPTY_2: 'Địa',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Văn',
    __EMPTY_4: '',
    __EMPTY_5: 'Sinh',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'GDQP',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A11 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'Sinh',
    __EMPTY_3: 'Sinh',
    __EMPTY_4: 'Tin',
    __EMPTY_5: 'GDQP',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Văn',
    __EMPTY_2: 'Sinh',
    __EMPTY_3: 'CNghệ',
    __EMPTY_4: 'Sử',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Tin',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Hóa',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'CNghệ',
    __EMPTY_5: 'Hóa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'HĐTN-HN',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Toán',
    __EMPTY_4: '',
    __EMPTY_5: 'N.Ngữ',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)':
      'THỜI KHÓA BIỂU LỚP 10A12 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'S',
    __EMPTY: '1',
    __EMPTY_1: 'SHDC',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'Sử',
    __EMPTY_4: 'GDQP',
    __EMPTY_5: 'HĐTN-HN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: 'Lí',
    __EMPTY_2: 'TD',
    __EMPTY_3: 'N.Ngữ',
    __EMPTY_4: 'Địa',
    __EMPTY_5: 'Địa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: 'Toán',
    __EMPTY_2: 'GDKT-PL',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'Địa',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: 'Tin',
    __EMPTY_2: 'N.Ngữ',
    __EMPTY_3: 'Văn',
    __EMPTY_4: 'Toán',
    __EMPTY_5: 'GDKT-PL',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: 'Sử',
    __EMPTY_2: 'N.Ngữ',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'Buổi',
    __EMPTY: 'Tiết',
    __EMPTY_1: 'Thứ 2',
    __EMPTY_2: 'Thứ 3',
    __EMPTY_3: 'Thứ 4',
    __EMPTY_4: 'Thứ 5',
    __EMPTY_5: 'Thứ 6',
    __EMPTY_6: 'Thứ 7'
  },
  {
    'THỜI KHÓA BIỂU LỚP 10A2 NĂM HỌC 2024-2025  ÁP DỤNG NGÀY 06/09/2024 (Mới)': 'C',
    __EMPTY: '1',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Lí',
    __EMPTY_4: '',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '2',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'Tin',
    __EMPTY_4: '',
    __EMPTY_5: 'Văn',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '3',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: 'HĐTN-HN',
    __EMPTY_4: '',
    __EMPTY_5: 'SHCN',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '4',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  },
  {
    __EMPTY: '5',
    __EMPTY_1: '',
    __EMPTY_2: '',
    __EMPTY_3: '',
    __EMPTY_4: '',
    __EMPTY_5: '',
    __EMPTY_6: ''
  }
];

const ModalUploadSchedule = ({
  isCloseModalSchedule,
  setIsCloseModalSchedule
}: ModalUploadScheduleProps) => {
  const handleDownload = () => {
    const url = `http://localhost:3000/Thời khóa biểu mẫu.xlsx`;

    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', 'Thời khóa biểu mẫu.xlsx');
    document.body.appendChild(link);
    link.click();
    link.remove();
  };

  const [fileInfo, setFileInfo] = useState<FileUploadProps>();
  const [fileData, setFileData] = useState<any>();

  const handleFileUpload = (e: any) => {
    const file = e.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = (event: any) => {
        const data = new Uint8Array(event.target.result);
        const workbook = XLSX.read(data, { type: 'array' });
        const sheetName = workbook.SheetNames[0];
        const worksheet = workbook.Sheets[sheetName];
        const jsonData = XLSX.utils.sheet_to_json(worksheet);
        setFileData(jsonData);

        setFileInfo({
          name: file.name,
          size: (file.size / 1024).toFixed(2) + ' KB',
          type: file.type
        });
      };
      reader.readAsArrayBuffer(file);
    }
  };

  const handleUpdate = () => {
    if (fileData) {
      console.log('Thời khóa biểu đã xử lý:');
    } else {
      console.log('Không có file để cập nhật');
    }
  };

  // Xử lý xóa file
  const clearFile = () => {
    setFileInfo(undefined);
    setFileData(undefined);
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  };

  ////////////////////////////////////////////////////////////////////////////
  //////////?????????????????????????????????????????????/////////////////////
  // TKB mỗi lớp cách nhau 13 record

  const a = sampleData[0 + 13];
  const b = sampleData[1 + 13]; // Slot 1 T2 - T7 S
  const c = sampleData[2 + 13]; // Slot 2 T2 - T7 S
  const d = sampleData[3 + 13]; // Slot 3 T2 - T7 S
  const e = sampleData[4 + 13]; // Slot 4 T2 - T7 S
  const f = sampleData[5 + 13]; // Slot 5 T2 - T7 S
  const g = sampleData[6 + 13]; // Slot 6 T2 - T7 C
  const h = sampleData[7 + 13]; // Slot 7 T2 - T7 C
  const i = sampleData[8 + 13]; // Slot 8 T2 - T7 C
  const j = sampleData[9 + 13]; // Slot 9 T2 - T7 C
  const k = sampleData[10 + 13]; // Slot 10 T2 - T7 C //
  const l = sampleData[11 + 13]; // Slot 11 T2 - T7 C //

  const aValues = Object.values(a);
  const bValues = Object.values(b);
  const cValues = Object.values(c);
  const dValues = Object.values(d);
  const eValues = Object.values(e);
  const fValues = Object.values(f);
  const gValues = Object.values(g);
  const hValues = Object.values(h);
  const iValues = Object.values(i);
  const jValues = Object.values(j);
  const kValues = Object.values(k);
  const lValues = Object.values(l);

  // console.log(aValues);
  // console.log(bValues.slice(1));
  // console.log(cValues);
  // console.log(dValues);
  // console.log(eValues);
  // console.log(fValues);
  // console.log(gValues);
  // console.log(hValues.slice(1));
  // console.log(iValues);
  // console.log(jValues);
  // console.log(kValues);
  // console.log(lValues);

  const handleToTimeTable = () => {
    if (fileData) {
      const dataLength = fileData.length;
      console.log('dataLength: ' + dataLength);

      fileData.forEach((item: any, index: number) => {
        if (index + 13 < dataLength - 1) {
          var rowValue = Object.values(item);
          console.log(rowValue);
        }
      });
    }
  };

  handleToTimeTable();

  useEffect(() => {}, [fileData]);

  console.log(fileData);

  ////////////////////////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////////////////

  return (
    <>
      <Modal
        isOpen={isCloseModalSchedule}
        className={cx('modal-wrapper')}
      >
        <h2 className={cx('text-uppercase', 'title', 'modal-schedule-title')}>
          Tạo thời khóa biểu
        </h2>

        {/* Icon close */}
        <div
          className={cx('modal-icon-close')}
          onClick={() => {
            setIsCloseModalSchedule(false);
          }}
        >
          <IoMdClose
            size={30}
            color='#ccc'
          />
        </div>

        {/* Modal content */}
        <div className={cx('modal-content')}>
          <div className={cx('line-break')}></div>
          <div className={cx('content-file-upload-wrapper')}>
            <div className={cx('content-file-upload')}>
              <div>
                <h3 className={cx('title', 'upload-file-title', 'mb-4')}>
                  Cập nhật tập tin Excel
                </h3>

                <div className='custom-file-upload'>
                  <input
                    type='file'
                    id='file-upload'
                    accept='.xlsx, .xls'
                    onChange={handleFileUpload}
                  />
                  <label
                    htmlFor='file-upload'
                    className={cx('upload-file-btn')}
                  >
                    {' '}
                    <SiMicrosoftexcel
                      size={20}
                      className={cx('me-2')}
                    />
                    Chọn tệp
                  </label>
                </div>

                {fileInfo && (
                  <div style={{ marginTop: '20px' }}>
                    <p style={{ wordWrap: 'break-word' }}>
                      <strong>File Name:</strong> {fileInfo.name}
                    </p>
                    <p>
                      <strong>File Size:</strong> {fileInfo.size}
                    </p>
                    <p>
                      <strong>File Type:</strong> {fileInfo.type}
                    </p>
                    <VemsButton
                      color='danger'
                      leftIcon={
                        <IoRemove
                          className={cx('me-1')}
                          size={20}
                        />
                      }
                      onClick={clearFile}
                      title='Xóa file'
                    />
                  </div>
                )}
              </div>
            </div>
          </div>
          <div className={cx('line-break')}></div>

          <div
            className={cx('d-flex justify-content-end mt-3')}
            style={{
              paddingRight: '30px'
            }}
          >
            <VemsButton
              leftIcon={<FaDownload className={cx('me-2')} />}
              onClick={handleDownload}
              title='Tải tập tin Excel mẫu'
              className={cx('me-3')}
            />

            <VemsButton
              leftIcon={
                <IoIosSend
                  className={cx('me-1')}
                  size={20}
                />
              }
              onClick={handleUpdate}
              title='Cập nhật'
            />
          </div>
        </div>
      </Modal>
    </>
  );
};

export default ModalUploadSchedule;
