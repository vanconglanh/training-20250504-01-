import axios, { AxiosInstance, AxiosResponse, InternalAxiosRequestConfig, AxiosError } from 'axios';
import { API } from './constant/endpoint';
import { ApiResponse } from '@/types/http.type';


// Có thể mở rộng kiểu dữ liệu cho các phản hồi cụ thể
interface AuthResponse {
  token: string;
  refreshToken?: string;
  expiresIn?: number;
}

class HttpClient {
  private instance: AxiosInstance;
  private baseURL: string;

  constructor(baseURL: string) {
    this.baseURL = baseURL;
    this.instance = axios.create({
      baseURL,
      timeout: 10000,
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    });

    this.initializeInterceptors();
  }

  private initializeInterceptors(): void {
    this.instance.interceptors.request.use(
      (config: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
        const token = localStorage.getItem('token');
        if (token && config.headers) {
          config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
      },
      (error: AxiosError): Promise<AxiosError> => {
        return Promise.reject(error);
      }
    );

    // Response interceptor - xử lý lỗi response
    this.instance.interceptors.response.use(
      (response: AxiosResponse): AxiosResponse => {
        return response;
      },
      async (error: AxiosError): Promise<AxiosError> => {
        // Xử lý lỗi 401 Unauthorized
        if (error.response && error.response.status === 401) {
          // Xử lý refresh token hoặc đăng xuất
          console.log('Token hết hạn hoặc không hợp lệ');
          // Tùy chọn: thử refresh token
          // await this.refreshAuthToken();
        }
        return Promise.reject(error);
      }
    );
  }

  // Phương thức refresh token (tuỳ chọn)
  private async refreshAuthToken(): Promise<boolean> {
    try {
      const refreshToken = localStorage.getItem('refreshToken');
      if (!refreshToken) {
        this.logout();
        return false;
      }

      const response = await this.instance.post<AuthResponse>('/auth/refresh', {
        refreshToken
      });

      localStorage.setItem('token', response.data.token);
      if (response.data.refreshToken) {
        localStorage.setItem('refreshToken', response.data.refreshToken);
      }
      
      return true;
    } catch (error) {
      this.logout();
      return false;
    }
  }

  private logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    // Chuyển hướng về trang đăng nhập
    // window.location.href = '/login';
  }

  // Các phương thức HTTP
  public async get<T>(url: string, params?: any): Promise<ApiResponse<T>> {
    return this.instance.get<T>(url, { params });
  }

  public async post<T>(url: string, data?: any): Promise<ApiResponse<T>> {
    return this.instance.post<T>(url, data);
  }

  public async put<T>(url: string, data?: any): Promise<ApiResponse<T>> {
    return this.instance.put<T>(url, data);
  }

  public async delete<T>(url: string, data?: any): Promise<ApiResponse<T>> {
    return this.instance.delete<T>(url, { data });
  }

  public async patch<T>(url: string, data?: any): Promise<ApiResponse<T>> {
    return this.instance.patch<T>(url, data);
  }
}

// Tạo instance và export
const apiClient = new HttpClient(API);
export default apiClient;

// Sử dụng:
// import apiClient from './httpClient';
// const data = await apiClient.get<UserProfile>('/users/profile');