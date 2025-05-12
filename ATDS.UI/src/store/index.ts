import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/user.slice.ts';
import uiReducer from './slices/ui.slice.ts';
import authReducer from './slices/auth.slice';

export const store = configureStore({
  reducer: {
    ui: uiReducer,
    auth: authReducer,
  },
  devTools: true,
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;