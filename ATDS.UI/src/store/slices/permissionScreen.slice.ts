import { createSlice } from '@reduxjs/toolkit';
import { PermissionScreen } from '../../types/permissionScreen.type';

interface PermissionScreenState {
  currentPermissionScreen: PermissionScreen | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: PermissionScreenState = {
  currentPermissionScreen: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const permissionScreenSlice = createSlice({
  name: 'permissionScreen',
  initialState,
  reducers: {

  },
});

export const {    } = permissionScreenSlice.actions;

export default permissionScreenSlice.reducer;