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
    public class VPermissionData
    {
        public VPermissionData() : base()
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
                sql.Append(" ,IFNULL(ROLE_ID                       , 0) AS RoleId                        ");  //   RoleId
                sql.Append(" ,IFNULL(ROLE_CODE                     ,'') AS RoleCode                      ");  //   RoleCode
                sql.Append(" ,IFNULL(ROLE_NAME                     ,'') AS RoleName                      ");  //   RoleName
                sql.Append(" ,IFNULL(SCREEN_ID                     , 0) AS ScreenId                      ");  //   ScreenId
                sql.Append(" ,IFNULL(SCREEN_CODE                   ,'') AS ScreenCode                    ");  //   ScreenCode
                sql.Append(" ,IFNULL(SCREEN_NAME                   ,'') AS ScreenName                    ");  //   ScreenName
                sql.Append(" ,IFNULL(PERMISSION_ID                 , 0) AS PermissionId                  ");  //   PermissionId
                sql.Append(" ,IFNULL(PERMISSION_CODE               ,'') AS PermissionCode                ");  //   PermissionCode
                sql.Append(" ,IFNULL(PERMISSION_NAME               ,'') AS PermissionName                ");  //   PermissionName
                sql.Append(" FROM V_PERMISSION                                                           ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" FROM V_PERMISSION                                                           ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
                sql.Append(" ,IFNULL(ROLE_ID                       , 0) AS RoleId                        ");  //   RoleId
                sql.Append(" ,IFNULL(ROLE_CODE                     ,'') AS RoleCode                      ");  //   RoleCode
                sql.Append(" ,IFNULL(ROLE_NAME                     ,'') AS RoleName                      ");  //   RoleName
                sql.Append(" ,IFNULL(SCREEN_ID                     , 0) AS ScreenId                      ");  //   ScreenId
                sql.Append(" ,IFNULL(SCREEN_CODE                   ,'') AS ScreenCode                    ");  //   ScreenCode
                sql.Append(" ,IFNULL(SCREEN_NAME                   ,'') AS ScreenName                    ");  //   ScreenName
                sql.Append(" ,IFNULL(PERMISSION_ID                 , 0) AS PermissionId                  ");  //   PermissionId
                sql.Append(" ,IFNULL(PERMISSION_CODE               ,'') AS PermissionCode                ");  //   PermissionCode
                sql.Append(" ,IFNULL(PERMISSION_NAME               ,'') AS PermissionName                ");  //   PermissionName
                sql.Append(" FROM V_PERMISSION                                                           ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
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
#endregion

#region Get Data
        /// <summary>
        /// GetDataSet
        /// </summary>
        /// <param name="Sdr"></param>
        /// <returns></returns>
        private VPermissionEntity GetDataSet(IDataReader Sdr)
        {
            VPermissionEntity VPermission = new VPermissionEntity();                                  // VPermissionｸﾗｽ定義   

            try
            {
                VPermission = new VPermissionEntity();                                   // V_PERMISSION　ｸﾗｽ初期化

                {
                    var withBlock = VPermission;                                               // @@@Table.NAME情報格納
                    withBlock.RoleId = System.Convert.ToInt32(Sdr["RoleId"]); //   RoleId
                    withBlock.RoleCode = ((string)Sdr["RoleCode"]).Trim(); //   RoleCode
                    withBlock.RoleName = ((string)Sdr["RoleName"]).Trim(); //   RoleName
                    withBlock.ScreenId = System.Convert.ToInt32(Sdr["ScreenId"]); //   ScreenId
                    withBlock.ScreenCode = ((string)Sdr["ScreenCode"]).Trim(); //   ScreenCode
                    withBlock.ScreenName = ((string)Sdr["ScreenName"]).Trim(); //   ScreenName
                    withBlock.PermissionId = System.Convert.ToInt32(Sdr["PermissionId"]); //   PermissionId
                    withBlock.PermissionCode = ((string)Sdr["PermissionCode"]).Trim(); //   PermissionCode
                    withBlock.PermissionName = ((string)Sdr["PermissionName"]).Trim(); //   PermissionName
                }

                return VPermission;
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
        /// <param name="vstrVPermissionId"></param>
        /// <returns></returns>
        public VPermissionEntity GetData(MySQLServerHelper Con )
        {
            string sql = "";
            string where = "";
            string Order = "";
            IDataReader Sdr;
            VPermissionEntity objCls = new VPermissionEntity();

            try
            {

                // --- 条件設定
                where += "  AND STATUS   =   " + (int)Constant.STATUS.ENABLED + " ";

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

#region 【一覧取得】 Search
        public List<VPermissionEntity> Search(MySQLServerHelper con, string where, List<IDbDataParameter> lstParameter, string order) 
        {
            string sql = "";         
            IDataReader Sdr;
            VPermissionEntity objCls = new VPermissionEntity();
            List<VPermissionEntity> lstVPermissionEntity = new List<VPermissionEntity>(); 

            try
            {
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, lstParameter);

                using (Sdr) { 

                    while (Sdr.Read()){
                        lstVPermissionEntity.Add(GetDataSet(Sdr));
                    }
                }

                return lstVPermissionEntity;

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
        public PaginatedList<VPermissionEntity> SearchPage(MySQLServerHelper con, 
                                            string where, 
                                            List<IDbDataParameter> lstParameter, 
                                            string order,
                                            int iPage = 1,
                                            int iSize = 20)
        {
            string sql = "";
            IDataReader Sdr;
            VPermissionEntity objCls = new VPermissionEntity();
            List<VPermissionEntity> lstVPermissionEntity = new List<VPermissionEntity>();

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
                            lstVPermissionEntity.Add(GetDataSet(Sdr));
                        }
                    }
                }

                return new PaginatedList<VPermissionEntity>(lstVPermissionEntity, iTotalRecord, iPage, iSize);

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
