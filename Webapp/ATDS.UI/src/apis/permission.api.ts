import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { Permission, PermissionFormValues, PermissionParams } from "@/types/permission.type";

export const permissionApi = {
    getPermissions: async (params: PermissionParams) => {
        const response =await apiClient.get<ApiResponse<Permission[]>>('/permission', { ...params });
        return response.data;
    },
    getPermissionById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<Permission>>(`/permission/${id}`);
        return response.data;
    },
    createPermission: async (permission: PermissionFormValues) => {
        const response = await apiClient.post<ApiResponse<Permission>>('/permission', permission);
        return response.data;
    },
    updatePermission: async (id: number, permission: PermissionFormValues) => {
        const response = await apiClient.put<ApiResponse<Permission>>(`/permission/${id}`, permission);
        return response.data;
    },
    deletePermission: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<Permission>>(`/permission/${id}`);
        return response.data;
    },
    deletePermissions: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<Permission>>(`/permission`, { ids });
        return response.data;
    }
}
