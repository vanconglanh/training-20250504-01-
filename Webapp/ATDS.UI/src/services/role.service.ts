import { roleApi } from '@/apis/role.api.ts';
import { Role, RoleFormValues, RoleListResponse, RoleParams } from '../types/role.type';


export const roleService = {
  /**
   * Get a list of roles with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated role list
   */
  getRoles: async (params: RoleParams): Promise<RoleListResponse> => {
    try {
      const { data, meta } = await roleApi.getRoles(params);

      const result: RoleListResponse = {
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
   * Get a single role by ID (Mock version)
   * @param id Role ID
   * @returns Mocked role data
   */
  getRoleById: async (id: number): Promise<Role> => {
    const { data } = await roleApi.getRoleById(id);
    if (!data) {
      throw new Error(`Role with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new role (Mock version)
   * @param roleData Role data to create
   */
  createRole: async (roleData: RoleFormValues): Promise<Role> => {
    try {
      const { data } = await roleApi.createRole(roleData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing role (Mock version)
   * @param id Role ID
   * @param roleData Role data to update
   * @returns Mocked updated role
   */
  updateRole: async (id: number, roleData: RoleFormValues): Promise<Role> => {
    try {
      const { data } = await roleApi.updateRole(id, roleData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a role by ID (Mock version)
   * @param id Role ID
   */
  deleteRole: async (id: number): Promise<void> => {
    try {
      await roleApi.deleteRole(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple roles by their IDs
   * @param ids Array of role IDs to delete
   */
  deleteRoles: async (ids: number[]): Promise<void> => {
    try {
      await roleApi.deleteRoles(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default roleService;
    