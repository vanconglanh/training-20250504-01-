import CloseIcon from '@mui/icons-material/Close';
import FilterListIcon from '@mui/icons-material/FilterList';
import SearchIcon from '@mui/icons-material/Search';
import {
  Autocomplete,
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Divider,
  IconButton,
  InputAdornment,
  Stack,
  TextField,
  Typography
} from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';
import { FilterOption, ActiveFilter, FilterProps } from '@/types/common.type';

const Filter: React.FC<FilterProps> = ({
  open,
  onClose,
  activeFilters,
  onApply,
  onClear,
  defaultFilters = []
}) => {
  const { t } = useTranslation();
  const [defaultFilterValues, setDefaultFilterValues] = useState<Record<string, string[]>>({});
  useEffect(() => {
    if (open) {
      const initialValues: Record<string, string[]> = {};
      defaultFilters.forEach(filter => {
        initialValues[filter.id] = filter.defaultValue ? [filter.defaultValue] : [];
      });
      activeFilters.forEach(filter => {
        initialValues[filter.field] = [filter.value];
      });
      setDefaultFilterValues(initialValues);
    }
  }, [open, activeFilters, defaultFilters]);

  const handleApply = () => {
    const processedFilters: ActiveFilter[] = Object.entries(defaultFilterValues)
      .filter(([_, values]) => values.length > 0)
      .map(([field, values]) => {
        const filter = defaultFilters.find(f => f.id === field);
        return {
          id: `${field}-${Date.now()}`,
          field,
          label: filter?.label || field,
          value: values[0] || '',
          operator: 'contains'
        };
      });
    
    onApply(processedFilters);
    onClose();
  };

  const handleClear = () => {
    setDefaultFilterValues({});
    onClear();
  };

  const renderFilterInput = (filter: FilterOption) => {
    if (filter.type === 'select') {
      return (
        <Autocomplete
          options={filter.options || []}
          getOptionLabel={option => option.label}
          value={filter.options?.find(opt => 
            (defaultFilterValues[filter.id] || [])[0] === opt.value
          ) || null}
          onChange={(_, newValue) => {
            setDefaultFilterValues(prev => ({
              ...prev,
              [filter.id]: newValue ? [newValue.value] : []
            }));
          }}
          renderInput={(params) => (
            <TextField
              {...params}
              label={filter.label}
              size="small"
              fullWidth
            />
          )}
        />
      );
    }

    if (filter.type === 'text') {
      return (
        <TextField
          label={filter.label}
          value={(defaultFilterValues[filter.id] || [])[0] || ''}
          onChange={(e) => setDefaultFilterValues(prev => ({
            ...prev,
            [filter.id]: [e.target.value]
          }))}
          onKeyDown={(e) => {
            if (e.key === 'Enter') {
              e.preventDefault()
              handleApply();
            }
          }}
          size="small"
          fullWidth
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon color="action" />
              </InputAdornment>
            )
          }}
        />
      );
    }

    return null;
  };

  return (
    <Dialog 
      open={open} 
      onClose={onClose}
      maxWidth="md"
      fullWidth
      PaperProps={{
        sx: {
          borderRadius: 2,
          boxShadow: '0 8px 32px rgba(0, 0, 0, 0.08)',
        }
      }}
    >
      <DialogTitle sx={{ 
        p: 2.5,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        borderBottom: '1px solid',
        borderColor: 'divider'
      }}>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1.5 }}>
          <FilterListIcon color="primary" />
          <Typography variant="h6">{t('common.filter')}</Typography>
        </Box>
        <IconButton onClick={onClose} size="small">
          <CloseIcon />
        </IconButton>
      </DialogTitle>

      <DialogContent sx={{ p: 3.5 }}>
        <Stack spacing={4}>
          {defaultFilters.length > 0 && (
            <Box>
              <Typography variant="subtitle2" color="text.secondary" gutterBottom sx={{ mb: 2, mt: 2 }}>
                {t('common.quickFilters')}
              </Typography>
              <Box sx={{ 
                display: 'grid', 
                gridTemplateColumns: { xs: '1fr', md: 'repeat(3, 1fr)' },
                gap: 2 
              }}>
                {defaultFilters.map((filter) => (
                  <Box key={filter.id}>
                    {renderFilterInput(filter)}
                  </Box>
                ))}
              </Box>
            </Box>
          )}
        </Stack>
      </DialogContent>

      <Divider />

      <DialogActions sx={{ p: 2.5, gap: 1.5 }}>
        <Button
          onClick={handleClear}
          variant="outlined"
          color="inherit"
          sx={{ minWidth: 100 }}
        >
          {t('filters.clearAll')}
        </Button>
        <Button
          onClick={onClose}
          variant="outlined"
          color="inherit"
          sx={{ minWidth: 100 }}
        >
          {t('common.cancel')}
        </Button>
        <Button
          onClick={handleApply}
          variant="contained"
          color="primary"
          sx={{
            minWidth: 100,
            background: 'linear-gradient(45deg, #6b97ff 30%, #3d78ff 90%)',
            boxShadow: '0 3px 5px 2px rgba(59, 120, 255, .3)',
            '&:hover': {
              background: 'linear-gradient(45deg, #3d78ff 30%, #2a61e6 90%)',
            },
          }}
        >
          {t('common.apply')}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default Filter; 