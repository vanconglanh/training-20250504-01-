import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// RolePermission type from database
export interface RolePermission {
      id: number;
      roleId: number;
      permissionScreenId: number;
      code: string;
      createdAt: string;
      updatedAt: string;
      yukoFlag: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// RolePermissionFormValuess will be used to create or update rolePermission
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type RolePermissionFormValues = Omit<
  RolePermission,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// RolePermissionParams extends SearchParams and Partial<RolePermissionFormValues>
export interface RolePermissionParams extends SearchParams, Partial<RolePermissionFormValues> {} 

// Can be extends fields from RolePermissionFormValues
// export interface RolePermissionParams extends SearchParams, Partial<RolePermissionFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface RolePermissionListResponse extends ListResponse<RolePermission> {}
 

