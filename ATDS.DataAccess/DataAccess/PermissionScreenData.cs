using ATDS.Common;
using ATDS.Common.Utils;
using ATDS.Common.DatabaseHelper;
using ATDS.DataAccess.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess
{
    public class PermissionScreenData
    {
        public PermissionScreenData() : base()
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
                sql.Append(" ,IFNULL(ID                            , 0) AS Id                            ");  //   Id
                sql.Append(" ,IFNULL(PERMISSION_ID                 , 0) AS PermissionId                  ");  //   PermissionId
                sql.Append(" ,IFNULL(SCREEN_ID                     , 0) AS ScreenId                      ");  //   ScreenId
                sql.Append(" ,IFNULL(CODE                          ,'') AS Code                          ");  //   Code
                sql.Append(" ,IFNULL(CREATED_AT                    , '" + Constant.DATE_MIN + "') AS CreatedAt                     ");  //   CreatedAt
                sql.Append(" ,IFNULL(UPDATED_AT                    , '" + Constant.DATE_MIN + "') AS UpdatedAt                     ");  //   UpdatedAt
                sql.Append(" ,IFNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,IFNULL(CREATED_USER                  , 0) AS CreatedUser                   ");  //   CreatedUser
                sql.Append(" ,IFNULL(LAST_UPDATE_USER              , 0) AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,IFNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM M_PERMISSION_SCREEN                                                    ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" FROM M_PERMISSION_SCREEN                                                    ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
        /// <param name="iPage"></param>
        /// <param name="iRecordOfPage"></param>
        /// <returns></returns>
        public string sqlBaseSetSelectPage(string Where, string Order, int iPage, int iRecordOfPage)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT                                                                                     ");
                sql.Append(" 1                                                                                          ");
                sql.Append(" ,IFNULL(ID                            , 0) AS Id                            ");  //   Id
                sql.Append(" ,IFNULL(PERMISSION_ID                 , 0) AS PermissionId                  ");  //   PermissionId
                sql.Append(" ,IFNULL(SCREEN_ID                     , 0) AS ScreenId                      ");  //   ScreenId
                sql.Append(" ,IFNULL(CODE                          ,'') AS Code                          ");  //   Code
                sql.Append(" ,IFNULL(CREATED_AT                    , '" + Constant.DATE_MIN + "') AS CreatedAt                     ");  //   CreatedAt
                sql.Append(" ,IFNULL(UPDATED_AT                    , '" + Constant.DATE_MIN + "') AS UpdatedAt                     ");  //   UpdatedAt
                sql.Append(" ,IFNULL(YUKO_FLAG                     , 0) AS YukoFlag                      ");  //   YukoFlag
                sql.Append(" ,IFNULL(CREATED_USER                  , 0) AS CreatedUser                   ");  //   CreatedUser
                sql.Append(" ,IFNULL(LAST_UPDATE_USER              , 0) AS LastUpdateUser                ");  //   LastUpdateUser
                sql.Append(" ,IFNULL(LAST_UPDATE_PROGRAM           ,'') AS LastUpdateProgram             ");  //   LastUpdateProgram
                sql.Append(" FROM M_PERMISSION_SCREEN                                                    ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" LIMIT " + iRecordOfPage + " OFFSET " + (iPage - 1) * iRecordOfPage);

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
        public string sqlBaseSetInsert(PermissionScreenEntity cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // INSERT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" INSERT INTO M_PERMISSION_SCREEN   (");
                sql.Append("  PERMISSION_ID                     ");  //   PermissionId
                sql.Append(" ,SCREEN_ID                         ");  //   ScreenId
                sql.Append(" ,CODE                              ");  //   Code
                sql.Append(" ,CREATED_AT                        ");  //   CreatedAt
                sql.Append(" ,UPDATED_AT                        ");  //   UpdatedAt
                sql.Append(" ,YUKO_FLAG                         ");  //   YukoFlag
                sql.Append(" ,CREATED_USER                      ");  //   CreatedUser
                sql.Append(" ,LAST_UPDATE_USER                  ");  //   LastUpdateUser
                sql.Append(" ,LAST_UPDATE_PROGRAM               ");  //   LastUpdateProgram
                sql.Append(" )  ");

                sql.Append(" VALUES ( ");
                sql.Append("  @PermissionId                      ");  //   PermissionId
                sql.Append(" ,@ScreenId                         ");  //   ScreenId
                sql.Append(" ,@Code                             ");  //   Code
                sql.Append(" ,@CreatedAt                        ");  //   CreatedAt
                sql.Append(" ,@UpdatedAt                        ");  //   UpdatedAt
                sql.Append(" ,@YukoFlag                         ");  //   YukoFlag
                sql.Append(" ,@CreatedUser                      ");  //   CreatedUser
                sql.Append(" ,@LastUpdateUser                   ");  //   LastUpdateUser
                sql.Append(" ,@LastUpdateProgram                ");  //   LastUpdateProgram
                sql.Append(" ); SELECT LAST_INSERT_ID();        ");  //   データ登録の自動採番データ取得

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
        public string sqlBaseSetUpdate(PermissionScreenEntity cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  M_PERMISSION_SCREEN                                          ");
                sql.Append(" SET PERMISSION_ID                  = @PermissionId                  ");  //   PermissionId
                sql.Append("    ,SCREEN_ID                      = @ScreenId                      "); //   ScreenId
                sql.Append("    ,CODE                           = @Code                          "); //   Code
                sql.Append("    ,CREATED_AT                     = @CreatedAt                     "); //   CreatedAt
                sql.Append("    ,UPDATED_AT                     = @UpdatedAt                     "); //   UpdatedAt
                sql.Append("    ,YUKO_FLAG                      = @YukoFlag                      "); //   YukoFlag
                sql.Append("    ,CREATED_USER                   = @CreatedUser                   "); //   CreatedUser
                sql.Append("    ,LAST_UPDATE_USER               = @LastUpdateUser                "); //   LastUpdateUser
                sql.Append("    ,LAST_UPDATE_PROGRAM            = @LastUpdateProgram             "); //   LastUpdateProgram

                sql.Append(" WHERE ID                             = @Id                            ");  //   検索条件定義
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
        /// </summary>        /// <param name="ID"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetDelete(int piId,
                                       string vstrUpdateUser, 
                                       string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  M_PERMISSION_SCREEN                                                                         ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "         ,");
                sql.Append("     LAST_UPDATE_USER           =    " + vstrUpdateUser + "                    ,");
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");
                sql.Append(" WHERE ID                       = @Id                            ");  //   検索条件定義

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
                sql.Append(" UPDATE M_PERMISSION_SCREEN                     ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "        ,");  
                sql.Append("     LAST_UPDATE_USER           =    " + vstrUpdateUser + "                     ,");      
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");  
                sql.Append(" WHERE YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.ENABLED);

                sql.Append(" AND PERMISSION_ID            = @PermissionId                  ");  //   検索条件定義
                sql.Append(" AND SCREEN_ID                = @ScreenId                      ");  //   検索条件定義

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
        private PermissionScreenEntity GetDataSet(IDataReader Sdr)
        {
            PermissionScreenEntity PermissionScreen = new PermissionScreenEntity();                                  // PermissionScreenｸﾗｽ定義   

            try
            {
                PermissionScreen = new PermissionScreenEntity();                                   // M_PERMISSION_SCREEN　ｸﾗｽ初期化

                {
                    var withBlock = PermissionScreen;                                               // @@@Table.NAME情報格納
                    withBlock.Id = System.Convert.ToInt32(Sdr["Id"]); //   Id
                    withBlock.PermissionId = System.Convert.ToInt32(Sdr["PermissionId"]); //   PermissionId
                    withBlock.ScreenId = System.Convert.ToInt32(Sdr["ScreenId"]); //   ScreenId
                    withBlock.Code = ((string)Sdr["Code"]).Trim(); //   Code
                    if (Sdr["CreatedAt"] == null){
                        withBlock.CreatedAt = DateTime.MinValue;
                    }
                    else{
                        withBlock.CreatedAt = Convert.ToDateTime(Sdr["CreatedAt"]); //  PermissionScreenDate 
                    }
                    if (Sdr["UpdatedAt"] == null){
                        withBlock.UpdatedAt = DateTime.MinValue;
                    }
                    else{
                        withBlock.UpdatedAt = Convert.ToDateTime(Sdr["UpdatedAt"]); //  PermissionScreenDate 
                    }
                    withBlock.YukoFlag = System.Convert.ToInt32(Sdr["YukoFlag"]); //   YukoFlag
                    withBlock.CreatedUser = System.Convert.ToInt32(Sdr["CreatedUser"]); //   CreatedUser
                    withBlock.LastUpdateUser = System.Convert.ToInt32(Sdr["LastUpdateUser"]); //   LastUpdateUser
                    withBlock.LastUpdateProgram = ((string)Sdr["LastUpdateProgram"]).Trim(); //   LastUpdateProgram
                }

                return PermissionScreen;
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
        /// <param name="Con">MySQLServerHelper</param>
        /// <param name="vstrPermissionScreenId"></param>
        /// <returns></returns>
        public PermissionScreenEntity GetData(MySQLServerHelper Con ,int piId)
        {
            string sql = "";
            string where = "";
            string Order = "";
            IDataReader Sdr;
            PermissionScreenEntity objCls = new PermissionScreenEntity();

            try
            {

                // --- 条件設定
                where += "  AND YUKO_FLAG   =   " + (int)Constant.YUKO_FLAG.ENABLED + " ";
                where += "  AND ID                             = " + piId                             + " "; //   Id

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
        public List<PermissionScreenEntity> GetDataByForeignKey(int piPermissionId,int piScreenId,MySQLServerHelper con)
        {
            string sql = "";
            string where = "";
            string order = "";
            IDataReader Sdr;
            PermissionScreenEntity objCls;
            List<PermissionScreenEntity> objResult = new List<PermissionScreenEntity>();

            try
            {

                //--- 条件設定
                where += "  AND  PERMISSION_ID = " + piPermissionId + " "; //   PermissionId
                where += "  AND  SCREEN_ID = " + piScreenId + " "; //   ScreenId
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
        public bool CheckData(MySQLServerHelper con ,int piId)
        {
            string sql = ""; 
            string where = "";
            string order = "";
            IDataReader Sdr;
            PermissionScreenEntity objCls = new PermissionScreenEntity();

            try
            {              

                //--- 条件設定
                where += "  AND ID                             = " + piId                             + " "; //   Id

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
        public ReturnInfo Insert(MySQLServerHelper Con, ref PermissionScreenEntity vCls, List<IDbDataParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            string where = "";
            string order = "";
            PermissionScreenEntity objCls = new PermissionScreenEntity();
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
        public ReturnInfo InsertGetID(MySQLServerHelper Con, ref PermissionScreenEntity vCls, List<IDbDataParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            PermissionScreenEntity objCls = new PermissionScreenEntity();
            ReturnInfo ret = new ReturnInfo();
            IDataReader Sdr;

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
                            withBlock.Code = System.Convert.ToInt32(Sdr["Id"]);
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
        public ReturnInfo Update(MySQLServerHelper Con, ref PermissionScreenEntity vCls, List<IDbDataParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            PermissionScreenEntity objCls = new PermissionScreenEntity();
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
        public ReturnInfo Delete(MySQLServerHelper con, int piId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<IDbDataParameter> Params = new List<IDbDataParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDelete(piId, vstrUpdateUser, vstrUpdateProgram);

                Params.Add(DBUtils.CreateParam("@Id", piId));  // Id

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
        public ReturnInfo DeleteByForeignKey(MySQLServerHelper con, int piPermissionId,int piScreenId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<IDbDataParameter> Params = new List<IDbDataParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDeleteByForeignKey(vstrUpdateUser, vstrUpdateProgram);

                Params.Add(DBUtils.CreateParam("@PermissionId", piPermissionId)); // PermissionId
                Params.Add(DBUtils.CreateParam("@ScreenId", piScreenId)); // ScreenId

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
        public List<PermissionScreenEntity> Search(MySQLServerHelper con, string where, List<IDbDataParameter> lstParameter, string order) 
        {
            string sql = "";         
            IDataReader Sdr;
            PermissionScreenEntity objCls = new PermissionScreenEntity();
            List<PermissionScreenEntity> lstPermissionScreenEntity = new List<PermissionScreenEntity>(); 

            try
            {
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, lstParameter);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstPermissionScreenEntity.Add(GetDataSet(Sdr));
                    }
                }

                return lstPermissionScreenEntity;

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
        public PaginatedList<PermissionScreenEntity> SearchPage(MySQLServerHelper con, 
                                            string where, 
                                            List<IDbDataParameter> lstParameter, 
                                            string order,
                                            int iPage = 1,
                                            int iSize = 20)
        {
            string sql = "";
            IDataReader Sdr;
            PermissionScreenEntity objCls = new PermissionScreenEntity();
            List<PermissionScreenEntity> lstPermissionScreenEntity = new List<PermissionScreenEntity>();

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
                    sql = sqlBaseSetSelectPage(where, order, iPage, iSize);

                    //--- 情報取得                    
                    Sdr = con.SelectSQLWithParams(sql, lstParameter.ToList());

                    using (Sdr)
                    {

                        while (Sdr.Read())
                        {
                            lstPermissionScreenEntity.Add(GetDataSet(Sdr));
                        }
                    }
                }

                return new PaginatedList<PermissionScreenEntity>(lstPermissionScreenEntity, iTotalRecord, iPage, iSize);

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
        public List<PermissionScreenEntity> SearchByKey(MySQLServerHelper con ,int piId)
        {
            string sql = "";
            string where = "";
            string order = "";
            IDataReader Sdr;
            List<IDbDataParameter> Params = new List<IDbDataParameter>();   
            PermissionScreenEntity objCls = new PermissionScreenEntity();
            List<PermissionScreenEntity> lstPermissionScreenEntity = new List<PermissionScreenEntity>(); 

            try
            {

                //--- 条件設定
            if(piId != -1){
                    where += "AND ID = @Id";
            }

                //--- SQL Params
            if(piId != -1 ){
                    Params.Add(DBUtils.CreateParam("@Id", piId));
            }

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, Params);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstPermissionScreenEntity.Add(GetDataSet(Sdr));
                    }
                }

                return lstPermissionScreenEntity;
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
        public DataSet SearchDt(MySQLServerHelper con, string where, List<IDbDataParameter> lstParameter, string order)
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
