// Menu item IDs
export const Menu = {
    // Main menu items
    DASHBOARD: 'DASHBOARD',
    PRODUCT_MANAGEMENT: 'PRODUCT_MANAGEMENT',
    USER_MANAGEMENT: 'USER_MANAGEMENT',

    // Product related menu items
    PRODUCTS: 'PRODUCTS',
    CATEGORIES: 'CATEGORIES_MANAGEMENT',

    // User management related menu items
    USERS: 'USERS',
    USER_CREATE: 'USER_CREATE',
    USER_UPDATE: 'USER_UPDATE',
    USER_VIEW: 'USER_VIEW',
    ADMINISTRATORS: 'ADMINISTRATORS',
    ROLES: 'ROLES',
} as const;

// Route paths
export const RoutePath = {
    DASHBOARD: '/dashboard',
    PRODUCTS: '/dashboard/products',
    CATEGORIES: '/dashboard/categories',
    USERS: '/dashboard/users',
    ADMINS: '/dashboard/admins',
    ROLES: '/dashboard/roles',
} as const;

// Translation keys
export const TranslationKey = {
    DASHBOARD: 'sidebar.dashboard',
    PRODUCTS: 'sidebar.productList',
    CATEGORIES: 'sidebar.categories',
    USER_MANAGEMENT: 'sidebar.users',
    USER: 'sidebar.userList',
    ADMINISTRATORS: 'sidebar.administrators',
    ROLES: 'sidebar.roles',
} as const;
