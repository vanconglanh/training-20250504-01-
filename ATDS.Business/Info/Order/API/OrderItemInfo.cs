using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class OrderItemInfo : BaseInfo
    {
        // Id
        public int Id = 0;

        // Name
        public string? Name = "";

        // ExchangeRateUsdVndBuy
        public decimal? ExchangeRateUsdVndBuy = 0;

        // ExchangeRateUsdVndSell
        public decimal? ExchangeRateUsdVndSell = 0;

        // TransportMethod
        public int? TransportMethod = 0;

        // PackingMethod
        public int? PackingMethod = 0;

        // WeightPerContainer
        public string? WeightPerContainer = "";

        // EstimatedTotalContainer
        public decimal? EstimatedTotalContainers = 0;

        // EstimatedTotalBookings
        public decimal? EstimatedTotalBookings = 0;

        // BookingNoCode
        public string? BookingNoCode = "";

        // PackingDate
        public DateTime? PackingDate = null;

        // YardIn
        public string? YardIn = "";

        // TruckPlate
        public string? TruckPlate = "";

        // ContainerNo
        public string? ContainerNo = "";

        // SealNo
        public string? SealNo = "";

        // SupplierName
        public string? SupplierName = "";

        // TransportCompanyName
        public string? TransportCompanyName = "";

        // Quantity
        public decimal? Quantity = 0;

        // CoatingCompanyName
        public string? CoatingCompanyName = "";

        // CoatedQuantity
        public decimal? CoatedQuantity = 0;

        // ProductUnitPrice
        public decimal? ProductUnitPrice = 0;

        // CoatedProductUnitPrice
        public decimal? CoatedProductUnitPrice = 0;

        // TransportUnitPrice
        public decimal? TransportUnitPrice = 0;

        // Invoice
        public string? Invoice = "";

        // PackingList
        public string? PackingList = "";

        // CertificateOfQuality
        public string? CertificateOfQuality = "";

        // ShippingInstruction
        public string? ShippingInstruction = "";

        // VerifiedGrossMass
        public string? VerifiedGrossMass = "";

        // TimberPackingDeclaration
        public string? TimberPackingDeclaration = "";

        // WeighingCostAtFactory
        public decimal? WeighingCostAtFactory = 0;

        // LiftingCost
        public decimal? LiftingCost = 0;

        // CreatedAt
        public DateTime? CreatedAt = null;

        // UpdatedAt
        public DateTime? UpdatedAt = null;

        // YukoFlag
        public int? YukoFlag = 0;

        // CreatedUser
        public int? CreatedUser = 0;

        // LastUpdateUser
        public int? LastUpdateUser = 0;

        // LastUpdateProgram
        public string? LastUpdateProgram = "";
    }
}
