// import apiClient from '../config/httpClient';
// import { User, UserFormValues, UserListResponse, UserParams } from '../types/user.type';

// /**
//  * User Service contains all API calls related to user management
//  */
// export const userService = {
//   /**
//    * Get a list of users with pagination and filtering
//    * @param params Query parameters for filtering and pagination
//    * @returns Promise with paginated user list
//    */
//   getUsers: async (params: UserParams): Promise<UserListResponse> => {
//     const response = await apiClient.get<UserListResponse>('/users', params);
//     return response.data;
//   },

//   /**
//    * Get a single user by ID
//    * @param id User ID
//    * @returns Promise with user data
//    */
//   getUserById: async (id: string): Promise<User> => {
//     const response = await apiClient.get<User>(`/users/${id}`);
//     return response.data;
//   },

//   /**
//    * Create a new user
//    * @param userData User data to create
//    * @returns Promise with created user
//    */
//   createUser: async (userData: UserFormValues): Promise<User> => {
//     const response = await apiClient.post<User>('/users', userData);
//     return response.data;
//   },

//   /**
//    * Update an existing user
//    * @param id User ID
//    * @param userData User data to update
//    * @returns Promise with updated user
//    */
//   updateUser: async (id: string, userData: UserFormValues): Promise<User> => {
//     const response = await apiClient.put<User>(`/users/${id}`, userData);
//     return response.data;
//   },

//   /**
//    * Delete a user by ID
//    * @param id User ID
//    * @returns Promise with success status
//    */
//   deleteUser: async (id: string): Promise<void> => {
//     await apiClient.delete(`/users/${id}`);
//   },
// };

// export default userService;

import { User, UserFormValues, UserListResponse, UserParams, UserSearchSuggestion } from '../types/user.type';
import { mockUsers } from './mock';

// Debounce function
const debounce = <T extends (...args: any[]) => Promise<any>>(
  func: T,
  wait: number
): ((...args: Parameters<T>) => Promise<Awaited<ReturnType<T>>>) => {
  let timeout: number | undefined;
  return (...args: Parameters<T>) => {
    return new Promise((resolve) => {
      if (timeout) {
        window.clearTimeout(timeout);
      }
      timeout = window.setTimeout(async () => {
        const result = await func(...args);
        resolve(result);
      }, wait);
    });
  };
};

// Enhanced logging helper
const logApiRequest = (endpoint: string, method: string, params: any) => {
  console.group(`%cAPI Request: ${method} ${endpoint}`, 'color: #2196F3; font-weight: bold');
  console.log('%cParams:', 'color: #4CAF50; font-weight: bold', params);
  console.log('%cTimestamp:', 'color: #FF9800', new Date().toISOString());
  console.groupEnd();
};

const logApiResponse = (endpoint: string, response: any) => {
  console.group(`%cAPI Response: ${endpoint}`, 'color: #4CAF50; font-weight: bold');
  console.log('%cData:', 'color: #2196F3; font-weight: bold', response);
  console.log('%cTimestamp:', 'color: #FF9800', new Date().toISOString());
  console.groupEnd();
};

const logApiError = (endpoint: string, error: any) => {
  console.group(`%cAPI Error: ${endpoint}`, 'color: #F44336; font-weight: bold');
  console.error('%cError:', 'color: #F44336; font-weight: bold', error);
  console.log('%cTimestamp:', 'color: #FF9800', new Date().toISOString());
  console.groupEnd();
};

