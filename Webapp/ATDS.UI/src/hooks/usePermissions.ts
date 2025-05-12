import { PermissionAction } from '@/config/enum/PermissionAction';
import { useAppSelector } from './useRedux';
import { checkPermission } from '@/utils/permissions';

export const usePermissions = () => {
  const profile = useAppSelector((state) => state.auth.profile);

  const hasPermission = (screenName: string, actionName: PermissionAction) => { 
    if (profile?.permissions == undefined) return false;
    return checkPermission(profile.permissions, screenName, actionName);
  };  

  const canAccessMenu = (screenName: string) => {
    return hasPermission(screenName, PermissionAction.VIEW);
  };

  return {
    hasPermission,
    canAccessMenu,
  };
}; 