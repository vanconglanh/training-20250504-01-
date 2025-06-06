﻿// Menu item IDs
export const Menu = {
    // Main menu items
    DASHBOARD: 'DASHBOARD',
    USER_MANAGEMENT: 'USER_MANAGEMENT',
    // Product related menu items

    // User management related menu items
    // USERS: 'USERS',
    // USER_CREATE: 'USER_CREATE',
    // USER_UPDATE: 'USER_UPDATE',
    // USER_VIEW: 'USER_VIEW',
    // ROLES: 'ROLES',
    PERMISSIONS: 'PERMISSIONS',
    PERMISSION_CREATE: 'PERMISSION_CREATE',
    PERMISSION_UPDATE: 'PERMISSION_UPDATE',
    PERMISSION_VIEW: 'PERMISSION_VIEW',
    PERMISSION_SCREENS: 'PERMISSION_SCREENS',
    PERMISSION_SCREEN_CREATE: 'PERMISSION_SCREEN_CREATE',
    PERMISSION_SCREEN_UPDATE: 'PERMISSION_SCREEN_UPDATE',
    PERMISSION_SCREEN_VIEW: 'PERMISSION_SCREEN_VIEW',
    ROLES: 'ROLES',
    ROLE_CREATE: 'ROLE_CREATE',
    ROLE_UPDATE: 'ROLE_UPDATE',
    ROLE_VIEW: 'ROLE_VIEW',
    ROLE_PERMISSIONS: 'ROLE_PERMISSIONS',
    ROLE_PERMISSION_CREATE: 'ROLE_PERMISSION_CREATE',
    ROLE_PERMISSION_UPDATE: 'ROLE_PERMISSION_UPDATE',
    ROLE_PERMISSION_VIEW: 'ROLE_PERMISSION_VIEW',
    SCREENS: 'SCREENS',
    SCREEN_CREATE: 'SCREEN_CREATE',
    SCREEN_UPDATE: 'SCREEN_UPDATE',
    SCREEN_VIEW: 'SCREEN_VIEW',
    USERS: 'USERS',
    USER_CREATE: 'USER_CREATE',
    USER_UPDATE: 'USER_UPDATE',
    USER_VIEW: 'USER_VIEW',
    CATEGORIES: 'CATEGORIES_MANAGEMENT',
    ADMINISTRATORS: 'ADMINISTRATORS',
} as const;

// Route paths
export const RoutePath = {
    // USERS: '/dashboard/users',
    // ROLES: '/dashboard/roles',
    DASHBOARD: '/dashboard',
    PERMISSIONS: '/dashboard/permissions',
    PERMISSION_SCREENS: '/dashboard/permissionScreens',
    ROLES: '/dashboard/roles',
    ROLE_PERMISSIONS: '/dashboard/rolePermissions',
    SCREENS: '/dashboard/screens',
    USERS: '/dashboard/users',
    CATEGORIES: '/dashboard/categories',
    ADMINS: '/dashboard/admins',
} as const;

// Translation keys
export const TranslationKey = {
    // USER_MANAGEMENT: 'sidebar.users',
    // USER: 'sidebar.userList',
    // ROLES: 'sidebar.roles',
    DASHBOARD: 'sidebar.dashboard',
    PERMISSION_MANAGEMENT: 'sidebar.permissions',
    PERMISSION: 'sidebar.permissionList',
    PERMISSION_SCREEN_MANAGEMENT: 'sidebar.permissionScreens',
    PERMISSION_SCREEN: 'sidebar.permissionScreenList',
    ROLE_MANAGEMENT: 'sidebar.roles',
    ROLE: 'sidebar.roleList',
    ROLE_PERMISSION_MANAGEMENT: 'sidebar.rolePermissions',
    ROLE_PERMISSION: 'sidebar.rolePermissionList',
    SCREEN_MANAGEMENT: 'sidebar.screens',
    SCREEN: 'sidebar.screenList',
    USER_MANAGEMENT: 'sidebar.users',
    USER: 'sidebar.userList',
    PRODUCTS: 'sidebar.productList',
    CATEGORIES: 'sidebar.categories',
    ADMINISTRATORS: 'sidebar.administrators',
} as const;