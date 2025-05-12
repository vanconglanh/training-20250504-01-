import { screenApi } from '@/apis/screen.api.ts';
import { Screen, ScreenFormValues, ScreenListResponse, ScreenParams } from '../types/screen.type';


export const screenService = {
  /**
   * Get a list of screens with pagination and filtering
   * @param params Query parameters for filtering and pagination
   * @returns Promise with paginated screen list
   */
  getScreens: async (params: ScreenParams): Promise<ScreenListResponse> => {
    try {
      const { data, meta } = await screenApi.getScreens(params);

      const result: ScreenListResponse = {
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
   * Get a single screen by ID (Mock version)
   * @param id Screen ID
   * @returns Mocked screen data
   */
  getScreenById: async (id: number): Promise<Screen> => {
    const { data } = await screenApi.getScreenById(id);
    if (!data) {
      throw new Error(`Screen with ID ${id} not found.`);
    }
    return data;
  },

  /**
   * Create a new screen (Mock version)
   * @param screenData Screen data to create
   */
  createScreen: async (screenData: ScreenFormValues): Promise<Screen> => {
    try {
      const { data } = await screenApi.createScreen(screenData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Update an existing screen (Mock version)
   * @param id Screen ID
   * @param screenData Screen data to update
   * @returns Mocked updated screen
   */
  updateScreen: async (id: number, screenData: ScreenFormValues): Promise<Screen> => {
    try {
      const { data } = await screenApi.updateScreen(id, screenData);
      if (!data) {
        throw new Error('Invalid response from server');
      }
      return data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete a screen by ID (Mock version)
   * @param id Screen ID
   */
  deleteScreen: async (id: number): Promise<void> => {
    try {
      await screenApi.deleteScreen(id);
    } catch (error) {
      throw error;
    }
  },

  /**
   * Delete multiple screens by their IDs
   * @param ids Array of screen IDs to delete
   */
  deleteScreens: async (ids: number[]): Promise<void> => {
    try {
      await screenApi.deleteScreens(ids);
    } catch (error) {
      throw error;
    }
  }
};

export default screenService;
    