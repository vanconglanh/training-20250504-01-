import { useCallback, useRef } from 'react';

/**
 * A custom hook that debounces a function call
 * @param callback The function to debounce
 * @param delay The delay in milliseconds
 * @returns A debounced version of the callback function
 */
export const useDebounce = <T extends (...args: any[]) => any>(
  callback: T,
  delay: number
): ((...args: Parameters<T>) => void) => {
  const timeoutRef = useRef<number | null>(null);

  return useCallback(
    (...args: Parameters<T>) => {
      if (timeoutRef.current) {
        window.clearTimeout(timeoutRef.current);
      }

      timeoutRef.current = window.setTimeout(() => {
        callback(...args);
      }, delay);
    },
    [callback, delay]
  );
}; 

