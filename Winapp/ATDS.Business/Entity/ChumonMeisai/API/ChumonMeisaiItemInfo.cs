using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity
{
    public class ChumonMeisaiItemInfo : BaseInfo
    {
        //ChumonMeisaiId
        public int ChumonMeisaiId = 0;

        //ChumonId
        public int ChumonId = 0;

        //ChumonMeisaiNo
        public string ChumonMeisaiNo = "";

        //ShohinCode
        public string ShohinCode = "";

        //ShohinName
        public string ShohinName = "";

        //Suryo
        public decimal Suryo = 0;

        //Tanka
        public decimal? Tanka = 0;

        //Kingaku
        public decimal? Kingaku = 0;

        //Soryo
        public decimal? Soryo = 0;

        //ZeiRitsu
        public decimal? ZeiRitsu = 0;

        //GokeiKingaku
        public decimal? GokeiKingaku = 0;

        //YukoFlag
        public int YukoFlag = 0;


    }
}
