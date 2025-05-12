import { userApi } from '@/apis/user.api.ts';
import { User, UserFormValues, UserListResponse, UserParams } from '../types/user.type';


export const userService = {
  /**
   * Get a list of users with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated user list
   */
  getUsers: async (params: UserParams): Promise<UserListResponse> => {
    try {
      const { data, meta } = await userApi.getUsers(params);

      const result: UserListResponse = {
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
   * Get a single user by ID (Mock version)
   * @param id User ID
   * @returns Mocked user data
   */
  getUserById: async (id: number): Promise<User> => {
    const { data } = await userApi.getUserById(id);
    if (!data) {
      throw new Error(`User with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new user (Mock version)
   * @param userData User data to create
   */
  createUser: async (userData: UserFormValues): Promise<User> => {
    try {
      const { data } = await userApi.createUser(userData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing user (Mock version)
   * @param id User ID
   * @param userData User data to update
   * @returns Mocked updated user
   */
  updateUser: async (id: number, userData: UserFormValues): Promise<User> => {
    try {
      const { data } = await userApi.updateUser(id, userData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a user by ID (Mock version)
   * @param id User ID
   */
  deleteUser: async (id: number): Promise<void> => {
    try {
      await userApi.deleteUser(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple users by their IDs
   * @param ids Array of user IDs to delete
   */
  deleteUsers: async (ids: number[]): Promise<void> => {
    try {
      await userApi.deleteUsers(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default userService;
    