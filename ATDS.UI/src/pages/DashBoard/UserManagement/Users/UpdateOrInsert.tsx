import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import BadgeIcon from '@mui/icons-material/Badge';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import EmailIcon from '@mui/icons-material/Email';
import LockIcon from '@mui/icons-material/Lock';
import PersonIcon from '@mui/icons-material/Person';
import SaveIcon from '@mui/icons-material/Save';
import ToggleOnIcon from '@mui/icons-material/ToggleOn';
import {
  Box,
  Button,
  Card,
  CardContent,
  Checkbox,
  CircularProgress,
  Divider,
  FormControl,
  FormControlLabel,
  FormHelperText,
  InputAdornment,
  InputLabel,
  MenuItem,
  Select,
  TextField,
  Typography
} from '@mui/material';
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';
import { useSnackbar } from 'notistack';
import React, { useEffect } from 'react';
import { Controller } from 'react-hook-form';
import { useTranslation } from 'react-i18next';
import { useNavigate, useParams, useLocation } from 'react-router-dom';
import { useZodForm } from '@/hooks/useZodForm';
import userService from '@/services/userService';
import { UserFormValues } from '@/types/user.type';
import { userEditSchema, userSchema } from '@/utils/validation/userScheme';


const UpdateOrInsertUser: React.FC = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const location = useLocation();
  const { enqueueSnackbar } = useSnackbar();
  const queryClient = useQueryClient();
  const isEditMode = Boolean(id);
  const isViewMode = location.pathname.includes('/view/');

  // Form setup with react-hook-form and zod
  const { 
    control, 
    handleSubmitWithErrorMessage, 
    reset, 
    formState: { errors, isSubmitting, isValid } 
  } = useZodForm(
    isEditMode ? userEditSchema : userSchema,
    {
      defaultValues: {
        username: '',
        email: '',
        password: '',
        role: 'user',
        status: 'active',
        yukoFlag: true
      },
      mode: 'onChange'
    }
  );

  // Query to fetch user data in edit mode
  const { data: userData, isLoading } = useQuery({
    queryKey: ['user', id],
    queryFn: async () => {
      if (!isEditMode) return null;
      return await userService.getUserById(id!);
    },
    enabled: isEditMode
  });

  // Set form values when user data is loaded
  useEffect(() => {
    if (userData) {
      reset({
        username: userData.username,
        email: userData.email,
        password: '', // Don't populate password
        role: userData.role,
        status: userData.status,
        yukoFlag: userData.yukoFlag
      });
    }
  }, [userData, reset]);

  // Mutation for create/update user
  const mutation = useMutation({
    mutationFn: async (data: UserFormValues) => {
      if (isEditMode) {
        return userService.updateUser(id!, data);
      } else {
        return userService.createUser(data);
      }
    },
    onSuccess: () => {
      // Invalidate and refetch users query
      queryClient.invalidateQueries({ queryKey: ['users'] });
      
      enqueueSnackbar(
        t(isEditMode ? 'users.updateSuccess' : 'users.createSuccess'), 
        { variant: 'success' }
      );
      navigate('/dashboard/users');
    },
    onError: (error) => {
      enqueueSnackbar(
        t(isEditMode ? 'users.updateError' : 'users.createError'), 
        { variant: 'error' }
      );
      console.error('Mutation error:', error);
    }
  });

  // Form submission handler
  const onSubmit = (data: UserFormValues) => {
    // If editing and password is empty, remove it
    if (isEditMode && !data.password) {
      const { password, ...restData } = data;
      return mutation.mutate(restData);
    }
    return mutation.mutate(data);
  };

  // Navigate back to user list
  const handleBack = () => {
    navigate('/dashboard/users');
  };


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
                  <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(50% - 1.5rem)' } }}>
                    <Controller
                      name="username"
                      control={control}
                      render={({ field }) => (
                        <TextField
                          {...field}
                          label={t('users.fields.username')}
                          fullWidth
                          error={!!errors.username}
                          helperText={errors.username?.message}
                          InputProps={{
                            startAdornment: (
                              <InputAdornment position="start">
                                <PersonIcon color="action" />
                              </InputAdornment>
                            ),
                          }}
                          sx={{
                            '& .MuiOutlinedInput-root': {
                              borderRadius: 1
                            }
                          }}
                          disabled={isViewMode}
                        />
                      )}
                    />
                  </Box>

                  <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(50% - 1.5rem)' } }}>
                    <Controller
                      name="email"
                      control={control}
                      render={({ field }) => (
                        <TextField
                          {...field}
                          label={t('users.fields.email')}
                          fullWidth
                          error={!!errors.email}
                          helperText={errors.email?.message}
                          InputProps={{
                            startAdornment: (
                              <InputAdornment position="start">
                                <EmailIcon color="action" />
                              </InputAdornment>
                            ),
                          }}
                          sx={{
                            '& .MuiOutlinedInput-root': {
                              borderRadius: 1
                            }
                          }}
                          disabled={isViewMode}
                        />
                      )}
                    />
                  </Box>

                  <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(50% - 1.5rem)' } }}>
                    <Controller
                      name="password"
                      control={control}
                      render={({ field }) => (
                        <TextField
                          {...field}
                          type="password"
                          label={t(isEditMode ? 'users.fields.newPassword' : 'users.fields.password')}
                          fullWidth
                          error={!!errors.password}
                          helperText={
                            errors.password?.message || 
                            (isEditMode && !isViewMode ? t('users.passwordHint') : '')
                          }
                          InputProps={{
                            startAdornment: (
                              <InputAdornment position="start">
                                <LockIcon color="action" />
                              </InputAdornment>
                            ),
                          }}
                          sx={{
                            '& .MuiOutlinedInput-root': {
                              borderRadius: 1
                            }
                          }}
                          disabled={isViewMode}
                        />
                      )}
                    />
                  </Box>
                </Box>
              </CardContent>
            </Card>

            {/* Role and Status Section */}
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
                  {t('users.roleAndStatus')}
                </Typography>
                <Divider sx={{ mb: 3 }} />
                <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 3 }}>
                  <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(50% - 1.5rem)' } }}>
                    <Controller
                      name="role"
                      control={control}
                      render={({ field }) => (
                        <FormControl fullWidth error={!!errors.role}>
                          <InputLabel id="role-label">{t('users.fields.role')}</InputLabel>
                          <Select
                            {...field}
                            labelId="role-label"
                            label={t('users.fields.role')}
                            startAdornment={
                              <InputAdornment position="start">
                                <BadgeIcon color="action" />
                              </InputAdornment>
                            }
                            sx={{
                              borderRadius: 1,
                              '& .MuiOutlinedInput-notchedOutline': {
                                borderColor: errors.role ? 'error.main' : 'divider'
                              }
                            }}
                            disabled={isViewMode}
                          >
                            <MenuItem value="admin">{t('users.roles.admin')}</MenuItem>
                            <MenuItem value="manager">{t('users.roles.manager')}</MenuItem>
                            <MenuItem value="user">{t('users.roles.user')}</MenuItem>
                          </Select>
                          {errors.role && (
                            <FormHelperText>{errors.role.message}</FormHelperText>
                          )}
                        </FormControl>
                      )}
                    />
                  </Box>

                  <Box sx={{ flexGrow: 1, minWidth: { xs: '100%', md: 'calc(50% - 1.5rem)' } }}>
                    <Controller
                      name="status"
                      control={control}
                      render={({ field }) => (
                        <FormControl fullWidth error={!!errors.status}>
                          <InputLabel id="status-label">{t('users.fields.status')}</InputLabel>
                          <Select
                            {...field}
                            labelId="status-label"
                            label={t('users.fields.status')}
                            startAdornment={
                              <InputAdornment position="start">
                                <ToggleOnIcon color="action" />
                              </InputAdornment>
                            }
                            sx={{
                              borderRadius: 1,
                              '& .MuiOutlinedInput-notchedOutline': {
                                borderColor: errors.status ? 'error.main' : 'divider'
                              }
                            }}
                            disabled={isViewMode}
                          >
                            <MenuItem value="active">{t('users.statuses.active')}</MenuItem>
                            <MenuItem value="inactive">{t('users.statuses.inactive')}</MenuItem>
                            <MenuItem value="pending">{t('users.statuses.pending')}</MenuItem>
                          </Select>
                          {errors.status && (
                            <FormHelperText>{errors.status.message}</FormHelperText>
                          )}
                        </FormControl>
                      )}
                    />
                  </Box>
                </Box>
              </CardContent>
            </Card>

            {/* Additional Settings */}
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
                  {t('users.additionalSettings')}
                </Typography>
                <Divider sx={{ mb: 3 }} />
                <Box>
                  <Controller
                    name="yukoFlag"
                    control={control}
                    render={({ field }) => (
                      <FormControlLabel
                        control={
                          <Checkbox
                            checked={field.value}
                            onChange={(e) => field.onChange(e.target.checked)}
                            icon={<CheckCircleIcon />}
                            checkedIcon={<CheckCircleIcon color="primary" />}
                          />
                        }
                        label={t('users.fields.yukoFlag')}
                        sx={{
                          '& .MuiFormControlLabel-label': {
                            color: 'text.primary'
                          }
                        }}
                        disabled={isViewMode}
                      />
                    )}
                  />
                </Box>
              </CardContent>
            </Card>

            {/* Submit Button */}
           {
              !isViewMode &&
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
                    disabled={isSubmitting || !isValid || isViewMode}
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
           }
          </Box>
        </form>
      </CardContent>
    </Box>
  );
};

export default UpdateOrInsertUser;