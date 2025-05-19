import { orderApi } from '@/apis/order.api.ts';
import { Order, OrderFormValues, OrderListResponse, OrderParams } from '../types/order.type';


export const orderService = {
  /**
   * Get a list of orders with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated order list
   */
  getOrders: async (params: OrderParams): Promise<OrderListResponse> => {
    try {
      const { data, meta } = await orderApi.getOrders(params);

      const result: OrderListResponse = {
        data: data,
        total: meta?.total || 0,
        page: meta?.page || 0,
        size: meta?.size || 10
      };

      return result;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Get a single order by ID (Mock version)
   * @param id Order ID
   * @returns Mocked order data
   */
  getOrderById: async (id: number): Promise<Order> => {
    const { data } = await orderApi.getOrderById(id);
    if (!data) {
      throw new Error(`Order with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new order (Mock version)
   * @param orderData Order data to create
   */
  createOrder: async (orderData: OrderFormValues): Promise<Order> => {
    try {
      const { data } = await orderApi.createOrder(orderData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing order (Mock version)
   * @param id Order ID
   * @param orderData Order data to update
   * @returns Mocked updated order
   */
  updateOrder: async (id: number, orderData: OrderFormValues): Promise<Order> => {
    try {
      
      const apiResponse = await orderApi.updateOrder(id, orderData);
      
      if (!apiResponse.data) {
        throw new Error('Invalid response from server');
      }
      return apiResponse.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a order by ID (Mock version)
   * @param id Order ID
   */
  deleteOrder: async (id: number): Promise<void> => {
    try {
      await orderApi.deleteOrder(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple orders by their IDs
   * @param ids Array of order IDs to delete
   */
  deleteOrders: async (ids: number[]): Promise<void> => {
    try {
      await orderApi.deleteOrders(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default orderService;
    