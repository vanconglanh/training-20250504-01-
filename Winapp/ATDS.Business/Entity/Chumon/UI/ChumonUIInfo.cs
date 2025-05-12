using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity
{
    public class ChumonUIInfo : BaseInfo
    {
        //ChumonId
        public int ChumonId { get; set; } = 0;

        //ChumonNo
        public string ChumonNo { get; set; } = "";

        //ChumonDate
        public DateTime ChumonDate { get; set; } = default(DateTime);

        //HojinCode
        public string HojinCode { get; set; } = "";

        //KonyuName
        public string KonyuName { get; set; } = "";

        //KonyuMailAddress
        public string KonyuMailAddress { get; set; } = "";

        //KonyuTantosha
        public string KonyuTantosha { get; set; } = "";

        //KonyuKingaku1
        public decimal? KonyuKingaku1 { get; set; } = 0;

        //KonyuKingaku2
        public decimal? KonyuKingaku2 { get; set; } = 0;

        //KonyuKingaku3
        public decimal? KonyuKingaku3 { get; set; } = 0;

        //Nebiki
        public decimal? Nebiki { get; set; } = 0;

        //Soryo
        public decimal? Soryo { get; set; } = 0;

        //Zei1
        public decimal? Zei1 { get; set; } = 0;

        //ZeiRitsu1
        public decimal? ZeiRitsu1 { get; set; } = 0;

        //Zei2
        public decimal? Zei2 { get; set; } = 0;

        //ZeiRitsu2
        public decimal? ZeiRitsu2 { get; set; } = 0;

        //Zei3
        public decimal? Zei3 { get; set; } = 0;

        //ZeiRitsu3
        public decimal? ZeiRitsu3 { get; set; } = 0;

        //GokeiKingaku
        public decimal? GokeiKingaku { get; set; } = 0;

        //Status
        public int Status { get; set; } = 0;

        //YukoFlag
        public int YukoFlag { get; set; } = 0;


        //Foreign Table
        public List<ChumonMeisaiUIInfo> ChumonMeisaiList { get; set; } = new List<ChumonMeisaiUIInfo>();

    }
}
