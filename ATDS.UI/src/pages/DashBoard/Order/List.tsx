
import ConfirmDialog from '@/components/ConfirmDialog/ConfirmDialog';
import SortMenu from '@/components/SortMenu/SortMenu';
import { Menu } from '@/config/constant/feature';
import { PermissionAction } from '@/config/enum/PermissionAction';
import { usePermissions } from '@/hooks/usePermissions';
import Filter from '@/pages/DashBoard/Order/filter';
import { orderService } from '@/services/order.service';
import { ActiveFilter, FilterOption, SortField } from '@/types/common.type';
import { Order, OrderListResponse, OrderParams } from '@/types/order.type';
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
  Box,
  Button,
  Checkbox,
  Chip,
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
import { useQuery, useQueryClient } from '@tanstack/react-query';
import React, { memo, useCallback, useEffect, useMemo, useState } from 'react';
import { useTranslation } from 'react-i18next';
import { useLocation, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

// Constants for column management
const STORAGE_KEY = 'orderTableColumns';
const DEFAULT_VISIBLE_COLUMNS = ['name', 'exchangeRateUsdVndBuy', 'exchangeRateUsdVndSell', 'transportMethod', 'packingMethod', 'weightPerContainer', 'estimatedTotalContainers', 'estimatedTotalBookings', 'bookingNoCode', 'packingDate', 'yardIn', 'truckPlate', 'containerNo', 'sealNo', 'supplierName', 'transportCompanyName', 'quantity', 'coatingCompanyName', 'coatedQuantity', 'productUnitPrice', 'coatedProductUnitPrice', 'transportUnitPrice', 'invoice', 'packingList', 'certificateOfQuality', 'shippingInstruction', 'verifiedGrossMass', 'timberPackingDeclaration', 'weighingCostAtFactory', 'liftingCost', 'createdAt', 'status'];

// Column configuration type
interface ColumnConfig {
  id: keyof Order | 'actions';
  label: string;
  visible: boolean;
  sortable?: boolean;
}

// Helper function to check if data is valid
const isValidData = (data: OrderListResponse | undefined): data is OrderListResponse => {
  return !!data && Array.isArray(data.data);
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

// Tﾃ｡ch logic x盻ｭ lﾃｽ filter values thﾃnh custom hook
const useFilterValues = (open: boolean, activeFilters: ActiveFilter[], defaultFilters: FilterOption[]) => {
  const [filterValues, setFilterValues] = useState<Record<string, string[]>>({});

  useEffect(() => {
    if (open) {
      const initialValues = defaultFilters.reduce((acc, filter) => ({
        ...acc,
        [filter.id]: filter.defaultValue ? [filter.defaultValue] : []
      }), {});

      const activeValues = activeFilters.reduce((acc, filter) => ({
        ...acc,
        [filter.field]: [filter.value]
      }), {});

      setFilterValues({ ...initialValues, ...activeValues });
    }
  }, [open, activeFilters, defaultFilters]);

  return [filterValues, setFilterValues] as const;
};

// Tﾃ｡ch riﾃｪng component CustomPagination
const CustomPagination = memo(({
  page,
  totalPages,
  onPageChange,
  isFetching
}: {
  page: number;
  totalPages: number;
  onPageChange: (page: number) => void;
  isFetching: boolean;
}) => {
  const handleChange = useCallback((_: React.ChangeEvent<unknown>, value: number) => {
    onPageChange(value);
  }, [onPageChange]);

  return (
    <Pagination
      count={totalPages}
      page={page}
      onChange={handleChange}
      color="primary"
      shape="rounded"
      showFirstButton
      showLastButton
      disabled={isFetching}
      sx={{
        '& .MuiPaginationItem-root': {
          transition: 'all 0.2s ease',
          '&:hover': {
            transform: 'translateY(-2px)'
          }
        }
      }}
    />
  );
});

CustomPagination.displayName = 'CustomPagination';

// Tﾃ｡ch riﾃｪng component PaginationFooter
const PaginationFooter = memo(({
  paginationInfo,
  isFetching,
  isMobile,
  rowsPerPageOptions,
  onPageChange,
  onRowsPerPageChange,
  t
}: {
  paginationInfo: {
    page: number;
    size: number;
    total: number;
    start: number;
    end: number;
    totalPages: number;
  };
  isFetching: boolean;
  isMobile: boolean;
  rowsPerPageOptions: number[];
  onPageChange: (page: number) => void;
  onRowsPerPageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  t: (key: string) => string;
}) => {
  const theme = useTheme();

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
        position: 'relative',
        minHeight: '64px'
      }}
    >
      <Stack
        direction="row"
        alignItems="center"
        spacing={2}
        sx={{ position: 'relative', zIndex: 2 }}
      >
        <TextField
          select
          size="small"
          value={paginationInfo.size}
          onChange={onRowsPerPageChange}
          sx={{
            width: 70,
            '& .MuiSelect-select': {
              py: 1
            }
          }}
          disabled={isFetching}
        >
          {rowsPerPageOptions.map((option) => (
            <MenuItem key={option} value={option}>
              {option}
            </MenuItem>
          ))}
        </TextField>
        <Typography
          variant="body2"
          sx={{
            display: { xs: 'none', sm: 'block' },
            color: isFetching ? 'text.disabled' : 'text.primary',
            transition: 'color 0.2s ease'
          }}
        >
          {t('common.show')} {`${paginationInfo.start} - ${paginationInfo.end} / ${paginationInfo.total} ${t('common.data')}`}
        </Typography>
        <Typography
          variant="body2"
          sx={{
            display: { xs: 'block', sm: 'none' },
            color: isFetching ? 'text.disabled' : 'text.primary',
            transition: 'color 0.2s ease'
          }}
        >
          {`${paginationInfo.start}-${paginationInfo.end}/${paginationInfo.total}`}
        </Typography>
      </Stack>

      <Box sx={{ position: 'relative', zIndex: 2 }}>
        <CustomPagination
          page={paginationInfo.page}
          totalPages={paginationInfo.totalPages}
          onPageChange={onPageChange}
          isFetching={isFetching}
        />
      </Box>
    </Box>
  );
}, (prevProps, nextProps) => {
  return (
    prevProps.paginationInfo.page === nextProps.paginationInfo.page &&
    prevProps.paginationInfo.size === nextProps.paginationInfo.size &&
    prevProps.paginationInfo.total === nextProps.paginationInfo.total &&
    prevProps.isFetching === nextProps.isFetching &&
    prevProps.isMobile === nextProps.isMobile
  );
});

