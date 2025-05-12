import React from 'react';
import { Outlet, Navigate } from 'react-router-dom';
import authService from '../services/auth.service';

const AuthLayout: React.FC = () => {
  // If user is already authenticated, redirect to dashboard
  if (authService.isAuthenticated() && !authService.isTokenExpired()) {
    return <Navigate to="/dashboard" replace />;
  }

  return (
    <div className="auth-layout">
      <div className="auth-container">
        <div className="auth-logo">
          <h1>My App</h1>
        </div>
        
        {/* This is where the login, register, etc. components will be rendered */}
        <div className="auth-content">
          <Outlet />
        </div>
        
        <div className="auth-footer">
          <p>&copy; {new Date().getFullYear()} Your Company. All rights reserved.</p>
        </div>
      </div>
    </div>
  );
};

export default AuthLayout;