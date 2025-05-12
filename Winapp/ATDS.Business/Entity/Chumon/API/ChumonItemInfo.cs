using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity
{
    public class ChumonItemInfo : BaseInfo
    {
        //ChumonId
        public int ChumonId = 0;

        //ChumonNo
        public string ChumonNo = "";

        //ChumonDate
        public DateTime ChumonDate = default(DateTime);

        //HojinCode
        public string HojinCode = "";

        //KonyuName
        public string KonyuName = "";

        //KonyuMailAddress
        public string KonyuMailAddress = "";

        //KonyuTantosha
        public string KonyuTantosha = "";

        //KonyuKingaku1
        public decimal? KonyuKingaku1 = 0;

        //KonyuKingaku2
        public decimal? KonyuKingaku2 = 0;

        //KonyuKingaku3
        public decimal? KonyuKingaku3 = 0;

        //Nebiki
        public decimal? Nebiki = 0;

        //Soryo
        public decimal? Soryo = 0;

        //Zei1
        public decimal? Zei1 = 0;

        //ZeiRitsu1
        public decimal? ZeiRitsu1 = 0;

        //Zei2
        public decimal? Zei2 = 0;

        //ZeiRitsu2
        public decimal? ZeiRitsu2 = 0;

        //Zei3
        public decimal? Zei3 = 0;

        //ZeiRitsu3
        public decimal? ZeiRitsu3 = 0;

        //GokeiKingaku
        public decimal? GokeiKingaku = 0;

        //Status
        public int Status = 0;

        //YukoFlag
        public int YukoFlag = 0;


    }
}
