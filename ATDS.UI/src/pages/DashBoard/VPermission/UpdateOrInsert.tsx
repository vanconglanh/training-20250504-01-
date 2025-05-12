import { useZodForm } from '@/hooks/useZodForm';
import vPermissionService from '@/services/vPermission.service.ts';
import { FormField } from '@/types/common.type';
import { VPermissionFormValues } from '@/types/vPermission.type';
import { vPermissionEditSchema, vPermissionSchema } from '@/utils/validation/vPermission.scheme';
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

const vPermissionFields: FormField<VPermissionFormValues>[] = [
    {
    name: 'roleId',
    label: 'common.roleId',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.roleId'
  },
  {
    name: 'roleCode',
    label: 'common.roleCode',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.roleCode'
  },
  {
    name: 'roleName',
    label: 'common.roleName',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.roleName'
  },
  {
    name: 'screenId',
    label: 'common.screenId',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.screenId'
  },
  {
    name: 'screenCode',
    label: 'common.screenCode',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.screenCode'
  },
  {
    name: 'screenName',
    label: 'common.screenName',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.screenName'
  },
  {
    name: 'permissionId',
    label: 'common.permissionId',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.permissionId'
  },
  {
    name: 'permissionCode',
    label: 'common.permissionCode',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.permissionCode'
  },
  {
    name: 'permissionName',
    label: 'common.permissionName',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'vPermissions.placeholders.permissionName'
  },
  {
    name: 'yukoFlag',
    label: 'common.status',
    type: 'select',
    required: true,
    options: [
      { value: 1, label: 'common.active' },
      { value: 0, label: 'common.inactive' }
    ]
  }
];

const FormFieldRenderer: React.FC<{
  field: FormField<VPermissionFormValues>;
  control: Control<VPermissionFormValues>;
  errors: FieldErrors<VPermissionFormValues>;
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

      default:
        return (
          <Controller
            name={field.name}
            control={control}
            render={({ field: { value, onChange, ...fieldProps } }) => (
              <TextField
                {...fieldProps}
                type={field.type}
                label={t(field.label)}
                value={value || ''}
                onChange={onChange}
                fullWidth
                multiline={field.multiline}
                rows={field.rows}
                error={!!errors[field.name]}
                helperText={errors[field.name]?.message}
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

const UpdateOrInsertVPermission: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const location = useLocation();
  const queryClient = useQueryClient();
  const isEditMode = Boolean(id);
  const isViewMode = location.pathname.includes('/view/');

  // Get current page from localStorage or default to 1
  const currentPage = Number(localStorage.getItem('vPermissionsCurrentPage')) || 1;

  // Handle browser back button
  useEffect(() => {
    const handleBeforeUnload = (e: BeforeUnloadEvent) => {
      e.preventDefault();
      e.returnValue = '';
    };

    const handlePopState = () => {
      navigate(`/dashboard/vPermissions?page=${currentPage}`, {
        replace: true,
        state: { forceReload: true }
      });
    };

    window.addEventListener('beforeunload', handleBeforeUnload);
    window.addEventListener('popstate', handlePopState);

    return () => {
      window.removeEventListener('beforeunload', handleBeforeUnload);
      window.removeEventListener('popstate', handlePopState);
    };
  }, [navigate, currentPage]);

  // Form setup with react-hook-form and zod
  const { 
    control, 
    handleSubmitWithErrorMessage, 
    reset, 
    formState: { errors, isSubmitting } 
  } = useZodForm(
    isEditMode ? vPermissionEditSchema : vPermissionSchema,
    {
      defaultValues: {
                roleId: 1,
        roleCode: '',
        roleName: '',
        screenId: 1,
        screenCode: '',
        screenName: '',
        permissionId: 1,
        permissionCode: '',
        permissionName: '',
        yukoFlag: 1,
      },
      mode: 'onChange',
      reValidateMode: 'onChange'
    }
  );


  // Query to fetch vPermission data in edit mode
  const { data: vPermissionData, isLoading } = useQuery({
    queryKey: ['vPermission', id],
    queryFn: async () => {
      if (!isEditMode) return null;
      return await vPermissionService.getVPermissionById(Number(id!));
    },
    enabled: isEditMode
  });

  // Set form values when vPermission data is loaded
  useEffect(() => {
    if (vPermissionData) {
      reset({
                roleId: vPermissionData.roleId || 1,
        roleCode: vPermissionData.roleCode || '',
        roleName: vPermissionData.roleName || '',
        screenId: vPermissionData.screenId || 1,
        screenCode: vPermissionData.screenCode || '',
        screenName: vPermissionData.screenName || '',
        permissionId: vPermissionData.permissionId || 1,
        permissionCode: vPermissionData.permissionCode || '',
        permissionName: vPermissionData.permissionName || '',
        yukoFlag: vPermissionData.yukoFlag || 1,
      });
    }
  }, [vPermissionData, reset]);

  // Mutation for create/update vPermission
  const mutation = useMutation({
    mutationFn: async (data: VPermissionFormValues) => {
      if (isEditMode) {
        return vPermissionService.updateVPermission(Number(id!), data);
      } else {
        return vPermissionService.createVPermission(data);
      }
    },
    onSuccess: () => {
      // Invalidate and refetch vPermissions query with exact page
      queryClient.invalidateQueries({ 
        queryKey: ['vPermissions'],
        refetchType: 'all'
      });
      toast.success(t(isEditMode ? 'vPermissions.updateSuccess' : 'vPermissions.createSuccess'));
      // Navigate back with the stored page number and force reload
      navigate(`/dashboard/vPermissions?page=${currentPage}`, { 
        replace: true,
        state: { forceReload: true }
      });
    },
    onError: (error) => {
      toast.error(t(isEditMode ? 'vPermissions.updateError' : 'vPermissions.createError'));
      console.error('Mutation error:', error);
    }
  });

  // Form submission handler
  const onSubmit = async (data: VPermissionFormValues) => {
    try {
      // Ensure roleId is a number
      const formData = {
        ...data,
      };
      
      // If editing and password is empty, remove it      
      if (isEditMode) {
        await mutation.mutateAsync(formData);
      } else {
        await mutation.mutateAsync(formData);
      }
      // Show success toast after successful mutation
    } catch (error) {
      // Error is already handled in mutation's onError
      console.error('Form submission error:', error);
    }
  };

  // Navigate back to vPermission list
  const handleBack = () => {
    navigate(`/dashboard/vPermissions?page=${currentPage}`, { 
      replace: true,
      state: { forceReload: true }
    });
  };


  useEffect(() => {
    const handlePopState = (event: PopStateEvent) => {
        event.preventDefault();
        navigate(`/dashboard/vPermissions?page=${currentPage}`, { 
            replace: true,
            state: { forceReload: true }
          });
    };

    window.addEventListener('popstate', (e) => handlePopState(e));

    return () => {
      window.removeEventListener('popstate', (e) => handlePopState(e));
    };
  }, []);


  // Display loading state while fetching vPermission data
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
        <form onSubmit={handleSubmitWithErrorMessage(onSubmit)}>
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
                  {t('vPermissions.basicInformation')}
                </Typography>
                <Divider sx={{ mb: 3 }} />
                <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 3 }}>
                  {vPermissionFields.map((field) => (
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

export default UpdateOrInsertVPermission;