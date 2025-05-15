using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Info
{
    [BindProperties]
    public class OrderInsert: BaseInfo
    {
        // Id
        public int Id { get; set; } = 0;

        // Name
        public string? Name { get; set; } = "";

        // ExchangeRateUsdVndBuy
        public decimal? ExchangeRateUsdVndBuy { get; set; } = 0;

        // ExchangeRateUsdVndSell
        public decimal? ExchangeRateUsdVndSell { get; set; } = 0;

        // TransportMethod
        public int? TransportMethod { get; set; } = 0;

        // PackingMethod
        public int? PackingMethod { get; set; } = 0;

        // WeightPerContainer
        public string? WeightPerContainer { get; set; } = "";

        // EstimatedTotalContainer
        public decimal? EstimatedTotalContainers { get; set; } = 0;

        // EstimatedTotalBookings
        public decimal? EstimatedTotalBookings { get; set; } = 0;

        // BookingNoCode
        public string? BookingNoCode { get; set; } = "";

        // PackingDate
        public DateTime? PackingDate { get; set; } = null;

        // YardIn
        public string? YardIn { get; set; } = "";

        // TruckPlate
        public string? TruckPlate { get; set; } = "";

        // ContainerNo
        public string? ContainerNo { get; set; } = "";

        // SealNo
        public string? SealNo { get; set; } = "";

        // SupplierName
        public string? SupplierName { get; set; } = "";

        // TransportCompanyName
        public string? TransportCompanyName { get; set; } = "";

        // Quantity
        public decimal? Quantity { get; set; } = 0;

        // CoatingCompanyName
        public string? CoatingCompanyName { get; set; } = "";

        // CoatedQuantity
        public decimal? CoatedQuantity { get; set; } = 0;

        // ProductUnitPrice
        public decimal? ProductUnitPrice { get; set; } = 0;

        // CoatedProductUnitPrice
        public decimal? CoatedProductUnitPrice { get; set; } = 0;

        // TransportUnitPrice
        public decimal? TransportUnitPrice { get; set; } = 0;

        // Invoice
        public string? Invoice { get; set; } = "";

        // PackingList
        public string? PackingList { get; set; } = "";

        // CertificateOfQuality
        public string? CertificateOfQuality { get; set; } = "";

        // ShippingInstruction
        public string? ShippingInstruction { get; set; } = "";

        // VerifiedGrossMass
        public string? VerifiedGrossMass { get; set; } = "";

        // TimberPackingDeclaration
        public string? TimberPackingDeclaration { get; set; } = "";

        // WeighingCostAtFactory
        public decimal? WeighingCostAtFactory { get; set; } = 0;

        // LiftingCost
        public decimal? LiftingCost { get; set; } = 0;

        // CreatedAt
        public DateTime? CreatedAt { get; set; } = null;

        // UpdatedAt
        public DateTime? UpdatedAt { get; set; } = null;

        // YukoFlag
        public int? YukoFlag { get; set; } = 0;

        // CreatedUser
        public int? CreatedUser { get; set; } = 0;

        // LastUpdateUser
        public int? LastUpdateUser { get; set; } = 0;

        // LastUpdateProgram
        public string? LastUpdateProgram { get; set; } = "";

    }
}
