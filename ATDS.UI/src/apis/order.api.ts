import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { Order, OrderFormValues, OrderParams } from "@/types/order.type";

export const orderApi = {
    getOrders: async (params: OrderParams) => {
        const response =await apiClient.get<ApiResponse<Order[]>>('/order', { ...params });
        return response.data;
    },
    getOrderById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<Order>>(`/order/${id}`);
        return response.data;
    },
    createOrder: async (order: OrderFormValues) => {
        const response = await apiClient.post<ApiResponse<Order>>('/order', order);
        return response.data;
    },
    updateOrder: async (id: number, order: OrderFormValues) => {
        const response = await apiClient.put<ApiResponse<Order>>(`/order/${id}`,  order );
        return response.data;
    },
    deleteOrder: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<Order>>(`/order/${id}`);
        return response.data;
    },
    // deleteOrders: async (ids: number[]) => {
    //     const response = await apiClient.delete<ApiResponse<Order>>(`/order`, { ids });
    //     return response.data;
    // }
    deleteOrders: async (ids: number[]) => {
    await Promise.all(
        ids.map(id => apiClient.delete<ApiResponse<Order>>(`/order/${id}`))
    );
    return { success: true };
}
}