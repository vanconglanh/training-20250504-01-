import DashboardIcon from '@mui/icons-material/Dashboard';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import InventoryIcon from '@mui/icons-material/Inventory';
import CategoryIcon from '@mui/icons-material/Category';
import GroupIcon from '@mui/icons-material/Group';
import PeopleIcon from '@mui/icons-material/People';
import SupervisorAccountIcon from '@mui/icons-material/SupervisorAccount';
import AssignmentIndIcon from '@mui/icons-material/AssignmentInd';
import { Menu, RoutePath, TranslationKey } from './constant/feature';

// Define menu item interface
export interface MenuItem {
  id: string;
  path: string | null;
  label: string;
  icon: React.ReactElement;
  children: MenuItem[];
  screenName: string; // Screen name for permission check
  childrenPath?: string[];
}

// Menu configuration 
export const menuItems: MenuItem[] = [
  { 
    id: Menu.DASHBOARD, 
    path: RoutePath.DASHBOARD, 
    label: TranslationKey.DASHBOARD,
    icon: <DashboardIcon />,
    children: [],
    screenName: Menu.DASHBOARD
  },
    { 
    id: Menu.PERMISSIONS, 
    path: null, 
    label: TranslationKey.PERMISSION_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.PERMISSIONS,
        path: RoutePath.PERMISSIONS,
        label: TranslationKey.PERMISSION,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.PERMISSIONS
      }
    ],
    screenName: Menu.PERMISSIONS
  },
  { 
    id: Menu.PERMISSION_SCREENS, 
    path: null, 
    label: TranslationKey.PERMISSION_SCREEN_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.PERMISSION_SCREENS,
        path: RoutePath.PERMISSION_SCREENS,
        label: TranslationKey.PERMISSION_SCREEN,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.PERMISSION_SCREENS
      }
    ],
    screenName: Menu.PERMISSION_SCREENS
  },
  { 
    id: Menu.ROLES, 
    path: null, 
    label: TranslationKey.ROLE_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.ROLES,
        path: RoutePath.ROLES,
        label: TranslationKey.ROLE,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.ROLES
      }
    ],
    screenName: Menu.ROLES
  },
  { 
    id: Menu.ROLE_PERMISSIONS, 
    path: null, 
    label: TranslationKey.ROLE_PERMISSION_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.ROLE_PERMISSIONS,
        path: RoutePath.ROLE_PERMISSIONS,
        label: TranslationKey.ROLE_PERMISSION,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.ROLE_PERMISSIONS
      }
    ],
    screenName: Menu.ROLE_PERMISSIONS
  },
  { 
    id: Menu.SCREENS, 
    path: null, 
    label: TranslationKey.SCREEN_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.SCREENS,
        path: RoutePath.SCREENS,
        label: TranslationKey.SCREEN,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.SCREENS
      }
    ],
    screenName: Menu.SCREENS
  },
  { 
    id: Menu.USERS, 
    path: null, 
    label: TranslationKey.USER_MANAGEMENT,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.USERS,
        path: RoutePath.USERS,
        label: TranslationKey.USER,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.USERS
      }
    ],
    screenName: Menu.USERS
  },
  { 
    id: Menu.USER_MANAGEMENT, 
    path: null, 
    label: TranslationKey.USER_MANAGEMENT,
    icon: <GroupIcon />,
    children: [
      {
        id: Menu.USERS,
        path: RoutePath.USERS,
        label: TranslationKey.USER,
        icon: <PeopleIcon />,
        children: [],
        screenName: Menu.USERS,
        childrenPath: ["/create", "/edit/:id", "/view/:id"].map(path => RoutePath.USERS + path)
      },
      {
        id: Menu.ADMINISTRATORS,
        path: RoutePath.ADMINS,
        label: TranslationKey.ADMINISTRATORS,
        icon: <SupervisorAccountIcon />,
        children: [],
        screenName: Menu.ADMINISTRATORS
      },
      {
        id: Menu.ROLES,
        path: RoutePath.ROLES,
        label: TranslationKey.ROLE,
        icon: <AssignmentIndIcon />,
        children: [],
        screenName: Menu.ROLES
      }
    ],
    screenName: Menu.USER_MANAGEMENT
  }
  
]; 