import { useZodForm } from '@/hooks/useZodForm';
import orderService from '@/services/order.service.ts';
import { FormField } from '@/types/common.type';
import { OrderFormValues } from '@/types/order.type';
import { orderEditSchema, orderSchema } from '@/utils/validation/order.scheme';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import PersonIcon from '@mui/icons-material/Person';
import SaveIcon from '@mui/icons-material/Save';
import {
  Box,
  Button,
  Card,
  CardContent,
  CircularProgress,
  Divider,
  FormControl,
  InputAdornment,
  InputLabel,
  MenuItem,
  Select,
  TextField,
  Typography
} from '@mui/material';
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import React, { useEffect } from 'react';
import { Control, Controller, FieldErrors } from 'react-hook-form';
import { useTranslation } from 'react-i18next';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { toast } from 'react-toastify';
import { number } from 'zod';
import { formatDate } from '@/utils/datetime';

const orderFields: FormField<OrderFormValues>[] = [
    {
  name: 'name',
  label: 'common.name',
  type: 'text',
  required: false,
  icon: <PersonIcon color="action" />,
  placeholder: 'placeholders.name'
},
{
  name: 'exchangeRateUsdVndBuy',
  label: 'common.exchangeRateUsdVndBuy',
  type: 'number',
  required: false,
  placeholder: 'placeholders.exchangeRateUsdVndBuy'
},
{
  name: 'exchangeRateUsdVndSell',
  label: 'common.exchangeRateUsdVndSell',
  type: 'number',
  required: false,
  placeholder: 'placeholders.exchangeRateUsdVndSell'
},
{
  name: 'transportMethod',
  label: 'common.transportMethod',
  type: 'number',
  required: false,
  placeholder: 'placeholders.transportMethod'
},
{
  name: 'packingMethod',
  label: 'common.packingMethod',
  type: 'number',
  required: false,
  placeholder: 'placeholders.packingMethod'
},
{
  name: 'weightPerContainer',
  label: 'common.weightPerContainer',
  type: 'text',
  required: false,
  placeholder: 'placeholders.weightPerContainer'
},
{
  name: 'estimatedTotalContainers',
  label: 'common.estimatedTotalContainers',
  type: 'number',
  required: false,
  placeholder: 'placeholders.estimatedTotalContainers'
},
{
  name: 'estimatedTotalBookings',
  label: 'common.estimatedTotalBookings',
  type: 'number',
  required: false,
  placeholder: 'placeholders.estimatedTotalBookings'
},
{
  name: 'bookingNoCode',
  label: 'common.bookingNoCode',
  type: 'text',
  required: false,
  placeholder: 'placeholders.bookingNoCode'
},
{
  name: 'packingDate',
  label: 'common.packingDate',
  type: 'date',
  required: false,
  placeholder: 'placeholders.packingDate'
},
{
  name: 'yardIn',
  label: 'common.yardIn',
  type: 'text',
  required: false,
  placeholder: 'placeholders.yardIn'
},
{
  name: 'truckPlate',
  label: 'common.truckPlate',
  type: 'text',
  required: false,
  placeholder: 'placeholders.truckPlate'
},
{
  name: 'containerNo',
  label: 'common.containerNo',
  type: 'text',
  required: false,
  placeholder: 'placeholders.containerNo'
},
{
  name: 'sealNo',
  label: 'common.sealNo',
  type: 'text',
  required: false,
  placeholder: 'placeholders.sealNo'
},
{
  name: 'supplierName',
  label: 'common.supplierName',
  type: 'text',
  required: false,
  placeholder: 'placeholders.supplierName'
},
{
  name: 'transportCompanyName',
  label: 'common.transportCompanyName',
  type: 'text',
  required: false,
  placeholder: 'placeholders.transportCompanyName'
},
{
  name: 'quantity',
  label: 'common.quantity',
  type: 'number',
  required: false,
  placeholder: 'placeholders.quantity'
},
{
  name: 'coatingCompanyName',
  label: 'common.coatingCompanyName',
  type: 'text',
  required: false,
  placeholder: 'placeholders.coatingCompanyName'
},
{
  name: 'coatedQuantity',
  label: 'common.coatedQuantity',
  type: 'number',
  required: false,
  placeholder: 'placeholders.coatedQuantity'
},
{
  name: 'productUnitPrice',
  label: 'common.productUnitPrice',
  type: 'number',
  required: false,
  placeholder: 'placeholders.productUnitPrice'
},
{
  name: 'coatedProductUnitPrice',
  label: 'common.coatedProductUnitPrice',
  type: 'number',
  required: false,
  placeholder: 'placeholders.coatedProductUnitPrice'
},
{
  name: 'transportUnitPrice',
  label: 'common.transportUnitPrice',
  type: 'number',
  required: false,
  placeholder: 'placeholders.transportUnitPrice'
},
{
  name: 'invoice',
  label: 'common.invoice',
  type: 'text',
  required: false,
  placeholder: 'placeholders.invoice'
},
{
  name: 'packingList',
  label: 'common.packingList',
  type: 'text',
  required: false,
  placeholder: 'placeholders.packingList'
},
{
  name: 'certificateOfQuality',
  label: 'common.certificateOfQuality',
  type: 'text',
  required: false,
  placeholder: 'placeholders.certificateOfQuality'
},
{
  name: 'shippingInstruction',
  label: 'common.shippingInstruction',
  type: 'text',
  required: false,
  placeholder: 'placeholders.shippingInstruction'
},
{
  name: 'verifiedGrossMass',
  label: 'common.verifiedGrossMass',
  type: 'text',
  required: false,
  placeholder: 'placeholders.verifiedGrossMass'
},
{
  name: 'timberPackingDeclaration',
  label: 'common.timberPackingDeclaration',
  type: 'text',
  required: false,
  placeholder: 'placeholders.timberPackingDeclaration'
},
{
  name: 'weighingCostAtFactory',
  label: 'common.weighingCostAtFactory',
  type: 'number',
  required: false,
  placeholder: 'placeholders.weighingCostAtFactory'
},
{
  name: 'liftingCost',
  label: 'common.liftingCost',
  type: 'number',
  required: false,
  placeholder: 'placeholders.liftingCost'
},
{
  name: 'yukoFlag',
  label: 'common.status',
  type: 'select',
  required: false,
  options: [
    { value: 1, label: 'common.active' },
    { value: 0, label: 'common.inactive' }
  ]
}
];

