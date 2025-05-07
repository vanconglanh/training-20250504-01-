import { Profile } from '@/types/auth.type';
import authApi, { AuthResponse, RegisterRequest, UserCredentials } from '../apis/authApi';
import { useAppDispatch } from '@/hooks/useRedux';
import { setProfile, setLoading } from '@/store/slices/AuthSlice';

// Define user interface
export interface User {
  id?: string;
  username: string;
  email: string;
  fullName?: string;
}

class AuthService {
  private tokenKey = 'token';
  private refreshTokenKey = 'refreshToken';
  private userKey = 'user';
  private tokenExpiryKey = 'tokenExpiry';

  /**
   * Get current authentication token
   */
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  /**
   * Get refresh token
   */
  getRefreshToken(): string | null {
    return localStorage.getItem(this.refreshTokenKey);
  }

  /**
   * Get current user information
   */
  getCurrentUser(): User | null {
    const userJson = localStorage.getItem(this.userKey);
    if (userJson) {
      return JSON.parse(userJson);
    }
    return null;
  }

  /**
   * Get profile and update Redux store
   */
  async getProfile(): Promise<Profile> {
    try {
      const profile = await authApi.getProfile();
      return profile;
    } catch (error) {
      // If token is invalid, try to refresh
      if (await this.refreshToken()) {
        // Retry getting profile after token refresh
        return await authApi.getProfile();
      }
      throw error;
    }
  }

  /**
   * Check if user is authenticated
   */
  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  /**
   * Check if token is expired
   */
  isTokenExpired(): boolean {
    const expiry = localStorage.getItem(this.tokenExpiryKey);
    if (!expiry) return true;
    
    return Date.now() > parseInt(expiry, 10);
  }

  /**
   * Set authentication data in local storage
   */
  private setAuthData(authResponse: AuthResponse, user: User): void {
    localStorage.setItem(this.tokenKey, authResponse.token);
    localStorage.setItem(this.refreshTokenKey, authResponse.refreshToken);
    localStorage.setItem(this.userKey, JSON.stringify(user));
    
    // Calculate token expiry
    const expiryTime = Date.now() + authResponse.expiresIn * 1000;
    localStorage.setItem(this.tokenExpiryKey, expiryTime.toString());
  }

  /**
   * Login user
   */
  async login(credentials: UserCredentials): Promise<User> {
    try {
      const authResponse = await authApi.login(credentials);
      
      // Decode JWT to get user info
      const user = this.extractUserFromToken(authResponse.token);
      
      this.setAuthData(authResponse, user);
      return user;
    } catch (error) {
      throw new Error('Authentication failed. Please check your credentials.');
    }
  }

  /**
   * Register new user
   */
  async register(userData: RegisterRequest): Promise<User> {
    try {
      const authResponse = await authApi.register(userData);
      
      const user: User = {
        username: userData.username,
        email: userData.email,
        fullName: userData.fullName
      };
      
      this.setAuthData(authResponse, user);
      return user;
    } catch (error) {
      throw new Error('Registration failed. Please try again.');
    }
  }

  /**
   * Logout user
   */
  async logout(): Promise<void> {
    try {
      await authApi.logout();
    } catch (error) {
      console.error('Error during logout:', error);
    } finally {
      this.clearAuthData();
    }
  }

  /**
   * Attempt to refresh the token
   */
  async refreshToken(): Promise<boolean> {
    try {
      const refreshToken = this.getRefreshToken();
      if (!refreshToken) {
        return false;
      }

      const authResponse = await authApi.refreshToken({ refreshToken });
      
      // Keep the same user data
      const user = this.getCurrentUser();
      if (user) {
        this.setAuthData(authResponse, user);
        return true;
      }
      return false;
    } catch (error) {
      this.clearAuthData();
      return false;
    }
  }

  /**
   * Clear all authentication data
   */
  private clearAuthData(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.refreshTokenKey);
    localStorage.removeItem(this.userKey);
    localStorage.removeItem(this.tokenExpiryKey);
  }

  /**
   * Extract user information from JWT token
   */
  private extractUserFromToken(token: string): User {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split('')
          .map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
          .join('')
      );

      const payload = JSON.parse(jsonPayload);
      
      return {
        username: payload.UserName,
        email: payload.Email,
      };
    } catch (error) {
      console.error('Error extracting user from token:', error);
      return { username: '', email: '' };
    }
  }

  /**
   * Initialize auth state on app start
   */
  async initAuth(): Promise<boolean> {
    if (!this.isAuthenticated()) {
      return false;
    }

    if (this.isTokenExpired()) {
      return await this.refreshToken();
    }

    return true;
  }
}

export const authService = new AuthService();
export default authService;