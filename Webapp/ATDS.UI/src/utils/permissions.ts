import { PermissionAction } from '@/config/enum/PermissionAction';
import { Permission } from '@/types/auth.type';


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



