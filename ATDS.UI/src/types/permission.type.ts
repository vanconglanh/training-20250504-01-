import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// Permission type from database
export interface Permission {
      id: number;
      code: string;
      name: string;
      createdAt: string;
      updatedAt: string;
      status: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// PermissionFormValuess will be used to create or update permission
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type PermissionFormValues = Omit<
  Permission,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// PermissionParams extends SearchParams and Partial<PermissionFormValues>
export interface PermissionParams extends SearchParams, Partial<PermissionFormValues> {} 

// Can be extends fields from PermissionFormValues
// export interface PermissionParams extends SearchParams, Partial<PermissionFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface PermissionListResponse extends ListResponse<Permission> {}
 

