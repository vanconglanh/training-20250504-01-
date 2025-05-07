import MainLayout from '@/layout/MainLayout';
import { lazy, Suspense } from 'react';
import { createBrowserRouter, Navigate } from 'react-router-dom';
import AuthGuard from '@/components/AuthGuard/AuthGuard';
import ProtectedRoute from '@/components/ProtectedRoute/ProtectedRoute';
import { PermissionAction } from '@/config/enum/PermissionAction';
import { Helmet } from 'react-helmet-async';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Menu } from '@/config/constant/feature';

// Lazy-loaded components
const UserList = lazy(() => import('@/pages/DashBoard/UserManagement/Users/List'));
const UpdateOrInsertUser = lazy(() => import('@/pages/DashBoard/UserManagement/Users/UpdateOrInsert'));
const NotFound = lazy(() => import('@/pages/Error/NotFound'));
const Forbidden = lazy(() => import('@/pages/Error/Forbidden'));
const RolesList = lazy(() => import('@/pages/DashBoard/UserManagement/Roles/List'));
// Auth pages
const Login = lazy(() => import('@/pages/Auth/Login'));

// Loading fallback
const LoadingFallback = () => (
  <div style={{ 
    display: 'flex', 
    justifyContent: 'center', 
    alignItems: 'center', 
    height: '100vh' 
  }}>
    Loading...
  </div>
);

// Page wrapper with Helmet
const PageWrapper = ({ children, title }: { children: React.ReactNode; title: string }) => (
  <>
    <Helmet>
      <title>{title} | ATDS</title>
    </Helmet>
    {children}
  </>
);

// Route configuration type
interface RouteConfig {
  path: string;
  element?: React.ReactNode;
  children?: RouteConfig[];
  title?: string;
  protected?: boolean;
  screenName?: string;
  actionName?: PermissionAction;
  redirect?: string;
}

// Route configuration
export const routes: RouteConfig[] = [
  {
    path: '/login',
    element: <Login />,
    title: 'Login'
  },
  {
    path: '/dashboard',
    element: <MainLayout />,
    protected: true,
    children: [
      {
        path: 'users',
        element: <UserList />,
        title: 'User Management',
        protected: true,
        screenName: Menu.USER_MANAGEMENT,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'users/create',
        element: <UpdateOrInsertUser />,
        title: 'Create User',
        protected: true,
        screenName: Menu.USERS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'users/edit/:id',
        element: <UpdateOrInsertUser />,
        title: 'Edit User',
        protected: true,
        screenName: Menu.USERS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'users/view/:id',
        element: <UpdateOrInsertUser />,
        title: 'View User',
        protected: true,
        screenName: Menu.USERS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'products',
        element: <div>Products Management Page (Coming Soon)</div>,
        title: 'Products'
      },
      {
        path: 'roles',
        element: <RolesList />,
        title: 'Roles',
        protected: true,
        screenName: Menu.ROLES,
        actionName: PermissionAction.VIEW
      }
    ]
  },
  {
    path: '/403',
    element: <Forbidden />,
    title: 'Forbidden'
  },
  {
    path: '*',
    element: <NotFound />,
    title: 'Not Found'
  }
];

// Helper function to wrap route with necessary components
const wrapRoute = (route: RouteConfig): RouteConfig => {
  let element = route.element;

  // Add PageWrapper if title exists
  if (element && route.title) {
    element = <PageWrapper title={route.title}>{element}</PageWrapper>;
  }

  // Add ProtectedRoute if protected
  if (element && route.protected && route.screenName && route.actionName) {
    element = (
      <ProtectedRoute 
        screenName={route.screenName} 
        actionName={route.actionName}
      >
        {element}
      </ProtectedRoute>
    );
  }

  // Add Suspense wrapper
  if (element) {
    element = (
      <Suspense fallback={<LoadingFallback />}>
        {element}
      </Suspense>
    );
  }

  // Add ToastContainer for main layout
  if (route.path === '/dashboard') {
    element = (
      <>
        {element}
        <ToastContainer />
      </>
    );
  }

  // Add AuthGuard for protected routes
  if (route.protected) {
    element = <AuthGuard>{element}</AuthGuard>;
  }

  // Handle redirects
  if (route.redirect) {
    element = <Navigate to={route.redirect} replace />;
  }

  return {
    ...route,
    element,
    children: route.children?.map(child => wrapRoute(child))
  };
};

// Create router with wrapped routes
const router = createBrowserRouter(routes.map(route => wrapRoute(route)));

export default router;