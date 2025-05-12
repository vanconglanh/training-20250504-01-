using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity
{
    public class ChumonMeisaiUIInfo : BaseInfo
    {
        //ChumonMeisaiId
        public int ChumonMeisaiId { get; set; } = 0;

        //ChumonId
        public int ChumonId { get; set; } = 0;

        //ChumonMeisaiNo
        public string ChumonMeisaiNo { get; set; } = "";

        //ShohinCode
        public string ShohinCode { get; set; } = "";

        //ShohinName
        public string ShohinName { get; set; } = "";

        //Suryo
        public decimal Suryo { get; set; } = 0;

        //Tanka
        public decimal? Tanka { get; set; } = 0;

        //Kingaku
        public decimal? Kingaku { get; set; } = 0;

        //Soryo
        public decimal? Soryo { get; set; } = 0;

        //ZeiRitsu
        public decimal? ZeiRitsu { get; set; } = 0;

        //GokeiKingaku
        public decimal? GokeiKingaku { get; set; } = 0;

        //YukoFlag
        public int YukoFlag { get; set; } = 0;


        //Foreign Table

    }
}
