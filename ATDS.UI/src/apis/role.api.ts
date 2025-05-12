import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { Role, RoleFormValues, RoleParams } from "@/types/role.type";

export const roleApi = {
    getRoles: async (params: RoleParams) => {
        const response =await apiClient.get<ApiResponse<Role[]>>('/role', { ...params });
        return response.data;
    },
    getRoleById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<Role>>(`/role/${id}`);
        return response.data;
    },
    createRole: async (role: RoleFormValues) => {
        const response = await apiClient.post<ApiResponse<Role>>('/role', role);
        return response.data;
    },
    updateRole: async (id: number, role: RoleFormValues) => {
        const response = await apiClient.put<ApiResponse<Role>>(`/role/${id}`, role);
        return response.data;
    },
    deleteRole: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<Role>>(`/role/${id}`);
        return response.data;
    },
    deleteRoles: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<Role>>(`/role`, { ids });
        return response.data;
    }
}
