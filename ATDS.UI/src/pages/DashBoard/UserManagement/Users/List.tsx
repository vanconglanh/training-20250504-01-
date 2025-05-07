import ConfirmDialog from '@/components/ConfirmDialog/ConfirmDialog';
import SortMenu, { SortField } from '@/components/SortMenu/SortMenu';
import { Menu } from '@/config/constant/feature';
import { PermissionAction } from '@/config/enum/PermissionAction';
import { usePermissions } from '@/hooks/usePermissions';
import Filter, { ActiveFilter, FilterOption, FilterValues } from '@/pages/DashBoard/UserManagement/Users/Filter';
import { userService } from '@/services/userService';
import { User, UserListResponse, UserParams } from '@/types/user.type';
import { formatDate } from '@/utils/datetime';
import AddIcon from '@mui/icons-material/Add';
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import FilterListIcon from '@mui/icons-material/FilterList';
import SearchIcon from '@mui/icons-material/Search';
import ViewColumnIcon from '@mui/icons-material/ViewColumn';
import VisibilityIcon from '@mui/icons-material/Visibility';
import {
  alpha,
  Autocomplete,
  Box,
  Button,
  Checkbox,
  Chip,
  CircularProgress,
  IconButton,
  InputAdornment,
  MenuItem,
  Menu as MuiMenu,
  Pagination,
  Paper,
  Popper,
  PopperProps,
  Skeleton,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Tooltip,
  Typography,
  useTheme
} from '@mui/material';
import { useQuery } from '@tanstack/react-query';
import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

// Column configuration type
interface ColumnConfig {
  id: keyof User | 'actions';
  label: string;
  visible: boolean;
  sortable?: boolean;
}

// Helper function to check if data is valid
const isValidData = (data: UserListResponse | undefined): data is UserListResponse => {
  return !!data && Array.isArray(data.data);
};

// Helper function to check if we have data
const hasData = (data: UserListResponse | undefined): boolean => {
  return isValidData(data) && data.data.length > 0;
};

// Custom Popper component for Autocomplete
const CustomPopper = React.forwardRef<HTMLDivElement, PopperProps>((props, ref) => (
  <Popper
    {...props}
    ref={ref}
    placement="bottom-start"
    open={props.open}
    modifiers={[
      {
        name: 'offset',
        options: {
          offset: [0, 8],
        },
      },
    ]}
  />
));

CustomPopper.displayName = 'CustomPopper';

