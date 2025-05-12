import { createSlice } from '@reduxjs/toolkit';
import { Permission } from '../../types/permission.type';

interface PermissionState {
  currentPermission: Permission | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: PermissionState = {
  currentPermission: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const permissionSlice = createSlice({
  name: 'permission',
  initialState,
  reducers: {

  },
});

export const {    } = permissionSlice.actions;

export default permissionSlice.reducer;