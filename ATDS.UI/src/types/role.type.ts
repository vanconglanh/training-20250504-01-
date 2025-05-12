import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// Role type from database
export interface Role {
      id: number;
      code: string;
      name: string;
      isSystem: number;
      createdAt: string;
      updatedAt: string;
      yukoFlag: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// RoleFormValuess will be used to create or update role
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type RoleFormValues = Omit<
  Role,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// RoleParams extends SearchParams and Partial<RoleFormValues>
export interface RoleParams extends SearchParams, Partial<RoleFormValues> {} 

// Can be extends fields from RoleFormValues
// export interface RoleParams extends SearchParams, Partial<RoleFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface RoleListResponse extends ListResponse<Role> {}
 

