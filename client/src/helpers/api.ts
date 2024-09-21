import axios, { AxiosRequestConfig, AxiosPromise } from 'axios';

export default function requestApi(
    endPoint: string,
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    body?: any,  
    responseType: 'json' | 'text' | 'arraybuffer' | 'blob' = 'json',
    params?: any

): AxiosPromise<any> { 
    const headers = {
        "Accept": "application/json",
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*"
    };

    const config: AxiosRequestConfig = {
        headers,
        method,
        url: `https://localhost:7268/api${endPoint}`,
        data: body,
        responseType,
        params,
    };

    return axios(config);
}
