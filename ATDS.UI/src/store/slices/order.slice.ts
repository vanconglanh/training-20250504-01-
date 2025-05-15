import { createSlice } from '@reduxjs/toolkit';
import { Order } from '../../types/order.type';

interface OrderState {
  currentOrder: Order | null;
  isAuthenticated: boolean;
  loading: boolean;
  error: string | null;
}

const initialState: OrderState = {
  currentOrder: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

const orderSlice = createSlice({
  name: 'order',
  initialState,
  reducers: {

  },
});

export const {    } = orderSlice.actions;

export default orderSlice.reducer;