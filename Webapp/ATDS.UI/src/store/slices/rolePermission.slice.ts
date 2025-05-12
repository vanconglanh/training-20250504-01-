import { createSlice } from '@reduxjs/toolkit';
import { RolePermission } from '../../types/rolePermission.type';

interface RolePermissionState {
  currentRolePermission: RolePermission | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: RolePermissionState = {
  currentRolePermission: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const rolePermissionSlice = createSlice({
  name: 'rolePermission',
  initialState,
  reducers: {

  },
});

export const {    } = rolePermissionSlice.actions;

export default rolePermissionSlice.reducer;