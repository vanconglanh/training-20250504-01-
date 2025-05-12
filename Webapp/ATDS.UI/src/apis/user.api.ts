import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { User, UserFormValues, UserParams } from "@/types/user.type";

export const userApi = {
    getUsers: async (params: UserParams) => {
        const response =await apiClient.get<ApiResponse<User[]>>('/user', { ...params });
        return response.data;
    },
    getUserById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<User>>(`/user/${id}`);
        return response.data;
    },
    createUser: async (user: UserFormValues) => {
        const response = await apiClient.post<ApiResponse<User>>('/user', user);
        return response.data;
    },
    updateUser: async (id: number, user: UserFormValues) => {
        const response = await apiClient.put<ApiResponse<User>>(`/user/${id}`, user);
        return response.data;
    },
    deleteUser: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<User>>(`/user/${id}`);
        return response.data;
    },
    deleteUsers: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<User>>(`/user`, { ids });
        return response.data;
    }
}
