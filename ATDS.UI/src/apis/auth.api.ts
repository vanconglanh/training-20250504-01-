import { Profile } from '@/types/auth.type';
import apiClient from '../config/httpClient';
import { ApiResponse } from '@/types/http.type';

// Define auth response interfaces
export interface AuthResponse {
  token: string;
  refreshToken: string;
  expiresIn: number;
}

export interface UserCredentials {
  username: string;
  password: string;
}

export interface RefreshTokenRequest {
  refreshToken: string;
}

export interface RegisterRequest {
  username: string;
  email: string;
  password: string;
  fullName?: string;
}

class AuthApi {
  /**
   * Log in with username and password
   */
  async login(credentials: UserCredentials): Promise<AuthResponse> {
    const response = await apiClient.post<AuthResponse>('/login', credentials);
    return response.data;
  }
  /**
   * Register a new user account
   */
  async register(userData: RegisterRequest): Promise<AuthResponse> {
    const response = await apiClient.post<AuthResponse>('/auth/register', userData);
    return response.data;
  }

  /**
   * Refresh authentication token
   */
  async refreshToken(refreshTokenData: RefreshTokenRequest): Promise<AuthResponse> {
    const response = await apiClient.post<AuthResponse>('/auth/refresh', refreshTokenData);
    return response.data;
  }

  /**
   * Log out current user
   */
  async logout(): Promise<void> {
    console.log("API logout mockup");
    
  }

  /**
   * Verify current token validity
   */
  async verifyToken(): Promise<boolean> {
    try {
      await apiClient.get('/auth/verify');
      return true;
    } catch (error) {
      return false;
    }
  }

  /**
   * Request password reset
   */
  async requestPasswordReset(email: string): Promise<void> {
    await apiClient.post('/auth/forgot-password', { email });
  }

  /**
   * Reset password with token
   */
  async resetPassword(token: string, newPassword: string): Promise<void> {
    await apiClient.post('/auth/reset-password', {
      token,
      newPassword
    });
  }

  /**
   * Get profile
   */
  async getProfile(): Promise<Profile> {
    const response = await apiClient.get<ApiResponse<Profile>>('/profile');
    return response.data.data; // Truy cập vào thuộc tính data của ApiResponse
  }
}

export const authApi = new AuthApi();
export default authApi;