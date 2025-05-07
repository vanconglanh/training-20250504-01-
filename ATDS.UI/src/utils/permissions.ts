import { PermissionAction } from '@/config/enum/PermissionAction';
import { Permission } from '@/types/auth.type';

export type ScreenPermission = {
  screenName: string;
  actions: {
    view: boolean;
    create: boolean;
    update: boolean;
    delete: boolean;
  };
};

export const checkPermission = (
  permissions: Permission[],
  screenName: string,
  actionName: PermissionAction
): boolean => {
  const permission = permissions.find(
    (p) => p.screenName === screenName && p.actionName.includes(actionName)
  );
  return !!permission;
};

export const getScreenPermissions = (
  permissions: Permission[],
  screenName: string
): ScreenPermission['actions'] => {
  return {
    view: checkPermission(permissions, screenName, PermissionAction.VIEW),
    create: checkPermission(permissions, screenName, PermissionAction.CREATE),
    update: checkPermission(permissions, screenName, PermissionAction.UPDATE),
    delete: checkPermission(permissions, screenName, PermissionAction.DELETE),
  };
};

// Map menu items to screen names
export const menuScreenMap: Record<string, string> = {
  dashboard: 'DASHBOARD',
  productList: 'PRODUCTS',
  categories: 'CATEGORIES',
  userList: 'USERS',
  administrators: 'ADMINISTRATORS',
  roles: 'ROLES',
  settings: 'SETTINGS',
  profile: 'PROFILE',
}; 