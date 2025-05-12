import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// Screen type from database
export interface Screen {
      id: number;
      code: string;
      name: string;
      createdAt: string;
      updatedAt: string;
      yukoFlag: number;
      createdUser: number;
      lastUpdateUser: number;
      lastUpdateProgram: string;
}


// ScreenFormValuess will be used to create or update screen
// UserFormValues equal User without some fields not needed (system fields) to be updated or created
export type ScreenFormValues = Omit<
  Screen,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
  | 'code'
>;


// ScreenParams extends SearchParams and Partial<ScreenFormValues>
export interface ScreenParams extends SearchParams, Partial<ScreenFormValues> {} 

// Can be extends fields from ScreenFormValues
// export interface ScreenParams extends SearchParams, Partial<ScreenFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface ScreenListResponse extends ListResponse<Screen> {}
 

