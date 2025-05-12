import { createSlice } from '@reduxjs/toolkit';
import { Role } from '../../types/role.type';

interface RoleState {
  currentRole: Role | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: RoleState = {
  currentRole: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const roleSlice = createSlice({
  name: 'role',
  initialState,
  reducers: {

  },
});

export const {    } = roleSlice.actions;

export default roleSlice.reducer;