const UserList: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { hasPermission } = usePermissions();
  const theme = useTheme();
  
  // Permission checks
  const canCreate = hasPermission(Menu.USERS, PermissionAction.CREATE);
  const canUpdate = hasPermission(Menu.USERS, PermissionAction.UPDATE);
  const canDelete = hasPermission(Menu.USERS, PermissionAction.DELETE);
  
  // Add username autocomplete states
  const [usernameLoading, setUsernameLoading] = useState(false);
  const [usernameSuggestions, setUsernameSuggestions] = useState<any[]>([]);
  const [selectedUsername, setSelectedUsername] = useState<string>('');

  // Pagination and other states
  const [params, setParams] = useState<UserParams>({
    page: 0,
    limit: 10,
    search: [],
    sortBy: 'username',
    sortOrder: 'asc'
  });

  const [selected, setSelected] = useState<string[]>([]);
  const [confirmDialog, setConfirmDialog] = useState({
    open: false,
    userId: '',
    multiple: false
  });

  // Filter states
  const [statusFilter, setStatusFilter] = useState({
    active: false,
    inactive: false,
    pending: false
  });

  const [roleFilter, setRoleFilter] = useState({
    admin: false,
    manager: false,
    user: false
  });

  const [filterValues, setFilterValues] = useState<FilterValues>({
    username: '',
    email: '',
    role: '',
    status: '',
    createdAt: '',
    updatedAt: '',
    lastUpdate: '',
    lastUpdateUser: '',
    lastUpdateProgram: '',
    passwordHash: '',
    yukoFlag: ''
  });

  // Advanced filter states
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [activeFilters, setActiveFilters] = useState<ActiveFilter[]>([]);

  // Add sort state
  const [sortConfig, setSortConfig] = useState<{
    field: string;
    direction: 'asc' | 'desc';
  }>({
    field: 'username',
    direction: 'asc'
  });

  // Column visibility state
  const [columns, setColumns] = useState<ColumnConfig[]>([
    { id: 'username', label: t('users.fields.username'), visible: true, sortable: true },
    { id: 'email', label: t('users.fields.email'), visible: true, sortable: true },
    { id: 'role', label: t('users.fields.role'), visible: true, sortable: true },
    { id: 'status', label: t('users.fields.status'), visible: true, sortable: true },
    { id: 'createdAt', label: t('users.fields.createdAt'), visible: true, sortable: true },
  ]);

  // Column menu state
  const [columnMenuAnchor, setColumnMenuAnchor] = useState<null | HTMLElement>(null);
  const [columnSearch, setColumnSearch] = useState('');

  // Filter columns based on search
  const filteredColumns = columns.filter(column => 
    column.label.toLowerCase().includes(columnSearch.toLowerCase())
  );

  // Query setup
  const { data, isLoading, isFetching, refetch } = useQuery<UserListResponse>({
    queryKey: ['users', params, { statusFilter, roleFilter }],
    queryFn: async () => {
      try {
        const filterParams: UserParams = {
          ...params,
        };

        const result = await userService.getUsers(filterParams);
        return result;
      } catch (error) {
        toast.error(t('errors.fetchFailed'));
        return { data: [], total: 0, page: 0, limit: 10 };
      }
    },
    refetchOnWindowFocus: false
  });

  // Handle delete user(s)
  const handleDelete = async (userId?: string) => {
    if (userId) {
      // Single delete
      setConfirmDialog({
        open: true,
        userId,
        multiple: false
      });
    } else if (selected.length > 0) {
      // Multiple delete
      setConfirmDialog({
        open: true,
        userId: '',
        multiple: true
      });
    }
  };

  // Confirm delete action
  const confirmDelete = async () => {
    try {
      if (confirmDialog.multiple) {
        // Delete multiple users
        await Promise.all(selected.map(id => userService.deleteUser(id)));
        toast.success(t('users.deleteMultipleSuccess'));
        setSelected([]);
      } else {
        // Delete single user
        await userService.deleteUser(confirmDialog.userId);
        toast.success(t('users.deleteSuccess'));
      }
      refetch();
    } catch (error) {
      toast.error(t('errors.deleteFailed'));
    } finally {
      setConfirmDialog({
        open: false,
        userId: '',
        multiple: false
      });
    }
  };

  // Cancel delete action
  const cancelDelete = () => {
    setConfirmDialog({
      open: false,
      userId: '',
      multiple: false
    });
  };

  // Handle rows per page change
  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setParams(prev => ({ 
      ...prev, 
      limit: parseInt(event.target.value, 10),
      page: 0 
    }));
  };

  // Navigate to create user page
  const handleCreateUser = () => {
    navigate('/dashboard/users/create');
  };

  // Navigate to edit user page
  const handleEditUser = (userId: string) => {
    navigate(`/dashboard/users/edit/${userId}`);
  };

  // Navigate to view user page
  const handleViewUser = (userId: string) => {
    navigate(`/dashboard/users/view/${userId}`);
  };

  // Calculate status chip color
  const getStatusColor = (status: string) => {
    switch (status.toLowerCase()) {
      case 'active':
        return 'success';
      case 'inactive':
        return 'error';
      case 'pending':
        return 'warning';
      default:
        return 'default';
    }
  };

  // Handle column sort
  const handleColumnSort = (field: string) => {
    setSortConfig(prevSort => ({
      field,
      direction: prevSort.field === field && prevSort.direction === 'asc' ? 'desc' : 'asc'
    }));

    setParams(prev => ({
      ...prev,
      sortBy: field,
      sortOrder: sortConfig.field === field && sortConfig.direction === 'asc' ? 'desc' : 'asc'
    }));
  };

  // Handle sort menu
  const handleSortMenu = (sortFields: SortField[]) => {
    setParams(prev => ({
      ...prev,
      sortFields,
      // Clear legacy sort params
      sortBy: undefined,
      sortOrder: undefined
    }));
  };

  // Table header cell component
  const TableHeaderCell: React.FC<{
    field: string;
    label: string;
    sortable?: boolean;
    align?: 'left' | 'right' | 'center';
    onClick?: (field: string) => void;
  }> = ({ field, label, sortable = true, align = 'left', onClick }) => {
    const theme = useTheme();
    
    return (
      <TableCell
        align={align}
        onClick={() => sortable && onClick?.(field)}
        sx={{
          cursor: sortable ? 'pointer' : 'default',
          userSelect: 'none',
          '&:hover': sortable ? {
            bgcolor: alpha(theme.palette.primary.main, 0.04)
          } : {},
          transition: 'all 0.2s ease',
          padding: '16px',
          fontWeight: 600,
          position: 'relative',
          whiteSpace: 'nowrap'
        }}
      >
        <Box sx={{ display: 'inline-flex', alignItems: 'center', gap: 0.5 }}>
          {label}
          {sortable && onClick && (
            <Box
              sx={{
                display: 'inline-flex',
                alignItems: 'center',
                opacity: 0,
                transition: 'opacity 0.2s ease',
                ml: 0.5,
                '.MuiTableCell-root:hover &': {
                  opacity: 0.5
                }
              }}
            >
              <ArrowUpwardIcon 
                sx={{ 
                  fontSize: 16,
                  verticalAlign: 'middle',
                  transform: sortConfig.direction === 'desc' ? 'rotate(180deg)' : 'none',
                  transition: 'transform 0.2s ease'
                }} 
              />
            </Box>
          )}
        </Box>
      </TableCell>
    );
  };

  // Handle select all rows
  const handleSelectAll = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked && isValidData(data)) {
      const newSelected = data.data.map(user => user.id);
      setSelected(newSelected);
      return;
    }
    setSelected([]);
  };

  // Handle select one row
  const handleSelectOne = (id: string) => {
    const selectedIndex = selected.indexOf(id);
    let newSelected: string[] = [];

    if (selectedIndex === -1) {
      // Select
      newSelected = [...selected, id];
    } else {
      // Deselect
      newSelected = selected.filter(itemId => itemId !== id);
    }

    setSelected(newSelected);
  };

  // Check if a row is selected
  const isSelected = (id: string) => selected.indexOf(id) !== -1;

  // Render table rows with skeleton loading
  const renderTableRows = () => {
    // If loading and no previous data
    if (isLoading && !hasData(data)) {
      return Array(params.limit)
        .fill(0)
        .map((_, index) => (
          <TableRow key={`skeleton-${index}`}>
            <TableCell padding="checkbox">
              <Skeleton animation="wave" width={20} height={20} />
            </TableCell>
            {columns.map((column) => column.visible && (
              <TableCell key={`skeleton-${column.id}`}>
                <Skeleton animation="wave" width="80%" />
              </TableCell>
            ))}
            <TableCell align="right">
              <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
                <Skeleton animation="wave" variant="circular" width={28} height={28} sx={{ mr: 1 }} />
                <Skeleton animation="wave" variant="circular" width={28} height={28} />
              </Box>
            </TableCell>
          </TableRow>
        ));
    }

    // If we have data but it's empty
    if (!hasData(data)) {
      return (
        <TableRow>
          <TableCell colSpan={columns.filter(col => col.visible).length + 2} align="center">
            {t('users.noData')}
          </TableCell>
        </TableRow>
      );
    }

    // If we have data, render it
    return (isValidData(data) ? data.data : []).map((user: User) => {
      const isItemSelected = isSelected(user.id);
      
      return (
        <TableRow 
          hover 
          key={user.id} 
          sx={{ opacity: isFetching ? 0.7 : 1 }}
          onClick={() => handleSelectOne(user.id)}
          selected={isItemSelected}
          role="checkbox"
          aria-checked={isItemSelected}
        >
          <TableCell padding="checkbox">
            <Checkbox
              checked={isItemSelected}
              onChange={() => handleSelectOne(user.id)}
              onClick={(e) => e.stopPropagation()}
            />
          </TableCell>
          {columns.map((column) => column.visible && (
            <TableCell key={column.id}>
              {column.id === 'status' ? (
                <Chip 
                  label={t(`users.statuses.${user.status}`)} 
                  color={getStatusColor(user.status) as any}
                  size="small"
                />
              ) : column.id === 'createdAt' ? (
                formatDate(new Date(user.createdAt).toString())
              ) : column.id === 'role' ? (
                t(`users.roles.${user.role}`)
              ) : column.id === 'username' ? (
                user.username
              ) : column.id === 'email' ? (
                user.email
              ) : null}
            </TableCell>
          ))}
          <TableCell align="right">
          <Tooltip title={t('common.view')}>
              <span>
                <IconButton 
                  size="small" 
                  color="primary"
                  onClick={(e) => {
                    e.stopPropagation();
                    handleViewUser(user.id);
                  }}
                >
                  <VisibilityIcon fontSize="small" />
                </IconButton>
              </span>
            </Tooltip>
            <Tooltip title={!canUpdate ? t('errors.insufficientPermissions') : t('common.edit')}>
              <span>
                <IconButton 
                  size="small" 
                  color="primary"
                  onClick={(e) => {
                    e.stopPropagation();
                    handleEditUser(user.id);
                  }}
                  disabled={isFetching || !canUpdate}
                >
                  <EditIcon fontSize="small" />
                </IconButton>
              </span>
            </Tooltip>
            <Tooltip title={!canDelete ? t('errors.insufficientPermissions') : t('common.delete')}>
              <span>
                <IconButton 
                  size="small" 
                  color="error"
                  onClick={(e) => {
                    e.stopPropagation();
                    handleDelete(user.id);
                  }}
                  disabled={isFetching || !canDelete}
                >
                  <DeleteIcon fontSize="small" />
                </IconButton>
              </span>
            </Tooltip>
          </TableCell>
        </TableRow>
      );
    });
  };

  // Reset filters
  const handleFilterClear = () => {
    setActiveFilters([]);
    setFilterValues({
      username: '',
      email: '',
      role: '',
      status: '',
      createdAt: '',
      updatedAt: '',
      lastUpdate: '',
      lastUpdateUser: '',
      lastUpdateProgram: '',
      passwordHash: '',
      yukoFlag: ''
    });
    setParams((prev: UserParams) => ({
      ...prev,
      username: undefined,
      email: undefined,
      role: undefined,
      status: undefined,
      page: 0
    }));
  };

  // Filter options
  const userFilterOptions: FilterOption[] = [
    {
      id: 'username',
      label: t('users.fields.username'),
      type: 'autocomplete',
      searchFunction: async (value: string) => {
        try {
          return await userService.getSearchSuggestionsByType(value, 'username');
        } catch (error) {
          console.error('Error fetching username suggestions:', error);
          return [];
        }
      }
    },
    {
      id: 'email',
      label: t('users.fields.email'),
      type: 'autocomplete',
      searchFunction: async (value: string) => {
        try {
          return await userService.getSearchSuggestionsByType(value, 'email');
        } catch (error) {
          console.error('Error fetching email suggestions:', error);
          return [];
        }
      }
    },
    {
      id: 'role',
      label: t('users.fields.role'),
      type: 'select',
      options: [
        { value: 'admin', label: t('users.roles.admin') },
        { value: 'manager', label: t('users.roles.manager') },
        { value: 'user', label: t('users.roles.user') }
      ]
    },
    {
      id: 'status',
      label: t('users.fields.status'),
      type: 'select',
      options: [
        { value: 'active', label: t('users.statuses.active') },
        { value: 'inactive', label: t('users.statuses.inactive') },
        { value: 'pending', label: t('users.statuses.pending') }
      ]
    }
  ];

  // Handle filter changes
  const handleFilterApply = (filters: ActiveFilter[]) => {
    setActiveFilters(filters);
    
    // Update params with new filters
    const newParams: UserParams = {
      ...params,
      page: 0,
      username: undefined,
      email: undefined,
      role: undefined,
      status: undefined
    };

    filters.forEach(filter => {
      const values = filter.value.split(',').map(v => v.trim()).filter(v => v.length > 0);
      if (values.length === 0) return;
      
      // Take only the first value for each filter
      switch (filter.field) {
        case 'username':
          newParams.username = values[0];
          break;
        case 'email':
          newParams.email = values[0];
          break;
        case 'role':
          newParams.role = values[0];
          break;
        case 'status':
          newParams.status = values[0];
          break;
      }
    });

    setParams(newParams);
  };

  // Handle column menu open
  const handleColumnMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setColumnMenuAnchor(event.currentTarget);
  };

  // Handle column menu close
  const handleColumnMenuClose = () => {
    setColumnMenuAnchor(null);
    setColumnSearch(''); // Reset search when closing menu
  };

  // Handle column visibility toggle
  const handleColumnVisibilityToggle = (columnId: string) => {
    setColumns(prev => prev.map(col => 
      col.id === columnId ? { ...col, visible: !col.visible } : col
    ));
  };

  // Get visible columns count
  const visibleColumnsCount = columns.filter(col => col.visible).length;

  // Add username search handler
  const handleUsernameSearch = async (value: string) => {
    if (value && value.length > 0) {
      setUsernameLoading(true);
      try {
        const results = await userService.getSearchSuggestionsByType(value, 'username');
        setUsernameSuggestions(results.map(user => typeof user === 'string' ? user : user.username));
      } catch (error) {
        console.error('Error fetching username suggestions:', error);
        setUsernameSuggestions([]);
      } finally {
        setUsernameLoading(false);
      }
    } else {
      setUsernameSuggestions([]);
    }
  };

  // Add username change handler
  const handleUsernameChange = (newValue: string | null) => {
    setParams(prev => ({
      ...prev,
      username: newValue || undefined,
      page: 0
    }));
  };

  const isMobile = false; // Assuming isMobile is not provided in the original code

  return (
    <Box>
      {/* Main Content */}
      <Paper 
        elevation={0}
        sx={{ 
          border: '1px solid',
          borderColor: 'divider',
          borderRadius: 2,
          overflow: 'hidden',
          height: { xs: 'calc(100vh - 120px)', sm: 'auto' }
        }}
      >
        {/* Header Section */}
        <Box 
          sx={{ 
            p: { xs: 2, sm: 3 },
            borderBottom: '1px solid',
            borderColor: 'divider',
            bgcolor: alpha(theme.palette.primary.main, 0.04),
          }}
        >
          <Stack 
            direction={{ xs: 'column', sm: 'row' }} 
            spacing={{ xs: 2, sm: 2 }} 
            alignItems={{ xs: 'stretch', sm: 'center' }}
            justifyContent="space-between"
          >
            <Autocomplete
              freeSolo
              options={usernameSuggestions}
              getOptionLabel={option => typeof option === 'string' ? option : ''}
              value={selectedUsername}
              loading={usernameLoading}
              onInputChange={async (_, value) => {
                await handleUsernameSearch(value);
              }}
              onChange={(_, newValue) => {
                handleUsernameChange(newValue);
              }}
              PopperComponent={CustomPopper}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={t('users.fields.username')}
                  size="small"
                  InputProps={{
                    ...params.InputProps,
                    startAdornment: (
                      <InputAdornment position="start">
                        <SearchIcon color="action" />
                      </InputAdornment>
                    ),
                    endAdornment: (
                      <>
                        {usernameLoading ? <CircularProgress color="inherit" size={16} /> : null}
                        {params.InputProps.endAdornment}
                      </>
                    )
                  }}
                  sx={{
                    width: { xs: '100%', sm: 300 },
                    '& .MuiOutlinedInput-root': {
                      '& fieldset': {
                        borderColor: 'divider',
                      },
                      '&:hover fieldset': {
                        borderColor: 'primary.main',
                      },
                      '&.Mui-focused fieldset': {
                        borderColor: 'primary.main',
                      },
                    },
                  }}
                />
              )}
            />
            
            <Stack 
              direction={{ xs: 'column', sm: 'row' }} 
              spacing={{ xs: 1, sm: 2 }}
              width={{ xs: '100%', sm: 'auto' }}
            >
              <Tooltip title={t('common.columns')}>
                <Button
                  onClick={handleColumnMenuOpen}
                  size="small"
                  startIcon={<ViewColumnIcon />}
                  variant="outlined"
                  fullWidth={isMobile}
                  sx={{
                    height: { xs: 36, sm: 42 },
                    borderRadius: '8px',
                    padding: { xs: '6px 12px', sm: '8px 16px' },
                    fontWeight: 500,
                    transition: 'all 0.3s ease',
                    '&:hover': {
                      transform: 'translateY(-2px)',
                      backgroundColor: 'action.hover'
                    }
                  }}
                >
                  {t('common.columns')} ({visibleColumnsCount})
                </Button>
              </Tooltip>

              {/* Nút Delete hàng loạt */}
              {canDelete && (
                <Tooltip title={selected.length === 0 ? t('users.selectToDelete') : t('common.delete')}>
                    <Button
                      onClick={() => handleDelete()}
                      size="small"
                      startIcon={<DeleteIcon />}
                      variant="outlined"
                      color="error"
                      disabled={selected.length === 0}
                      fullWidth={isMobile}
                      sx={{
                        height: { xs: 36, sm: 42 },
                        borderRadius: '8px',
                        padding: { xs: '6px 12px', sm: '8px 16px' },
                        fontWeight: 500,
                        transition: 'all 0.3s ease',
                        ml: 1
                      }}
                    >
                      {t('common.delete')}
                    </Button>
                </Tooltip>
              )}

              <Tooltip title={t('common.advancedFilter')}>
                <Button
                  onClick={() => setIsFilterOpen(true)}
                  size="small"
                  startIcon={<FilterListIcon />}
                  variant="contained"
                  fullWidth={isMobile}
                  disableElevation
                  sx={{
                    height: { xs: 36, sm: 42 },
                    background: 'linear-gradient(45deg, #6b97ff 30%, #3d78ff 90%)',
                    boxShadow: '0 3px 5px 2px rgba(59, 120, 255, .3)',
                    borderRadius: '8px',
                    padding: { xs: '6px 12px', sm: '8px 16px' },
                    color: '#ffffff',
                    fontWeight: 500,
                    transition: 'all 0.3s ease',
                    '&:hover': {
                      transform: 'translateY(-2px)',
                      boxShadow: '0 4px 8px 2px rgba(59, 120, 255, .4)',
                      background: 'linear-gradient(45deg, #3d78ff 30%, #2a61e6 90%)'
                    }
                  }}
                >
                  {t('common.filter')}
                </Button>
              </Tooltip>
             
              <SortMenu 
                onSort={handleSortMenu}
                translationPrefix="users.fields"
                buttonLabel="common.sort"
                activeSortsLabel="common.activeSorts"
                availableFieldsLabel="common.availableFields"
                availableFields={[
                  'username',
                  'email',
                  'role',
                  'status',
                  'createdAt'
                ]}
              />

              <Tooltip title={!canCreate ? t('errors.insufficientPermissions') : ''}>
                  <Button 
                    variant="contained" 
                    color="primary" 
                    startIcon={<AddIcon sx={{ color: 'white', fontSize: 20 }} />}
                    onClick={handleCreateUser}
                    disabled={!canCreate}
                    fullWidth={isMobile}
                    sx={{ 
                      height: { xs: 36, sm: 42 },
                      px: { xs: 2, sm: 2.5 },
                      borderRadius: 1.5,
                      background: 'linear-gradient(120deg, #3a7bd5 0%, #2456a8 100%)',
                      boxShadow: '0 3px 8px rgba(58, 123, 213, 0.3)',
                      border: 'none',
                      fontWeight: 600,
                      textTransform: 'none',
                      fontSize: { xs: '0.875rem', sm: '0.95rem' },
                      letterSpacing: '0.3px',
                      transition: 'all 0.3s ease',
                      '&:hover': {
                        background: 'linear-gradient(120deg, #2d6bc5 0%, #1a4990 100%)',
                        boxShadow: '0 4px 12px rgba(58, 123, 213, 0.4)',
                        transform: 'translateY(-2px)'
                      }
                    }}
                  >
                    {t('users.create')}
                  </Button>
              </Tooltip>
            </Stack>
          </Stack>
        </Box>

        {/* Table Section */}
        <TableContainer sx={{ 
          maxHeight: { xs: 'calc(100vh - 280px)', sm: 'calc(100vh - 300px)' },
          overflowX: 'auto'
        }}>
          <Table stickyHeader size={isMobile ? "small" : "medium"}>
            <TableHead>
              <TableRow>
                <TableCell padding="checkbox">
                  <Checkbox
                    indeterminate={selected.length > 0 && isValidData(data) && selected.length < data.data.length}
                    checked={isValidData(data) && data.data.length > 0 && selected.length === data.data.length}
                    onChange={handleSelectAll}
                    size={isMobile ? "small" : "medium"}
                  />
                </TableCell>
                {columns.map((column) => column.visible && (
                  <TableHeaderCell 
                    key={column.id}
                    field={column.id} 
                    label={column.label} 
                    onClick={column.sortable ? handleColumnSort : undefined}
                    sortable={column.sortable}
                  />
                ))}
                <TableHeaderCell field="actions" label={t('common.actions')} sortable={false} align="right" />
              </TableRow>
            </TableHead>
            <TableBody>
              {renderTableRows()}
            </TableBody>
          </Table>
        </TableContainer>

        {/* Pagination Footer */}
        {(() => {
          const page = params.page ?? 0;
          const limit = params.limit ?? 10;
          return (
            <Box
              sx={{
                display: 'flex',
                flexDirection: { xs: 'column', sm: 'row' },
                alignItems: { xs: 'stretch', sm: 'center' },
                justifyContent: 'space-between',
                gap: { xs: 2, sm: 0 },
                px: { xs: 1, sm: 2 },
                py: { xs: 2, sm: 1.5 },
                borderTop: '1px solid',
                borderColor: 'divider',
                bgcolor: alpha(theme.palette.primary.main, 0.02),
              }}
            >
              {/* Left: Rows per page and data count */}
              <Stack direction="row" alignItems="center" spacing={2}>
                <TextField
                  select
                  size="small"
                  value={limit}
                  onChange={handleChangeRowsPerPage}
                  sx={{ width: 70 }}
                >
                  {[5, 10, 25, 50].map((option) => (
                    <MenuItem key={option} value={option}>
                      {option}
                    </MenuItem>
                  ))}
                </TextField>
                <Typography variant="body2" sx={{ display: { xs: 'none', sm: 'block' } }}>
                  {t('common.show')} {`${page * limit + 1} - ${Math.min((page + 1) * limit, isValidData(data) ? data.total : 0)} / ${isValidData(data) ? data.total : 0} ${t('common.data')}`}
                </Typography>
                <Typography variant="body2" sx={{ display: { xs: 'block', sm: 'none' } }}>
                  {`${page * limit + 1}-${Math.min((page + 1) * limit, isValidData(data) ? data.total : 0)}/${isValidData(data) ? data.total : 0}`}
                </Typography>
              </Stack>

              {/* Right: Pagination */}
              <Pagination
                count={Math.ceil((isValidData(data) ? data.total : 0) / limit)}
                page={page + 1}
                onChange={(_, value) => setParams(prev => ({ ...prev, page: value - 1 }))}
                color="primary"
                shape="rounded"
                showFirstButton={!isMobile}
                showLastButton={!isMobile}
                size={isMobile ? "small" : "medium"}
              />
            </Box>
          );
        })()}
      </Paper>

      {/* Confirm Dialog for delete */}
      <ConfirmDialog
        open={confirmDialog.open}
        title={confirmDialog.multiple ? t('users.deleteMultipleTitle') : t('users.deleteTitle')}
        message={confirmDialog.multiple 
          ? t('users.confirmDeleteMultiple', { count: selected.length }) 
          : t('users.confirmDelete')}
        onConfirm={confirmDelete}
        onCancel={cancelDelete}
        confirmText={t('common.delete')}
        cancelText={t('common.cancel')}
        confirmColor="error"
      />

      {/*  Filter Dialog */}
      <Filter
        open={isFilterOpen}
        onClose={() => setIsFilterOpen(false)}
        filterOptions={userFilterOptions}
        activeFilters={activeFilters}
        onApply={handleFilterApply}
        onClear={handleFilterClear}
        defaultFilters={userFilterOptions}
      />

      {/* Column Menu */}
      <MuiMenu
        anchorEl={columnMenuAnchor}
        open={Boolean(columnMenuAnchor)}
        onClose={handleColumnMenuClose}
        PaperProps={{
          sx: {
            width: 280,
            maxHeight: 400,
            mt: 1
          }
        }}
      >
        <Box sx={{ p: 1, borderBottom: '1px solid', borderColor: 'divider' }}>
          <TextField
            size="small"
            placeholder={t('common.search')}
            value={columnSearch}
            onChange={(e) => setColumnSearch(e.target.value)}
            fullWidth
            InputProps={{
              startAdornment: (
                <InputAdornment position="start">
                  <SearchIcon fontSize="small" />
                </InputAdornment>
              )
            }}
          />
        </Box>
        <Box sx={{ maxHeight: 300, overflow: 'auto' }}>
          {filteredColumns.map((column) => (
            <MenuItem
              key={column.id}
              onClick={() => handleColumnVisibilityToggle(column.id)}
              sx={{
                py: 1,
                px: 2,
                display: 'flex',
                alignItems: 'center',
                gap: 1
              }}
            >
              <Checkbox
                checked={column.visible}
                size="small"
              />
              <Typography variant="body2">
                {column.label}
              </Typography>
            </MenuItem>
          ))}
        </Box>
      </MuiMenu>
    </Box>
  );
};

export default UserList;

