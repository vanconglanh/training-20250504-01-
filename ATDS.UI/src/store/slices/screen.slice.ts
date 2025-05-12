import { createSlice } from '@reduxjs/toolkit';
import { Screen } from '../../types/screen.type';

interface ScreenState {
  currentScreen: Screen | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: ScreenState = {
  currentScreen: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const screenSlice = createSlice({
  name: 'screen',
  initialState,
  reducers: {

  },
});

export const {    } = screenSlice.actions;

export default screenSlice.reducer;