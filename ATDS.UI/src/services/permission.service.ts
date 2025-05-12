import { permissionApi } from '@/apis/permission.api.ts';
import { Permission, PermissionFormValues, PermissionListResponse, PermissionParams } from '../types/permission.type';


export const permissionService = {
  /**
   * Get a list of permissions with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated permission list
   */
  getPermissions: async (params: PermissionParams): Promise<PermissionListResponse> => {
    try {
      const { data, meta } = await permissionApi.getPermissions(params);

      const result: PermissionListResponse = {
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
   * Get a single permission by ID (Mock version)
   * @param id Permission ID
   * @returns Mocked permission data
   */
  getPermissionById: async (id: number): Promise<Permission> => {
    const { data } = await permissionApi.getPermissionById(id);
    if (!data) {
      throw new Error(`Permission with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new permission (Mock version)
   * @param permissionData Permission data to create
   */
  createPermission: async (permissionData: PermissionFormValues): Promise<Permission> => {
    try {
      const { data } = await permissionApi.createPermission(permissionData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing permission (Mock version)
   * @param id Permission ID
   * @param permissionData Permission data to update
   * @returns Mocked updated permission
   */
  updatePermission: async (id: number, permissionData: PermissionFormValues): Promise<Permission> => {
    try {
      const { data } = await permissionApi.updatePermission(id, permissionData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a permission by ID (Mock version)
   * @param id Permission ID
   */
  deletePermission: async (id: number): Promise<void> => {
    try {
      await permissionApi.deletePermission(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple permissions by their IDs
   * @param ids Array of permission IDs to delete
   */
  deletePermissions: async (ids: number[]): Promise<void> => {
    try {
      await permissionApi.deletePermissions(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default permissionService;
    