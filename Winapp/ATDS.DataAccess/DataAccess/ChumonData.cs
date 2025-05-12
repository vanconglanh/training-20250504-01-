using ATDS.Common;
using ATDS.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess
{
    public class ChumonData
    {
        public ChumonData() : base()
        {
        }
#region Base Function
        /// <summary>
        /// sqlBaseSetSelect
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public string sqlBaseSetSelect(string Where, string Order)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT                                                                                     ");
                sql.Append(" 1                                                                                          ");
                sql.Append(" ,ISNULL(CHUMON_ID                     , 0) AS ChumonId                      ");  //   ChumonId
                sql.Append(" ,ISNULL(CHUMON_NO                     ,'') AS ChumonNo                      ");  //   ChumonNo
                sql.Append(" ,ISNULL(CHUMON_DATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS ChumonDate                    ");  //   ChumonDate
                sql.Append(" ,ISNULL(HOJIN_CODE                    ,'') AS HojinCode                     ");  //   HojinCode
                sql.Append(" ,ISNULL(KONYU_NAME                    ,'') AS KonyuName                     ");  //   KonyuName
                sql.Append(" ,ISNULL(KONYU_MAIL_ADDRESS            ,'') AS KonyuMailAddress              ");  //   KonyuMailAddress
                sql.Append(" ,ISNULL(KONYU_TANTOSHA                ,'') AS KonyuTantosha                 ");  //   KonyuTantosha
                sql.Append(" ,ISNULL(KONYU_KINGAKU1                , 0) AS KonyuKingaku1                 ");  //   KonyuKingaku1
                sql.Append(" ,ISNULL(KONYU_KINGAKU2                , 0) AS KonyuKingaku2                 ");  //   KonyuKingaku2
                sql.Append(" ,ISNULL(KONYU_KINGAKU3                , 0) AS KonyuKingaku3                 ");  //   KonyuKingaku3
                sql.Append(" ,ISNULL(NEBIKI                        , 0) AS Nebiki                        ");  //   Nebiki
                sql.Append(" ,ISNULL(SORYO                         , 0) AS Soryo                         ");  //   Soryo
                sql.Append(" ,ISNULL(ZEI1                          , 0) AS Zei1                          ");  //   Zei1
                sql.Append(" ,ISNULL(ZEI_RITSU1                    , 0) AS ZeiRitsu1                     ");  //   ZeiRitsu1
                sql.Append(" ,ISNULL(ZEI2                          , 0) AS Zei2                          ");  //   Zei2
                sql.Append(" ,ISNULL(ZEI_RITSU2                    , 0) AS ZeiRitsu2                     ");  //   ZeiRitsu2
                sql.Append(" ,ISNULL(ZEI3                          , 0) AS Zei3                          ");  //   Zei3
                sql.Append(" ,ISNULL(ZEI_RITSU3                    , 0) AS ZeiRitsu3                     ");  //   ZeiRitsu3
                sql.Append(" ,ISNULL(GOKEI_KINGAKU                 , 0) AS GokeiKingaku                  ");  //   GokeiKingaku
                sql.Append(" ,ISNULL(STATUS                        , 0) AS Status                        ");  //   Status
                sql.Append(" ,ISNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,ISNULL(LAST_UPDATE_USER              ,'') AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,ISNULL(LAST_UPDATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS LastUpdate                    ");  //   LastUpdate
                sql.Append(" ,ISNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM T_CHUMON                                                               ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if( !string.IsNullOrWhiteSpace(Where)) {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }
                // Order by
                if( !string.IsNullOrWhiteSpace(Order)){
                    sql.Append(" ORDER BY                                                                ");  //   並び順定義
                    sql.Append(Order);                                                                        //   並び順(ﾕｰｻﾞｰ条件)
                }

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sql = null;
            }
        }

        /// <summary>
        /// sqlBaseSetSelect - Get Total record
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string sqlBaseSetSelectTotalRecord(string Where)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT  COUNT(1) AS NUM_RECORDS                                             ");                
                sql.Append(" FROM T_CHUMON                                                               ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if (!string.IsNullOrWhiteSpace(Where))
                {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }                

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// sqlBaseSetSelect
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="iRecordOfPage"></param>
        /// <returns></returns>
        public string sqlBaseSetSelectPage(string Where, string Order, int iPageIndex, int iRecordOfPage)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT                                                                                     ");
                sql.Append(" 1                                                                                          ");
                sql.Append(" ,ISNULL(CHUMON_ID                     , 0) AS ChumonId                      ");  //   ChumonId
                sql.Append(" ,ISNULL(CHUMON_NO                     ,'') AS ChumonNo                      ");  //   ChumonNo
                sql.Append(" ,ISNULL(CHUMON_DATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS ChumonDate                    ");  //   ChumonDate
                sql.Append(" ,ISNULL(HOJIN_CODE                    ,'') AS HojinCode                     ");  //   HojinCode
                sql.Append(" ,ISNULL(KONYU_NAME                    ,'') AS KonyuName                     ");  //   KonyuName
                sql.Append(" ,ISNULL(KONYU_MAIL_ADDRESS            ,'') AS KonyuMailAddress              ");  //   KonyuMailAddress
                sql.Append(" ,ISNULL(KONYU_TANTOSHA                ,'') AS KonyuTantosha                 ");  //   KonyuTantosha
                sql.Append(" ,ISNULL(KONYU_KINGAKU1                , 0) AS KonyuKingaku1                 ");  //   KonyuKingaku1
                sql.Append(" ,ISNULL(KONYU_KINGAKU2                , 0) AS KonyuKingaku2                 ");  //   KonyuKingaku2
                sql.Append(" ,ISNULL(KONYU_KINGAKU3                , 0) AS KonyuKingaku3                 ");  //   KonyuKingaku3
                sql.Append(" ,ISNULL(NEBIKI                        , 0) AS Nebiki                        ");  //   Nebiki
                sql.Append(" ,ISNULL(SORYO                         , 0) AS Soryo                         ");  //   Soryo
                sql.Append(" ,ISNULL(ZEI1                          , 0) AS Zei1                          ");  //   Zei1
                sql.Append(" ,ISNULL(ZEI_RITSU1                    , 0) AS ZeiRitsu1                     ");  //   ZeiRitsu1
                sql.Append(" ,ISNULL(ZEI2                          , 0) AS Zei2                          ");  //   Zei2
                sql.Append(" ,ISNULL(ZEI_RITSU2                    , 0) AS ZeiRitsu2                     ");  //   ZeiRitsu2
                sql.Append(" ,ISNULL(ZEI3                          , 0) AS Zei3                          ");  //   Zei3
                sql.Append(" ,ISNULL(ZEI_RITSU3                    , 0) AS ZeiRitsu3                     ");  //   ZeiRitsu3
                sql.Append(" ,ISNULL(GOKEI_KINGAKU                 , 0) AS GokeiKingaku                  ");  //   GokeiKingaku
                sql.Append(" ,ISNULL(STATUS                        , 0) AS Status                        ");  //   Status
                sql.Append(" ,ISNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,ISNULL(LAST_UPDATE_USER              ,'') AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,ISNULL(LAST_UPDATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS LastUpdate                    ");  //   LastUpdate
                sql.Append(" ,ISNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM T_CHUMON                                                               ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if (!string.IsNullOrWhiteSpace(Where))
                {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }
                // Order by
                if (!string.IsNullOrWhiteSpace(Order))
                {
                    sql.Append(" ORDER BY                                                                ");  //   並び順定義
                    sql.Append(Order);                                                                        //   並び順(ﾕｰｻﾞｰ条件)
                }
                // Get Record of page
                sql.Append(" OFFSET " + (iPageIndex -1) * iRecordOfPage + " ROWS FETCH NEXT "+ iRecordOfPage + " ROWS ONLY ");

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// sqlBaseSetInsert
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetInsert(ChumonInfo cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // INSERT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" INSERT INTO T_CHUMON              (");
                sql.Append("  CHUMON_NO                         ");  //   ChumonNo
                sql.Append(" ,CHUMON_DATE                       ");  //   ChumonDate
                sql.Append(" ,HOJIN_CODE                        ");  //   HojinCode
                sql.Append(" ,KONYU_NAME                        ");  //   KonyuName
                sql.Append(" ,KONYU_MAIL_ADDRESS                ");  //   KonyuMailAddress
                sql.Append(" ,KONYU_TANTOSHA                    ");  //   KonyuTantosha
                sql.Append(" ,KONYU_KINGAKU1                    ");  //   KonyuKingaku1
                sql.Append(" ,KONYU_KINGAKU2                    ");  //   KonyuKingaku2
                sql.Append(" ,KONYU_KINGAKU3                    ");  //   KonyuKingaku3
                sql.Append(" ,NEBIKI                            ");  //   Nebiki
                sql.Append(" ,SORYO                             ");  //   Soryo
                sql.Append(" ,ZEI1                              ");  //   Zei1
                sql.Append(" ,ZEI_RITSU1                        ");  //   ZeiRitsu1
                sql.Append(" ,ZEI2                              ");  //   Zei2
                sql.Append(" ,ZEI_RITSU2                        ");  //   ZeiRitsu2
                sql.Append(" ,ZEI3                              ");  //   Zei3
                sql.Append(" ,ZEI_RITSU3                        ");  //   ZeiRitsu3
                sql.Append(" ,GOKEI_KINGAKU                     ");  //   GokeiKingaku
                sql.Append(" ,STATUS                            ");  //   Status
                sql.Append(" ,YUKO_FLAG                         ");  //   YukoFlag
                sql.Append(" ,LAST_UPDATE_USER                  ");  //   LastUpdateUser
                sql.Append(" ,LAST_UPDATE                       ");  //   LastUpdate
                sql.Append(" ,LAST_UPDATE_PROGRAM               ");  //   LastUpdateProgram
                sql.Append(" )  ");

                sql.Append("OUTPUT Inserted.ChumonId"); // データ登録の自動採番データ取得

                sql.Append(" VALUES ( ");
                sql.Append("  @ChumonNo                          ");  //   ChumonNo
                sql.Append(" ,@ChumonDate                       ");  //   ChumonDate
                sql.Append(" ,@HojinCode                        ");  //   HojinCode
                sql.Append(" ,@KonyuName                        ");  //   KonyuName
                sql.Append(" ,@KonyuMailAddress                 ");  //   KonyuMailAddress
                sql.Append(" ,@KonyuTantosha                    ");  //   KonyuTantosha
                sql.Append(" ,@KonyuKingaku1                    ");  //   KonyuKingaku1
                sql.Append(" ,@KonyuKingaku2                    ");  //   KonyuKingaku2
                sql.Append(" ,@KonyuKingaku3                    ");  //   KonyuKingaku3
                sql.Append(" ,@Nebiki                           ");  //   Nebiki
                sql.Append(" ,@Soryo                            ");  //   Soryo
                sql.Append(" ,@Zei1                             ");  //   Zei1
                sql.Append(" ,@ZeiRitsu1                        ");  //   ZeiRitsu1
                sql.Append(" ,@Zei2                             ");  //   Zei2
                sql.Append(" ,@ZeiRitsu2                        ");  //   ZeiRitsu2
                sql.Append(" ,@Zei3                             ");  //   Zei3
                sql.Append(" ,@ZeiRitsu3                        ");  //   ZeiRitsu3
                sql.Append(" ,@GokeiKingaku                     ");  //   GokeiKingaku
                sql.Append(" ,@Status                           ");  //   Status
                sql.Append(" ,@YukoFlag                         ");  //   YukoFlag
                sql.Append(" ,@LastUpdateUser                   ");  //   LastUpdateUser
                sql.Append(" ,@LastUpdate                       ");  //   LastUpdate
                sql.Append(" ,@LastUpdateProgram                ");  //   LastUpdateProgram
                sql.Append(" )  ");

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// sqlBaseSetUpdate
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetUpdate(ChumonInfo cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  T_CHUMON                                                     ");
                sql.Append(" SET CHUMON_NO                      = @ChumonNo                      ");  //   ChumonNo
                sql.Append("    ,CHUMON_DATE                    = @ChumonDate                    "); //   ChumonDate
                sql.Append("    ,HOJIN_CODE                     = @HojinCode                     "); //   HojinCode
                sql.Append("    ,KONYU_NAME                     = @KonyuName                     "); //   KonyuName
                sql.Append("    ,KONYU_MAIL_ADDRESS             = @KonyuMailAddress              "); //   KonyuMailAddress
                sql.Append("    ,KONYU_TANTOSHA                 = @KonyuTantosha                 "); //   KonyuTantosha
                sql.Append("    ,KONYU_KINGAKU1                 = @KonyuKingaku1                 "); //   KonyuKingaku1
                sql.Append("    ,KONYU_KINGAKU2                 = @KonyuKingaku2                 "); //   KonyuKingaku2
                sql.Append("    ,KONYU_KINGAKU3                 = @KonyuKingaku3                 "); //   KonyuKingaku3
                sql.Append("    ,NEBIKI                         = @Nebiki                        "); //   Nebiki
                sql.Append("    ,SORYO                          = @Soryo                         "); //   Soryo
                sql.Append("    ,ZEI1                           = @Zei1                          "); //   Zei1
                sql.Append("    ,ZEI_RITSU1                     = @ZeiRitsu1                     "); //   ZeiRitsu1
                sql.Append("    ,ZEI2                           = @Zei2                          "); //   Zei2
                sql.Append("    ,ZEI_RITSU2                     = @ZeiRitsu2                     "); //   ZeiRitsu2
                sql.Append("    ,ZEI3                           = @Zei3                          "); //   Zei3
                sql.Append("    ,ZEI_RITSU3                     = @ZeiRitsu3                     "); //   ZeiRitsu3
                sql.Append("    ,GOKEI_KINGAKU                  = @GokeiKingaku                  "); //   GokeiKingaku
                sql.Append("    ,STATUS                         = @Status                        "); //   Status
                sql.Append("    ,YUKO_FLAG                      = @YukoFlag                      "); //   YukoFlag
                sql.Append("    ,LAST_UPDATE_USER               = @LastUpdateUser                "); //   LastUpdateUser
                sql.Append("    ,LAST_UPDATE                    = @LastUpdate                    "); //   LastUpdate
                sql.Append("    ,LAST_UPDATE_PROGRAM            = @LastUpdateProgram             "); //   LastUpdateProgram
                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// sqlBaseSetUpdate
        /// </summary>        /// <param name="CHUMON_ID"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetDelete(int piChumonId,
                                       string vstrUpdateUser, 
                                       string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  T_CHUMON                                                                                    ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "         ,");
                sql.Append("     LAST_UPDATE_USER           =   '" + vstrUpdateUser + "'                    ,");
                sql.Append("     LAST_UPDATE                =   '" + DateTime.Now.ToString("yyyy-MM-dd") + "'   ,");
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");
                sql.Append(" WHERE CHUMON_ID                = @ChumonId                      ");  //   検索条件定義

                sql.Append(" AND YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.ENABLED);

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }


#endregion

#region Get Data
        /// <summary>
        /// GetDataSet
        /// </summary>
        /// <param name="Sdr"></param>
        /// <returns></returns>
        private ChumonInfo GetDataSet(SqlDataReader Sdr)
        {
            ChumonInfo Chumon = new ChumonInfo();                                  // Chumonｸﾗｽ定義   

            try
            {
                Chumon = new ChumonInfo();                                   // T_CHUMON　ｸﾗｽ初期化

                {
                    var withBlock = Chumon;                                               // @@@Table.NAME情報格納
                    withBlock.ChumonId = System.Convert.ToInt32(Sdr["ChumonId"]); //   ChumonId
                    withBlock.ChumonNo = ((string)Sdr["ChumonNo"]).Trim(); //   ChumonNo
                    if (Sdr["ChumonDate"] == null){
                        withBlock.ChumonDate = DateTime.MinValue;
                    }
                    else{
                        withBlock.ChumonDate = (DateTime)Sdr["ChumonDate"]; //  ChumonDate 
                    }
                    withBlock.HojinCode = ((string)Sdr["HojinCode"]).Trim(); //   HojinCode
                    withBlock.KonyuName = ((string)Sdr["KonyuName"]).Trim(); //   KonyuName
                    withBlock.KonyuMailAddress = ((string)Sdr["KonyuMailAddress"]).Trim(); //   KonyuMailAddress
                    withBlock.KonyuTantosha = ((string)Sdr["KonyuTantosha"]).Trim(); //   KonyuTantosha
                    withBlock.KonyuKingaku1 = System.Convert.ToInt32(Sdr["KonyuKingaku1"]); //   KonyuKingaku1
                    withBlock.KonyuKingaku2 = System.Convert.ToInt32(Sdr["KonyuKingaku2"]); //   KonyuKingaku2
                    withBlock.KonyuKingaku3 = System.Convert.ToInt32(Sdr["KonyuKingaku3"]); //   KonyuKingaku3
                    withBlock.Nebiki = System.Convert.ToInt32(Sdr["Nebiki"]); //   Nebiki
                    withBlock.Soryo = System.Convert.ToInt32(Sdr["Soryo"]); //   Soryo
                    withBlock.Zei1 = System.Convert.ToInt32(Sdr["Zei1"]); //   Zei1
                    withBlock.ZeiRitsu1 = System.Convert.ToInt32(Sdr["ZeiRitsu1"]); //   ZeiRitsu1
                    withBlock.Zei2 = System.Convert.ToInt32(Sdr["Zei2"]); //   Zei2
                    withBlock.ZeiRitsu2 = System.Convert.ToInt32(Sdr["ZeiRitsu2"]); //   ZeiRitsu2
                    withBlock.Zei3 = System.Convert.ToInt32(Sdr["Zei3"]); //   Zei3
                    withBlock.ZeiRitsu3 = System.Convert.ToInt32(Sdr["ZeiRitsu3"]); //   ZeiRitsu3
                    withBlock.GokeiKingaku = System.Convert.ToInt32(Sdr["GokeiKingaku"]); //   GokeiKingaku
                    withBlock.Status = System.Convert.ToInt32(Sdr["Status"]); //   Status
                    withBlock.YukoFlag = System.Convert.ToInt32(Sdr["YukoFlag"]); //   YukoFlag
                    withBlock.LastUpdateUser = ((string)Sdr["LastUpdateUser"]).Trim(); //   LastUpdateUser
                    if (Sdr["LastUpdate"] == null){
                        withBlock.LastUpdate = DateTime.MinValue;
                    }
                    else{
                        withBlock.LastUpdate = (DateTime)Sdr["LastUpdate"]; //  ChumonDate 
                    }
                    withBlock.LastUpdateProgram = ((string)Sdr["LastUpdateProgram"]).Trim(); //   LastUpdateProgram
                }

                return Chumon;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }// SQLServerDataRead初期化
        }


        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="Con">SQLServerHelper</param>
        /// <param name="vstrChumonId"></param>
        /// <returns></returns>
        public ChumonInfo GetData(SQLServerHelper Con ,int piChumonId)
        {
            string sql = "";
            string where = "";
            string Order = "";
            SqlDataReader Sdr;
            ChumonInfo objCls = new ChumonInfo();

            try
            {

                // --- 条件設定
                where += "  AND YUKO_FLAG   =   " + (int)Constant.YUKO_FLAG.ENABLED + " ";
                where += "  AND CHUMON_ID                      = " + piChumonId                       + " "; //   ChumonId

                // --- SQL設定
                sql = sqlBaseSetSelect(where, Order);

                // --- 情報取得
                Sdr = Con.SelectSQL(sql);

                using (Sdr) {
                    while (Sdr.Read())
                    {
                        objCls = GetDataSet(Sdr);
                    }
                }
                return objCls;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }



#endregion

#region 【メソッド】 CheckData
        /// <summary>
        /// CheckData
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public bool CheckData(SQLServerHelper con ,int piChumonId)
        {
            string sql = ""; 
            string where = "";
            string order = "";
            SqlDataReader Sdr;
            ChumonInfo objCls = new ChumonInfo();

            try
            {              

                //--- 条件設定
                where += "  AND CHUMON_ID                      = " + piChumonId                       + " "; //   ChumonId

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQL(sql);

                using (Sdr) {
                    if(Sdr.Read()){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
#endregion

#region Insert - Update - Delete
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Insert(SQLServerHelper Con, ref ChumonInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            string where = "";
            string order = "";
            ChumonInfo objCls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            // --- Begin transaction
            // Con.BeginTrans();

            try
            {
                sql = "";
                where = "";
                order = "";

                // --- 登録データ設定
                if (vCls != null) objCls = vCls;

                // --- SQL設定
                sql = sqlBaseSetInsert(objCls, vstrUpdateUser, vstrUpdateProgram);

                // --- SQL実行
                Con.ExecuteSQLWithParams(sql, lstParameter);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                // --- Commit transaction
                // Con.Commit();

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // Con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }

        /// <summary>
        /// InsertGetID
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo InsertGetID(SQLServerHelper Con, ref ChumonInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            ChumonInfo objCls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();
            SqlDataReader Sdr;

            // --- Begin transaction
            // Con.BeginTrans();

            try
            {
                sql = "";

                // --- 登録データ設定
                if (vCls != null)
                    objCls = vCls;

                // --- SQL設定
                sql = sqlBaseSetInsert(objCls, vstrUpdateUser, vstrUpdateProgram);

                // --- SQL実行
                Sdr = Con.SelectSQLWithParams(sql, lstParameter);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Message = string.Empty;

                    using (Sdr){
                        while ((Sdr.Read())){
                            withBlock.Code = System.Convert.ToInt32(Sdr["ChumonId"]);
                        }
                    }
                }

                // --- Commit transaction
                // Con.Commit();

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // Con.Rollback();
                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Update(SQLServerHelper Con, ref ChumonInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            ChumonInfo objCls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            // --- Begin transaction
            // Con.BeginTrans();

            try
            {
                sql = "";

                // --- 登録データ設定
                if (vCls != null)
                    objCls = vCls;

                // --- SQL設定
                sql = sqlBaseSetUpdate(objCls, vstrUpdateUser, vstrUpdateProgram);

                // --- SQL実行
                Con.ExecuteSQLWithParams(sql, lstParameter);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                // --- Commit transaction
                // Con.Commit();

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // Con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }

        /// <summary>
        /// データを削除
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Delete(SQLServerHelper con, int piChumonId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<SqlParameter> Params = new List<SqlParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDelete(piChumonId, vstrUpdateUser, vstrUpdateProgram);

                Params.Add(new SqlParameter("@ChumonId", piChumonId));  // ChumonId

                //--- SQL実行
                con.ExecuteSQLWithParams(sql, Params);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }
 
#endregion

#region 【一覧取得】 Search
        public List<ChumonInfo> Search(SQLServerHelper con, string where, List<SqlParameter> lstParameter, string order) 
        {
            string sql = "";         
            SqlDataReader Sdr;
            ChumonInfo objCls = new ChumonInfo();
            List<ChumonInfo> lstChumonInfo = new List<ChumonInfo>(); 

            try
            {
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, lstParameter);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstChumonInfo.Add(GetDataSet(Sdr));
                    }
                }

                return lstChumonInfo;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
#endregion

        #region 【一覧取得】 Search Page
        public PaginatedList<ChumonInfo> SearchPage(SQLServerHelper con, 
                                            string where, 
                                            List<SqlParameter> lstParameter, 
                                            string order,
                                            int iPageIndex = 1,
                                            int iPageSize = 20)
        {
            string sql = "";
            SqlDataReader Sdr;
            ChumonInfo objCls = new ChumonInfo();
            List<ChumonInfo> lstChumonInfo = new List<ChumonInfo>();

            try
            {
                //--- Get total record
                sql = sqlBaseSetSelectTotalRecord(where);
                Sdr = con.SelectSQLWithParams(sql, lstParameter.ToList());
                var iTotalRecord = 0;
                using (Sdr){
                    Sdr.Read();
                    iTotalRecord = System.Convert.ToInt32(Sdr["NUM_RECORDS"]);
                }
                if (iTotalRecord > 0)
                {
                    //--- SQL設定
                    sql = sqlBaseSetSelectPage(where, order, iPageIndex, iPageSize);

                    //--- 情報取得                    
                    Sdr = con.SelectSQLWithParams(sql, lstParameter.ToList());

                    using (Sdr)
                    {

                        while (Sdr.Read())
                        {
                            lstChumonInfo.Add(GetDataSet(Sdr));
                        }
                    }
                }

                return new PaginatedList<ChumonInfo>(lstChumonInfo, iTotalRecord, iPageIndex, iPageSize);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

#region 【一覧取得】 SearchByKey
        public List<ChumonInfo> SearchByKey(SQLServerHelper con ,int piChumonId)
        {
            string sql = "";
            string where = "";
            string order = "";
            SqlDataReader Sdr;
            List<SqlParameter> Params = new List<SqlParameter>();   
            ChumonInfo objCls = new ChumonInfo();
            List<ChumonInfo> lstChumonInfo = new List<ChumonInfo>(); 

            try
            {

                //--- 条件設定
            if(piChumonId != -1){
                    where += "AND CHUMON_ID = @ChumonId";
            }

                //--- SQL Params
            if(piChumonId != -1 ){
                    Params.Add(new SqlParameter("@ChumonId", piChumonId));
            }

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, Params);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstChumonInfo.Add(GetDataSet(Sdr));
                    }
                }

                return lstChumonInfo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
#endregion

#region 【メソッド】 SearchDt     
        public DataSet SearchDt(SQLServerHelper con, string where, List<SqlParameter> lstParameter, string order)
        {
            string sql = "";     
            DataSet ret;

            try
            {                
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                ret = con.SelectSqlDsWithParams(sql, lstParameter);

                return ret;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
#endregion

    }
}
