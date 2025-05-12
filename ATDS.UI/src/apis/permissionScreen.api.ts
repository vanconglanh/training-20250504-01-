import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { PermissionScreen, PermissionScreenFormValues, PermissionScreenParams } from "@/types/permissionScreen.type";

export const permissionScreenApi = {
    getPermissionScreens: async (params: PermissionScreenParams) => {
        const response =await apiClient.get<ApiResponse<PermissionScreen[]>>('/permissionScreen', { ...params });
        return response.data;
    },
    getPermissionScreenById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<PermissionScreen>>(`/permissionScreen/${id}`);
        return response.data;
    },
    createPermissionScreen: async (permissionScreen: PermissionScreenFormValues) => {
        const response = await apiClient.post<ApiResponse<PermissionScreen>>('/permissionScreen', permissionScreen);
        return response.data;
    },
    updatePermissionScreen: async (id: number, permissionScreen: PermissionScreenFormValues) => {
        const response = await apiClient.put<ApiResponse<PermissionScreen>>(`/permissionScreen/${id}`, permissionScreen);
        return response.data;
    },
    deletePermissionScreen: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<PermissionScreen>>(`/permissionScreen/${id}`);
        return response.data;
    },
    deletePermissionScreens: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<PermissionScreen>>(`/permissionScreen`, { ids });
        return response.data;
    }
}
