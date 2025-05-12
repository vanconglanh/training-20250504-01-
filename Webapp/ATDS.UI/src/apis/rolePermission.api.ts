import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { RolePermission, RolePermissionFormValues, RolePermissionParams } from "@/types/rolePermission.type";

export const rolePermissionApi = {
    getRolePermissions: async (params: RolePermissionParams) => {
        const response =await apiClient.get<ApiResponse<RolePermission[]>>('/rolePermission', { ...params });
        return response.data;
    },
    getRolePermissionById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<RolePermission>>(`/rolePermission/${id}`);
        return response.data;
    },
    createRolePermission: async (rolePermission: RolePermissionFormValues) => {
        const response = await apiClient.post<ApiResponse<RolePermission>>('/rolePermission', rolePermission);
        return response.data;
    },
    updateRolePermission: async (id: number, rolePermission: RolePermissionFormValues) => {
        const response = await apiClient.put<ApiResponse<RolePermission>>(`/rolePermission/${id}`, rolePermission);
        return response.data;
    },
    deleteRolePermission: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<RolePermission>>(`/rolePermission/${id}`);
        return response.data;
    },
    deleteRolePermissions: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<RolePermission>>(`/rolePermission`, { ids });
        return response.data;
    }
}
