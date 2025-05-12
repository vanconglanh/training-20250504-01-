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
    public class RolePermissionSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public RolePermissionItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var lst = new List<RolePermissionEntity>();
            // var lstRet = new List<RolePermissionSearchListInfo>();
            var ret = new RolePermissionItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (RolePermissionEntity row in lst){
                    // lstRet.Add(ConvertToRolePermissionItemInfo(row));
                    ret = RolePermissionConvertFunction.ConvertToRolePermissionItemInfo(row);
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
        public System.Data.DataSet SearchDt(RolePermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = RolePermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RolePermissionConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(RolePermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = RolePermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RolePermissionConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<RolePermissionItemInfo> Search(RolePermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var lst = new List<RolePermissionEntity>();
            var lstRet = new List<RolePermissionItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = RolePermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RolePermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (RolePermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(RolePermissionConvertFunction.ConvertToRolePermissionItemInfo(row));

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
        public List<RolePermissionUIInfo> Search(RolePermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var lst = new List<RolePermissionEntity>();
            var lstRet = new List<RolePermissionUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = RolePermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RolePermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (RolePermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(RolePermissionConvertFunction.ConvertToRolePermissionUIInfo(row));

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
        public PaginatedList<RolePermissionItemInfo> SearchPage(RolePermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RolePermissionData();
            var lstRet = new List<RolePermissionItemInfo>();
            PaginatedList<RolePermissionItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = RolePermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RolePermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (RolePermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(RolePermissionConvertFunction.ConvertToRolePermissionItemInfo(row));

                lstResult = new PaginatedList<RolePermissionItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
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