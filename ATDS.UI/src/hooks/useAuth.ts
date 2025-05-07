import { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from './useRedux';
import { setAuth, setProfile, setLoading, setError, logout } from '@/store/slices/AuthSlice';
import authApi from '@/apis/authApi';
import { useNavigate, useLocation } from 'react-router-dom';
import { useSnackbar } from 'notistack';
import { useTranslation } from 'react-i18next';

export const useAuth = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const location = useLocation();
  const { enqueueSnackbar } = useSnackbar();
  const { t } = useTranslation();
  const { isAuthenticated, loading, profile } = useAppSelector(state => state.auth);
  
  // Initialize auth state on mount
  useEffect(() => {
    const initAuth = async () => {
      const token = localStorage.getItem('token');
      if (token && !profile) { // Only fetch profile if we don't have it
        try {
          dispatch(setLoading(true));
          const profile = await authApi.getProfile();
          dispatch(setProfile(profile));
        } catch (error) {
          console.error('Failed to fetch profile:', error);
          dispatch(logout());
        } finally {
          dispatch(setLoading(false));
        }
      }
    };

    initAuth();
  }, [dispatch, profile]);

  const login = async (username: string, password: string) => {
    try {
      dispatch(setLoading(true));
      const response = await authApi.login({ username, password });
      dispatch(setAuth({ 
        token: response.token, 
        refreshToken: response.refreshToken 
      }));
      
      // Fetch profile after successful login
      const profile = await authApi.getProfile();
      dispatch(setProfile(profile));
      
      enqueueSnackbar(t('auth.loginSuccess'), { variant: 'success' });
      
      // Get the return URL from location state or default to dashboard
      const from = location.state?.from?.pathname || '/dashboard';
      navigate(from, { replace: true });
    } catch (error) {
      console.error('Login failed:', error);
      dispatch(setError(t('auth.loginFailed')));
      enqueueSnackbar(t('auth.loginFailed'), { variant: 'error' });
    } finally {
      dispatch(setLoading(false));
    }
  };

  const handleLogout = async () => {
    try {
      await authApi.logout();
    } catch (error) {
      console.error('Logout failed:', error);
    } finally {
      dispatch(logout());
      navigate('/login');
    }
  };

  return {
    isAuthenticated,
    loading,
    profile,
    login,
    logout: handleLogout
  };
}; 