const FormFieldRenderer: React.FC<{
  field: FormField<OrderFormValues>;
  control: Control<OrderFormValues>;
  errors: FieldErrors<OrderFormValues>;
  isViewMode: boolean;
}> = ({ field, control, errors, isViewMode }) => {
  const { t } = useTranslation();

  const renderField = () => {
    switch (field.type) {
      case 'select':
        return (
          <Controller
            name={field.name}
            control={control}
            render={({ field: { value, onChange, ...fieldProps } }) => (
              <FormControl fullWidth error={!!errors[field.name]}>
                <InputLabel>{t(field.label)}</InputLabel>
                <Select
                  {...fieldProps}
                  value={value}
                  label={t(field.label)}
                  onChange={(e) => {                    
                      onChange(e.target.value);
                  }}
                  startAdornment={
                    field.icon && (
                      <InputAdornment position="start">
                        {field.icon}
                      </InputAdornment>
                    )
                  }
                  disabled={isViewMode || field.disabled}
                >
                  {field.options?.map((option) => (
                    <MenuItem key={option.value} value={option.value}>
                      {t(option.label)}
                    </MenuItem>
                  ))}
                </Select>
                {errors[field.name] && (
                  <Typography color="error" variant="caption">
                    {errors[field.name]?.message}
                  </Typography>
                )}
              </FormControl>
            )}
          />
        );
    case 'date': 
            return (
              <Controller
                name={field.name}
                control={control}
                render={({ field: { value, onChange, ...fieldProps } }) => (
                  <TextField
                    {...fieldProps}
                    type="date" 
                    label={t(field.label)}
                    value={value || ''} // API có thể trả về null cho date
                    onChange={onChange}
                    fullWidth
                    error={!!errors[field.name]}
                    helperText={errors[field.name]?.message as string}
                    InputLabelProps={{
                      shrink: true, // Để label không bị chồng lên giá trị date
                    }}
                    InputProps={{
                      startAdornment: field.icon && (
                        <InputAdornment position="start">
                          {field.icon}
                        </InputAdornment>
                      ),
                    }}
                    disabled={isViewMode || field.disabled}
                  />
                )}
              />
            );
      default:
        return (
          <Controller
            name={field.name}
            control={control}
            render={({ field: { value, onChange, ...fieldProps } }) => (
              <TextField
                {...fieldProps}
                type={field.type} // Xử lý nếu có type 'number'
                label={t(field.label)}
                value={value || ''}
                onChange={field.type === 'number' 
                  ? (e) => onChange(Number(e.target.value)) 
                  : onChange
                }
                fullWidth
                multiline={field.multiline}
                rows={field.rows}
                error={!!errors[field.name]}
                helperText={errors[field.name]?.message as string}
                placeholder={field.placeholder ? t(field.placeholder) : undefined}
                InputProps={{
                  startAdornment: field.icon && (
                    <InputAdornment position="start">
                      {field.icon}
                    </InputAdornment>
                  ),
                  endAdornment: field.endAdornment
                }}
                disabled={isViewMode || field.disabled}
              />
            )}
          />
        );
    }
  };

  return (
    <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(33.33% - 1rem)' } }}>
      {renderField()}
    </Box>
  );
};

