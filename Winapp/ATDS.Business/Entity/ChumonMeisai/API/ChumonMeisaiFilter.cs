using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Business.Entity.Common;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Entity
{
    [BindProperties]
    public class ChumonMeisaiFilter : BaseFilterInfo
    {
        //ChumonMeisaiId
        public int? ChumonMeisaiId { get; set; } = null;

        //ChumonId
        public int? ChumonId { get; set; } = null;

        //ChumonMeisaiNo
        public string? ChumonMeisaiNo { get; set; } = null;

        //ShohinCode
        public string? ShohinCode { get; set; } = null;

        //ShohinName
        public string? ShohinName { get; set; } = null;

        //Suryo
        public decimal? Suryo { get; set; } = null;

        //Tanka
        public decimal? Tanka { get; set; } = null;

        //Kingaku
        public decimal? Kingaku { get; set; } = null;

        //Soryo
        public decimal? Soryo { get; set; } = null;

        //ZeiRitsu
        public decimal? ZeiRitsu { get; set; } = null;

        //GokeiKingaku
        public decimal? GokeiKingaku { get; set; } = null;

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
