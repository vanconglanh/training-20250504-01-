import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/UserSlice';
import uiReducer from './slices/UISlice';
import authReducer from './slices/AuthSlice';

export const store = configureStore({
  reducer: {
    user: userReducer,
    ui: uiReducer,
    auth: authReducer,
  },
  devTools: true,
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;