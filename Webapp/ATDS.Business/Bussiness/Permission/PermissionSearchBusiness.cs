using ATDS.Common;
using ATDS.DataAccess;
using ATDS.Business.Info;
using ATDS.DataAccess.Entity;
using ATDS.Common.DatabaseHelper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace ATDS.Business
{
    public class PermissionSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public PermissionItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var lst = new List<PermissionEntity>();
            // var lstRet = new List<PermissionSearchListInfo>();
            var ret = new PermissionItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (PermissionEntity row in lst){
                    // lstRet.Add(ConvertToPermissionItemInfo(row));
                    ret = PermissionConvertFunction.ConvertToPermissionItemInfo(row);
                    break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return ret;
        }            
#endregion

#region 【メソッド】 SearchDt(API)
        public System.Data.DataSet SearchDt(PermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = PermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";
                con.Open();               

                // --- Search data
                ret = da.SearchDt(con, whereCondition, lstParameter, order);

                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
#endregion

#region 【メソッド】 SearchDt(UI)
        public System.Data.DataSet SearchDt(PermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = PermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";
                con.Open();               

                // --- Search data
                ret = da.SearchDt(con, whereCondition, lstParameter, order);

                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
#endregion

#region 【メソッド】 Search（all item）(API)
        public List<PermissionItemInfo> Search(PermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var lst = new List<PermissionEntity>();
            var lstRet = new List<PermissionItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = PermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (PermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionConvertFunction.ConvertToPermissionItemInfo(row));

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return lstRet;
        }
#endregion

#region 【メソッド】 Search（all item）(UI)
        public List<PermissionUIInfo> Search(PermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var lst = new List<PermissionEntity>();
            var lstRet = new List<PermissionUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = PermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (PermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionConvertFunction.ConvertToPermissionUIInfo(row));

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return lstRet;
        }
#endregion
    
#region 【メソッド】 SearchPage
        public PaginatedList<PermissionItemInfo> SearchPage(PermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionData();
            var lstRet = new List<PermissionItemInfo>();
            PaginatedList<PermissionItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = PermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (PermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionConvertFunction.ConvertToPermissionItemInfo(row));

                lstResult = new PaginatedList<PermissionItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return lstResult;
        }
        #endregion
    }
}