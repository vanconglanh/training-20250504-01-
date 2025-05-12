import { permissionScreenApi } from '@/apis/permissionScreen.api.ts';
import { PermissionScreen, PermissionScreenFormValues, PermissionScreenListResponse, PermissionScreenParams } from '../types/permissionScreen.type';


export const permissionScreenService = {
  /**
   * Get a list of permissionScreens with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated permissionScreen list
   */
  getPermissionScreens: async (params: PermissionScreenParams): Promise<PermissionScreenListResponse> => {
    try {
      const { data, meta } = await permissionScreenApi.getPermissionScreens(params);

      const result: PermissionScreenListResponse = {
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
   * Get a single permissionScreen by ID (Mock version)
   * @param id PermissionScreen ID
   * @returns Mocked permissionScreen data
   */
  getPermissionScreenById: async (id: number): Promise<PermissionScreen> => {
    const { data } = await permissionScreenApi.getPermissionScreenById(id);
    if (!data) {
      throw new Error(`PermissionScreen with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new permissionScreen (Mock version)
   * @param permissionScreenData PermissionScreen data to create
   */
  createPermissionScreen: async (permissionScreenData: PermissionScreenFormValues): Promise<PermissionScreen> => {
    try {
      const { data } = await permissionScreenApi.createPermissionScreen(permissionScreenData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing permissionScreen (Mock version)
   * @param id PermissionScreen ID
   * @param permissionScreenData PermissionScreen data to update
   * @returns Mocked updated permissionScreen
   */
  updatePermissionScreen: async (id: number, permissionScreenData: PermissionScreenFormValues): Promise<PermissionScreen> => {
    try {
      const { data } = await permissionScreenApi.updatePermissionScreen(id, permissionScreenData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a permissionScreen by ID (Mock version)
   * @param id PermissionScreen ID
   */
  deletePermissionScreen: async (id: number): Promise<void> => {
    try {
      await permissionScreenApi.deletePermissionScreen(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple permissionScreens by their IDs
   * @param ids Array of permissionScreen IDs to delete
   */
  deletePermissionScreens: async (ids: number[]): Promise<void> => {
    try {
      await permissionScreenApi.deletePermissionScreens(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default permissionScreenService;
    