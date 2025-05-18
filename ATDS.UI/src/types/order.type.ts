import { SearchParams } from "./common.type";
import { ListResponse } from "./http.type";

// Order type from database
export interface Order {
    id: number;
    name: string;
    exchangeRateUsdVndBuy: number;
    exchangeRateUsdVndSell: number;
    transportMethod: number;
    packingMethod: number;
    weightPerContainer: string;
    estimatedTotalContainers: number;
    estimatedTotalBookings: number;
    bookingNoCode: string;
    packingDate: string; // ISO date string
    yardIn: string;
    truckPlate: string;
    containerNo: string;
    sealNo: string;
    supplierName: string;
    transportCompanyName: string;
    quantity: number;
    coatingCompanyName: string;
    coatedQuantity: number;
    productUnitPrice: number;
    coatedProductUnitPrice: number;
    transportUnitPrice: number;
    invoice: string;
    packingList: string;
    certificateOfQuality: string;
    shippingInstruction: string;
    verifiedGrossMass: string;
    timberPackingDeclaration: string;
    weighingCostAtFactory: number;
    liftingCost: number;
    createdAt: string; 
    updatedAt: string; 
    yukoFlag: number;
    createdUser: number;
    lastUpdateUser: number;
    lastUpdateProgram: string;
}


// OrderFormValuess will be used to create or update Order
// OrderFormValues equal Order without some fields not needed (system fields) to be updated or created
export type OrderFormValues = Omit<
  Order,
  | 'id'
  | 'createdAt'
  | 'updatedAt'
  | 'lastUpdate'
  | 'lastUpdateUser'
  | 'lastUpdateProgram'
  | 'createdUser'
>;

// OrderParams extends SearchParams and Partial<OrderFormValues>
export interface OrderParams extends SearchParams, Partial<OrderFormValues> {} 

// Can be extends fields from OrderFormValues
// export interface OrderParams extends SearchParams, Partial<OrderFormValues> {
//   id?: number;
//   createdAt?: string;
// } 

// Format response from API
export interface OrderListResponse extends ListResponse<Order> {}