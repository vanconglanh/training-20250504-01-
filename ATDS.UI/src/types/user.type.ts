import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// User type from database
export interface User {
      id: number;
      code: string;
      name: string;
      email: string;
      username: string;
      language: string;
      password: string;
      passwordHash: string;
      roleId: number;
      createdAt: string;
      updatedAt: string;
      yukoFlag: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// UserFormValuess will be used to create or update user
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type UserFormValues = Omit<
  User,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// UserParams extends SearchParams and Partial<UserFormValues>
export interface UserParams extends SearchParams, Partial<UserFormValues> {} 

// Can be extends fields from UserFormValues
// export interface UserParams extends SearchParams, Partial<UserFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface UserListResponse extends ListResponse<User> {}
 