export const userService = {
  /**
   * Get a list of users with pagination and filtering (Mock version)
   * @param params Query parameters for filtering and pagination
   * @returns Mocked paginated user list
   */
  getUsers: async (params: UserParams): Promise<UserListResponse> => {
    try {
      logApiRequest('/users', 'GET', params);

      // Apply all filters
      let filteredUsers = [...mockUsers];

      // Search filter
      if (params.search?.length) {
        const searchTerms = params.search.map(term => term.toLowerCase());
        filteredUsers = filteredUsers.filter(user =>
          searchTerms.some(term =>
            user.username.toLowerCase().includes(term) ||
            user.email.toLowerCase().includes(term)
          )
        );
      }

      if (params.status) {
        filteredUsers = filteredUsers.filter(
          user => user.status.toLowerCase() === params.status?.toLowerCase()
        );
      }
      
      if (params.role) {
        filteredUsers = filteredUsers.filter(
          user => user.role.toLowerCase() === params.role?.toLowerCase()
        );
      }

      // Username filter
      if (params.username) {
        filteredUsers = filteredUsers.filter(user => 
          user.username.toLowerCase().includes(params.username!.toLowerCase())
        );
      }

      // Email filter
      if (params.email) {
        filteredUsers = filteredUsers.filter(user => 
          user.email.toLowerCase().includes(params.email!.toLowerCase())
        );
      }

      // Sort
      if (params.sortFields?.length) {
        filteredUsers.sort((a, b) => {
          for (const sort of params.sortFields!) {
            const aValue = a[sort.field as keyof User];
            const bValue = b[sort.field as keyof User];
            
            if (aValue === bValue) continue;
            
            const order = sort.order === 'desc' ? -1 : 1;
            
            if (typeof aValue === 'string' && typeof bValue === 'string') {
              const comparison = aValue.localeCompare(bValue);
              if (comparison !== 0) return order * comparison;
            }
          }
          return 0;
        });
      } else if (params.sortBy) {
        filteredUsers.sort((a, b) => {
          const aValue = a[params.sortBy as keyof User];
          const bValue = b[params.sortBy as keyof User];
          const order = params.sortOrder === 'desc' ? -1 : 1;
          
          if (typeof aValue === 'string' && typeof bValue === 'string') {
            return order * aValue.localeCompare(bValue);
          }
          return 0;
        });
      }

      // Pagination
      const start = (params.page || 0) * (params.limit || 10);
      const end = start + (params.limit || 10);
      const paginatedUsers = filteredUsers.slice(start, end);

      const response = {
        data: paginatedUsers,
        total: filteredUsers.length,
        page: params.page || 0,
        limit: params.limit || 10,
      };

      logApiResponse('/users', {
        total: response.total,
        page: response.page,
        limit: response.limit,
        dataSample: response.data.slice(0, 2),
        appliedFilters: {
          search: params.search,
          status: params.status,
          role: params.role,
          username: params.username,
          email: params.email,
          sort: params.sortFields || { field: params.sortBy, order: params.sortOrder }
        }
      });

      return response;
    } catch (error) {
      logApiError('/users', error);
      throw error;
    }
  },

  /**
   * Get search suggestions (Mock version)
   * @param searchTerm Search term for suggestions
   * @returns Promise with search suggestions
   */
  getSearchSuggestions: async (searchTerm: string): Promise<UserSearchSuggestion[]> => {
    // Log API request
    logApiRequest('/users/suggestions', 'GET', { searchTerm });

    // Simulate API delay
    await new Promise(resolve => setTimeout(resolve, 300));

    if (!searchTerm) return [];
    
    const searchLower = searchTerm.toLowerCase();
    const suggestions: UserSearchSuggestion[] = [];
    
    // Check username matches
    const usernameMatches = mockUsers
      .filter(user => user.username.toLowerCase().includes(searchLower))
      .map(user => ({
        id: user.id,
        username: user.username,
        email: user.email,
        type: 'username' as const
      }));
    
    // Check email matches
    const emailMatches = mockUsers
      .filter(user => user.email.toLowerCase().includes(searchLower))
      .map(user => ({
        id: user.id,
        username: user.username,
        email: user.email,
        type: 'email' as const
      }));

    // Combine and deduplicate results
    const seen = new Set<string>();
    [...usernameMatches, ...emailMatches].forEach(suggestion => {
      if (!seen.has(suggestion.id)) {
        seen.add(suggestion.id);
        suggestions.push(suggestion);
      }
    });

    // Limit to 5 suggestions
    const limitedSuggestions = suggestions.slice(0, 5);

    // Log API response
    console.group('Mock API Response');
    console.log('Suggestions:', limitedSuggestions);
    console.groupEnd();

    return limitedSuggestions;
  },

  /**
   * Get a single user by ID (Mock version)
   * @param id User ID
   * @returns Mocked user data
   */
  getUserById: async (id: string): Promise<User> => {
    const user = mockUsers.find(user => user.id === id);
    if (!user) {
      throw new Error(`User with ID ${id} not found.`);
    }
    return user;
  },

  /**
   * Create a new user (Mock version)
   * @param userData User data to create
   * @returns Mocked created user
   */
  createUser: async (userData: UserFormValues): Promise<User> => {
    const newUser: User = {
      ...userData,
      id: (mockUsers.length + 1).toString(), // Mock ID generation
      passwordHash: 'hashedPassword123', // Simulated hashed password
      createdAt: new Date().toISOString(),
      updatedAt: new Date().toISOString(),
      lastUpdate: new Date().toISOString(),
      lastUpdateUser: 'admin',
      lastUpdateProgram: 'user-service',
    };
    mockUsers.push(newUser);
    return newUser;
  },

  /**
   * Update an existing user (Mock version)
   * @param id User ID
   * @param userData User data to update
   * @returns Mocked updated user
   */
  updateUser: async (id: string, userData: UserFormValues): Promise<User> => {
    const index = mockUsers.findIndex(user => user.id === id);
    if (index === -1) {
      throw new Error(`User with ID ${id} not found.`);
    }
    const updatedUser = { ...mockUsers[index], ...userData };
    mockUsers[index] = updatedUser;
    return updatedUser;
  },

  /**
   * Delete a user by ID (Mock version)
   * @param id User ID
   * @returns Mocked success status
   */
  deleteUser: async (id: string): Promise<void> => {
    const index = mockUsers.findIndex(user => user.id === id);
    if (index === -1) {
      throw new Error(`User with ID ${id} not found.`);
    }
    mockUsers.splice(index, 1); // Remove user from mock array
  },

  /**
   * Debounced version of getSearchSuggestions
   * @param searchTerm Search term for suggestions
   * @returns Promise with search suggestions
   */
  debouncedGetSearchSuggestions: debounce(
    async (searchTerm: string): Promise<UserSearchSuggestion[]> => {
      return userService.getSearchSuggestions(searchTerm);
    },
    300
  ),

  /**
   * Get search suggestions by type (Mock version)
   * @param searchTerm Search term for suggestions
   * @param type Type of suggestion to search for ('username' | 'email')
   * @returns Promise with search suggestions
   */
  getSearchSuggestionsByType: async (searchTerm: string, type: 'username' | 'email'): Promise<UserSearchSuggestion[]> => {
    try {
      logApiRequest('/users/suggestions', 'GET', { searchTerm, type });

      // Simulate API delay
      await new Promise(resolve => setTimeout(resolve, 300));

      if (!searchTerm) return [];
      
      const searchLower = searchTerm.toLowerCase();
      
      const matches = mockUsers
        .filter(user => {
          const fieldValue = type === 'username' ? user.username : user.email;
          return fieldValue.toLowerCase().includes(searchLower);
        })
        .map(user => ({
          id: user.id,
          username: user.username,
          email: user.email,
          type
        }))
        .slice(0, 5);

      logApiResponse('/users/suggestions', {
        type,
        searchTerm,
        suggestionsCount: matches.length,
        suggestions: matches
      });

      return matches;
    } catch (error) {
      logApiError('/users/suggestions', error);
      throw error;
    }
  },

  /**
   * Debounced version of getSearchSuggestionsByType
   */
  debouncedGetSearchSuggestionsByType: debounce(
    async (searchTerm: string, type: 'username' | 'email'): Promise<UserSearchSuggestion[]> => {
      return userService.getSearchSuggestionsByType(searchTerm, type);
    },
    300
  ),
};

export default userService;
  