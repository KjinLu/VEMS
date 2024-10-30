import type { BaseQueryFn } from '@reduxjs/toolkit/query';
import { AxiosError, AxiosRequestConfig } from 'axios';
import { axiosPublic } from '@/libs/axios/axiosPublic';
import { axiosAuth } from '@/libs/axios/axiosAuth';

const baseURL = import.meta.env.VITE_PUBLIC_API;

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
    {
      // baseUrl
    }: {
      baseUrl: string;
    }
  ): BaseQueryFn<AxiosBaseQueryProps & T, unknown, unknown> =>
  async ({
    url,
    method,
    data,
    params,
    authRequired = false,
    ...config
  }: AxiosBaseQueryProps & T) => {
    try {
      const instance = authRequired ? axiosAuth : axiosPublic;
      // console.log('baseUrl', baseURL);
      const result = await instance({
        url: `http://localhost:8080/apigateway${url}`,
        method,
        data,
        params,
        ...config
      });
      return { data: result.data.dataResponse, status: result.status as number };
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
