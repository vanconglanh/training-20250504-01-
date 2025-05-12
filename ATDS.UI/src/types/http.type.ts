export interface Pagination {
    total: number;
    page: number;
    size: number;
    pageCount: number;
    canNext: boolean;
    canPrev: boolean;
    [key: string]: any; 
  }
  

  
export interface ApiResponse<T> {
    meta?: Pagination;
    data: T;
}


export interface ListResponse<T> {
  total: number;
  page: number;
  size: number;
  data: T[];
}
