import logo from '@/assets/logo.png';
import LanguageSwitcher from '@/components/LanguageSwitcher/LanguageSwitcher';
import { PermissionAction } from '@/config/enum/PermissionAction';
import { MenuItem as MenuItemType, menuItems } from '@/config/menuConfig';
import { useAuth } from '@/hooks/useAuth';
import { usePermissions } from '@/hooks/usePermissions';
import { useAppDispatch, useAppSelector } from '@/hooks/useRedux';
import { setDrawerOpen } from '@/store/slices/UISlice';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import KeyboardArrowLeftIcon from '@mui/icons-material/KeyboardArrowLeft';
import KeyboardArrowRightIcon from '@mui/icons-material/KeyboardArrowRight';
import LogoutIcon from '@mui/icons-material/Logout';
import MenuIcon from '@mui/icons-material/Menu';
import NotificationsIcon from '@mui/icons-material/Notifications';
import PersonIcon from '@mui/icons-material/Person';
import SettingsIcon from '@mui/icons-material/Settings';
import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import VisibilityIcon from '@mui/icons-material/Visibility';
import EditIcon from '@mui/icons-material/Edit';
import {
  AppBar,
  Avatar,
  Badge,
  Box,
  Collapse,
  CssBaseline,
  Divider,
  Drawer,
  IconButton,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Menu,
  MenuItem,
  Toolbar,
  Tooltip,
  Typography,
  useMediaQuery,
  useTheme,
  Link,
  Button
} from '@mui/material';
import { alpha } from '@mui/material/styles';
import React, { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';
import { Outlet, useLocation, useNavigate, Link as RouterLink } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

// Responsive drawer widths
const drawerWidthPercent = 15; // Drawer width as percentage of viewport width
const drawerMinWidth = 260; // Minimum width in pixels 
const drawerMaxWidth = 320; // Maximum width in pixels
const miniDrawerWidth = 70; // Mini drawer width in pixels

// Mock notifications data
const mockNotifications = [
  {
    id: 1,
    title: 'New User Registration',
    message: 'John Doe has registered as a new user',
    time: '5 minutes ago',
    read: false
  },
  {
    id: 2,
    title: 'System Update',
    message: 'System maintenance scheduled for tomorrow',
    time: '1 hour ago',
    read: false
  },
  {
    id: 3,
    title: 'Task Completed',
    message: 'Project X has been completed',
    time: '2 hours ago',
    read: true
  }
];

const MainLayout: React.FC = () => {
  const { t } = useTranslation();
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('md'));
  const navigate = useNavigate();
  const location = useLocation();
  const { hasPermission } = usePermissions();
  
  const dispatch = useAppDispatch();
  const open = useAppSelector((state) => state.ui.drawerOpen);
  
  // Auth hooks
  const {logout} = useAuth();

  // State for mini drawer mode
  const [miniDrawer, setMiniDrawer] = useState(false);
  
  // State for expanded menu items
  const [expandedItems, setExpandedItems] = useState<Record<string, boolean>>({});
  
  // Profile menu state
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const profileMenuOpen = Boolean(anchorEl);

  // Notification menu state
  const [notificationAnchorEl, setNotificationAnchorEl] = useState<null | HTMLElement>(null);
  const notificationMenuOpen = Boolean(notificationAnchorEl);

  // Update drawer state based on screen size when component mounts
  useEffect(() => {
    // Only auto-close on mobile
    if (isMobile) {
      dispatch(setDrawerOpen(false));
      setMiniDrawer(false);
    }
    
    // Initialize expanded items based on current path
    const newExpandedItems: Record<string, boolean> = {};
    menuItems.forEach(item => {
      if (item.children.length > 0) {
        // Check if current path matches any child path or childrenPath
        const isActive = item.children.some(child => {
          // Check direct path match
          if (location.pathname === child.path) return true;
          
          // Check childrenPath matches with path parameters
          if (child.childrenPath?.some(path => {
            // Convert path pattern to regex
            const pattern = path.replace(/:id/g, '\\d+');
            const regex = new RegExp(`^${pattern}$`);
            return regex.test(location.pathname);
          })) return true;
          
          return false;
        });
        
        if (isActive) {
          newExpandedItems[item.id] = true;
        }
      }
    });
    setExpandedItems(newExpandedItems);
  }, [isMobile, dispatch, location.pathname]);

  const handleDrawerOpen = () => {
    if (open && !isMobile) {
      // If drawer is open, toggle mini mode
      setMiniDrawer(!miniDrawer);
    } else {
      // If drawer is closed, open it
      dispatch(setDrawerOpen(true));
      setMiniDrawer(false);
    }
  };

  const handleDrawerClose = () => {
    if (isMobile) {
      // On mobile, fully close the drawer
      dispatch(setDrawerOpen(false));
    } else {
      // On desktop, switch to mini drawer
      setMiniDrawer(true);
    }
  };

  const toggleExpandItem = (itemId: string) => {
    if (!miniDrawer) {
      setExpandedItems(prev => ({
        ...prev,
        [itemId]: !prev[itemId]
      }));
    }
  };

  const handleNavigation = (path: string | null) => {
    if (path) {
      navigate(path);
      if (isMobile) {
        dispatch(setDrawerOpen(false));
      }
    }
  };

  // Profile menu handlers
  const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleProfileMenuClose = () => {
    setAnchorEl(null);
  };

  const handleSettings = () => {
    handleProfileMenuClose();
    navigate('/dashboard/settings');
  };

  // Add handleProfile function
  const handleProfile = () => {
    navigate('/dashboard/profile');
    handleProfileMenuClose();
  };

  // Check if a menu item or any of its children is active
  const isMenuItemActive = (item: MenuItemType): boolean => {
    // Check if current path matches item's path
    if (item.path && location.pathname === item.path) {
      return true;
    }

    // Check if current path matches any of the children paths
    if (item.childrenPath?.some(path => {
      // Convert path pattern to regex
      // Replace :id with regex pattern for numbers
      const pattern = path.replace(/:id/g, '\\d+');
      const regex = new RegExp(`^${pattern}$`);
      return regex.test(location.pathname);
    })) {
      return true;
    }

    // Check children recursively
    if (item.children.length > 0) {
      return item.children.some(child => isMenuItemActive(child));
    }

    return false;
  };

  // Helper function to find a menu item by ID
  const findMenuItem = (items: MenuItemType[], id: string): MenuItemType | undefined => {
    for (const item of items) {
      if (item.id === id) return item;
      if (item.children.length > 0) {
        const found = findMenuItem(item.children, id);
        if (found) return found;
      }
    }
    return undefined;
  };

  // Check if user has access to a menu item
  const canAccessMenu = (menuId: string): boolean => {
    const menuItem = findMenuItem(menuItems, menuId);
    if (!menuItem) return false;
    
    // Only check for view permission using the screen name
    return hasPermission(menuItem.screenName, PermissionAction.VIEW);
  };

  // Handle notification menu
  const handleNotificationMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setNotificationAnchorEl(event.currentTarget);
  };

  const handleNotificationMenuClose = () => {
    setNotificationAnchorEl(null);
  };

  // Count unread notifications
  const unreadCount = mockNotifications.filter(n => !n.read).length;

  // Generate breadcrumb items from current path
  const generateBreadcrumbs = () => {
    const paths = location.pathname.split('/').filter(Boolean);
    const breadcrumbs = paths.map((path, index) => {
      const url = `/${paths.slice(0, index + 1).join('/')}`;
      const label = path.charAt(0).toUpperCase() + path.slice(1);
      return { url, label };
    });
    return breadcrumbs;
  };

  // Helper to get screen name (title) from path
  const getScreenName = () => {
    // You can expand this mapping as needed
    const pathMap: Record<string, string> = {
      '/dashboard/users': t('users.title') || 'Danh sách tài khoản Portal',
      '/dashboard': t('breadcrumb.dashboard') || 'Quản lý tài khoản Portal',
      // Add more mappings as needed
    };
    // Try to match the full path, or fallback to parent
    return pathMap[location.pathname] || pathMap[`/${location.pathname.split('/').slice(1,3).join('/')}`] || '';
  };

  // Recursive menu item renderer
  const renderMenuItem = (item: MenuItemType, level: number = 0) => {
    const isActive = isMenuItemActive(item);
    const hasChildren = item.children.length > 0;
    const isExpanded = expandedItems[item.id];
    const canAccess = canAccessMenu(item.id);

    return (
      <React.Fragment key={item.id}>
        {/* Menu Item */}
        <Tooltip 
          title={miniDrawer ? t(item.label) : ""}
          placement="right"
          disableHoverListener={!miniDrawer}
        >
          <ListItemButton 
            onClick={() => {
              if (canAccess) {
                hasChildren 
                  ? toggleExpandItem(item.id)
                  : handleNavigation(item.path);
              }
            }}
            selected={isActive}
            sx={{
              minHeight: { xs: 40, sm: 48 },
              justifyContent: miniDrawer ? 'center' : 'initial',
              px: { xs: 2, sm: 2.5 },
              pl: !miniDrawer && level > 0 ? { xs: 3, sm: 4 } : { xs: 2, sm: 2.5 },
              ml: !miniDrawer && level > 0 ? { xs: 1.5, sm: 2 } : 0,
              borderRadius: '8px',
              mb: 0.5,
              backgroundColor: isActive 
                ? theme.palette.action.selected 
                : 'transparent',
              '&:hover': {
                backgroundColor: canAccess 
                  ? theme.palette.action.hover 
                  : 'transparent',
              },
              cursor: canAccess ? 'pointer' : 'not-allowed',
              opacity: canAccess ? 1 : 0.6,
            }}
          >
            <ListItemIcon
              sx={{
                minWidth: 0,
                mr: miniDrawer ? 'auto' : { xs: 2, sm: 3 },
                justifyContent: 'center',
                '& .MuiSvgIcon-root': {
                  fontSize: { xs: 20, sm: 24 },
                }
              }}
            >
              {item.icon}
            </ListItemIcon>
            <ListItemText 
              primary={t(item.label)} 
              sx={{ 
                opacity: miniDrawer ? 0 : 1,
                display: miniDrawer ? 'none' : 'block',
                '& .MuiTypography-root': {
                  fontSize: { xs: '0.875rem', sm: '0.875rem' },
                  fontWeight: isActive ? 600 : 400,
                }
              }} 
            />
            {!miniDrawer && hasChildren && (
              isExpanded ? <ExpandLess /> : <ExpandMore />
            )}
          </ListItemButton>
        </Tooltip>

        {/* Children */}
        {hasChildren && !miniDrawer && (
          <Collapse in={isExpanded} timeout="auto" unmountOnExit>
            <List component="div" disablePadding>
              {item.children.map(child => renderMenuItem(child, level + 1))}
            </List>
          </Collapse>
        )}

        {/* Mini Drawer Children */}
        {hasChildren && miniDrawer && item.children.map(child => (
          <Tooltip 
            key={child.id}
            title={t(child.label)}
            placement="right"
          >
            {renderMenuItem(child, level + 1)}
          </Tooltip>
        ))}
      </React.Fragment>
    );
  };

  const handleViewUser = (userId: string) => {
    navigate(`/dashboard/users/edit/${userId}?view=1`);
  };

  return (
    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <ToastContainer
        position="top-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme={theme.palette.mode}
      />
      
      {/* App Bar / Header */}
      <AppBar
        position="fixed"
        sx={{
          zIndex: theme.zIndex.drawer + 1,
          transition: theme.transitions.create(['width', 'margin'], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
          }),
          ...(open && !miniDrawer) ? {
            marginLeft: {
              xs: 0, 
              sm: '50%',
              md: `clamp(${drawerMinWidth}px, ${drawerWidthPercent}%, ${drawerMaxWidth}px)`
            },
            width: { 
              xs: '100%',
              sm: `calc(100% - 50%)`,
              md: `calc(100% - clamp(${drawerMinWidth}px, ${drawerWidthPercent}%, ${drawerMaxWidth}px))` 
            }
          } : miniDrawer ? {
            marginLeft: miniDrawerWidth,
            width: `calc(100% - ${miniDrawerWidth}px)`
          } : {},
        }}
      >
        <Toolbar sx={{ 
          minHeight: { xs: 56, sm: 64 },
          px: { xs: 1, sm: 2 }
        }}>
          {/* Menu Toggle Button - Only visible on mobile */}
          {isMobile && (
            <IconButton
              color="inherit"
              aria-label="toggle drawer"
              onClick={handleDrawerOpen}
              edge="start"
              sx={{ marginRight: 1 }}
              size="medium"
            >
              <MenuIcon />
            </IconButton>
          )}
          {/* Breadcrumb Navigation + Screen Name */}
          <Box sx={{ 
            display: 'flex', 
            flexDirection: 'column',
            alignItems: 'flex-start',
            flexGrow: 1,
            ml: { xs: 0, sm: 2 },
            flexWrap: 'wrap',
            overflow: 'hidden'
          }}>
            {/* Screen Name (Title) */}
            <Typography 
              variant="h6" 
              sx={{ 
                fontWeight: 700, 
                mb: 0.5, 
                color: 'text.primary',
                fontSize: { xs: '1rem', sm: '1.25rem' },
                whiteSpace: 'nowrap',
                overflow: 'hidden',
                textOverflow: 'ellipsis',
                maxWidth: { xs: '200px', sm: 'none' }
              }}
            >
              {getScreenName()}
            </Typography>
            {/* Breadcrumb */}
            <Box 
              sx={{ 
                display: 'flex', 
                alignItems: 'center', 
                gap: 1,
                overflow: 'hidden',
                width: '100%'
              }}
            >
              {generateBreadcrumbs().map((item, index) => (
                <React.Fragment key={item.url}>
                  <Link
                    component={RouterLink}
                    to={item.url}
                    sx={{
                      color: 'text.primary',
                      textDecoration: 'none',
                      fontSize: { xs: '0.75rem', sm: '0.875rem' },
                      whiteSpace: 'nowrap',
                      '&:hover': {
                        color: 'primary.main'
                      }
                    }}
                  >
                    {item.label}
                  </Link>
                  {index < generateBreadcrumbs().length - 1 && (
                    <NavigateNextIcon sx={{ 
                      fontSize: { xs: '0.875rem', sm: '1rem' }, 
                      color: 'text.secondary' 
                    }} />
                  )}
                </React.Fragment>
              ))}
            </Box>
          </Box>
          
          {/* Right side of header */}
          <Box sx={{ 
            display: 'flex', 
            alignItems: 'center', 
            gap: { xs: 0.5, sm: 1 },
            ml: { xs: 1, sm: 2 }
          }}>
            {/* Language Switcher */}
            <Box sx={{ display: { xs: 'none', sm: 'block' } }}>
              <LanguageSwitcher />
            </Box>
            
            {/* Notifications */}
            <IconButton 
              color="inherit" 
              onClick={handleNotificationMenuOpen}
              sx={{ ml: { xs: 0.5, sm: 1 } }} 
              size="small"
            >
              <Badge badgeContent={unreadCount} color="error" title={t('common.notifications')}>
                <NotificationsIcon />
              </Badge>
            </IconButton>
            
            {/* Settings Button - Hide on xs screens */}
            <IconButton 
              color="inherit" 
              onClick={handleSettings} 
              sx={{ ml: { xs: 0.5, sm: 1 }, display: { xs: 'none', sm: 'flex' } }}
              size="small"
            >
              <SettingsIcon />
            </IconButton>
            
            {/* Profile Menu */}
            <Box>
              <IconButton
                onClick={handleProfileMenuOpen}
                size="small"
                sx={{ ml: { xs: 0.5, sm: 2 } }}
                aria-controls={profileMenuOpen ? 'account-menu' : undefined}
                aria-haspopup="true"
                aria-expanded={profileMenuOpen ? 'true' : undefined}
              >
                <Avatar sx={{ width: { xs: 28, sm: 32 }, height: { xs: 28, sm: 32 } }}>U</Avatar>
              </IconButton>
              <Menu
                anchorEl={anchorEl}
                id="account-menu"
                open={profileMenuOpen}
                onClose={handleProfileMenuClose}
                onClick={handleProfileMenuClose}
                transformOrigin={{ horizontal: 'right', vertical: 'top' }}
                anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
                PaperProps={{
                  sx: {
                    minWidth: { xs: '200px', sm: '240px' }
                  }
                }}
              >
                <MenuItem onClick={handleProfile}>
                  <ListItemIcon>
                    <PersonIcon fontSize="small" />
                  </ListItemIcon>
                  <ListItemText primary={t('common.profile')} />
                </MenuItem>
                <MenuItem onClick={handleSettings}>
                  <ListItemIcon>
                    <SettingsIcon fontSize="small" />
                  </ListItemIcon>
                  <ListItemText primary={t('common.settings')} />
                </MenuItem>
                <Divider />
                <MenuItem onClick={logout}>
                  <ListItemIcon>
                    <LogoutIcon fontSize="small" />
                  </ListItemIcon>
                  <ListItemText primary={t('common.logout')} />
                </MenuItem>
              </Menu>
            </Box>
          </Box>
        </Toolbar>
      </AppBar>
      
      {/* Sidebar / Drawer */}
      <Drawer
        variant={isMobile ? "temporary" : "permanent"}
        open={open}
        onClose={handleDrawerClose}
        sx={{
          width: miniDrawer ? miniDrawerWidth : {
            xs: '85%', // On very small screens, use 85% width but max 290px
            sm: '50%',
            md: `${drawerWidthPercent}%`,
          },
          flexShrink: 0,
          whiteSpace: 'nowrap',
          boxSizing: 'border-box',
          '& .MuiDrawer-paper': {
            width: miniDrawer ? miniDrawerWidth : {
              xs: '85%', // Mobile: 85% of screen but max 290px
              sm: '50%',
              md: `clamp(${drawerMinWidth}px, ${drawerWidthPercent}%, ${drawerMaxWidth}px)`,
            },
            overflowX: 'hidden',
            borderRight: `1px solid ${theme.palette.divider}`,
            transition: theme.transitions.create('width', {
              easing: theme.transitions.easing.sharp,
              duration: theme.transitions.duration.enteringScreen,
            }),
            display: 'flex',
            flexDirection: 'column',
          },
        }}
      >
        {/* Logo at the top */}
        <Box sx={{ 
          p: { xs: 1.5, sm: 2 },
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}>
          <Box
            component="img"
            src={logo}
            alt="Company Logo"
            sx={{
              height: { xs: 40, sm: 60 },
              width: 'auto',
              objectFit: 'contain',
            }}
          />
        </Box>
        
        {/* Drawer Content */}
        <List component="nav" sx={{ 
          p: { xs: 1, sm: 1.5 },
          flexGrow: 1,
          '& .MuiListItemButton-root': {
            py: { xs: 1, sm: 1.2 },
          }
        }}>
          {menuItems.map(item => renderMenuItem(item))}
        </List>
      </Drawer>
      
      {/* Main Content */}
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: { xs: 1, sm: 2, md: 3 },
          width: { 
            xs: '100%',
            sm: open 
              ? miniDrawer 
                ? `calc(100% - ${miniDrawerWidth}px)` 
                : { 
                    sm: '50%', 
                    md: `calc(100% - clamp(${drawerMinWidth}px, ${drawerWidthPercent}%, ${drawerMaxWidth}px))` 
                  } 
              : '100%'
          },
          marginTop: { xs: '56px', sm: '64px' }, // Adjust top margin for mobile
          backgroundColor: theme.palette.background.default,
          minHeight: { xs: 'calc(100vh - 56px)', sm: 'calc(100vh - 64px)' },
          display: 'flex',
          flexDirection: 'column'
        }}
      >
        <Box sx={{ flexGrow: 1 }}>
          <Outlet />
        </Box>
        
        {/* Footer */}
        <Box
          component="footer"
          sx={{
            py: 2,
            px: 3,
            mt: 'auto',
            backgroundColor: theme.palette.background.paper,
            borderTop: `1px solid ${theme.palette.divider}`,
            textAlign: 'center'
          }}
        >
          <Typography variant="body2" color="text.secondary">
            © {new Date().getFullYear()} ATDS - Vietnam Automation Technology Development Solutions. All rights reserved.
          </Typography>
        </Box>
      </Box>

      {/* Notification Menu */}
      <Menu
        anchorEl={notificationAnchorEl}
        open={notificationMenuOpen}
        onClose={handleNotificationMenuClose}
        PaperProps={{
          sx: {
            width: 360,
            maxHeight: 400,
            mt: 1.5
          }
        }}
        transformOrigin={{ horizontal: 'right', vertical: 'top' }}
        anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
      >
        <Box sx={{ p: 2, borderBottom: '1px solid', borderColor: 'divider' }}>
          <Typography variant="h6" sx={{ fontWeight: 600 }}>Notifications</Typography>
        </Box>
        {mockNotifications.map((notification) => (
          <MenuItem 
            key={notification.id}
            onClick={handleNotificationMenuClose}
            sx={{
              py: 1.5,
              px: 2,
              borderBottom: '1px solid',
              borderColor: 'divider',
              backgroundColor: notification.read ? 'transparent' : 'action.hover',
              '&:hover': {
                backgroundColor: 'action.hover'
              }
            }}
          >
            <Box sx={{ width: '100%' }}>
              <Typography variant="subtitle2" sx={{ fontWeight: notification.read ? 400 : 600 }}>
                {notification.title}
              </Typography>
              <Typography variant="body2" color="text.secondary" sx={{ mt: 0.5 }}>
                {notification.message}
              </Typography>
              <Typography variant="caption" color="text.secondary" sx={{ mt: 0.5, display: 'block' }}>
                {notification.time}
              </Typography>
            </Box>
          </MenuItem>
        ))}
      </Menu>

      {/* Sidebar Toggle Floating Button */}
      <Box
        sx={{
          position: 'fixed',
          top: 16,
          left: open && !miniDrawer ? { xs: 16, sm: `clamp(${drawerMinWidth}px, ${drawerWidthPercent}% - 16px, ${drawerMaxWidth}px)` } : 50,
          zIndex: theme.zIndex.drawer + 2,
          transition: 'left 0.3s',
          display: { xs: 'none', sm: 'block' }
        }}
      >
        <IconButton
          onClick={handleDrawerOpen}
          sx={{
            bgcolor: 'background.paper',
            boxShadow: 1,
            width: 30,
            height: 30,
            borderRadius: '50%',
            '&:hover': {
              bgcolor: alpha(theme.palette.primary.main, 0.08),
            },
          }}
        >
          {open && !miniDrawer ? <KeyboardArrowLeftIcon /> : <KeyboardArrowRightIcon />}
        </IconButton>
      </Box>
    </Box>
  );
};

export default MainLayout;