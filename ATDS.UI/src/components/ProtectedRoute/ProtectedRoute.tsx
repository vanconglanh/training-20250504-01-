import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { usePermissions } from '@/hooks/usePermissions';
import Forbidden from '@/pages/Error/Forbidden';
import { PermissionAction } from '@/config/enum/PermissionAction';

interface ProtectedRouteProps {
  children: React.ReactNode;
  screenName: string;
  actionName?: PermissionAction;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ 
  children, 
  screenName,
  actionName = PermissionAction.VIEW
}) => {
  const { hasPermission } = usePermissions();
  const location = useLocation();
  // Check if user has the required permission
  if (!hasPermission(screenName, actionName)) {
    // If trying to access directly, redirect to forbidden page
    if (location.pathname !== '/403') {
      return <Navigate to="/403" replace />;
    }
    // If already on forbidden page, show it
    return <Forbidden />;
  }

  // If user has permission, render the children
  return <>{children}</>;
};

export default ProtectedRoute; 

