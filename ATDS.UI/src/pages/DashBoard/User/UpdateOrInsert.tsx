import { useZodForm } from '@/hooks/useZodForm';
import userService from '@/services/user.service.ts';
import { FormField } from '@/types/common.type';
import { UserFormValues } from '@/types/user.type';
import { userEditSchema, userSchema } from '@/utils/validation/user.scheme';
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

const userFields: FormField<UserFormValues>[] = [
    {
    name: 'name',
    label: 'common.name',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.name'
  },
  {
    name: 'email',
    label: 'common.email',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.email'
  },
  {
    name: 'username',
    label: 'common.username',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.username'
  },
  {
    name: 'language',
    label: 'common.language',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.language'
  },
  {
    name: 'password',
    label: 'common.password',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.password'
  },
  {
    name: 'passwordHash',
    label: 'common.passwordHash',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.passwordHash'
  },
  {
    name: 'roleId',
    label: 'common.roleId',
    type: 'text',
    required: true,
    icon: <PersonIcon color="action" />,
    placeholder: 'users.placeholders.roleId'
  },
  {
    name: 'status',
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
  field: FormField<UserFormValues>;
  control: Control<UserFormValues>;
  errors: FieldErrors<UserFormValues>;
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

const UpdateOrInsertUser: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const location = useLocation();
  const queryClient = useQueryClient();
  const isEditMode = Boolean(id);
  const isViewMode = location.pathname.includes('/view/');

  // Get current page from localStorage or default to 1
  const currentPage = Number(localStorage.getItem('usersCurrentPage')) || 1;

  // Handle browser back button
  useEffect(() => {
    const handleBeforeUnload = (e: BeforeUnloadEvent) => {
      e.preventDefault();
      e.returnValue = '';
    };

    const handlePopState = () => {
      navigate(`/dashboard/users?page=${currentPage}`, {
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
    isEditMode ? userEditSchema : userSchema,
    {
      defaultValues: {
                name: '',
        email: '',
        username: '',
        language: '',
        password: '',
        passwordHash: '',
        roleId: 1,
        status: 1,
      },
      mode: 'onChange',
      reValidateMode: 'onChange'
    }
  );


  // Query to fetch user data in edit mode
  const { data: userData, isLoading } = useQuery({
    queryKey: ['user', id],
    queryFn: async () => {
      if (!isEditMode) return null;
      return await userService.getUserById(Number(id!));
    },
    enabled: isEditMode
  });

  // Set form values when user data is loaded
  useEffect(() => {
    if (userData) {
      reset({
                name: userData.name || '',
        email: userData.email || '',
        username: userData.username || '',
        language: userData.language || '',
        password: userData.password || '',
        passwordHash: userData.passwordHash || '',
        roleId: userData.roleId || 1,
        status: userData.status || 1,
      });
    }
  }, [userData, reset]);

  // Mutation for create/update user
  const mutation = useMutation({
    mutationFn: async (data: UserFormValues) => {
      if (isEditMode) {
        return userService.updateUser(Number(id!), data);
      } else {
        return userService.createUser(data);
      }
    },
    onSuccess: () => {
      // Invalidate and refetch users query with exact page
      queryClient.invalidateQueries({ 
        queryKey: ['users'],
        refetchType: 'all'
      });
      toast.success(t(isEditMode ? 'users.updateSuccess' : 'users.createSuccess'));
      // Navigate back with the stored page number and force reload
      navigate(`/dashboard/users?page=${currentPage}`, { 
        replace: true,
        state: { forceReload: true }
      });
    },
    onError: (error) => {
      toast.error(t(isEditMode ? 'users.updateError' : 'users.createError'));
      console.error('Mutation error:', error);
    }
  });

  // Form submission handler
  const onSubmit = async (data: UserFormValues) => {
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

  // Navigate back to user list
  const handleBack = () => {
    navigate(`/dashboard/users?page=${currentPage}`, { 
      replace: true,
      state: { forceReload: true }
    });
  };


  useEffect(() => {
    const handlePopState = (event: PopStateEvent) => {
        event.preventDefault();
        navigate(`/dashboard/users?page=${currentPage}`, { 
            replace: true,
            state: { forceReload: true }
          });
    };

    window.addEventListener('popstate', (e) => handlePopState(e));

    return () => {
      window.removeEventListener('popstate', (e) => handlePopState(e));
    };
  }, []);


  // Display loading state while fetching user data
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
                  {t('users.basicInformation')}
                </Typography>
                <Divider sx={{ mb: 3 }} />
                <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 3 }}>
                  {userFields.map((field) => (
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

export default UpdateOrInsertUser;