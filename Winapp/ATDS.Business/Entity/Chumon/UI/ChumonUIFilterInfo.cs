using ATDS.Business.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity
{
    public class ChumonUIFilterInfo : BaseFilterInfo
    {
        //ChumonId
        public int? ChumonId { get; set; } = null;

        //ChumonNo
        public string? ChumonNo { get; set; } = null;

        //ChumonDate
        public DateTime? ChumonDate { get; set; } = null;

        //HojinCode
        public string? HojinCode { get; set; } = null;

        //KonyuName
        public string? KonyuName { get; set; } = null;

        //KonyuMailAddress
        public string? KonyuMailAddress { get; set; } = null;

        //KonyuTantosha
        public string? KonyuTantosha { get; set; } = null;

        //KonyuKingaku1
        public decimal? KonyuKingaku1 { get; set; } = null;

        //KonyuKingaku2
        public decimal? KonyuKingaku2 { get; set; } = null;

        //KonyuKingaku3
        public decimal? KonyuKingaku3 { get; set; } = null;

        //Nebiki
        public decimal? Nebiki { get; set; } = null;

        //Soryo
        public decimal? Soryo { get; set; } = null;

        //Zei1
        public decimal? Zei1 { get; set; } = null;

        //ZeiRitsu1
        public decimal? ZeiRitsu1 { get; set; } = null;

        //Zei2
        public decimal? Zei2 { get; set; } = null;

        //ZeiRitsu2
        public decimal? ZeiRitsu2 { get; set; } = null;

        //Zei3
        public decimal? Zei3 { get; set; } = null;

        //ZeiRitsu3
        public decimal? ZeiRitsu3 { get; set; } = null;

        //GokeiKingaku
        public decimal? GokeiKingaku { get; set; } = null;

        //Status
        public int? Status { get; set; } = null;

        //YukoFlag
        public int? YukoFlag { get; set; } = null;

        //LastUpdateUser
        public string? LastUpdateUser { get; set; } = null;

        //LastUpdate
        public DateTime? LastUpdate { get; set; } = null;

        //LastUpdateProgram
        public string? LastUpdateProgram { get; set; } = null;


    }
}
