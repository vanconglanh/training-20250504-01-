using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Business.Info;
using ATDS.Common.Utils;
using ATDS.DataAccess.Entity;

namespace ATDS.Business.Bussiness.Order
{
    public class OrderConvertFunction
    {
        #region Convert Object (Entry)
        public static OrderEntity ConvertToOrderEntity(OrderInsert vCls)
        {
            OrderEntity clsRet;

            try
            {
                clsRet = new OrderEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; // Id
                    withBlock.Name = vCls.Name; // Name
                    withBlock.ExchangeRateUsdVndBuy = vCls.ExchangeRateUsdVndBuy; // ExchangeRateUsdVndBuy
                    withBlock.ExchangeRateUsdVndSell = vCls.ExchangeRateUsdVndSell; // ExchangeRateUsdVndSell
                    withBlock.TransportMethod = vCls.TransportMethod; // TransportMethod
                    withBlock.PackingMethod = vCls.PackingMethod; // PackingMethod
                    withBlock.WeightPerContainer = vCls.WeightPerContainer; // WeightPerContainer
                    withBlock.EstimatedTotalContainers = vCls.EstimatedTotalContainers; // EstimatedTotalContainer
                    withBlock.EstimatedTotalBookings = vCls.EstimatedTotalBookings; // EstimatedTotalBookings
                    withBlock.BookingNoCode = vCls.BookingNoCode; // BookingNoCode
                    withBlock.PackingDate = vCls.PackingDate; // PackingDate
                    withBlock.YardIn = vCls.YardIn; // YardIn
                    withBlock.TruckPlate = vCls.TruckPlate; // TruckPlate
                    withBlock.ContainerNo = vCls.ContainerNo; // ContainerNo
                    withBlock.SealNo = vCls.SealNo; // SealNo
                    withBlock.SupplierName = vCls.SupplierName; // SupplierName
                    withBlock.TransportCompanyName = vCls.TransportCompanyName; // TransportCompanyName
                    withBlock.Quantity = vCls.Quantity; // Quantity
                    withBlock.CoatingCompanyName = vCls.CoatingCompanyName; // CoatingCompanyName
                    withBlock.CoatedQuantity = vCls.CoatedQuantity; // CoatedQuantity
                    withBlock.ProductUnitPrice = vCls.ProductUnitPrice; // ProductUnitPrice
                    withBlock.CoatedProductUnitPrice = vCls.CoatedProductUnitPrice; // CoatedProductUnitPrice
                    withBlock.TransportUnitPrice = vCls.TransportUnitPrice; // TransportUnitPrice
                    withBlock.Invoice = vCls.Invoice; // Invoice
                    withBlock.PackingList = vCls.PackingList; // PackingList
                    withBlock.CertificateOfQuality = vCls.CertificateOfQuality; // CertificateOfQuality
                    withBlock.ShippingInstruction = vCls.ShippingInstruction; // ShippingInstruction
                    withBlock.VerifiedGrossMass = vCls.VerifiedGrossMass; // VerifiedGrossMass
                    withBlock.TimberPackingDeclaration = vCls.TimberPackingDeclaration; // TimberPackingDeclaration
                    withBlock.WeighingCostAtFactory = vCls.WeighingCostAtFactory; // WeighingCostAtFactory
                    withBlock.LiftingCost = vCls.LiftingCost; // LiftingCost
                    withBlock.CreatedAt = vCls.CreatedAt; // CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; // UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; // YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; // CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; // LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; // LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static OrderEntity ConvertToOrderEntity(OrderUpdate vCls)
        {
            OrderEntity clsRet;

            try
            {
                clsRet = new OrderEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; // Id
                    withBlock.Name = vCls.Name; // Name
                    withBlock.ExchangeRateUsdVndBuy = vCls.ExchangeRateUsdVndBuy; // ExchangeRateUsdVndBuy
                    withBlock.ExchangeRateUsdVndSell = vCls.ExchangeRateUsdVndSell; // ExchangeRateUsdVndSell
                    withBlock.TransportMethod = vCls.TransportMethod; // TransportMethod
                    withBlock.PackingMethod = vCls.PackingMethod; // PackingMethod
                    withBlock.WeightPerContainer = vCls.WeightPerContainer; // WeightPerContainer
                    withBlock.EstimatedTotalContainers = vCls.EstimatedTotalContainers; // EstimatedTotalContainer
                    withBlock.EstimatedTotalBookings = vCls.EstimatedTotalBookings; // EstimatedTotalBookings
                    withBlock.BookingNoCode = vCls.BookingNoCode; // BookingNoCode
                    withBlock.PackingDate = vCls.PackingDate; // PackingDate
                    withBlock.YardIn = vCls.YardIn; // YardIn
                    withBlock.TruckPlate = vCls.TruckPlate; // TruckPlate
                    withBlock.ContainerNo = vCls.ContainerNo; // ContainerNo
                    withBlock.SealNo = vCls.SealNo; // SealNo
                    withBlock.SupplierName = vCls.SupplierName; // SupplierName
                    withBlock.TransportCompanyName = vCls.TransportCompanyName; // TransportCompanyName
                    withBlock.Quantity = vCls.Quantity; // Quantity
                    withBlock.CoatingCompanyName = vCls.CoatingCompanyName; // CoatingCompanyName
                    withBlock.CoatedQuantity = vCls.CoatedQuantity; // CoatedQuantity
                    withBlock.ProductUnitPrice = vCls.ProductUnitPrice; // ProductUnitPrice
                    withBlock.CoatedProductUnitPrice = vCls.CoatedProductUnitPrice; // CoatedProductUnitPrice
                    withBlock.TransportUnitPrice = vCls.TransportUnitPrice; // TransportUnitPrice
                    withBlock.Invoice = vCls.Invoice; // Invoice
                    withBlock.PackingList = vCls.PackingList; // PackingList
                    withBlock.CertificateOfQuality = vCls.CertificateOfQuality; // CertificateOfQuality
                    withBlock.ShippingInstruction = vCls.ShippingInstruction; // ShippingInstruction
                    withBlock.VerifiedGrossMass = vCls.VerifiedGrossMass; // VerifiedGrossMass
                    withBlock.TimberPackingDeclaration = vCls.TimberPackingDeclaration; // TimberPackingDeclaration
                    withBlock.WeighingCostAtFactory = vCls.WeighingCostAtFactory; // WeighingCostAtFactory
                    withBlock.LiftingCost = vCls.LiftingCost; // LiftingCost
                    withBlock.CreatedAt = vCls.CreatedAt; // CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; // UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; // YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; // CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; // LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; // LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }
        #endregion

        #region 【メソッド】 Convert Object (Search)

        public static OrderItemInfo ConvertToOrderItemInfo(OrderEntity vCls)
        {
            OrderItemInfo clsRet;

            try
            {
                clsRet = new OrderItemInfo();
                {
                    var withBlock = clsRet;

                    withBlock.Id = vCls.Id; // Id
                    withBlock.Name = vCls.Name; // Name
                    withBlock.ExchangeRateUsdVndBuy = vCls.ExchangeRateUsdVndBuy; // ExchangeRateUsdVndBuy
                    withBlock.ExchangeRateUsdVndSell = vCls.ExchangeRateUsdVndSell; // ExchangeRateUsdVndSell
                    withBlock.TransportMethod = vCls.TransportMethod; // TransportMethod
                    withBlock.PackingMethod = vCls.PackingMethod; // PackingMethod
                    withBlock.WeightPerContainer = vCls.WeightPerContainer; // WeightPerContainer
                    withBlock.EstimatedTotalContainers = vCls.EstimatedTotalContainers; // EstimatedTotalContainer
                    withBlock.EstimatedTotalBookings = vCls.EstimatedTotalBookings; // EstimatedTotalBookings
                    withBlock.BookingNoCode = vCls.BookingNoCode; // BookingNoCode
                    withBlock.PackingDate = vCls.PackingDate; // PackingDate
                    withBlock.YardIn = vCls.YardIn; // YardIn
                    withBlock.TruckPlate = vCls.TruckPlate; // TruckPlate
                    withBlock.ContainerNo = vCls.ContainerNo; // ContainerNo
                    withBlock.SealNo = vCls.SealNo; // SealNo
                    withBlock.SupplierName = vCls.SupplierName; // SupplierName
                    withBlock.TransportCompanyName = vCls.TransportCompanyName; // TransportCompanyName
                    withBlock.Quantity = vCls.Quantity; // Quantity
                    withBlock.CoatingCompanyName = vCls.CoatingCompanyName; // CoatingCompanyName
                    withBlock.CoatedQuantity = vCls.CoatedQuantity; // CoatedQuantity
                    withBlock.ProductUnitPrice = vCls.ProductUnitPrice; // ProductUnitPrice
                    withBlock.CoatedProductUnitPrice = vCls.CoatedProductUnitPrice; // CoatedProductUnitPrice
                    withBlock.TransportUnitPrice = vCls.TransportUnitPrice; // TransportUnitPrice
                    withBlock.Invoice = vCls.Invoice; // Invoice
                    withBlock.PackingList = vCls.PackingList; // PackingList
                    withBlock.CertificateOfQuality = vCls.CertificateOfQuality; // CertificateOfQuality
                    withBlock.ShippingInstruction = vCls.ShippingInstruction; // ShippingInstruction
                    withBlock.VerifiedGrossMass = vCls.VerifiedGrossMass; // VerifiedGrossMass
                    withBlock.TimberPackingDeclaration = vCls.TimberPackingDeclaration; // TimberPackingDeclaration
                    withBlock.WeighingCostAtFactory = vCls.WeighingCostAtFactory; // WeighingCostAtFactory
                    withBlock.LiftingCost = vCls.LiftingCost; // LiftingCost
                    withBlock.CreatedAt = vCls.CreatedAt; // CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; // UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; // YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; // CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; // LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; // LastUpdateProgram

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static string ConvertFilterToWhereCondition(OrderFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.Id != null)
                    where += " AND ID = @Id";
                if (filter.Name != null)
                    where += " AND NAME = @Name";
                if (filter.ExchangeRateUsdVndBuy != null)
                    where += " AND EXCHANGE_RATE_USD_VND_BUY = @ExchangeRateUsdVndBuy";
                if (filter.ExchangeRateUsdVndSell != null)
                    where += " AND EXCHANGE_RATE_USD_VND_SELL = @ExchangeRateUsdVndSell";
                if (filter.TransportMethod != null)
                    where += " AND TRANSPORT_METHOD = @TransportMethod";
                if (filter.PackingMethod != null)
                    where += " AND PACKING_METHOD = @PackingMethod";
                if (filter.WeightPerContainer != null)
                    where += " AND WEIGHT_PER_CONTAINER = @WeightPerContainer";
                if (filter.EstimatedTotalContainers != null)
                    where += " AND ESTIMATED_TOTAL_CONTAINERS = @EstimatedTotalContainers";
                if (filter.EstimatedTotalBookings != null)
                    where += " AND ESTIMATED_TOTAL_BOOKINGS = @EstimatedTotalBookings";
                if (filter.BookingNoCode != null)
                    where += " AND BOOKING_NO_CODE = @BookingNoCode";
                if (filter.PackingDate != null)
                    where += " AND PACKING_DATE = @PackingDate";
                if (filter.YardIn != null)
                    where += " AND YARD_IN = @YardIn";
                if (filter.TruckPlate != null)
                    where += " AND TRUCK_PLATE = @TruckPlate";
                if (filter.ContainerNo != null)
                    where += " AND CONTAINER_NO = @ContainerNo";
                if (filter.SealNo != null)
                    where += " AND SEAL_NO = @SealNo";
                if (filter.SupplierName != null)
                    where += " AND SUPPLIER_NAME = @SupplierName";
                if (filter.TransportCompanyName != null)
                    where += " AND TRANSPORT_COMPANY_NAME = @TransportCompanyName";
                if (filter.Quantity != null)
                    where += " AND QUANTITY = @Quantity";
                if (filter.CoatingCompanyName != null)
                    where += " AND COATING_COMPANY_NAME = @CoatingCompanyName";
                if (filter.CoatedQuantity != null)
                    where += " AND COATED_QUANTITY = @CoatedQuantity";
                if (filter.ProductUnitPrice != null)
                    where += " AND PRODUCT_UNIT_PRICE = @ProductUnitPrice";
                if (filter.CoatedProductUnitPrice != null)
                    where += " AND COATED_PRODUCT_UNIT_PRICE = @CoatedProductUnitPrice";
                if (filter.TransportUnitPrice != null)
                    where += " AND TRANSPORT_UNIT_PRICE = @TransportUnitPrice";
                if (filter.Invoice != null)
                    where += " AND INVOICE = @Invoice";
                if (filter.PackingList != null)
                    where += " AND PACKING_LIST = @PackingList";
                if (filter.CertificateOfQuality != null)
                    where += " AND CERTIFICATE_OF_QUALITY = @CertificateOfQuality";
                if (filter.ShippingInstruction != null)
                    where += " AND SHIPPING_INSTRUCTION = @ShippingInstruction";
                if (filter.VerifiedGrossMass != null)
                    where += " AND VERIFIED_GROSS_MASS = @VerifiedGrossMass";
                if (filter.TimberPackingDeclaration != null)
                    where += " AND TIMBER_PACKING_DECLARATION = @TimberPackingDeclaration";
                if (filter.WeighingCostAtFactory != null)
                    where += " AND WEIGHING_COST_AT_FACTORY = @WeighingCostAtFactory";
                if (filter.LiftingCost != null)
                    where += " AND LIFTING_COST = @LiftingCost";
                if (filter.CreatedAt != null)
                    where += " AND CREATED_AT = @CreatedAt";
                if (filter.UpdatedAt != null)
                    where += " AND UPDATED_AT = @UpdatedAt";
                if (filter.YukoFlag != null)
                    where += " AND YUKO_FLAG = @YukoFlag";
                if (filter.CreatedUser != null)
                    where += " AND CREATED_USER = @CreatedUser";
                if (filter.LastUpdateUser != null)
                    where += " AND LAST_UPDATE_USER = @LastUpdateUser";
                if (filter.LastUpdateProgram != null)
                    where += " AND LAST_UPDATE_PROGRAM = @LastUpdateProgram";
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }
        public static List<IDbDataParameter> ConvertFilterToParamsCondition(OrderFilter filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params

                if (filter.Id != null)
                    lstParameter.Add(DBUtils.CreateParam("@Id", filter.Id));
                if (filter.Name != null)
                    lstParameter.Add(DBUtils.CreateParam("@Name", filter.Name));
                if (filter.ExchangeRateUsdVndBuy != null)
                    lstParameter.Add(DBUtils.CreateParam("@ExchangeRateUsdVndBuy", filter.ExchangeRateUsdVndBuy));
                if (filter.ExchangeRateUsdVndSell != null)
                    lstParameter.Add(DBUtils.CreateParam("@ExchangeRateUsdVndSell", filter.ExchangeRateUsdVndSell));
                if (filter.TransportMethod != null)
                    lstParameter.Add(DBUtils.CreateParam("@TransportMethod", filter.TransportMethod));
                if (filter.PackingMethod != null)
                    lstParameter.Add(DBUtils.CreateParam("@PackingMethod", filter.PackingMethod));
                if (filter.WeightPerContainer != null)
                    lstParameter.Add(DBUtils.CreateParam("@WeightPerContainer", filter.WeightPerContainer));
                if (filter.EstimatedTotalContainers != null)
                    lstParameter.Add(DBUtils.CreateParam("@EstimatedTotalContainers", filter.EstimatedTotalContainers));
                if (filter.EstimatedTotalBookings != null)
                    lstParameter.Add(DBUtils.CreateParam("@EstimatedTotalBookings", filter.EstimatedTotalBookings));
                if (filter.BookingNoCode != null)
                    lstParameter.Add(DBUtils.CreateParam("@BookingNoCode", filter.BookingNoCode));
                if (filter.PackingDate != null)
                    lstParameter.Add(DBUtils.CreateParam("@PackingDate", filter.PackingDate));
                if (filter.YardIn != null)
                    lstParameter.Add(DBUtils.CreateParam("@YardIn", filter.YardIn));
                if (filter.TruckPlate != null)
                    lstParameter.Add(DBUtils.CreateParam("@TruckPlate", filter.TruckPlate));
                if (filter.ContainerNo != null)
                    lstParameter.Add(DBUtils.CreateParam("@ContainerNo", filter.ContainerNo));
                if (filter.SealNo != null)
                    lstParameter.Add(DBUtils.CreateParam("@SealNo", filter.SealNo));
                if (filter.SupplierName != null)
                    lstParameter.Add(DBUtils.CreateParam("@SupplierName", filter.SupplierName));
                if (filter.TransportCompanyName != null)
                    lstParameter.Add(DBUtils.CreateParam("@TransportCompanyName", filter.TransportCompanyName));
                if (filter.Quantity != null)
                    lstParameter.Add(DBUtils.CreateParam("@Quantity", filter.Quantity));
                if (filter.CoatingCompanyName != null)
                    lstParameter.Add(DBUtils.CreateParam("@CoatingCompanyName", filter.CoatingCompanyName));
                if (filter.CoatedQuantity != null)
                    lstParameter.Add(DBUtils.CreateParam("@CoatedQuantity", filter.CoatedQuantity));
                if (filter.ProductUnitPrice != null)
                    lstParameter.Add(DBUtils.CreateParam("@ProductUnitPrice", filter.ProductUnitPrice));
                if (filter.CoatedProductUnitPrice != null)
                    lstParameter.Add(DBUtils.CreateParam("@CoatedProductUnitPrice", filter.CoatedProductUnitPrice));
                if (filter.TransportUnitPrice != null)
                    lstParameter.Add(DBUtils.CreateParam("@TransportUnitPrice", filter.TransportUnitPrice));
                if (filter.Invoice != null)
                    lstParameter.Add(DBUtils.CreateParam("@Invoice", filter.Invoice));
                if (filter.PackingList != null)
                    lstParameter.Add(DBUtils.CreateParam("@PackingList", filter.PackingList));
                if (filter.CertificateOfQuality != null)
                    lstParameter.Add(DBUtils.CreateParam("@CertificateOfQuality", filter.CertificateOfQuality));
                if (filter.ShippingInstruction != null)
                    lstParameter.Add(DBUtils.CreateParam("@ShippingInstruction", filter.ShippingInstruction));
                if (filter.VerifiedGrossMass != null)
                    lstParameter.Add(DBUtils.CreateParam("@VerifiedGrossMass", filter.VerifiedGrossMass));
                if (filter.TimberPackingDeclaration != null)
                    lstParameter.Add(DBUtils.CreateParam("@TimberPackingDeclaration", filter.TimberPackingDeclaration));
                if (filter.WeighingCostAtFactory != null)
                    lstParameter.Add(DBUtils.CreateParam("@WeighingCostAtFactory", filter.WeighingCostAtFactory));
                if (filter.LiftingCost != null)
                    lstParameter.Add(DBUtils.CreateParam("@LiftingCost", filter.LiftingCost));
                if (filter.CreatedAt != null)
                    lstParameter.Add(DBUtils.CreateParam("@CreatedAt", filter.CreatedAt));
                if (filter.UpdatedAt != null)
                    lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", filter.UpdatedAt));
                if (filter.YukoFlag != null)
                    lstParameter.Add(DBUtils.CreateParam("@YukoFlag", filter.YukoFlag));
                if (filter.CreatedUser != null)
                    lstParameter.Add(DBUtils.CreateParam("@CreatedUser", filter.CreatedUser));
                if (filter.LastUpdateUser != null)
                    lstParameter.Add(DBUtils.CreateParam("@LastUpdateUser", filter.LastUpdateUser));
                if (filter.LastUpdateProgram != null)
                    lstParameter.Add(DBUtils.CreateParam("@LastUpdateProgram", filter.LastUpdateProgram));

            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }

        public static List<IDbDataParameter> ConvertOrderEntityToParams(OrderEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                lstParameter.Add(DBUtils.CreateParam("@Id", vCls.Id)); // Id
                lstParameter.Add(DBUtils.CreateParam("@Name", vCls.Name)); // Name
                lstParameter.Add(DBUtils.CreateParam("@ExchangeRateUsdVndBuy", vCls.ExchangeRateUsdVndBuy)); // ExchangeRateUsdVndBuy
                lstParameter.Add(DBUtils.CreateParam("@ExchangeRateUsdVndSell", vCls.ExchangeRateUsdVndSell)); // ExchangeRateUsdVndSell
                lstParameter.Add(DBUtils.CreateParam("@TransportMethod", vCls.TransportMethod)); // TransportMethod
                lstParameter.Add(DBUtils.CreateParam("@PackingMethod", vCls.PackingMethod)); // PackingMethod
                lstParameter.Add(DBUtils.CreateParam("@WeightPerContainer", vCls.WeightPerContainer)); // WeightPerContainer
                lstParameter.Add(DBUtils.CreateParam("@EstimatedTotalContainers", vCls.EstimatedTotalContainers)); // EstimatedTotalContainer
                lstParameter.Add(DBUtils.CreateParam("@EstimatedTotalBookings", vCls.EstimatedTotalBookings)); // EstimatedTotalBookings
                lstParameter.Add(DBUtils.CreateParam("@BookingNoCode", vCls.BookingNoCode)); // BookingNoCode
                lstParameter.Add(DBUtils.CreateParam("@PackingDate", vCls.PackingDate)); // PackingDate
                lstParameter.Add(DBUtils.CreateParam("@YardIn", vCls.YardIn)); // YardIn
                lstParameter.Add(DBUtils.CreateParam("@TruckPlate", vCls.TruckPlate)); // TruckPlate
                lstParameter.Add(DBUtils.CreateParam("@ContainerNo", vCls.ContainerNo)); // ContainerNo
                lstParameter.Add(DBUtils.CreateParam("@SealNo", vCls.SealNo)); // SealNo
                lstParameter.Add(DBUtils.CreateParam("@SupplierName", vCls.SupplierName)); // SupplierName
                lstParameter.Add(DBUtils.CreateParam("@TransportCompanyName", vCls.TransportCompanyName)); // TransportCompanyName
                lstParameter.Add(DBUtils.CreateParam("@Quantity", vCls.Quantity)); // Quantity
                lstParameter.Add(DBUtils.CreateParam("@CoatingCompanyName", vCls.CoatingCompanyName)); // CoatingCompanyName
                lstParameter.Add(DBUtils.CreateParam("@CoatedQuantity", vCls.CoatedQuantity)); // CoatedQuantity
                lstParameter.Add(DBUtils.CreateParam("@ProductUnitPrice", vCls.ProductUnitPrice)); // ProductUnitPrice
                lstParameter.Add(DBUtils.CreateParam("@CoatedProductUnitPrice", vCls.CoatedProductUnitPrice)); // CoatedProductUnitPrice
                lstParameter.Add(DBUtils.CreateParam("@TransportUnitPrice", vCls.TransportUnitPrice)); // TransportUnitPrice
                lstParameter.Add(DBUtils.CreateParam("@Invoice", vCls.Invoice)); // Invoice
                lstParameter.Add(DBUtils.CreateParam("@PackingList", vCls.PackingList)); // PackingList
                lstParameter.Add(DBUtils.CreateParam("@CertificateOfQuality", vCls.CertificateOfQuality)); // CertificateOfQuality
                lstParameter.Add(DBUtils.CreateParam("@ShippingInstruction", vCls.ShippingInstruction)); // ShippingInstruction
                lstParameter.Add(DBUtils.CreateParam("@VerifiedGrossMass", vCls.VerifiedGrossMass)); // VerifiedGrossMass
                lstParameter.Add(DBUtils.CreateParam("@TimberPackingDeclaration", vCls.TimberPackingDeclaration)); // TimberPackingDeclaration
                lstParameter.Add(DBUtils.CreateParam("@WeighingCostAtFactory", vCls.WeighingCostAtFactory)); // WeighingCostAtFactory
                lstParameter.Add(DBUtils.CreateParam("@LiftingCost", vCls.LiftingCost)); // LiftingCost
                lstParameter.Add(DBUtils.CreateParam("@CreatedAt", vCls.CreatedAt)); // CreatedAt
                lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", vCls.UpdatedAt)); // UpdatedAt
                lstParameter.Add(DBUtils.CreateParam("@YukoFlag", vCls.YukoFlag)); // YukoFlag
                lstParameter.Add(DBUtils.CreateParam("@CreatedUser", vCls.CreatedUser)); // CreatedUser
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateUser", vCls.LastUpdateUser)); // LastUpdateUser
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateProgram", vCls.LastUpdateProgram)); // LastUpdateProgram

            }
            catch (Exception)
            {
                throw;
            }

            return lstParameter;
        }
        #endregion
    }
}