PaginationFooter.displayName = 'PaginationFooter';

const OrderList: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { hasPermission } = usePermissions();
  const theme = useTheme();
  const queryClient = useQueryClient();
  const location = useLocation();
  // Permission checks
  const canCreate = hasPermission(Menu.ORDERS, PermissionAction.CREATE);
  const canUpdate = hasPermission(Menu.ORDERS, PermissionAction.UPDATE);
  const canDelete = hasPermission(Menu.ORDERS, PermissionAction.DELETE);

  // Get page from URL or localStorage
  const getInitialPage = () => {
    const searchParams = new URLSearchParams(location.search);
    const pageFromUrl = searchParams.get('page');
    if (pageFromUrl) {
      const page = Number(pageFromUrl);
      localStorage.setItem('ordersCurrentPage', page.toString());
      return page;
    }
    return Number(localStorage.getItem('ordersCurrentPage')) || 1;
  };

  // Pagination and other states
  const [params, setParams] = useState<OrderParams>({
    page: getInitialPage(),
    size: 10,
    search: [],
  });

  const [selected, setSelected] = useState<number[]>([]);
  const [confirmDialog, setConfirmDialog] = useState({
    open: false,
    orderId: 1,
    multiple: false
  });

  const [_, setFilterValues] = useFilterValues(false, [], []);

  // Advanced filter states
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [activeFilters, setActiveFilters] = useState<ActiveFilter[]>([]);

  // Add sort state
  const [sortConfig, setSortConfig] = useState<{
    field: string;
    direction: 'asc' | 'desc';
  }>({
    field: 'id',

    direction: 'asc'
  });
  // Column visibility state with localStorage persistence
  const [columns, setColumns] = useState<ColumnConfig[]>(() => {
    const savedColumns = localStorage.getItem(STORAGE_KEY);
    if (savedColumns) {
      return JSON.parse(savedColumns);
    }

    // Default columns configuration
    return [
      { id: 'id', label: t('orders.fields.id'), visible: true, sortable: true  },
      { id: 'name', label: t('orders.fields.name'), visible: true, sortable: true },
      { id: 'exchangeRateUsdVndBuy', label: t('orders.fields.exchangeRateUsdVndBuy'), visible: true, sortable: true },
      { id: 'exchangeRateUsdVndSell', label: t('orders.fields.exchangeRateUsdVndSell'), visible: true, sortable: true },
      { id: 'transportMethod', label: t('orders.fields.transportMethod'), visible: true, sortable: true },
      { id: 'packingMethod', label: t('orders.fields.packingMethod'), visible: true, sortable: true },
      { id: 'weightPerContainer', label: t('orders.fields.weightPerContainer'), visible: true, sortable: true },
      { id: 'estimatedTotalContainers', label: t('orders.fields.estimatedTotalContainers'), visible: true, sortable: true },
      { id: 'estimatedTotalBookings', label: t('orders.fields.estimatedTotalBookings'), visible: true, sortable: true },
      { id: 'bookingNoCode', label: t('orders.fields.bookingNoCode'), visible: true, sortable: true },
      { id: 'packingDate', label: t('orders.fields.packingDate'), visible: true, sortable: true },
      { id: 'yardIn', label: t('orders.fields.yardIn'), visible: true, sortable: true },
      { id: 'truckPlate', label: t('orders.fields.truckPlate'), visible: true, sortable: true },
      { id: 'containerNo', label: t('orders.fields.containerNo'), visible: true, sortable: true },
      { id: 'sealNo', label: t('orders.fields.sealNo'), visible: true, sortable: true },
      { id: 'supplierName', label: t('orders.fields.supplierName'), visible: true, sortable: true },
      { id: 'transportCompanyName', label: t('orders.fields.transportCompanyName'), visible: true, sortable: true },
      { id: 'quantity', label: t('orders.fields.quantity'), visible: true, sortable: true },
      { id: 'coatingCompanyName', label: t('orders.fields.coatingCompanyName'), visible: true, sortable: true },
      { id: 'coatedQuantity', label: t('orders.fields.coatedQuantity'), visible: true, sortable: true },
      { id: 'productUnitPrice', label: t('orders.fields.productUnitPrice'), visible: true, sortable: true },
      { id: 'coatedProductUnitPrice', label: t('orders.fields.coatedProductUnitPrice'), visible: true, sortable: true },
      { id: 'transportUnitPrice', label: t('orders.fields.transportUnitPrice'), visible: true, sortable: true },
      { id: 'invoice', label: t('orders.fields.invoice'), visible: true, sortable: true },
      { id: 'packingList', label: t('orders.fields.packingList'), visible: true, sortable: true },
      { id: 'certificateOfQuality', label: t('orders.fields.certificateOfQuality'), visible: true, sortable: true },
      { id: 'shippingInstruction', label: t('orders.fields.shippingInstruction'), visible: true, sortable: true },
      { id: 'verifiedGrossMass', label: t('orders.fields.verifiedGrossMass'), visible: true, sortable: true },
      { id: 'timberPackingDeclaration', label: t('orders.fields.timberPackingDeclaration'), visible: true, sortable: true },
      { id: 'weighingCostAtFactory', label: t('orders.fields.weighingCostAtFactory'), visible: true, sortable: true },
      { id: 'liftingCost', label: t('orders.fields.liftingCost'), visible: true, sortable: true },
      { id: 'createdAt', label: t('orders.fields.createdAt'), visible: true, sortable: true },
      { id: 'updatedAt', label: t('orders.fields.updatedAt'), visible: true, sortable: true },
      { id: 'status', label: t('orders.fields.status'), visible: true, sortable: true },
      { id: 'createdUser', label: t('orders.fields.createdUser'), visible: true, sortable: true },
      { id: 'lastUpdateUser', label: t('orders.fields.lastUpdateUser'), visible: true, sortable: true },
      { id: 'lastUpdateProgram', label: t('orders.fields.lastUpdateProgram'), visible: true, sortable: true },

    ].map(col => ({
      ...col,
      visible: DEFAULT_VISIBLE_COLUMNS.includes(col.id)
    }));
  });

  // Save columns state to localStorage whenever it changes
  useEffect(() => {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(columns));
  }, [columns]);

  // Column menu state
  const [columnMenuAnchor, setColumnMenuAnchor] = useState<null | HTMLElement>(null);
  const [columnSearch, setColumnSearch] = useState('');

  // Filter columns based on search
  const filteredColumns = columns.filter(column =>
    column.label.toLowerCase().includes(columnSearch.toLowerCase())
  );

  // State ﾄ黛ｻ・lﾆｰu tr盻ｯ d盻ｯ li盻㎡ ﾄ妥｣ t蘯｣i
  const [cachedData, setCachedData] = useState<Record<string, Order[]>>({});
  const [totalItems, setTotalItems] = useState(0);

  // State ﾄ黛ｻ・lﾆｰu tr盻ｯ d盻ｯ li盻㎡ hi盻ハ th盻・hi盻㌻ t蘯｡i
  const [displayData, setDisplayData] = useState<Order[]>([]);

  const [name, setName] = useState('');
  // Effect to handle URL changes and force reload
  useEffect(() => {
    const searchParams = new URLSearchParams(location.search);
    const pageFromUrl = searchParams.get('page');
    const forceReload = location.state?.forceReload;

    if (pageFromUrl) {
      const page = Number(pageFromUrl);
      setParams(prev => ({ ...prev, page }));
      localStorage.setItem('ordersCurrentPage', page.toString());
    }

    // If force reload is true, refetch the data
    if (forceReload) {
      queryClient.invalidateQueries({
        queryKey: ['orders'],
        refetchType: 'all'
      });
      // Clear the force reload state
      navigate(location.pathname + location.search, {
        replace: true,
        state: {}
      });
    }
  }, [location.search, location.state, queryClient, navigate]);

  // T盻訴 ﾆｰu query options
  const { data, isLoading, isFetching, refetch } = useQuery<OrderListResponse>({
    queryKey: ['order', params],
    queryFn: async () => {
      try {
        const result = await orderService.getOrders(params);
        return result;
      } catch (error) {
        toast.error(t('errors.fetchFailed'));
        return { data: [], total: 0, page: 0, size: 10 };
      }
    },
    refetchOnWindowFocus: false,
    enabled: true,
    refetchOnMount: true,
    refetchOnReconnect: true,
    staleTime: 30000,
    placeholderData: (previousData) => previousData, // Gi盻ｯ l蘯｡i d盻ｯ li盻㎡ cﾅｩ trong khi ﾄ疎ng t蘯｣i d盻ｯ li盻㎡ m盻嬖
  });

  // Effect ﾄ黛ｻ・c蘯ｭp nh蘯ｭt displayData
  useEffect(() => {
    if (isValidData(data)) {
      setDisplayData(data.data);
    }
  }, [data]);

  // Memoize pagination calculations
  const paginationInfo = useMemo(() => {
    const page = params.page ?? 1;
    const size = params.size ?? 10;
    const total = data?.total ?? 0;
    const start = total > 0 ? (page - 1) * size + 1 : 0;
    const end = Math.min(page * size, total);
    const totalPages = Math.ceil(total / size);

    return {
      page,
      size,
      total,
      start,
      end,
      totalPages
    };
  }, [params.page, params.size, data?.total]);

  // Memoize rows per page options
  const rowsPerPageOptions = useMemo(() => [5, 10, 25, 50], []);

  // Prefetch next page data
  const prefetchNextPage = useCallback((nextPage: number) => {
    const nextPageParams: OrderParams = {
      ...params,
      page: nextPage
    };

    queryClient.prefetchQuery({
      queryKey: ['order', nextPageParams],
      queryFn: async () => {
        try {
          const result = await orderService.getOrders(nextPageParams);
          return result;
        } catch (error) {
          console.error('Prefetch error:', error);
          return { data: [], total: 0, page: 0, size: 10 };
        }
      }
    });
  }, [params, queryClient]);

  // Handle filter changes
  const handleFilterApply = useCallback((filters: ActiveFilter[]) => {
    setActiveFilters(filters);

    // Reset relevant params
    const newParams: OrderParams = {
      ...params,
      page: 1,
      name: '',
      status: 1,
    };

    filters.forEach(filter => {
      if (filter.field in newParams) {
        const key = filter.field as keyof OrderParams;
        if (key === 'status') {
          newParams[key] = Number(filter.value);
        } else {
          newParams[key] = filter.value as any;
        }
      }
    });

    // Clear cached data when filters change
    setCachedData({});
    setParams(newParams);
  }, [params]);

  // Prefetch next page when current page data is loaded
  useEffect(() => {
    const currentPage = params.page ?? 1;
    if (data && currentPage < paginationInfo.totalPages && !isFetching) {
      const nextPage = currentPage + 1;
      // Only prefetch if we don't already have the data cached
      if (!cachedData[String(nextPage)]) {
        prefetchNextPage(nextPage);
      }
    }
  }, [data, params.page, paginationInfo.totalPages, prefetchNextPage, isFetching, cachedData]);

  // T盻訴 ﾆｰu handlePageChange
  const handlePageChange = useCallback((newPage: number) => {
    // Lﾆｰu l蘯｡i trang hi盻㌻ t蘯｡i vﾃo localStorage
    localStorage.setItem('ordersCurrentPage', newPage.toString());

    // C蘯ｭp nh蘯ｭt URL v盻嬖 s盻・trang m盻嬖
    navigate(`/dashboard/orders?page=${newPage}`, { replace: true });

    // C蘯ｭp nh蘯ｭt params
    setParams(prev => ({ ...prev, page: newPage }));
  }, [navigate]);

  // Effect ﾄ黛ｻ・c蘯ｭp nh蘯ｭt displayData khi cﾃｳ d盻ｯ li盻㎡ m盻嬖
  useEffect(() => {
    if (isValidData(data)) {
      setDisplayData(data.data);
      // Cache d盻ｯ li盻㎡ m盻嬖
      setCachedData(prev => ({
        ...prev,
        [String(params.page)]: data.data
      }));
    }
  }, [data, params.page]);

  // Handle rows per page change
  const handleChangeRowsPerPage = useCallback((event: React.ChangeEvent<HTMLInputElement>) => {
    const newSize = parseInt(event.target.value, 10);

    // Gi盻ｯ l蘯｡i d盻ｯ li盻㎡ hi盻㌻ t蘯｡i
    const currentDisplayData = displayData;

    // Update params
    setParams(prev => ({
      ...prev,
      size: newSize,
      page: 1
    }));

    // Clear cache
    setCachedData({});

    // Update URL
    navigate('/dashboard/orders?page=1', { replace: true });

    // Gi盻ｯ l蘯｡i d盻ｯ li盻㎡ cho ﾄ黛ｺｿn khi cﾃｳ d盻ｯ li盻㎡ m盻嬖
    if (currentDisplayData.length > 0) {
      setDisplayData(currentDisplayData);
    }
  }, [navigate, displayData]);

  // Handle delete order(s)
  const handleDelete = async (orderId?: number) => {
    if (orderId) {
      // Single delete
      setConfirmDialog({
        open: true,
        orderId,
        multiple: false
      });
    } else if (selected.length > 0) {
      // Multiple delete
      setConfirmDialog({
        open: true,
        orderId: 1,
        multiple: true
      });
    }
  };

  // Confirm delete action
  const confirmDelete = async () => {
    try {
      if (confirmDialog.multiple) {
        await orderService.deleteOrders(selected);
        toast.success(t('orders.deleteMultipleSuccess'));
        setSelected([]);
      } else {
        // Delete single order
        await orderService.deleteOrder(confirmDialog.orderId);
        toast.success(t('orders.deleteSuccess'));
      }
      refetch();
    } catch (error) {
      toast.error(t('errors.deleteFailed'));
    } finally {
      setConfirmDialog({
        open: false,
        orderId: 1,
        multiple: false
      });
    }
  };

  // Cancel delete action
  const cancelDelete = () => {
    setConfirmDialog({
      open: false,
      orderId: 1,
      multiple: false
    });
  };

  // Navigate to create order page
  const handleCreateOrder = () => {
    navigate('/dashboard/orders/create');
  };

  // Navigate to edit order page
  const handleEditOrder = (orderId: number) => {
    navigate(`/dashboard/orders/edit/${orderId}`);
  };

  // Navigate to view order page
  const handleViewOrder = (orderId: number) => {
    navigate(`/dashboard/orders/view/${orderId}`);
  };

  // Calculate status chip color
  const getStatusColor = (status: boolean) => {
    return status ? 'success' : 'error';
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
  const handleSortMenu = useCallback((sortFields: SortField[]) => {
    console.log('sortFields', sortFields);
    setParams(prev => ({
      ...prev,
      sortFields,
      // Clear legacy sort params
      sortBy: undefined,
      sortOrder: undefined
    }));
  }, []);

  // Table header cell component
  const TableHeaderCell: React.FC<{
    field: string;
    label: string;
    sortable?: boolean;
    align?: 'left' | 'right' | 'center';
    onClick?: (field: string) => void;
  }> = ({ field, label, sortable = true, align = 'left', onClick }) => {
    return (
      <TableCell
        align={align}
        onClick={() => sortable && onClick?.(field)}
        sx={{
          cursor: sortable ? 'pointer' : 'default',
          orderSelect: 'none',
          bgcolor: 'grey.100',
          '&:hover': sortable ? {
            bgcolor: 'grey.200'
          } : {},
          transition: 'all 0.2s ease',
          padding: '16px',
          fontWeight: 600,
          position: 'sticky',
          top: 0,
          zIndex: 2,
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
        const newSelected = data.data.map(order => order.id);
        setSelected(newSelected);
        return;
      }
      setSelected([]);
    };

    // Handle select one row
  const handleSelectOne = (id: number) => {
    const selectedIndex = selected.indexOf(id);
    let newSelected: number[] = [];

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
  const isSelected = (id: number) => selected.indexOf(id) !== -1;

  // Render table rows with optimized loading
    const renderTableRows = () => {
      // Ch盻・hi盻ハ th盻・skeleton khi load trang ﾄ黛ｺｧu tiﾃｪn vﾃ khﾃｴng cﾃｳ d盻ｯ li盻㎡
      if (isLoading && params.page === 1 && displayData.length === 0) {
        return Array(params.size)
          .fill(0)
          .map((_, index) => (
            <TableRow key={`skeleton-${index}`}>
              <TableCell padding="checkbox">
                <Skeleton 
                  animation="wave" 
                  width={20} 
                  height={20} 
                  sx={{ 
                    transform: 'scale(1)',
                    transformOrigin: '0 0'
                  }} 
                />
              </TableCell>
              {columns.map((column) => column.visible && (
                <TableCell key={`skeleton-${column.id}`}>
                  <Skeleton 
                    animation="wave" 
                    width="80%" 
                    height={24}
                    sx={{ 
                      transform: 'scale(1)',
                      transformOrigin: '0 0'
                    }} 
                  />
                </TableCell>
              ))}
              <TableCell align="right">
                <Box sx={{ display: 'flex', justifyContent: 'flex-end', gap: 1 }}>
                  <Skeleton 
                    animation="wave" 
                    variant="circular" 
                    width={28} 
                    height={28}
                    sx={{ 
                      transform: 'scale(1)',
                      transformOrigin: '0 0'
                    }} 
                  />
                  <Skeleton 
                    animation="wave" 
                    variant="circular" 
                    width={28} 
                    height={28}
                    sx={{ 
                      transform: 'scale(1)',
                      transformOrigin: '0 0'
                    }} 
                  />
                </Box>
              </TableCell>
            </TableRow>
          ));
      }
  
      // N蘯ｿu khﾃｴng cﾃｳ d盻ｯ li盻㎡ hi盻ハ th盻・
      if (displayData.length === 0 && !isLoading) {
        return (
          <TableRow>
            <TableCell colSpan={columns.filter(col => col.visible).length + 2} align="center">
              {t('orders.noData')}
            </TableCell>
          </TableRow>
        );
      }
  
      // S盻ｭ d盻･ng displayData ﾄ黛ｻ・render
      return displayData.map((order: Order) => {
        const isItemSelected = isSelected(order.id);
        
        return (
          <TableRow 
            hover 
            key={order.id} 
            sx={{ 
              opacity: isFetching ? 0.7 : 1,
              position: 'relative',
              transition: 'opacity 0.2s ease'
            }}
            onClick={() => handleSelectOne(order.id)}
            selected={isItemSelected}
            role="checkbox"
            aria-checked={isItemSelected}
          >
            <TableCell padding="checkbox">
              <Checkbox
                checked={isItemSelected}
                onChange={() => handleSelectOne(order.id)}
                onClick={(e) => e.stopPropagation()}
              />
            </TableCell>
            {columns.map((column) => column.visible && (
              <TableCell key={column.id}>
                {column.id === 'status' ? (
                  <Chip 
                    label={t(`statuses.${order.status ? 'active' : 'inactive'}`)} 
                    color={getStatusColor(Boolean(order.status))}
                    size="small"
                  />
                ) : column.id === 'createdAt' ? (
                  formatDate(new Date(order.createdAt).toString())
                ) : column.id === 'id' ? (
                t(`${order.id}`)) : column.id === 'name' ? (
                t(`${order.name}`)) : column.id === 'exchangeRateUsdVndBuy' ? (
                t(`${order.exchangeRateUsdVndBuy}`)) : column.id === 'exchangeRateUsdVndSell' ? (
                t(`${order.exchangeRateUsdVndSell}`)) : column.id === 'transportMethod' ? (
                t(`${order.transportMethod}`)) : column.id === 'packingMethod' ? (
                t(`${order.packingMethod}`)) : column.id === 'weightPerContainer' ? (
                t(`${order.weightPerContainer}`)) : column.id === 'estimatedTotalContainers' ? (
                t(`${order.estimatedTotalContainers}`)) : column.id === 'estimatedTotalBookings' ? (
                t(`${order.estimatedTotalBookings}`)) : column.id === 'bookingNoCode' ? (
                t(`${order.bookingNoCode}`)) : column.id === 'packingDate' ? (
                t(`${order.packingDate}`)) : column.id === 'yardIn' ? (
                t(`${order.yardIn}`)) : column.id === 'truckPlate' ? (
                t(`${order.truckPlate}`)) : column.id === 'containerNo' ? (
                t(`${order.containerNo}`)) : column.id === 'sealNo' ? (
                t(`${order.sealNo}`)) : column.id === 'supplierName' ? (
                t(`${order.supplierName}`)) : column.id === 'transportCompanyName' ? (
                t(`${order.transportCompanyName}`)) : column.id === 'quantity' ? (
                t(`${order.quantity}`)) : column.id === 'coatingCompanyName' ? (
                t(`${order.coatingCompanyName}`)) : column.id === 'coatedQuantity' ? (
                t(`${order.coatedQuantity}`)) : column.id === 'productUnitPrice' ? (
                t(`${order.productUnitPrice}`)) : column.id === 'coatedProductUnitPrice' ? (
                t(`${order.coatedProductUnitPrice}`)) : column.id === 'transportUnitPrice' ? (
                t(`${order.transportUnitPrice}`)) : column.id === 'invoice' ? (
                t(`${order.invoice}`)) : column.id === 'packingList' ? (
                t(`${order.packingList}`)) : column.id === 'certificateOfQuality' ? (
                t(`${order.certificateOfQuality}`)) : column.id === 'shippingInstruction' ? (
                t(`${order.shippingInstruction}`)) : column.id === 'verifiedGrossMass' ? (
                t(`${order.verifiedGrossMass}`)) : column.id === 'timberPackingDeclaration' ? (
                t(`${order.timberPackingDeclaration}`)) : column.id === 'weighingCostAtFactory' ? (
                t(`${order.weighingCostAtFactory}`)) : column.id === 'liftingCost' ? (
                t(`${order.createdAt}`)) : column.id === 'updatedAt' ? (
                t(`${order.status}`)) : column.id === 'createdUser' ? (
                t(`${order.createdUser}`)) : column.id === 'lastUpdateUser' ? (
                t(`${order.lastUpdateUser}`)) : column.id === 'lastUpdateProgram' ? (
                t(`${order.lastUpdateProgram}`)
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
                      handleViewOrder(order.id);
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
                      handleEditOrder(order.id);
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
                      handleDelete(order.id);
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
        setFilterValues({});
        setParams((prev: OrderParams) => ({
          ...prev,
                             
          id: undefined,
          name: undefined,
          exchangeRateUsdVndBuy: undefined,
          exchangeRateUsdVndSell: undefined,
          transportMethod: undefined,
          packingMethod: undefined,
          weightPerContainer: undefined,
          estimatedTotalContainers: undefined,
          estimatedTotalBookings: undefined,
          bookingNoCode: undefined,
          packingDate: undefined,
          yardIn: undefined,
          truckPlate: undefined,
          containerNo: undefined,
          sealNo: undefined,
          supplierName: undefined,
          transportCompanyName: undefined,
          quantity: undefined,
          coatingCompanyName: undefined,
          coatedQuantity: undefined,
          productUnitPrice: undefined,
          coatedProductUnitPrice: undefined,
          transportUnitPrice: undefined,
          invoice: undefined,
          packingList: undefined,
          certificateOfQuality: undefined,
          shippingInstruction: undefined,
          verifiedGrossMass: undefined,
          timberPackingDeclaration: undefined,
          weighingCostAtFactory: undefined,
          liftingCost: undefined,
          createdAt: undefined,
          updatedAt: undefined,
          status: undefined,
          createdUser: undefined,
          lastUpdateUser: undefined,
          lastUpdateProgram: undefined,

          page: 1
        }));
      };

      // Filter options
        const orderFilterOptions: FilterOption[] = useMemo(() => {
          const baseFilters: FilterOption[] = [
          { id: 'id', label: t('orders.fields.id'), type: 'text' },
          { id: 'name', label: t('orders.fields.name'), type: 'text' },
          { id: 'exchangeRateUsdVndBuy', label: t('orders.fields.exchangeRateUsdVndBuy'), type: 'text' },
          { id: 'exchangeRateUsdVndSell', label: t('orders.fields.exchangeRateUsdVndSell'), type: 'text' },
          { id: 'transportMethod', label: t('orders.fields.transportMethod'), type: 'text' },
          { id: 'packingMethod', label: t('orders.fields.packingMethod'), type: 'text' },
          { id: 'weightPerContainer', label: t('orders.fields.weightPerContainer'), type: 'text' },
          { id: 'estimatedTotalContainers', label: t('orders.fields.estimatedTotalContainers'), type: 'text' },
          { id: 'estimatedTotalBookings', label: t('orders.fields.estimatedTotalBookings'), type: 'text' },
          { id: 'bookingNoCode', label: t('orders.fields.bookingNoCode'), type: 'text' },
          { id: 'packingDate', label: t('orders.fields.packingDate'), type: 'text' },
          { id: 'yardIn', label: t('orders.fields.yardIn'), type: 'text' },
          { id: 'truckPlate', label: t('orders.fields.truckPlate'), type: 'text' },
          { id: 'containerNo', label: t('orders.fields.containerNo'), type: 'text' },
          { id: 'sealNo', label: t('orders.fields.sealNo'), type: 'text' },
          { id: 'supplierName', label: t('orders.fields.supplierName'), type: 'text' },
          { id: 'transportCompanyName', label: t('orders.fields.transportCompanyName'), type: 'text' },
          { id: 'quantity', label: t('orders.fields.quantity'), type: 'text' },
          { id: 'coatingCompanyName', label: t('orders.fields.coatingCompanyName'), type: 'text' },
          { id: 'coatedQuantity', label: t('orders.fields.coatedQuantity'), type: 'text' },
          { id: 'productUnitPrice', label: t('orders.fields.productUnitPrice'), type: 'text' },
          { id: 'coatedProductUnitPrice', label: t('orders.fields.coatedProductUnitPrice'), type: 'text' },
          { id: 'transportUnitPrice', label: t('orders.fields.transportUnitPrice'), type: 'text' },
          { id: 'invoice', label: t('orders.fields.invoice'), type: 'text' },
          { id: 'packingList', label: t('orders.fields.packingList'), type: 'text' },
          { id: 'certificateOfQuality', label: t('orders.fields.certificateOfQuality'), type: 'text' },
          { id: 'shippingInstruction', label: t('orders.fields.shippingInstruction'), type: 'text' },
          { id: 'verifiedGrossMass', label: t('orders.fields.verifiedGrossMass'), type: 'text' },
          { id: 'timberPackingDeclaration', label: t('orders.fields.timberPackingDeclaration'), type: 'text' },
          { id: 'weighingCostAtFactory', label: t('orders.fields.weighingCostAtFactory'), type: 'text' },
          { id: 'liftingCost', label: t('orders.fields.liftingCost'), type: 'text' },
          { id: 'createdAt', label: t('orders.fields.createdAt'), type: 'text' },
          { id: 'updatedAt', label: t('orders.fields.updatedAt'), type: 'text' },
          { id: 'status', label: t('orders.fields.status'), type: 'text' },
          { id: 'createdUser', label: t('orders.fields.createdUser'), type: 'text' },
          { id: 'lastUpdateUser', label: t('orders.fields.lastUpdateUser'), type: 'text' },
          { id: 'lastUpdateProgram', label: t('orders.fields.lastUpdateProgram'), type: 'text' },
        ];

        // L盻皇 cﾃ｡c filter d盻ｱa trﾃｪn cﾃ｡c c盻冲 ﾄ疎ng hi盻ハ th盻・
        return baseFilters.filter(filter => {
        // Luﾃｴn hi盻ハ th盻・cﾃ｡c filter cﾆ｡ b蘯｣n
        if (['id','name','exchangeRateUsdVndBuy','exchangeRateUsdVndSell','transportMethod','packingMethod','weightPerContainer','estimatedTotalContainers','estimatedTotalBookings','bookingNoCode','packingDate','yardIn','truckPlate','containerNo','sealNo','supplierName','transportCompanyName','quantity','coatingCompanyName','coatedQuantity','productUnitPrice','coatedProductUnitPrice','transportUnitPrice','invoice','packingList','certificateOfQuality','shippingInstruction','verifiedGrossMass','timberPackingDeclaration','weighingCostAtFactory','liftingCost','createdAt','updatedAt','status','createdUser','lastUpdateUser','lastUpdateProgram']
        .includes(filter.id)) {
          return true;
        }
        // Ch盻・hi盻ハ th盻・filter cho cﾃ｡c c盻冲 ﾄ疎ng ﾄ柁ｰ盻｣c hi盻ハ th盻・
        return columns.find(col => col.id === filter.id)?.visible;
      });
  }, [columns, t]);

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
  const totalColumnsCount = columns.length;

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
                  {t('common.columns')} ({visibleColumnsCount}/{totalColumnsCount})
                </Button>
              </Tooltip>

              {/* Nﾃｺt Delete hﾃng lo蘯｡t */}
              {canDelete && (
                <Tooltip title={selected.length === 0 ? t('orders.selectToDelete') : t('common.delete')}>
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
                    onClick={() => {
                      setIsFilterOpen(true)
                    }}
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
                  translationPrefix="orders.fields"
                  buttonLabel="common.sort"
                  activeSortsLabel="common.activeSorts"
                  availableFieldsLabel="common.availableFields"
                  availableFields={columns.map(col => col.id)}
                />
                <Tooltip title={!canCreate ? t('errors.insufficientPermissions') : ''}>
                  <Button 
                    variant="contained" 
                    color="primary" 
                    startIcon={<AddIcon sx={{ color: 'white', fontSize: 20 }} />}
                    onClick={handleCreateOrder}
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
                    {t('orders.create')}
                  </Button>
              </Tooltip>
            </Stack>
          </Stack>
        </Box>

        {/* Table Section with optimized rendering */}
        <TableContainer 
          sx={{ 
            maxHeight: { xs: 'calc(100vh - 280px)', sm: 'calc(100vh - 300px)' },
            overflowX: 'auto',
            '& .MuiTable-root': {
              minWidth: 1000,
            }
          }}
        >
          <Table stickyHeader size={isMobile ? "small" : "medium"}>
                      <TableHead>
                        <TableRow>
                          <TableCell 
                            padding="checkbox" 
                            sx={{ 
                              bgcolor: 'grey.100',
                              position: 'sticky',
                              top: 0,
                              zIndex: 2
                            }}
                          >
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
                          <TableHeaderCell 
                            field="actions" 
                            label={t('common.actions')} 
                            sortable={false} 
                            align="right"
                          />
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        {renderTableRows()}
                      </TableBody>
                    </Table>
        </TableContainer>

        {/* Pagination Footer with optimized rendering */}
        <PaginationFooter
          paginationInfo={paginationInfo}
          isFetching={isFetching}
          isMobile={isMobile}
          rowsPerPageOptions={rowsPerPageOptions}
          onPageChange={handlePageChange}
          onRowsPerPageChange={handleChangeRowsPerPage}
          t={t}
        />
      </Paper>

      {/* Confirm Dialog for delete */}
        <ConfirmDialog
          open={confirmDialog.open}
          title={confirmDialog.multiple ? t('orders.deleteMultipleTitle') : t('orders.deleteTitle')}
          message={confirmDialog.multiple 
            ? t('orders.confirmDeleteMultiple', { count: selected.length }) 
            : t('orders.confirmDelete')}
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
        activeFilters={activeFilters}
        onApply={handleFilterApply}
        onClear={handleFilterClear}
        defaultFilters={orderFilterOptions}
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
        {/* searching bar */}
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

export default OrderList;