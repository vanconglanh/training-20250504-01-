import { rolePermissionApi } from '@/apis/rolePermission.api.ts';
import { RolePermission, RolePermissionFormValues, RolePermissionListResponse, RolePermissionParams } from '../types/rolePermission.type';


export const rolePermissionService = {
  /**
   * Get a list of rolePermissions with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated rolePermission list
   */
  getRolePermissions: async (params: RolePermissionParams): Promise<RolePermissionListResponse> => {
    try {
      const { data, meta } = await rolePermissionApi.getRolePermissions(params);

      const result: RolePermissionListResponse = {
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
   * Get a single rolePermission by ID (Mock version)
   * @param id RolePermission ID
   * @returns Mocked rolePermission data
   */
  getRolePermissionById: async (id: number): Promise<RolePermission> => {
    const { data } = await rolePermissionApi.getRolePermissionById(id);
    if (!data) {
      throw new Error(`RolePermission with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new rolePermission (Mock version)
   * @param rolePermissionData RolePermission data to create
   */
  createRolePermission: async (rolePermissionData: RolePermissionFormValues): Promise<RolePermission> => {
    try {
      const { data } = await rolePermissionApi.createRolePermission(rolePermissionData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing rolePermission (Mock version)
   * @param id RolePermission ID
   * @param rolePermissionData RolePermission data to update
   * @returns Mocked updated rolePermission
   */
  updateRolePermission: async (id: number, rolePermissionData: RolePermissionFormValues): Promise<RolePermission> => {
    try {
      const { data } = await rolePermissionApi.updateRolePermission(id, rolePermissionData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a rolePermission by ID (Mock version)
   * @param id RolePermission ID
   */
  deleteRolePermission: async (id: number): Promise<void> => {
    try {
      await rolePermissionApi.deleteRolePermission(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple rolePermissions by their IDs
   * @param ids Array of rolePermission IDs to delete
   */
  deleteRolePermissions: async (ids: number[]): Promise<void> => {
    try {
      await rolePermissionApi.deleteRolePermissions(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default rolePermissionService;
    