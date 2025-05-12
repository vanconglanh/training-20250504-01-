import apiClient from "@/config/httpClient";
import { ApiResponse } from "@/types/http.type";
import { Screen, ScreenFormValues, ScreenParams } from "@/types/screen.type";

export const screenApi = {
    getScreens: async (params: ScreenParams) => {
        const response =await apiClient.get<ApiResponse<Screen[]>>('/screen', { ...params });
        return response.data;
    },
    getScreenById: async (id: number) => {
        const response = await apiClient.get<ApiResponse<Screen>>(`/screen/${id}`);
        return response.data;
    },
    createScreen: async (screen: ScreenFormValues) => {
        const response = await apiClient.post<ApiResponse<Screen>>('/screen', screen);
        return response.data;
    },
    updateScreen: async (id: number, screen: ScreenFormValues) => {
        const response = await apiClient.put<ApiResponse<Screen>>(`/screen/${id}`, screen);
        return response.data;
    },
    deleteScreen: async (id: number) => {
        const response = await apiClient.delete<ApiResponse<Screen>>(`/screen/${id}`);
        return response.data;
    },
    deleteScreens: async (ids: number[]) => {
        const response = await apiClient.delete<ApiResponse<Screen>>(`/screen`, { ids });
        return response.data;
    }
}
