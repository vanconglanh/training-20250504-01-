using ATDS.Business.Entity;
using ATDS.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business
{
    public static class ChumonMeisaiConvertFunction
    {
        #region Convert Object (Entry)
        public static ChumonMeisaiUIInfo ConvertToChumonMeisaiUIInfo(ChumonMeisaiInfo vCls)
        {
            ChumonMeisaiUIInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdate = vCls.LastUpdate; //LastUpdate
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

        public static ChumonMeisaiInfo ConvertToChumonMeisaiInfo(ChumonMeisaiUIInfo vCls)
        {
            ChumonMeisaiInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdate = vCls.LastUpdate; //LastUpdate
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

    
        public static List<ChumonMeisaiUIInfo> ConvertToChumonMeisaiUIInfo(List<ChumonMeisaiInfo> vlstChumonMeisaiInfo)
        {
            ChumonMeisaiUIInfo clsRet;
            List<ChumonMeisaiUIInfo> ChumonMeisaiUIInfoList = new List<ChumonMeisaiUIInfo>();

            try
            {
                foreach(ChumonMeisaiInfo chumonMeisaiInfo in vlstChumonMeisaiInfo)
                {
                    clsRet = new ChumonMeisaiUIInfo();
                    {
                        var withBlock = clsRet;
                        withBlock.ChumonMeisaiId = chumonMeisaiInfo.ChumonMeisaiId; //ChumonMeisaiId
                        withBlock.ChumonId = chumonMeisaiInfo.ChumonId; //ChumonId
                        withBlock.ChumonMeisaiNo = chumonMeisaiInfo.ChumonMeisaiNo; //ChumonMeisaiNo
                        withBlock.ShohinCode = chumonMeisaiInfo.ShohinCode; //ShohinCode
                        withBlock.ShohinName = chumonMeisaiInfo.ShohinName; //ShohinName
                        withBlock.Suryo = chumonMeisaiInfo.Suryo; //Suryo
                        withBlock.Tanka = chumonMeisaiInfo.Tanka; //Tanka
                        withBlock.Kingaku = chumonMeisaiInfo.Kingaku; //Kingaku
                        withBlock.Soryo = chumonMeisaiInfo.Soryo; //Soryo
                        withBlock.ZeiRitsu = chumonMeisaiInfo.ZeiRitsu; //ZeiRitsu
                        withBlock.GokeiKingaku = chumonMeisaiInfo.GokeiKingaku; //GokeiKingaku
                        withBlock.YukoFlag = chumonMeisaiInfo.YukoFlag; //YukoFlag
                        withBlock.LastUpdateUser = chumonMeisaiInfo.LastUpdateUser; //LastUpdateUser
                        withBlock.LastUpdate = chumonMeisaiInfo.LastUpdate; //LastUpdate
                        withBlock.LastUpdateProgram = chumonMeisaiInfo.LastUpdateProgram; //LastUpdateProgram
                        ChumonMeisaiUIInfoList.Add(withBlock);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ChumonMeisaiUIInfoList;
        }


        public static ChumonMeisaiInfo ConvertToChumonMeisaiInfo(ChumonMeisaiInsertInfo vCls)
        {
            ChumonMeisaiInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdate = vCls.LastUpdate; //LastUpdate
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static ChumonMeisaiInfo ConvertToChumonMeisaiInfo(ChumonMeisaiUpdateInfo vCls)
        {
            ChumonMeisaiInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdate = vCls.LastUpdate; //LastUpdate
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static ChumonMeisaiInfo ConvertToChumonMeisaiInfo(ChumonMeisaiItemInfo vCls)
        {
            ChumonMeisaiInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdate = vCls.LastUpdate; //LastUpdate
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<SqlParameter> ConvertChumonMeisaiInfoToParams(ChumonMeisaiInfo vCls)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                    lstParameter.Add(new SqlParameter("@ChumonMeisaiId", vCls.ChumonMeisaiId));//ChumonMeisaiId
                    lstParameter.Add(new SqlParameter("@ChumonId", vCls.ChumonId));//ChumonId
                    lstParameter.Add(new SqlParameter("@ChumonMeisaiNo", vCls.ChumonMeisaiNo));//ChumonMeisaiNo
                    lstParameter.Add(new SqlParameter("@ShohinCode", vCls.ShohinCode));//ShohinCode
                    lstParameter.Add(new SqlParameter("@ShohinName", vCls.ShohinName));//ShohinName
                    lstParameter.Add(new SqlParameter("@Suryo", vCls.Suryo));//Suryo
                    lstParameter.Add(new SqlParameter("@Tanka", vCls.Tanka));//Tanka
                    lstParameter.Add(new SqlParameter("@Kingaku", vCls.Kingaku));//Kingaku
                    lstParameter.Add(new SqlParameter("@Soryo", vCls.Soryo));//Soryo
                    lstParameter.Add(new SqlParameter("@ZeiRitsu", vCls.ZeiRitsu));//ZeiRitsu
                    lstParameter.Add(new SqlParameter("@GokeiKingaku", vCls.GokeiKingaku));//GokeiKingaku
                    lstParameter.Add(new SqlParameter("@YukoFlag", vCls.YukoFlag));//YukoFlag
                    lstParameter.Add(new SqlParameter("@LastUpdateUser", vCls.LastUpdateUser));//LastUpdateUser
                    lstParameter.Add(new SqlParameter("@LastUpdate", vCls.LastUpdate));//LastUpdate
                    lstParameter.Add(new SqlParameter("@LastUpdateProgram", vCls.LastUpdateProgram));//LastUpdateProgram
                
            }
            catch (Exception)
            {
                throw;
            }

            return lstParameter;
         }
        #endregion


        #region 【メソッド】 Convert Object (Search)
        public static ChumonMeisaiItemInfo ConvertToChumonMeisaiItemInfo(ChumonMeisaiInfo vCls)
        {
            ChumonMeisaiItemInfo clsRet;

            try
            {
                clsRet = new ChumonMeisaiItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonMeisaiId = vCls.ChumonMeisaiId; //ChumonMeisaiId
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonMeisaiNo = vCls.ChumonMeisaiNo; //ChumonMeisaiNo
                    withBlock.ShohinCode = vCls.ShohinCode; //ShohinCode
                    withBlock.ShohinName = vCls.ShohinName; //ShohinName
                    withBlock.Suryo = vCls.Suryo; //Suryo
                    withBlock.Tanka = vCls.Tanka; //Tanka
                    withBlock.Kingaku = vCls.Kingaku; //Kingaku
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.ZeiRitsu = vCls.ZeiRitsu; //ZeiRitsu
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static  string ConvertFilterToWhereCondition(ChumonMeisaiFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.ChumonMeisaiId != null){
                        where += " AND CHUMON_MEISAI_ID = @ChumonMeisaiId";
                }
                if (filter.ChumonId != null){
                        where += " AND CHUMON_ID = @ChumonId";
                }
                if (filter.ChumonMeisaiNo != null){
                        where += " AND CHUMON_MEISAI_NO = @ChumonMeisaiNo";
                }
                if (filter.ShohinCode != null){
                        where += " AND SHOHIN_CODE = @ShohinCode";
                }
                if (filter.ShohinName != null){
                        where += " AND SHOHIN_NAME = @ShohinName";
                }
                if (filter.Suryo != null){
                        where += " AND SURYO = @Suryo";
                }
                if (filter.Tanka != null){
                        where += " AND TANKA = @Tanka";
                }
                if (filter.Kingaku != null){
                        where += " AND KINGAKU = @Kingaku";
                }
                if (filter.Soryo != null){
                        where += " AND SORYO = @Soryo";
                }
                if (filter.ZeiRitsu != null){
                        where += " AND ZEI_RITSU = @ZeiRitsu";
                }
                if (filter.GokeiKingaku != null){
                        where += " AND GOKEI_KINGAKU = @GokeiKingaku";
                }
                if (filter.YukoFlag != null){
                        where += " AND YUKO_FLAG = @YukoFlag";
                }
                if (filter.LastUpdateUser != null){
                        where += " AND LAST_UPDATE_USER = @LastUpdateUser";
                }
                if (filter.LastUpdate != null){
                        where += " AND LAST_UPDATE = @LastUpdate";
                }
                if (filter.LastUpdateProgram != null){
                        where += " AND LAST_UPDATE_PROGRAM = @LastUpdateProgram";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  string ConvertFilterToWhereCondition(ChumonMeisaiUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.ChumonMeisaiId != null){
                    where += " AND CHUMON_MEISAI_ID = @ChumonMeisaiId";
                }
                if (filter.ChumonId != null){
                    where += " AND CHUMON_ID = @ChumonId";
                }
                if (filter.ChumonMeisaiNo != null){
                    where += " AND CHUMON_MEISAI_NO = @ChumonMeisaiNo";
                }
                if (filter.ShohinCode != null){
                    where += " AND SHOHIN_CODE = @ShohinCode";
                }
                if (filter.ShohinName != null){
                    where += " AND SHOHIN_NAME = @ShohinName";
                }
                if (filter.Suryo != null){
                    where += " AND SURYO = @Suryo";
                }
                if (filter.Tanka != null){
                    where += " AND TANKA = @Tanka";
                }
                if (filter.Kingaku != null){
                    where += " AND KINGAKU = @Kingaku";
                }
                if (filter.Soryo != null){
                    where += " AND SORYO = @Soryo";
                }
                if (filter.ZeiRitsu != null){
                    where += " AND ZEI_RITSU = @ZeiRitsu";
                }
                if (filter.GokeiKingaku != null){
                    where += " AND GOKEI_KINGAKU = @GokeiKingaku";
                }
                if (filter.YukoFlag != null){
                    where += " AND YUKO_FLAG = @YukoFlag";
                }
                if (filter.LastUpdateUser != null){
                    where += " AND LAST_UPDATE_USER = @LastUpdateUser";
                }
                if (filter.LastUpdate != null){
                    where += " AND LAST_UPDATE = @LastUpdate";
                }
                if (filter.LastUpdateProgram != null){
                    where += " AND LAST_UPDATE_PROGRAM = @LastUpdateProgram";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  List<SqlParameter> ConvertFilterToParamsCondition(ChumonMeisaiFilter filter)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.ChumonMeisaiId != null ){
                lstParameter.Add(new SqlParameter("@ChumonMeisaiId", filter.ChumonMeisaiId));
            }
            if( filter.ChumonId != null ){
                lstParameter.Add(new SqlParameter("@ChumonId", filter.ChumonId));
            }
            if( filter.ChumonMeisaiNo != null ){
                lstParameter.Add(new SqlParameter("@ChumonMeisaiNo", filter.ChumonMeisaiNo));
            }
            if( filter.ShohinCode != null ){
                lstParameter.Add(new SqlParameter("@ShohinCode", filter.ShohinCode));
            }
            if( filter.ShohinName != null ){
                lstParameter.Add(new SqlParameter("@ShohinName", filter.ShohinName));
            }
            if( filter.Suryo != null ){
                lstParameter.Add(new SqlParameter("@Suryo", filter.Suryo));
            }
            if( filter.Tanka != null ){
                lstParameter.Add(new SqlParameter("@Tanka", filter.Tanka));
            }
            if( filter.Kingaku != null ){
                lstParameter.Add(new SqlParameter("@Kingaku", filter.Kingaku));
            }
            if( filter.Soryo != null ){
                lstParameter.Add(new SqlParameter("@Soryo", filter.Soryo));
            }
            if( filter.ZeiRitsu != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu", filter.ZeiRitsu));
            }
            if( filter.GokeiKingaku != null ){
                lstParameter.Add(new SqlParameter("@GokeiKingaku", filter.GokeiKingaku));
            }
            if( filter.YukoFlag != null ){
                lstParameter.Add(new SqlParameter("@YukoFlag", filter.YukoFlag));
            }
            if( filter.LastUpdateUser != null ){
                lstParameter.Add(new SqlParameter("@LastUpdateUser", filter.LastUpdateUser));
            }
            if( filter.LastUpdate != null ){
                lstParameter.Add(new SqlParameter("@LastUpdate", filter.LastUpdate));
            }
            if( filter.LastUpdateProgram != null ){
                lstParameter.Add(new SqlParameter("@LastUpdateProgram", filter.LastUpdateProgram));
            } 
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }

        public static List<SqlParameter> ConvertFilterToParamsCondition(ChumonMeisaiUIFilterInfo filter)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.ChumonMeisaiId != null ){
                lstParameter.Add(new SqlParameter("@ChumonMeisaiId", filter.ChumonMeisaiId));
            }
            if( filter.ChumonId != null ){
                lstParameter.Add(new SqlParameter("@ChumonId", filter.ChumonId));
            }
            if( filter.ChumonMeisaiNo != null ){
                lstParameter.Add(new SqlParameter("@ChumonMeisaiNo", filter.ChumonMeisaiNo));
            }
            if( filter.ShohinCode != null ){
                lstParameter.Add(new SqlParameter("@ShohinCode", filter.ShohinCode));
            }
            if( filter.ShohinName != null ){
                lstParameter.Add(new SqlParameter("@ShohinName", filter.ShohinName));
            }
            if( filter.Suryo != null ){
                lstParameter.Add(new SqlParameter("@Suryo", filter.Suryo));
            }
            if( filter.Tanka != null ){
                lstParameter.Add(new SqlParameter("@Tanka", filter.Tanka));
            }
            if( filter.Kingaku != null ){
                lstParameter.Add(new SqlParameter("@Kingaku", filter.Kingaku));
            }
            if( filter.Soryo != null ){
                lstParameter.Add(new SqlParameter("@Soryo", filter.Soryo));
            }
            if( filter.ZeiRitsu != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu", filter.ZeiRitsu));
            }
            if( filter.GokeiKingaku != null ){
                lstParameter.Add(new SqlParameter("@GokeiKingaku", filter.GokeiKingaku));
            }
            if( filter.YukoFlag != null ){
                lstParameter.Add(new SqlParameter("@YukoFlag", filter.YukoFlag));
            }
            if( filter.LastUpdateUser != null ){
                lstParameter.Add(new SqlParameter("@LastUpdateUser", filter.LastUpdateUser));
            }
            if( filter.LastUpdate != null ){
                lstParameter.Add(new SqlParameter("@LastUpdate", filter.LastUpdate));
            }
            if( filter.LastUpdateProgram != null ){
                lstParameter.Add(new SqlParameter("@LastUpdateProgram", filter.LastUpdateProgram));
            }    
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }


        #endregion
    }
}