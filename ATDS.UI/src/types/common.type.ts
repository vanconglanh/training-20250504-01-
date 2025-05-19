
export interface FilterOption {
    id: string;
    label: string;
    type: 'text' | 'select' | 'autocomplete' | 'date';
    options?: { value: string; label: string }[];
    suggestionFn?: (value: string) => Promise<any[]>;
    defaultValue?: string;
  }
  
  export interface ActiveFilter {
    id: string;
    field: string;
    label: string;
    value: string;
    operator: string;
  }
  
  export interface FilterProps {
    open: boolean;
    onClose: () => void;
    activeFilters: ActiveFilter[];
    onApply: (filters: ActiveFilter[]) => void;
    onClear: () => void;
    defaultFilters?: FilterOption[];
  }

  export interface SortField {
    field: string;
    order: 'asc' | 'desc';
  }


  export interface SearchParams {
    page?: number;
    size?: number;
    search?: string[];
    sortBy?: string;
    sortOrder?: 'asc' | 'desc';
    sortFields?: SortField[];
    status?: number;
  }

  export type FieldType =
  | 'text'
  | 'password'
  | 'email'
  | 'select'
  | 'number'
  | 'boolean'
  | 'date'
  | 'datetime-local'
  | 'time'
  | 'textarea'
  | 'file'
  | 'checkbox'
  | 'radio'
  | 'url'
  | 'tel'
  | 'range'
  | 'color'
  | 'multiselect'
  | 'custom';

  interface FieldOption {
    value: string | number;
    label: string;
  }

  export interface FormField<T> {
    name: keyof T;
    label: string;
    type: FieldType;
    required?: boolean;
    disabled?: boolean;
    placeholder?: string;
    icon?: React.ReactNode;
    options?: FieldOption[];
    multiline?: boolean;
    rows?: number;
    startAdornment?: React.ReactNode;
    endAdornment?: React.ReactNode;
  }