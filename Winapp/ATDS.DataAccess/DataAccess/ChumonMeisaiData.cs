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
    public class ChumonMeisaiData
    {
        public ChumonMeisaiData() : base()
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
                sql.Append(" ,ISNULL(CHUMON_MEISAI_ID              , 0) AS ChumonMeisaiId                ");  //   ChumonMeisaiId
                sql.Append(" ,ISNULL(CHUMON_ID                     , 0) AS ChumonId                      ");  //   ChumonId
                sql.Append(" ,ISNULL(CHUMON_MEISAI_NO              ,'') AS ChumonMeisaiNo                ");  //   ChumonMeisaiNo
                sql.Append(" ,ISNULL(SHOHIN_CODE                   ,'') AS ShohinCode                    ");  //   ShohinCode
                sql.Append(" ,ISNULL(SHOHIN_NAME                   ,'') AS ShohinName                    ");  //   ShohinName
                sql.Append(" ,ISNULL(SURYO                         , 0) AS Suryo                         ");  //   Suryo
                sql.Append(" ,ISNULL(TANKA                         , 0) AS Tanka                         ");  //   Tanka
                sql.Append(" ,ISNULL(KINGAKU                       , 0) AS Kingaku                       ");  //   Kingaku
                sql.Append(" ,ISNULL(SORYO                         , 0) AS Soryo                         ");  //   Soryo
                sql.Append(" ,ISNULL(ZEI_RITSU                     , 0) AS ZeiRitsu                      ");  //   ZeiRitsu
                sql.Append(" ,ISNULL(GOKEI_KINGAKU                 , 0) AS GokeiKingaku                  ");  //   GokeiKingaku
                sql.Append(" ,ISNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,ISNULL(LAST_UPDATE_USER              ,'') AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,ISNULL(LAST_UPDATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS LastUpdate                    ");  //   LastUpdate
                sql.Append(" ,ISNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM T_CHUMON_MEISAI                                                        ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" FROM T_CHUMON_MEISAI                                                        ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" ,ISNULL(CHUMON_MEISAI_ID              , 0) AS ChumonMeisaiId                ");  //   ChumonMeisaiId
                sql.Append(" ,ISNULL(CHUMON_ID                     , 0) AS ChumonId                      ");  //   ChumonId
                sql.Append(" ,ISNULL(CHUMON_MEISAI_NO              ,'') AS ChumonMeisaiNo                ");  //   ChumonMeisaiNo
                sql.Append(" ,ISNULL(SHOHIN_CODE                   ,'') AS ShohinCode                    ");  //   ShohinCode
                sql.Append(" ,ISNULL(SHOHIN_NAME                   ,'') AS ShohinName                    ");  //   ShohinName
                sql.Append(" ,ISNULL(SURYO                         , 0) AS Suryo                         ");  //   Suryo
                sql.Append(" ,ISNULL(TANKA                         , 0) AS Tanka                         ");  //   Tanka
                sql.Append(" ,ISNULL(KINGAKU                       , 0) AS Kingaku                       ");  //   Kingaku
                sql.Append(" ,ISNULL(SORYO                         , 0) AS Soryo                         ");  //   Soryo
                sql.Append(" ,ISNULL(ZEI_RITSU                     , 0) AS ZeiRitsu                      ");  //   ZeiRitsu
                sql.Append(" ,ISNULL(GOKEI_KINGAKU                 , 0) AS GokeiKingaku                  ");  //   GokeiKingaku
                sql.Append(" ,ISNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,ISNULL(LAST_UPDATE_USER              ,'') AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,ISNULL(LAST_UPDATE                   , '" + DateTime.MinValue.ToString("MM/dd/yyyy") + "') AS LastUpdate                    ");  //   LastUpdate
                sql.Append(" ,ISNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM T_CHUMON_MEISAI                                                        ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
        public string sqlBaseSetInsert(ChumonMeisaiInfo cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // INSERT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" INSERT INTO T_CHUMON_MEISAI       (");
                sql.Append("  CHUMON_ID                         ");  //   ChumonId
                sql.Append(" ,CHUMON_MEISAI_NO                  ");  //   ChumonMeisaiNo
                sql.Append(" ,SHOHIN_CODE                       ");  //   ShohinCode
                sql.Append(" ,SHOHIN_NAME                       ");  //   ShohinName
                sql.Append(" ,SURYO                             ");  //   Suryo
                sql.Append(" ,TANKA                             ");  //   Tanka
                sql.Append(" ,KINGAKU                           ");  //   Kingaku
                sql.Append(" ,SORYO                             ");  //   Soryo
                sql.Append(" ,ZEI_RITSU                         ");  //   ZeiRitsu
                sql.Append(" ,GOKEI_KINGAKU                     ");  //   GokeiKingaku
                sql.Append(" ,YUKO_FLAG                         ");  //   YukoFlag
                sql.Append(" ,LAST_UPDATE_USER                  ");  //   LastUpdateUser
                sql.Append(" ,LAST_UPDATE                       ");  //   LastUpdate
                sql.Append(" ,LAST_UPDATE_PROGRAM               ");  //   LastUpdateProgram
                sql.Append(" )  ");

                sql.Append("OUTPUT Inserted.ChumonMeisaiId"); // データ登録の自動採番データ取得

                sql.Append(" VALUES ( ");
                sql.Append("  @ChumonId                          ");  //   ChumonId
                sql.Append(" ,@ChumonMeisaiNo                   ");  //   ChumonMeisaiNo
                sql.Append(" ,@ShohinCode                       ");  //   ShohinCode
                sql.Append(" ,@ShohinName                       ");  //   ShohinName
                sql.Append(" ,@Suryo                            ");  //   Suryo
                sql.Append(" ,@Tanka                            ");  //   Tanka
                sql.Append(" ,@Kingaku                          ");  //   Kingaku
                sql.Append(" ,@Soryo                            ");  //   Soryo
                sql.Append(" ,@ZeiRitsu                         ");  //   ZeiRitsu
                sql.Append(" ,@GokeiKingaku                     ");  //   GokeiKingaku
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
        public string sqlBaseSetUpdate(ChumonMeisaiInfo cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  T_CHUMON_MEISAI                                              ");
                sql.Append(" SET CHUMON_ID                      = @ChumonId                      ");  //   ChumonId
                sql.Append("    ,CHUMON_MEISAI_NO               = @ChumonMeisaiNo                "); //   ChumonMeisaiNo
                sql.Append("    ,SHOHIN_CODE                    = @ShohinCode                    "); //   ShohinCode
                sql.Append("    ,SHOHIN_NAME                    = @ShohinName                    "); //   ShohinName
                sql.Append("    ,SURYO                          = @Suryo                         "); //   Suryo
                sql.Append("    ,TANKA                          = @Tanka                         "); //   Tanka
                sql.Append("    ,KINGAKU                        = @Kingaku                       "); //   Kingaku
                sql.Append("    ,SORYO                          = @Soryo                         "); //   Soryo
                sql.Append("    ,ZEI_RITSU                      = @ZeiRitsu                      "); //   ZeiRitsu
                sql.Append("    ,GOKEI_KINGAKU                  = @GokeiKingaku                  "); //   GokeiKingaku
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
        /// </summary>        /// <param name="CHUMON_MEISAI_ID"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetDelete(int piChumonMeisaiId,
                                       string vstrUpdateUser, 
                                       string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  T_CHUMON_MEISAI                                                                             ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "         ,");
                sql.Append("     LAST_UPDATE_USER           =   '" + vstrUpdateUser + "'                    ,");
                sql.Append("     LAST_UPDATE                =   '" + DateTime.Now.ToString("yyyy-MM-dd") + "'   ,");
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");
                sql.Append(" WHERE CHUMON_MEISAI_ID         = @ChumonMeisaiId                ");  //   検索条件定義

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


        /// <summary>
        /// sqlBaseSetDeleteByForeignKey
        /// </summary>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetDeleteByForeignKey(string vstrUpdateUser,
                                                   string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                //  DELETE
                sql.Length = 0;                                              //   SQL定義
                sql.Append(" UPDATE T_CHUMON_MEISAI                         ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "        ,");  
                sql.Append("     LAST_UPDATE_USER           =   '" + vstrUpdateUser + "'                    ,");    
                sql.Append("     LAST_UPDATE                =   '" + DateTime.Now.ToString("yyyy-MM-dd") + "'   ,");    
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");  
                sql.Append(" WHERE YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.ENABLED);

                sql.Append(" AND CHUMON_ID                = @ChumonId                      ");  //   検索条件定義

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
        private ChumonMeisaiInfo GetDataSet(SqlDataReader Sdr)
        {
            ChumonMeisaiInfo ChumonMeisai = new ChumonMeisaiInfo();                                  // ChumonMeisaiｸﾗｽ定義   

            try
            {
                ChumonMeisai = new ChumonMeisaiInfo();                                   // T_CHUMON_MEISAI　ｸﾗｽ初期化

                {
                    var withBlock = ChumonMeisai;                                               // @@@Table.NAME情報格納
                    withBlock.ChumonMeisaiId = System.Convert.ToInt32(Sdr["ChumonMeisaiId"]); //   ChumonMeisaiId
                    withBlock.ChumonId = System.Convert.ToInt32(Sdr["ChumonId"]); //   ChumonId
                    withBlock.ChumonMeisaiNo = ((string)Sdr["ChumonMeisaiNo"]).Trim(); //   ChumonMeisaiNo
                    withBlock.ShohinCode = ((string)Sdr["ShohinCode"]).Trim(); //   ShohinCode
                    withBlock.ShohinName = ((string)Sdr["ShohinName"]).Trim(); //   ShohinName
                    withBlock.Suryo = System.Convert.ToInt32(Sdr["Suryo"]); //   Suryo
                    withBlock.Tanka = System.Convert.ToInt32(Sdr["Tanka"]); //   Tanka
                    withBlock.Kingaku = System.Convert.ToInt32(Sdr["Kingaku"]); //   Kingaku
                    withBlock.Soryo = System.Convert.ToInt32(Sdr["Soryo"]); //   Soryo
                    withBlock.ZeiRitsu = System.Convert.ToInt32(Sdr["ZeiRitsu"]); //   ZeiRitsu
                    withBlock.GokeiKingaku = System.Convert.ToInt32(Sdr["GokeiKingaku"]); //   GokeiKingaku
                    withBlock.YukoFlag = System.Convert.ToInt32(Sdr["YukoFlag"]); //   YukoFlag
                    withBlock.LastUpdateUser = ((string)Sdr["LastUpdateUser"]).Trim(); //   LastUpdateUser
                    if (Sdr["LastUpdate"] == null){
                        withBlock.LastUpdate = DateTime.MinValue;
                    }
                    else{
                        withBlock.LastUpdate = (DateTime)Sdr["LastUpdate"]; //  ChumonMeisaiDate 
                    }
                    withBlock.LastUpdateProgram = ((string)Sdr["LastUpdateProgram"]).Trim(); //   LastUpdateProgram
                }

                return ChumonMeisai;
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
        /// <param name="vstrChumonMeisaiId"></param>
        /// <returns></returns>
        public ChumonMeisaiInfo GetData(SQLServerHelper Con ,int piChumonMeisaiId)
        {
            string sql = "";
            string where = "";
            string Order = "";
            SqlDataReader Sdr;
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();

            try
            {

                // --- 条件設定
                where += "  AND YUKO_FLAG   =   " + (int)Constant.YUKO_FLAG.ENABLED + " ";
                where += "  AND CHUMON_MEISAI_ID               = " + piChumonMeisaiId                 + " "; //   ChumonMeisaiId

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


        /// <summary>
        /// GetDataByForeignKey
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public List<ChumonMeisaiInfo> GetDataByForeignKey(int piChumonId,SQLServerHelper con)
        {
            string sql = "";
            string where = "";
            string order = "";
            SqlDataReader Sdr;
            ChumonMeisaiInfo objCls;
            List<ChumonMeisaiInfo> objResult = new List<ChumonMeisaiInfo>();

            try
            {

                //--- 条件設定
                where += "  AND  CHUMON_ID = " + piChumonId + " "; //   ChumonId
                where += "  AND YUKO_FLAG   =   " + (int)Constant.YUKO_FLAG.ENABLED + " ";

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQL(sql);

                using (Sdr) { 

                   while (Sdr.Read()){
                        objCls = GetDataSet(Sdr);
                        objResult.Add(objCls);
                    }

                }

                return objResult;

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
        public bool CheckData(SQLServerHelper con ,int piChumonMeisaiId)
        {
            string sql = ""; 
            string where = "";
            string order = "";
            SqlDataReader Sdr;
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();

            try
            {              

                //--- 条件設定
                where += "  AND CHUMON_MEISAI_ID               = " + piChumonMeisaiId                 + " "; //   ChumonMeisaiId

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
        public ReturnInfo Insert(SQLServerHelper Con, ref ChumonMeisaiInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            string where = "";
            string order = "";
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
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
        public ReturnInfo InsertGetID(SQLServerHelper Con, ref ChumonMeisaiInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
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
                            withBlock.Code = System.Convert.ToInt32(Sdr["ChumonMeisaiId"]);
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
        public ReturnInfo Update(SQLServerHelper Con, ref ChumonMeisaiInfo vCls, List<SqlParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
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
        public ReturnInfo Delete(SQLServerHelper con, int piChumonMeisaiId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<SqlParameter> Params = new List<SqlParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDelete(piChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);

                Params.Add(new SqlParameter("@ChumonMeisaiId", piChumonMeisaiId));  // ChumonMeisaiId

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
 
        /// <summary>
        /// データを削除
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo DeleteByForeignKey(SQLServerHelper con, int piChumonId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<SqlParameter> Params = new List<SqlParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDeleteByForeignKey(vstrUpdateUser, vstrUpdateProgram);

                Params.Add(new SqlParameter("@ChumonId", piChumonId)); // ChumonId

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
        public List<ChumonMeisaiInfo> Search(SQLServerHelper con, string where, List<SqlParameter> lstParameter, string order) 
        {
            string sql = "";         
            SqlDataReader Sdr;
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
            List<ChumonMeisaiInfo> lstChumonMeisaiInfo = new List<ChumonMeisaiInfo>(); 

            try
            {
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, lstParameter);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstChumonMeisaiInfo.Add(GetDataSet(Sdr));
                    }
                }

                return lstChumonMeisaiInfo;

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
        public PaginatedList<ChumonMeisaiInfo> SearchPage(SQLServerHelper con, 
                                            string where, 
                                            List<SqlParameter> lstParameter, 
                                            string order,
                                            int iPageIndex = 1,
                                            int iPageSize = 20)
        {
            string sql = "";
            SqlDataReader Sdr;
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
            List<ChumonMeisaiInfo> lstChumonMeisaiInfo = new List<ChumonMeisaiInfo>();

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
                            lstChumonMeisaiInfo.Add(GetDataSet(Sdr));
                        }
                    }
                }

                return new PaginatedList<ChumonMeisaiInfo>(lstChumonMeisaiInfo, iTotalRecord, iPageIndex, iPageSize);

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
        public List<ChumonMeisaiInfo> SearchByKey(SQLServerHelper con ,int piChumonMeisaiId)
        {
            string sql = "";
            string where = "";
            string order = "";
            SqlDataReader Sdr;
            List<SqlParameter> Params = new List<SqlParameter>();   
            ChumonMeisaiInfo objCls = new ChumonMeisaiInfo();
            List<ChumonMeisaiInfo> lstChumonMeisaiInfo = new List<ChumonMeisaiInfo>(); 

            try
            {

                //--- 条件設定
            if(piChumonMeisaiId != -1){
                    where += "AND CHUMON_MEISAI_ID = @ChumonMeisaiId";
            }

                //--- SQL Params
            if(piChumonMeisaiId != -1 ){
                    Params.Add(new SqlParameter("@ChumonMeisaiId", piChumonMeisaiId));
            }

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, Params);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstChumonMeisaiInfo.Add(GetDataSet(Sdr));
                    }
                }

                return lstChumonMeisaiInfo;
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
