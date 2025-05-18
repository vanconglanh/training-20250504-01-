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
// import PermissionList from '@/pages/DashBoard/Permission/List';
// import UpdateOrInsertPermission from '@/pages/DashBoard/Permission/UpdateOrInsert';
// import PermissionScreenList from '@/pages/DashBoard/PermissionScreen/List';
// import UpdateOrInsertPermissionScreen from '@/pages/DashBoard/PermissionScreen/UpdateOrInsert';
// import RoleList from '@/pages/DashBoard/Role/List';
// import UpdateOrInsertRole from '@/pages/DashBoard/Role/UpdateOrInsert';
// import RolePermissionList from '@/pages/DashBoard/RolePermission/List';
// import UpdateOrInsertRolePermission from '@/pages/DashBoard/RolePermission/UpdateOrInsert';
// import ScreenList from '@/pages/DashBoard/Screen/List';
// import UpdateOrInsertScreen from '@/pages/DashBoard/Screen/UpdateOrInsert';
// import UserList from '@/pages/DashBoard/User/List';
// import UpdateOrInsertUser from '@/pages/DashBoard/User/UpdateOrInsert';


// Lazy-loaded components
// const UserList = lazy(() => import('@/pages/DashBoard/UserManagement/Users/List'));
// const UpdateOrInsertUser = lazy(() => import('@/pages/DashBoard/UserManagement/Users/UpdateOrInsert'));
const PermissionList = lazy(() => import('@/pages/DashBoard/Permission/List'));
const UpdateOrInsertPermission = lazy(() => import('@/pages/DashBoard/Permission/UpdateOrInsert'));
const PermissionScreenList = lazy(() => import('@/pages/DashBoard/PermissionScreen/List'));
const UpdateOrInsertPermissionScreen = lazy(() => import('@/pages/DashBoard/PermissionScreen/UpdateOrInsert'));
const RoleList = lazy(() => import('@/pages/DashBoard/Role/List'));
const UpdateOrInsertRole = lazy(() => import('@/pages/DashBoard/Role/UpdateOrInsert'));
const RolePermissionList = lazy(() => import('@/pages/DashBoard/RolePermission/List'));
const UpdateOrInsertRolePermission = lazy(() => import('@/pages/DashBoard/RolePermission/UpdateOrInsert'));
const ScreenList = lazy(() => import('@/pages/DashBoard/Screen/List'));
const UpdateOrInsertScreen = lazy(() => import('@/pages/DashBoard/Screen/UpdateOrInsert'));
const UserList = lazy(() => import('@/pages/DashBoard/User/List'));
const UpdateOrInsertUser = lazy(() => import('@/pages/DashBoard/User/UpdateOrInsert'));
const NotFound = lazy(() => import('@/pages/Error/NotFound'));
const Forbidden = lazy(() => import('@/pages/Error/Forbidden'));
const RolesList = lazy(() => import('@/pages/DashBoard/UserManagement/Roles/List'));
const OrderList = lazy(() => import('@/pages/DashBoard/Order/List'));
const UpdateOrInsertOrder = lazy(() => import('@/pages/DashBoard/Order/UpdateOrInsert'));
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
    path: '/',
    element: <Navigate to="/login" replace />
  },
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
        path: 'permissions',
        element: <PermissionList />,
        title: 'Permission Management',
        protected: true,
        screenName: Menu.PERMISSIONS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'permissions/create',
        element: <UpdateOrInsertPermission />,
        title: 'Create Permission',
        protected: true,
        screenName: Menu.PERMISSIONS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'permissions/edit/:id',
        element: <UpdateOrInsertPermission />,
        title: 'Edit Permission',
        protected: true,
        screenName: Menu.PERMISSIONS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'permissions/view/:id',
        element: <UpdateOrInsertPermission />,
        title: 'View Permission',
        protected: true,
        screenName: Menu.PERMISSIONS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'permissionScreens',
        element: <PermissionScreenList />,
        title: 'PermissionScreen Management',
        protected: true,
        screenName: Menu.PERMISSION_SCREENS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'permissionScreens/create',
        element: <UpdateOrInsertPermissionScreen />,
        title: 'Create PermissionScreen',
        protected: true,
        screenName: Menu.PERMISSION_SCREENS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'permissionScreens/edit/:id',
        element: <UpdateOrInsertPermissionScreen />,
        title: 'Edit PermissionScreen',
        protected: true,
        screenName: Menu.PERMISSION_SCREENS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'permissionScreens/view/:id',
        element: <UpdateOrInsertPermissionScreen />,
        title: 'View PermissionScreen',
        protected: true,
        screenName: Menu.PERMISSION_SCREENS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'roles',
        element: <RoleList />,
        title: 'Role Management',
        protected: true,
        screenName: Menu.ROLES,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'roles/create',
        element: <UpdateOrInsertRole />,
        title: 'Create Role',
        protected: true,
        screenName: Menu.ROLES,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'roles/edit/:id',
        element: <UpdateOrInsertRole />,
        title: 'Edit Role',
        protected: true,
        screenName: Menu.ROLES,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'roles/view/:id',
        element: <UpdateOrInsertRole />,
        title: 'View Role',
        protected: true,
        screenName: Menu.ROLES,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'rolePermissions',
        element: <RolePermissionList />,
        title: 'RolePermission Management',
        protected: true,
        screenName: Menu.ROLE_PERMISSIONS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'rolePermissions/create',
        element: <UpdateOrInsertRolePermission />,
        title: 'Create RolePermission',
        protected: true,
        screenName: Menu.ROLE_PERMISSIONS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'rolePermissions/edit/:id',
        element: <UpdateOrInsertRolePermission />,
        title: 'Edit RolePermission',
        protected: true,
        screenName: Menu.ROLE_PERMISSIONS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'rolePermissions/view/:id',
        element: <UpdateOrInsertRolePermission />,
        title: 'View RolePermission',
        protected: true,
        screenName: Menu.ROLE_PERMISSIONS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'screens',
        element: <ScreenList />,
        title: 'Screen Management',
        protected: true,
        screenName: Menu.SCREENS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'screens/create',
        element: <UpdateOrInsertScreen />,
        title: 'Create Screen',
        protected: true,
        screenName: Menu.SCREENS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'screens/edit/:id',
        element: <UpdateOrInsertScreen />,
        title: 'Edit Screen',
        protected: true,
        screenName: Menu.SCREENS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'screens/view/:id',
        element: <UpdateOrInsertScreen />,
        title: 'View Screen',
        protected: true,
        screenName: Menu.SCREENS,
        actionName: PermissionAction.VIEW
      },
      {
        path: 'users',
        element: <UserList />,
        title: 'User Management',
        protected: true,
        screenName: Menu.USERS,
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
      },
      {
        path : 'orders',
        element: <OrderList />,
        title: 'Orders',
        protected : true,
        screenName: Menu.ORDERS,
        actionName: PermissionAction.VIEW,
      },
      {
        path: 'orders/create',
        element: <UpdateOrInsertOrder />,
        title: 'Create Order',
        protected: true,
        screenName: Menu.ORDERS,
        actionName: PermissionAction.CREATE
      },
      {
        path: 'orders/edit/:id',
        element: <UpdateOrInsertOrder />,
        title: 'Edit Order',
        protected: true,
        screenName: Menu.ORDERS,
        actionName: PermissionAction.UPDATE
      },
      {
        path: 'orders/view/:id',
        element: <UpdateOrInsertOrder />,
        title: 'View Order',
        protected: true,
        screenName: Menu.ORDERS,
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