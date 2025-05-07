import { SortField } from "@/utils/validation/common.type";
import { ListResponse } from "./http.type";

// src/types/user.ts
export interface User {
  id: string;
  username: string;
  email: string;
  role: string;
  status: string;
  createdAt: string;
  updatedAt: string;
  lastUpdate: string;
  lastUpdateUser: string;
  lastUpdateProgram: string;
  passwordHash?: string;
  yukoFlag?: boolean;
}

export interface UserFormValues {
  username: string;
  email: string;
  role: string;
  status: string;
  password?: string;
}


export interface UserParams {
  page?: number;
  limit?: number;
  search?: string[];
  sortBy?: string;
  sortOrder?: 'asc' | 'desc';
  sortFields?: SortField[];
  status?: string;
  role?: string;
  username?: string;
  email?: string;
  dateRange?: {
    start: Date | null;
    end: Date | null;
  };
}

export interface UserListResponse extends ListResponse<User> {}
 

export interface UserSearchSuggestion {
  id: string;
  username: string;
  email: string;
  type: 'username' | 'email';
}

