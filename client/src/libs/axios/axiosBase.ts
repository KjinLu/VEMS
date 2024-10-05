import type { BaseQueryFn } from '@reduxjs/toolkit/query';
import { AxiosError, AxiosRequestConfig } from 'axios';
import { axiosPublic } from '@/libs/axios/axiosPublic';
import { axiosAuth } from '@/libs/axios/axiosAuth';

interface AxiosBaseQueryProps {
  url: string;
  method?: AxiosRequestConfig['method'];
  data?: AxiosRequestConfig['data'];
  params?: AxiosRequestConfig['params'];
  headers?: AxiosRequestConfig['headers'];
  authRequired?: boolean;
}

export const axiosBaseQuery =
  <T extends Record<string, unknown> = {}>(
    { baseUrl }: { baseUrl: string } = { baseUrl: '' }
  ): BaseQueryFn<AxiosBaseQueryProps & T, unknown, unknown> =>
  async ({
    url,
    method,
    data,
    params,
    headers,
    authRequired = false
  }: AxiosBaseQueryProps & T) => {
    try {
      const instance = authRequired ? axiosAuth : axiosPublic;
      const result = await instance({
        url: `${baseUrl}${url}`,
        method,
        data,
        params,
        headers
      });
      return { data: result.data, status: result.status as number };
    } catch (axiosError) {
      const err = axiosError as AxiosError;

      if (!err.response) {
        return {
          error: {
            status: 500,
            data: null,
            message: 'Network error. Please check your connection.'
          }
        };
      }

      return {
        error: {
          status: err.response?.status,
          data: err.response?.data,
          message: err.message || 'An unknown error occurred.'
        }
      };
    }
  };
