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
    id: Menu.PRODUCT_MANAGEMENT, 
    path: null, 
    label: TranslationKey.PRODUCTS,
    icon: <ShoppingCartIcon />,
    children: [
      {
        id: Menu.PRODUCTS,
        path: RoutePath.PRODUCTS,
        label: TranslationKey.PRODUCTS,
        icon: <InventoryIcon />,
        children: [],
        screenName: Menu.PRODUCTS
      },
      {
        id: Menu.CATEGORIES,
        path: RoutePath.CATEGORIES,
        label: TranslationKey.CATEGORIES,
        icon: <CategoryIcon />,
        children: [],
        screenName: Menu.CATEGORIES
      }
    ],
    screenName: Menu.PRODUCT_MANAGEMENT
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
        label: TranslationKey.ROLES,
        icon: <AssignmentIndIcon />,
        children: [],
        screenName: Menu.ROLES
      }
    ],
    screenName: Menu.USER_MANAGEMENT
  }
]; 