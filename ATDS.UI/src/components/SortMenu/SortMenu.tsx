import { SortField } from '@/types/common.type';
import BadgeIcon from '@mui/icons-material/Badge';
import CalendarTodayIcon from '@mui/icons-material/CalendarToday';
import DeleteIcon from '@mui/icons-material/Delete';
import DragIndicatorIcon from '@mui/icons-material/DragIndicator';
import EmailIcon from '@mui/icons-material/Email';
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import PersonIcon from '@mui/icons-material/Person';
import SortIcon from '@mui/icons-material/Sort';
import TranslateIcon from '@mui/icons-material/Translate';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import VerifiedUserIcon from '@mui/icons-material/VerifiedUser';
import {
  alpha,
  Box,
  Button,
  IconButton,
  Menu,
  Paper,
  Stack,
  Tooltip,
  Typography,
  useTheme
} from '@mui/material';
import React, { useState, useCallback } from 'react';
import { useTranslation } from 'react-i18next';

export interface SortMenuProps {
  onSort: (sortFields: SortField[]) => void;
  availableFields?: string[];
  initialSortFields?: SortField[];
  translationPrefix?: string;
  buttonLabel?: string;
  activeSortsLabel?: string;
  availableFieldsLabel?: string;
}

const SortMenu: React.FC<SortMenuProps> = ({ 
  onSort, 
  availableFields = ['username', 'email', 'role', 'status', 'createdAt'],
  initialSortFields = [],
  translationPrefix = 'users.fields',
  buttonLabel = 'common.sort',
  activeSortsLabel = 'common.activeSorts',
  availableFieldsLabel = 'common.availableFields'
}) => {
  const { t } = useTranslation();
  const theme = useTheme();
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [sortFields, setSortFields] = useState<SortField[]>(initialSortFields);
  const [draggedField, setDraggedField] = useState<string | null>(null);
  const [dragOverField, setDragOverField] = useState<string | null>(null);

  const handleClick = useCallback((event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  }, []);

  const handleClose = useCallback(() => {
    setAnchorEl(null);
  }, []);

  const toggleSort = useCallback((field: string) => {
    const existingIndex = sortFields.findIndex(sf => sf.field === field);
    let newSortFields: SortField[];

    if (existingIndex >= 0) {
      // If field exists, toggle its order
      newSortFields = [...sortFields];
      newSortFields[existingIndex] = {
        field,
        order: newSortFields[existingIndex].order === 'asc' ? 'desc' : 'asc'
      };
    } else {
      // If field doesn't exist, add it
      newSortFields = [...sortFields, { field, order: 'asc' }];
    }

    // Update state and call onSort in a single operation
    setSortFields(newSortFields);
    onSort(newSortFields);
  }, [sortFields, onSort]);

  const removeSort = useCallback((field: string) => {
    const newSortFields = sortFields.filter(sf => sf.field !== field);
    setSortFields(newSortFields);
    onSort(newSortFields);
  }, [sortFields, onSort]);

  const handleDragStart = useCallback((field: string) => {
    setDraggedField(field);
  }, []);

  const handleDragOver = useCallback((e: React.DragEvent, field: string) => {
    e.preventDefault();
    setDragOverField(field);
  }, []);

  const handleDragLeave = useCallback(() => {
    setDragOverField(null);
  }, []);

  const handleDrop = useCallback((targetField: string) => {
    if (!draggedField || draggedField === targetField) return;

    const draggedIndex = sortFields.findIndex(sf => sf.field === draggedField);
    const targetIndex = sortFields.findIndex(sf => sf.field === targetField);

    if (draggedIndex === -1 || targetIndex === -1) return;

    const newSortFields = [...sortFields];
    const [draggedItem] = newSortFields.splice(draggedIndex, 1);
    newSortFields.splice(targetIndex, 0, draggedItem);

    setSortFields(newSortFields);
    onSort(newSortFields);
    setDraggedField(null);
    setDragOverField(null);
  }, [draggedField, sortFields, onSort]);

  const getSortIcon = useCallback((order: 'asc' | 'desc') => {
    return order === 'asc' ? (
      <Box sx={{ display: 'flex', alignItems: 'center', color: 'success.main' }}>
        <ExpandLessIcon fontSize="small" />
        <Typography variant="caption" sx={{ ml: 0.5 }}>↑</Typography>
      </Box>
    ) : (
      <Box sx={{ display: 'flex', alignItems: 'center', color: 'error.main' }}>
        <ExpandMoreIcon fontSize="small" />
        <Typography variant="caption" sx={{ ml: 0.5 }}>↓</Typography>
      </Box>
    );
  }, []);

  const getFieldIcon = useCallback((fieldId: string) => {
    switch (fieldId) {
      case 'username':
        return <PersonIcon />;
      case 'name':
        return <AccountCircleIcon />;
      case 'email':
        return <EmailIcon />;
      case 'language':
        return <TranslateIcon />;
      case 'roleId':
        return <VerifiedUserIcon />;
      case 'status':
        return <BadgeIcon />;
      case 'createdAt':
        return <CalendarTodayIcon />;
      default:
        return null;
    }
  }, []);

  return (
    <>
      <Tooltip title={sortFields.length > 0 ? t('common.sortApplied') : t('common.sort')}>
        <Button
          size="small"
          onClick={handleClick}
          startIcon={<SortIcon sx={{ color: '#ffffff' }} />}
          endIcon={sortFields.length > 0 ? <ExpandLessIcon sx={{ color: '#ffffff' }} /> : <ExpandMoreIcon sx={{ color: '#ffffff' }} />}
          variant="contained"
          disableElevation
          sx={{ 
            height: 40,
            px: 2,
            borderRadius: 2,
            minWidth: { xs: '100%', sm: 'auto' },
            background: sortFields.length > 0 
              ? 'linear-gradient(45deg, #3d78ff 30%, #2a61e6 90%)'
              : 'linear-gradient(45deg, #6b97ff 30%, #3d78ff 90%)',
            color: '#ffffff',
            fontWeight: 600,
            letterSpacing: '0.5px',
            boxShadow: '0 3px 5px 2px rgba(59, 120, 255, .3)',
            border: 'none',
            transition: 'all 0.3s ease',
            '&:hover': {
              background: 'linear-gradient(45deg, #3d78ff 30%, #2a61e6 90%)',
              transform: 'translateY(-2px)',
              boxShadow: '0 4px 8px 2px rgba(59, 120, 255, .4)',
            },
            '&:active': {
              transform: 'translateY(0px)',
              boxShadow: '0 2px 4px 1px rgba(59, 120, 255, .3)'
            }
          }}
        >
          <Box sx={{ 
            display: 'flex', 
            alignItems: 'center',
            gap: 0.5
          }}>
            {t(buttonLabel)}
            {sortFields.length > 0 && (
              <Box component="span" sx={{ 
                ml: 0.5, 
                bgcolor: 'rgba(255, 255, 255, 0.25)',
                color: 'white',
                borderRadius: 12,
                px: 1,
                py: 0.15,
                fontSize: '0.75rem',
                fontWeight: 700,
                display: 'inline-flex',
                alignItems: 'center',
                justifyContent: 'center',
                minWidth: 20,
                backdropFilter: 'blur(4px)',
                transition: 'all 0.3s ease'
              }}>
                {sortFields.length}
              </Box>
            )}
          </Box>
        </Button>
      </Tooltip>
      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleClose}
        PaperProps={{
          sx: {
            width: 320,
            maxWidth: '100%',
            mt: 1
          }
        }}
      >
        {/* Active Sort Fields */}
        {sortFields.length > 0 && (
          <Box sx={{ p: 1, borderBottom: 1, borderColor: 'divider' }}>
            <Typography variant="subtitle2" sx={{ mb: 1, px: 2, color: 'text.secondary' }}>
              {t(activeSortsLabel)}
            </Typography>
            <Stack spacing={1} sx={{ px: 1 }}>
              {sortFields.map((sortField, index) => (
                <Paper
                  key={sortField.field}
                  draggable
                  onDragStart={() => handleDragStart(sortField.field)}
                  onDragOver={(e) => handleDragOver(e, sortField.field)}
                  onDragLeave={handleDragLeave}
                  onDrop={() => handleDrop(sortField.field)}
                  sx={{
                    p: 1,
                    display: 'flex',
                    alignItems: 'center',
                    gap: 1,
                    cursor: 'move',
                    bgcolor: draggedField === sortField.field 
                      ? alpha(theme.palette.primary.main, 0.08)
                      : dragOverField === sortField.field
                      ? alpha(theme.palette.primary.main, 0.04)
                      : 'background.paper',
                    border: dragOverField === sortField.field ? `1px dashed ${theme.palette.primary.main}` : '1px solid transparent',
                    '&:hover': {
                      bgcolor: 'action.hover'
                    }
                  }}
                >
                  <DragIndicatorIcon 
                    fontSize="small" 
                    sx={{ 
                      color: 'text.secondary',
                      opacity: 0.5
                    }} 
                  />
                  <Typography variant="body2" color="text.secondary">
                    {index + 1}.
                  </Typography>
                  <Box sx={{ flex: 1 }}>
                    <Typography variant="body2">
                      {t(`${translationPrefix}.${sortField.field}`)}
                    </Typography>
                  </Box>
                  <IconButton
                    size="small"
                    onClick={() => toggleSort(sortField.field)}
                    color={sortField.order === 'asc' ? 'success' : 'error'}
                    sx={{
                      '&:hover': {
                        bgcolor: sortField.order === 'asc' 
                          ? alpha(theme.palette.success.main, 0.1)
                          : alpha(theme.palette.error.main, 0.1)
                      }
                    }}
                  >
                    {getSortIcon(sortField.order)}
                  </IconButton>
                  <IconButton
                    size="small"
                    onClick={() => removeSort(sortField.field)}
                    color="error"
                    sx={{
                      '&:hover': {
                        bgcolor: alpha(theme.palette.error.main, 0.1)
                      }
                    }}
                  >
                    <DeleteIcon fontSize="small" />
                  </IconButton>
                </Paper>
              ))}
            </Stack>
          </Box>
        )}

        {/* Available Sort Fields */}
        <Box sx={{ p: 1 }}>
          <Typography variant="subtitle2" sx={{ mb: 1, px: 2, color: 'text.secondary' }}>
            {t(availableFieldsLabel)}
          </Typography>
          <Stack spacing={1}>
            {availableFields.map((field) => {
              const isActive = sortFields.some(sf => sf.field === field);
              const sortField = sortFields.find(sf => sf.field === field);
              return (
                <Button
                  key={field}
                  fullWidth
                  variant={isActive ? 'contained' : 'outlined'}
                  color={isActive ? 'primary' : 'inherit'}
                  onClick={() => toggleSort(field)}
                  startIcon={getFieldIcon(field)}
                  endIcon={isActive && getSortIcon(sortField!.order)}
                  sx={{
                    justifyContent: 'flex-start',
                    textTransform: 'none',
                    height: 40,
                    border: 'none',
                    '&:hover': {
                      bgcolor: isActive 
                        ? alpha(theme.palette.primary.main, 0.9)
                        : 'action.hover'
                    }
                  }}
                >
                  {t(`${translationPrefix}.${field}`)}
                </Button>
              );
            })}
          </Stack>
        </Box>
      </Menu>
    </>
  );
};

export default SortMenu; 