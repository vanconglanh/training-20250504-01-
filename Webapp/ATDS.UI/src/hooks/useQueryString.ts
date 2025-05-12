import { useCallback } from 'react';
import { useSearchParams } from 'react-router-dom';

/**
 * Custom hook for managing URL query parameters
 */
export const useQueryString = () => {
  const [searchParams, setSearchParams] = useSearchParams();

  /**
   * Get a query parameter value by key
   * @param key - The query parameter key
   * @param defaultValue - Default value if the parameter doesn't exist
   */
  const getParam = useCallback((key: string, defaultValue: string = '') => {
    return searchParams.get(key) || defaultValue;
  }, [searchParams]);

  /**
   * Set a query parameter value
   * @param key - The query parameter key
   * @param value - The value to set
   */
  const setParam = useCallback((key: string, value: string) => {
    const newSearchParams = new URLSearchParams(searchParams);
    if (value) {
      newSearchParams.set(key, value);
    } else {
      newSearchParams.delete(key);
    }
    setSearchParams(newSearchParams);
  }, [searchParams, setSearchParams]);

  /**
   * Set multiple query parameters at once
   * @param params - Object containing key-value pairs to set
   */
  const setParams = useCallback((params: Record<string, string>) => {
    const newSearchParams = new URLSearchParams(searchParams);
    
    Object.entries(params).forEach(([key, value]) => {
      if (value) {
        newSearchParams.set(key, value);
      } else {
        newSearchParams.delete(key);
      }
    });
    
    setSearchParams(newSearchParams);
  }, [searchParams, setSearchParams]);

  /**
   * Delete a query parameter
   * @param key - The query parameter key to delete
   */
  const deleteParam = useCallback((key: string) => {
    const newSearchParams = new URLSearchParams(searchParams);
    newSearchParams.delete(key);
    setSearchParams(newSearchParams);
  }, [searchParams, setSearchParams]);

  /**
   * Clear all query parameters
   */
  const clearParams = useCallback(() => {
    setSearchParams(new URLSearchParams());
  }, [setSearchParams]);

  return {
    getParam,
    setParam,
    setParams,
    deleteParam,
    clearParams,
    searchParams
  };
};