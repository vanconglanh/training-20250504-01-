import { createSlice } from '@reduxjs/toolkit';
import { User } from '../../types/user.type';

interface UserState {
  currentUser: User | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: UserState = {
  currentUser: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {

  },
});

export const {    } = userSlice.actions;

export default userSlice.reducer;