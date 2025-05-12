import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// PermissionScreen type from database
export interface PermissionScreen {
      id: number;
      permissionId: number;
      screenId: number;
      code: string;
      createdAt: string;
      updatedAt: string;
      yukoFlag: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// PermissionScreenFormValuess will be used to create or update permissionScreen
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type PermissionScreenFormValues = Omit<
  PermissionScreen,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// PermissionScreenParams extends SearchParams and Partial<PermissionScreenFormValues>
export interface PermissionScreenParams extends SearchParams, Partial<PermissionScreenFormValues> {} 

// Can be extends fields from PermissionScreenFormValues
// export interface PermissionScreenParams extends SearchParams, Partial<PermissionScreenFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface PermissionScreenListResponse extends ListResponse<PermissionScreen> {}
 