const UpdateOrInsertOrder: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const location = useLocation();
  const queryClient = useQueryClient();
  const isEditMode = Boolean(id);
  const isViewMode = location.pathname.includes('/view/');

  // Get current page from localStorage or default to 1
  const currentPage = Number(localStorage.getItem('ordersCurrentPage')) || 1;

  // Handle browser back button
  useEffect(() => {
    // const handleBeforeUnload = (e: BeforeUnloadEvent) => {
    //   e.preventDefault();
    //   e.returnValue = '';
    // };

    const handlePopState = () => {
      navigate(`/dashboard/orders?page=${currentPage}`, {
        replace: true,
        state: { forceReload: true }
      });
    };

    // window.addEventListener('beforeunload', handleBeforeUnload);
    window.addEventListener('popstate', handlePopState);

    return () => {
      // window.removeEventListener('beforeunload', handleBeforeUnload);
      window.removeEventListener('popstate', handlePopState);
    };
  }, [navigate, currentPage]);

  // Form setup with react-hook-form and zod
  const { 
    control, 
    handleSubmit, 
    reset, 
    formState: { errors, isSubmitting } 
  } = useZodForm(
    isEditMode ? orderEditSchema : orderSchema,
    {
      defaultValues: {
                name: '',
        exchangeRateUsdVndBuy:  0,
        exchangeRateUsdVndSell: 0,
        transportMethod: 1,
        packingMethod: 1,
        weightPerContainer: '',
        estimatedTotalContainers: 0,
        estimatedTotalBookings: 0,
        bookingNoCode: '',
        packingDate: '',
        yardIn: '',
        truckPlate: '',
        containerNo: '',
        sealNo: '',
        supplierName: '',
        transportCompanyName:  '',
        quantity: 0,
        coatingCompanyName:  '',
        coatedQuantity: 0,
        productUnitPrice: 0,
        coatedProductUnitPrice: 0,
        transportUnitPrice:  0,
        invoice: '',
        packingList:  '',
        certificateOfQuality:  '',
        shippingInstruction: '',
        verifiedGrossMass: '',
        timberPackingDeclaration: '',
        weighingCostAtFactory: 0,
        liftingCost: 0,
        yukoFlag: 1,
      } as OrderFormValues,
      // mode: 'onChange',
      // reValidateMode: 'onChange'
    }
  );


  // Query to fetch order data in edit mode
  const { data: orderData, isLoading } = useQuery({
    queryKey: ['order', id],
    queryFn: async () => {
      if (!isEditMode) return null;
      return await orderService.getOrderById(Number(id!));
    },
    enabled: isEditMode
  });

  // Set form values when order data is loaded
  useEffect(() => {
    if (orderData) {
      reset({
    name: orderData.name || '',
    exchangeRateUsdVndBuy: orderData.exchangeRateUsdVndBuy || 0,
    exchangeRateUsdVndSell: orderData.exchangeRateUsdVndSell || 0,
    transportMethod: orderData.transportMethod || 1,
    packingMethod: orderData.packingMethod || 1,
    weightPerContainer: orderData.weightPerContainer || '',
    estimatedTotalContainers: orderData.estimatedTotalContainers || 0,
    estimatedTotalBookings: orderData.estimatedTotalBookings || 0,
    bookingNoCode: orderData.bookingNoCode || '',
    packingDate : formatDate(orderData.packingDate) || '',
    yardIn: orderData.yardIn || '',
    truckPlate: orderData.truckPlate || '',
    containerNo: orderData.containerNo || '',
    sealNo: orderData.sealNo || '',
    supplierName: orderData.supplierName || '',
    transportCompanyName: orderData.transportCompanyName || '',
    quantity: orderData.quantity || 0,
    coatingCompanyName: orderData.coatingCompanyName || '',
    coatedQuantity: orderData.coatedQuantity || 0,
    productUnitPrice: orderData.productUnitPrice || 0,
    coatedProductUnitPrice: orderData.coatedProductUnitPrice || 0,
    transportUnitPrice: orderData.transportUnitPrice || 0,
    invoice: orderData.invoice || '',
    packingList: orderData.packingList || '',
    certificateOfQuality: orderData.certificateOfQuality || '',
    shippingInstruction: orderData.shippingInstruction || '',
    verifiedGrossMass: orderData.verifiedGrossMass || '',
    timberPackingDeclaration: orderData.timberPackingDeclaration || '',
    weighingCostAtFactory: orderData.weighingCostAtFactory || 0,
    liftingCost: orderData.liftingCost || 0,
    yukoFlag: orderData.yukoFlag || 1,
      });
    }
  }, [orderData, reset]);

  // Mutation for create/update order
  const mutation = useMutation({
    mutationFn: async (data: OrderFormValues) => {
      if (isEditMode) {
        return orderService.updateOrder(Number(id!), data);
      } else {
        return orderService.createOrder(data);
      }
    },
    onSuccess: () => {
      // Invalidate and refetch orders query with exact page
      queryClient.invalidateQueries({ 
        queryKey: ['orders'],
        refetchType: 'all'
      });
      toast.success(t(isEditMode ? 'orders.updateSuccess' : 'orders.createSuccess'));
      // Navigate back with the stored page number and force reload
      navigate(`/dashboard/orders?page=${currentPage}`, { 
        replace: true,
        state: { forceReload: true }
      });
    },
    onError: (error) => {
      toast.error(t(isEditMode ? 'orders.updateError' : 'orders.createError'));
      console.error('Mutation error:', error);
    }
  });

  // Form submission handler
  const onSubmit = async (data: OrderFormValues) => {
    try {
      await mutation.mutateAsync(data);
      
    } catch (error) {
      console.error('Form submission error:', error);
    }
  };
  
  // Navigate back to order list
  const handleBack = () => {
    navigate(`/dashboard/orders?page=${currentPage}`, { 
      replace: true,
      state: { forceReload: true }
    });
  };


  useEffect(() => {
    const handlePopState = (event: PopStateEvent) => {
        event.preventDefault();
        navigate(`/dashboard/orders?page=${currentPage}`, { 
            replace: true,
            state: { forceReload: true }
          });
    };

    window.addEventListener('popstate', (e) => handlePopState(e));

    return () => {
      window.removeEventListener('popstate', (e) => handlePopState(e));
    };
  }, []);


  // Display loading state while fetching order data
  if (isEditMode && isLoading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 8 }}>
        <CircularProgress />
      </Box>
    );
  }

  return (
    <Box>
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 3, alignItems: 'center' }}>
        <Button
          variant="outlined"
          startIcon={<ArrowBackIcon />}
          onClick={handleBack}
          sx={{ 
            borderRadius: 1,
            px: 2
          }}
        >
          {t('common.back')}
        </Button>
      </Box>

      <CardContent sx={{ p: 3 }}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Box sx={{ display: 'flex', flexDirection: 'column', gap: 4 }}>
            {/* Basic Information Section */}
            <Card 
              elevation={0}
              sx={{ 
                border: '1px solid',
                borderColor: 'divider',
                borderRadius: 2,
                overflow: 'hidden'
              }}
            >
              <CardContent sx={{ p: 3 }}>
                <Typography variant="subtitle1" sx={{ mb: 2, color: 'text.primary' }}>
                  {t('orders.basicInformation')}
                </Typography>
                <Divider sx={{ mb: 3 }} />
                <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 3 }}>
                  {orderFields.map((field) => (
                    <FormFieldRenderer
                      key={field.name}
                      field={field}
                      control={control}
                      errors={errors}
                      isViewMode={isViewMode}
                    />
                  ))}
                </Box>
              </CardContent>
            </Card>

            {/* Submit Button */}
            {!isViewMode && (
              <Box 
                sx={{ 
                  display: 'flex', 
                  justifyContent: 'flex-end', 
                  mt: 2,
                  pt: 2,
                  borderTop: '1px solid',
                  borderColor: 'divider'
                }}
              >
                <Button
                  variant="contained"
                  color="primary"
                  type="submit"
                  startIcon={isSubmitting ? <CircularProgress size={20} /> : <SaveIcon />}
                  sx={{ 
                    borderRadius: 1,
                    px: 3,
                    minWidth: 120
                  }}
                >
                  {t(isEditMode ? 'common.update' : 'common.save')}
                </Button>
              </Box>
            )}
          </Box>
        </form>
      </CardContent>
    </Box>
  );
};

export default UpdateOrInsertOrder;