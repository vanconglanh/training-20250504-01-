using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Business.Info.Common;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Info
{
    [BindProperties]
    public class OrderFilter: BaseFilterInfo
    {
        // Id
        public int? Id { get; set; } = null;

        // Name
        public string? Name { get; set; } = null;

        // ExchangeRateUsdVndBuy
        public decimal? ExchangeRateUsdVndBuy { get; set; } = null;

        // ExchangeRateUsdVndSell
        public decimal? ExchangeRateUsdVndSell { get; set; } = null;

        // TransportMethod
        public int? TransportMethod { get; set; } = null;

        // PackingMethod
        public int? PackingMethod { get; set; } = null;

        // WeightPerContainer
        public string? WeightPerContainer { get; set; } = null;

        // EstimatedTotalContainer
        public decimal? EstimatedTotalContainers { get; set; } = null;

        // EstimatedTotalBookings
        public decimal? EstimatedTotalBookings { get; set; } = null;

        // BookingNoCode
        public string? BookingNoCode { get; set; } = null;

        // PackingDate
        public DateTime? PackingDate { get; set; } = null;

        // YardIn
        public string? YardIn { get; set; } = null;

        // TruckPlate
        public string? TruckPlate { get; set; } = null;

        // ContainerNo
        public string? ContainerNo { get; set; } = null;

        // SealNo
        public string? SealNo { get; set; } = null;

        // SupplierName
        public string? SupplierName { get; set; } = null;

        // TransportCompanyName
        public string? TransportCompanyName { get; set; } = null;

        // Quantity
        public decimal? Quantity { get; set; } = null;

        // CoatingCompanyName
        public string? CoatingCompanyName { get; set; } = null;

        // CoatedQuantity
        public decimal? CoatedQuantity { get; set; } = null;

        // ProductUnitPrice
        public decimal? ProductUnitPrice { get; set; } = null;

        // CoatedProductUnitPrice
        public decimal? CoatedProductUnitPrice { get; set; } = null;

        // TransportUnitPrice
        public decimal? TransportUnitPrice { get; set; } = null;

        // Invoice
        public string? Invoice { get; set; } = null;

        // PackingList
        public string? PackingList { get; set; } = null;

        // CertificateOfQuality
        public string? CertificateOfQuality { get; set; } = null;

        // ShippingInstruction
        public string? ShippingInstruction { get; set; } = null;

        // VerifiedGrossMass
        public string? VerifiedGrossMass { get; set; } = null;

        // TimberPackingDeclaration
        public string? TimberPackingDeclaration { get; set; } = null;

        // WeighingCostAtFactory
        public decimal? WeighingCostAtFactory { get; set; } = null;

        // LiftingCost
        public decimal? LiftingCost { get; set; } = null;

        // CreatedAt
        public DateTime? CreatedAt { get; set; } = null;

        // UpdatedAt
        public DateTime? UpdatedAt { get; set; } = null;

        // YukoFlag
        public int? YukoFlag { get; set; } = null;

        // CreatedUser
        public int? CreatedUser { get; set; } = null;

        // LastUpdateUser
        public int? LastUpdateUser { get; set; } = null;

        // LastUpdateProgram
        public string? LastUpdateProgram { get; set; } = null;

    }
}
