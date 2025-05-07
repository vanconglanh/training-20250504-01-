import React, { useEffect } from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '@/hooks/useRedux';
import { setProfile, setLoading, setAuth } from '@/store/slices/AuthSlice';
import authApi from '@/apis/authApi';
import { useSnackbar } from 'notistack';
import { useTranslation } from 'react-i18next';
import authService from '@/services/authService';

interface AuthGuardProps {
  children: React.ReactNode;
}

const AuthGuard: React.FC<AuthGuardProps> = ({ children }) => {
  const dispatch = useAppDispatch();
  const location = useLocation();
  const { enqueueSnackbar } = useSnackbar();
  const { t } = useTranslation();
  const { isAuthenticated, loading, profile } = useAppSelector((state) => state.auth);

  useEffect(() => {
    const initAuth = async () => {
      const token = authService.getToken();
      const refreshToken = authService.getRefreshToken()  ?? 'ATDS';;
      if (token && !profile) {
        try {
          dispatch(setLoading(true));
          const profile = await authApi.getProfile();
          dispatch(setProfile(profile));
          dispatch(setAuth({ token: token, refreshToken: refreshToken }));
        } catch (error) {
          console.error('Failed to fetch profile:', error);
          enqueueSnackbar(t('errors.sessionExpired'), { variant: 'error' });
          // Clear invalid token
          localStorage.removeItem('token');
          localStorage.removeItem('refreshToken');
        } finally {
          dispatch(setLoading(false));
        }
      }
    };

    initAuth();
  }, [dispatch, profile, enqueueSnackbar, t]);

  // Show loading state while checking authentication
  if (loading || (!isAuthenticated && localStorage.getItem('token'))) {
    return <div>Loading...</div>; // You can replace this with a proper loading component
  }

  // Only redirect to login if we're sure the user is not authenticated
  if (!isAuthenticated) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  return <>{children}</>;
};

export default AuthGuard; 