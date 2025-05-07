import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface UiState {
  drawerOpen: boolean;
  darkMode: boolean;
  language: string;
  loading: boolean;
  error: string | null;
}

const initialState: UiState = {
  drawerOpen: true,
  darkMode: false,
  language: localStorage.getItem('i18nextLng') || 'en',
  loading: false,
  error: null,
};

const uiSlice = createSlice({
  name: 'ui',
  initialState,
  reducers: {
    toggleDrawer: (state) => {
      state.drawerOpen = !state.drawerOpen;
    },
    setDrawerOpen: (state, action: PayloadAction<boolean>) => {
      state.drawerOpen = action.payload;
    },
    toggleDarkMode: (state) => {
      state.darkMode = !state.darkMode;
    },
    setDarkMode: (state, action: PayloadAction<boolean>) => {
      state.darkMode = action.payload;
    },
    setLanguage: (state, action: PayloadAction<string>) => {
      state.language = action.payload;
      localStorage.setItem('i18nextLng', action.payload);
    },
    setLoading: (state, action: PayloadAction<boolean>) => {
      state.loading = action.payload;
    },
    setError: (state, action: PayloadAction<string | null>) => {
      state.error = action.payload;
    },
  },
});

export const {
  toggleDrawer,
  setDrawerOpen,
  toggleDarkMode,
  setDarkMode,
  setLanguage,
  setLoading,
  setError,
} = uiSlice.actions;

export default uiSlice.reducer;