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
    public static class ChumonConvertFunction
    {
        #region Convert Object (Entry)
        public static ChumonUIInfo ConvertToChumonUIInfo(ChumonInfo vCls)
        {
            ChumonUIInfo clsRet;

            try
            {
                clsRet = new ChumonUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
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

        public static ChumonInfo ConvertToChumonInfo(ChumonUIInfo vCls)
        {
            ChumonInfo clsRet;

            try
            {
                clsRet = new ChumonInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
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

    

        public static ChumonInfo ConvertToChumonInfo(ChumonInsertInfo vCls)
        {
            ChumonInfo clsRet;

            try
            {
                clsRet = new ChumonInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
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

        public static ChumonInfo ConvertToChumonInfo(ChumonUpdateInfo vCls)
        {
            ChumonInfo clsRet;

            try
            {
                clsRet = new ChumonInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
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

        public static ChumonInfo ConvertToChumonInfo(ChumonItemInfo vCls)
        {
            ChumonInfo clsRet;

            try
            {
                clsRet = new ChumonInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
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

        public static List<SqlParameter> ConvertChumonInfoToParams(ChumonInfo vCls)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                    lstParameter.Add(new SqlParameter("@ChumonId", vCls.ChumonId));//ChumonId
                    lstParameter.Add(new SqlParameter("@ChumonNo", vCls.ChumonNo));//ChumonNo
                    lstParameter.Add(new SqlParameter("@ChumonDate", vCls.ChumonDate));//ChumonDate
                    lstParameter.Add(new SqlParameter("@HojinCode", vCls.HojinCode));//HojinCode
                    lstParameter.Add(new SqlParameter("@KonyuName", vCls.KonyuName));//KonyuName
                    lstParameter.Add(new SqlParameter("@KonyuMailAddress", vCls.KonyuMailAddress));//KonyuMailAddress
                    lstParameter.Add(new SqlParameter("@KonyuTantosha", vCls.KonyuTantosha));//KonyuTantosha
                    lstParameter.Add(new SqlParameter("@KonyuKingaku1", vCls.KonyuKingaku1));//KonyuKingaku1
                    lstParameter.Add(new SqlParameter("@KonyuKingaku2", vCls.KonyuKingaku2));//KonyuKingaku2
                    lstParameter.Add(new SqlParameter("@KonyuKingaku3", vCls.KonyuKingaku3));//KonyuKingaku3
                    lstParameter.Add(new SqlParameter("@Nebiki", vCls.Nebiki));//Nebiki
                    lstParameter.Add(new SqlParameter("@Soryo", vCls.Soryo));//Soryo
                    lstParameter.Add(new SqlParameter("@Zei1", vCls.Zei1));//Zei1
                    lstParameter.Add(new SqlParameter("@ZeiRitsu1", vCls.ZeiRitsu1));//ZeiRitsu1
                    lstParameter.Add(new SqlParameter("@Zei2", vCls.Zei2));//Zei2
                    lstParameter.Add(new SqlParameter("@ZeiRitsu2", vCls.ZeiRitsu2));//ZeiRitsu2
                    lstParameter.Add(new SqlParameter("@Zei3", vCls.Zei3));//Zei3
                    lstParameter.Add(new SqlParameter("@ZeiRitsu3", vCls.ZeiRitsu3));//ZeiRitsu3
                    lstParameter.Add(new SqlParameter("@GokeiKingaku", vCls.GokeiKingaku));//GokeiKingaku
                    lstParameter.Add(new SqlParameter("@Status", vCls.Status));//Status
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
        public static ChumonItemInfo ConvertToChumonItemInfo(ChumonInfo vCls)
        {
            ChumonItemInfo clsRet;

            try
            {
                clsRet = new ChumonItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.ChumonId = vCls.ChumonId; //ChumonId
                    withBlock.ChumonNo = vCls.ChumonNo; //ChumonNo
                    withBlock.ChumonDate = vCls.ChumonDate; //ChumonDate
                    withBlock.HojinCode = vCls.HojinCode; //HojinCode
                    withBlock.KonyuName = vCls.KonyuName; //KonyuName
                    withBlock.KonyuMailAddress = vCls.KonyuMailAddress; //KonyuMailAddress
                    withBlock.KonyuTantosha = vCls.KonyuTantosha; //KonyuTantosha
                    withBlock.KonyuKingaku1 = vCls.KonyuKingaku1; //KonyuKingaku1
                    withBlock.KonyuKingaku2 = vCls.KonyuKingaku2; //KonyuKingaku2
                    withBlock.KonyuKingaku3 = vCls.KonyuKingaku3; //KonyuKingaku3
                    withBlock.Nebiki = vCls.Nebiki; //Nebiki
                    withBlock.Soryo = vCls.Soryo; //Soryo
                    withBlock.Zei1 = vCls.Zei1; //Zei1
                    withBlock.ZeiRitsu1 = vCls.ZeiRitsu1; //ZeiRitsu1
                    withBlock.Zei2 = vCls.Zei2; //Zei2
                    withBlock.ZeiRitsu2 = vCls.ZeiRitsu2; //ZeiRitsu2
                    withBlock.Zei3 = vCls.Zei3; //Zei3
                    withBlock.ZeiRitsu3 = vCls.ZeiRitsu3; //ZeiRitsu3
                    withBlock.GokeiKingaku = vCls.GokeiKingaku; //GokeiKingaku
                    withBlock.Status = vCls.Status; //Status
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static  string ConvertFilterToWhereCondition(ChumonFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.ChumonId != null){
                        where += " AND CHUMON_ID = @ChumonId";
                }
                if (filter.ChumonNo != null){
                        where += " AND CHUMON_NO = @ChumonNo";
                }
                if (filter.ChumonDate != null){
                        where += " AND CHUMON_DATE = @ChumonDate";
                }
                if (filter.HojinCode != null){
                        where += " AND HOJIN_CODE = @HojinCode";
                }
                if (filter.KonyuName != null){
                        where += " AND KONYU_NAME = @KonyuName";
                }
                if (filter.KonyuMailAddress != null){
                        where += " AND KONYU_MAIL_ADDRESS = @KonyuMailAddress";
                }
                if (filter.KonyuTantosha != null){
                        where += " AND KONYU_TANTOSHA = @KonyuTantosha";
                }
                if (filter.KonyuKingaku1 != null){
                        where += " AND KONYU_KINGAKU1 = @KonyuKingaku1";
                }
                if (filter.KonyuKingaku2 != null){
                        where += " AND KONYU_KINGAKU2 = @KonyuKingaku2";
                }
                if (filter.KonyuKingaku3 != null){
                        where += " AND KONYU_KINGAKU3 = @KonyuKingaku3";
                }
                if (filter.Nebiki != null){
                        where += " AND NEBIKI = @Nebiki";
                }
                if (filter.Soryo != null){
                        where += " AND SORYO = @Soryo";
                }
                if (filter.Zei1 != null){
                        where += " AND ZEI1 = @Zei1";
                }
                if (filter.ZeiRitsu1 != null){
                        where += " AND ZEI_RITSU1 = @ZeiRitsu1";
                }
                if (filter.Zei2 != null){
                        where += " AND ZEI2 = @Zei2";
                }
                if (filter.ZeiRitsu2 != null){
                        where += " AND ZEI_RITSU2 = @ZeiRitsu2";
                }
                if (filter.Zei3 != null){
                        where += " AND ZEI3 = @Zei3";
                }
                if (filter.ZeiRitsu3 != null){
                        where += " AND ZEI_RITSU3 = @ZeiRitsu3";
                }
                if (filter.GokeiKingaku != null){
                        where += " AND GOKEI_KINGAKU = @GokeiKingaku";
                }
                if (filter.Status != null){
                        where += " AND STATUS = @Status";
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

        public static  string ConvertFilterToWhereCondition(ChumonUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.ChumonId != null){
                    where += " AND CHUMON_ID = @ChumonId";
                }
                if (filter.ChumonNo != null){
                    where += " AND CHUMON_NO = @ChumonNo";
                }
                if (filter.ChumonDate != null){
                    where += " AND CHUMON_DATE = @ChumonDate";
                }
                if (filter.HojinCode != null){
                    where += " AND HOJIN_CODE = @HojinCode";
                }
                if (filter.KonyuName != null){
                    where += " AND KONYU_NAME = @KonyuName";
                }
                if (filter.KonyuMailAddress != null){
                    where += " AND KONYU_MAIL_ADDRESS = @KonyuMailAddress";
                }
                if (filter.KonyuTantosha != null){
                    where += " AND KONYU_TANTOSHA = @KonyuTantosha";
                }
                if (filter.KonyuKingaku1 != null){
                    where += " AND KONYU_KINGAKU1 = @KonyuKingaku1";
                }
                if (filter.KonyuKingaku2 != null){
                    where += " AND KONYU_KINGAKU2 = @KonyuKingaku2";
                }
                if (filter.KonyuKingaku3 != null){
                    where += " AND KONYU_KINGAKU3 = @KonyuKingaku3";
                }
                if (filter.Nebiki != null){
                    where += " AND NEBIKI = @Nebiki";
                }
                if (filter.Soryo != null){
                    where += " AND SORYO = @Soryo";
                }
                if (filter.Zei1 != null){
                    where += " AND ZEI1 = @Zei1";
                }
                if (filter.ZeiRitsu1 != null){
                    where += " AND ZEI_RITSU1 = @ZeiRitsu1";
                }
                if (filter.Zei2 != null){
                    where += " AND ZEI2 = @Zei2";
                }
                if (filter.ZeiRitsu2 != null){
                    where += " AND ZEI_RITSU2 = @ZeiRitsu2";
                }
                if (filter.Zei3 != null){
                    where += " AND ZEI3 = @Zei3";
                }
                if (filter.ZeiRitsu3 != null){
                    where += " AND ZEI_RITSU3 = @ZeiRitsu3";
                }
                if (filter.GokeiKingaku != null){
                    where += " AND GOKEI_KINGAKU = @GokeiKingaku";
                }
                if (filter.Status != null){
                    where += " AND STATUS = @Status";
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

        public static  List<SqlParameter> ConvertFilterToParamsCondition(ChumonFilter filter)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.ChumonId != null ){
                lstParameter.Add(new SqlParameter("@ChumonId", filter.ChumonId));
            }
            if( filter.ChumonNo != null ){
                lstParameter.Add(new SqlParameter("@ChumonNo", filter.ChumonNo));
            }
            if( filter.ChumonDate != null ){
                lstParameter.Add(new SqlParameter("@ChumonDate", filter.ChumonDate));
            }
            if( filter.HojinCode != null ){
                lstParameter.Add(new SqlParameter("@HojinCode", filter.HojinCode));
            }
            if( filter.KonyuName != null ){
                lstParameter.Add(new SqlParameter("@KonyuName", filter.KonyuName));
            }
            if( filter.KonyuMailAddress != null ){
                lstParameter.Add(new SqlParameter("@KonyuMailAddress", filter.KonyuMailAddress));
            }
            if( filter.KonyuTantosha != null ){
                lstParameter.Add(new SqlParameter("@KonyuTantosha", filter.KonyuTantosha));
            }
            if( filter.KonyuKingaku1 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku1", filter.KonyuKingaku1));
            }
            if( filter.KonyuKingaku2 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku2", filter.KonyuKingaku2));
            }
            if( filter.KonyuKingaku3 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku3", filter.KonyuKingaku3));
            }
            if( filter.Nebiki != null ){
                lstParameter.Add(new SqlParameter("@Nebiki", filter.Nebiki));
            }
            if( filter.Soryo != null ){
                lstParameter.Add(new SqlParameter("@Soryo", filter.Soryo));
            }
            if( filter.Zei1 != null ){
                lstParameter.Add(new SqlParameter("@Zei1", filter.Zei1));
            }
            if( filter.ZeiRitsu1 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu1", filter.ZeiRitsu1));
            }
            if( filter.Zei2 != null ){
                lstParameter.Add(new SqlParameter("@Zei2", filter.Zei2));
            }
            if( filter.ZeiRitsu2 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu2", filter.ZeiRitsu2));
            }
            if( filter.Zei3 != null ){
                lstParameter.Add(new SqlParameter("@Zei3", filter.Zei3));
            }
            if( filter.ZeiRitsu3 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu3", filter.ZeiRitsu3));
            }
            if( filter.GokeiKingaku != null ){
                lstParameter.Add(new SqlParameter("@GokeiKingaku", filter.GokeiKingaku));
            }
            if( filter.Status != null ){
                lstParameter.Add(new SqlParameter("@Status", filter.Status));
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

        public static List<SqlParameter> ConvertFilterToParamsCondition(ChumonUIFilterInfo filter)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.ChumonId != null ){
                lstParameter.Add(new SqlParameter("@ChumonId", filter.ChumonId));
            }
            if( filter.ChumonNo != null ){
                lstParameter.Add(new SqlParameter("@ChumonNo", filter.ChumonNo));
            }
            if( filter.ChumonDate != null ){
                lstParameter.Add(new SqlParameter("@ChumonDate", filter.ChumonDate));
            }
            if( filter.HojinCode != null ){
                lstParameter.Add(new SqlParameter("@HojinCode", filter.HojinCode));
            }
            if( filter.KonyuName != null ){
                lstParameter.Add(new SqlParameter("@KonyuName", filter.KonyuName));
            }
            if( filter.KonyuMailAddress != null ){
                lstParameter.Add(new SqlParameter("@KonyuMailAddress", filter.KonyuMailAddress));
            }
            if( filter.KonyuTantosha != null ){
                lstParameter.Add(new SqlParameter("@KonyuTantosha", filter.KonyuTantosha));
            }
            if( filter.KonyuKingaku1 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku1", filter.KonyuKingaku1));
            }
            if( filter.KonyuKingaku2 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku2", filter.KonyuKingaku2));
            }
            if( filter.KonyuKingaku3 != null ){
                lstParameter.Add(new SqlParameter("@KonyuKingaku3", filter.KonyuKingaku3));
            }
            if( filter.Nebiki != null ){
                lstParameter.Add(new SqlParameter("@Nebiki", filter.Nebiki));
            }
            if( filter.Soryo != null ){
                lstParameter.Add(new SqlParameter("@Soryo", filter.Soryo));
            }
            if( filter.Zei1 != null ){
                lstParameter.Add(new SqlParameter("@Zei1", filter.Zei1));
            }
            if( filter.ZeiRitsu1 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu1", filter.ZeiRitsu1));
            }
            if( filter.Zei2 != null ){
                lstParameter.Add(new SqlParameter("@Zei2", filter.Zei2));
            }
            if( filter.ZeiRitsu2 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu2", filter.ZeiRitsu2));
            }
            if( filter.Zei3 != null ){
                lstParameter.Add(new SqlParameter("@Zei3", filter.Zei3));
            }
            if( filter.ZeiRitsu3 != null ){
                lstParameter.Add(new SqlParameter("@ZeiRitsu3", filter.ZeiRitsu3));
            }
            if( filter.GokeiKingaku != null ){
                lstParameter.Add(new SqlParameter("@GokeiKingaku", filter.GokeiKingaku));
            }
            if( filter.Status != null ){
                lstParameter.Add(new SqlParameter("@Status", filter.Status));
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