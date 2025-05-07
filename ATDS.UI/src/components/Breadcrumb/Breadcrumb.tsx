import React from 'react';
import { 
  Breadcrumbs, 
  Link, 
  Box,
  useTheme
} from '@mui/material';
import { Link as RouterLink, useLocation } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import HomeIcon from '@mui/icons-material/Home';
import { alpha } from '@mui/material/styles';

interface BreadcrumbItem {
  path: string;
  label: string;
  icon?: React.ReactNode;
}

interface BreadcrumbProps {
  items?: BreadcrumbItem[];
  currentPageTitle?: string;
}

const Breadcrumb: React.FC<BreadcrumbProps> = ({ items }) => {
  const { t } = useTranslation();
  const location = useLocation();
  const theme = useTheme();
  
  // If no items are provided, generate from the current path
  const generateBreadcrumbs = (): BreadcrumbItem[] => {
    if (items && items.length > 0) return items;
    
    const paths = location.pathname.split('/')
      .filter(path => path !== '');
    
    const generatedItems: BreadcrumbItem[] = [
      { path: '/', label: 'breadcrumb.home', icon: <HomeIcon fontSize="small" /> }
    ];

    let currentPath = '';
    paths.forEach((path, index) => {
      currentPath += `/${path}`;
      // Skip adding the last path as a link - it will be the current page
      if (index < paths.length - 1) {
        generatedItems.push({
          path: currentPath,
          label: `breadcrumb.${path}`, // Assuming translation keys follow a pattern
        });
      }
    });

    return generatedItems;
  };
  
  const breadcrumbItems = generateBreadcrumbs();

  return (
    <Box
      sx={{
        py: 2,
        px: 3,
        mb: 3,
        borderRadius: 2,
        background: `linear-gradient(135deg, ${alpha(theme.palette.primary.main, 0.05)} 0%, ${alpha(theme.palette.primary.main, 0.1)} 100%)`,
        boxShadow: `0 2px 12px ${alpha(theme.palette.primary.main, 0.08)}`,
        border: `1px solid ${alpha(theme.palette.primary.main, 0.12)}`,
        transition: 'all 0.3s ease',
        '&:hover': {
          boxShadow: `0 4px 20px ${alpha(theme.palette.primary.main, 0.12)}`,
          transform: 'translateY(-1px)'
        }
      }}
    >
      <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
        <Breadcrumbs
          separator={
            <NavigateNextIcon
              fontSize="small"
              sx={{
                color: alpha(theme.palette.primary.main, 0.5),
                transition: 'transform 0.2s ease',
                '&:hover': {
                  transform: 'translateX(2px)'
                }
              }}
            />
          }
          aria-label="breadcrumb"
        >
          {breadcrumbItems.map((item, index) => {
            const isLast = index === breadcrumbItems.length - 1;
            const isFirst = index === 0;

            return (
              <Link
                key={item.path}
                component={RouterLink}
                to={item.path}
                sx={{
                  display: 'flex',
                  alignItems: 'center',
                  gap: 0.5,
                  color: isLast ? theme.palette.primary.main : theme.palette.text.secondary,
                  textDecoration: 'none',
                  fontWeight: isLast ? 600 : 500,
                  fontSize: '0.95rem',
                  transition: 'all 0.2s ease',
                  opacity: isLast ? 1 : 0.8,
                  '&:hover': {
                    color: theme.palette.primary.main,
                    opacity: 1,
                    transform: 'translateY(-1px)',
                    textDecoration: 'none'
                  }
                }}
              >
                {isFirst && (
                  <HomeIcon
                    sx={{
                      fontSize: '1.1rem',
                      color: isLast ? theme.palette.primary.main : 'inherit',
                      transition: 'transform 0.2s ease',
                      '&:hover': {
                        transform: 'scale(1.1)'
                      }
                    }}
                  />
                )}
                {t(item.label)}
              </Link>
            );
          })}
        </Breadcrumbs>
      </Box>
    </Box>
  );
};

export default Breadcrumb;