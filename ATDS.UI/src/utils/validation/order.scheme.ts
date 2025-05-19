// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const orderSchema = z.object({
    
    name: z.string().max(255, { message: t('validation.usernameMax') }),
    exchangeRateUsdVndBuy: z.number().min(0, { message: t('validation.exchangeRateUsdVndBuyMin') }),
    exchangeRateUsdVndSell: z.number().min(0, { message: t('validation.exchangeRateUsdVndSellMin') }),
    transportMethod: z.number().min(0, { message: t('validation.transportMethodMin') }),
    packingMethod: z.number().min(0, { message: t('validation.packingMethodMin') }),
    weightPerContainer: z.string().max(255, { message: t('validation.usernameMax') }),
    estimatedTotalContainers: z.number().min(0, { message: t('validation.estimatedTotalContainersMin') }),
    estimatedTotalBookings: z.number().min(0, { message: t('validation.estimatedTotalBookingsMin') }),
    bookingNoCode: z.string().max(255, { message: t('validation.usernameMax') }),
    packingDate: z.coerce.date(),
    yardIn: z.string().max(255, { message: t('validation.usernameMax') }),
    truckPlate: z.string().max(255, { message: t('validation.usernameMax') }),
    containerNo: z.string().max(255, { message: t('validation.usernameMax') }),
    sealNo: z.string().max(255, { message: t('validation.usernameMax') }),
    supplierName: z.string().max(255, { message: t('validation.usernameMax') }),
    transportCompanyName: z.string().max(255, { message: t('validation.usernameMax') }),
    quantity: z.number().min(0, { message: t('validation.quantityMin') }),
    coatingCompanyName: z.string().max(255, { message: t('validation.usernameMax') }),
    coatedQuantity: z.number().min(0, { message: t('validation.coatedQuantityMin') }),
    productUnitPrice: z.number().min(0, { message: t('validation.productUnitPriceMin') }),
    coatedProductUnitPrice: z.number().min(0, { message: t('validation.coatedProductUnitPriceMin') }),
    transportUnitPrice: z.number().min(0, { message: t('validation.transportUnitPriceMin') }),
    invoice: z.string().max(255, { message: t('validation.usernameMax') }),
    packingList: z.string().max(255, { message: t('validation.usernameMax') }),
    certificateOfQuality: z.string().max(255, { message: t('validation.usernameMax') }),
    shippingInstruction: z.string().max(255, { message: t('validation.usernameMax') }),
    verifiedGrossMass: z.string().max(255, { message: t('validation.usernameMax') }),
    timberPackingDeclaration: z.string().max(255, { message: t('validation.usernameMax') }),
    weighingCostAtFactory: z.number().min(0, { message: t('validation.weighingCostAtFactoryMin') }),
    liftingCost: z.number().min(0, { message: t('validation.liftingCostMin') }),
    status: z.number().min(0, { message: t('validation.statusMin') })

});

export const orderEditSchema = orderSchema.extend({
 
});

export type OrderValidationSchema = z.infer<typeof orderSchema>;
export type OrderEditValidationSchema = z.infer<typeof orderEditSchema>;