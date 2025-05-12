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
    public class VPermissionSearchBusiness
    {
#region 【メソッド】 SearchDt(API)
        public System.Data.DataSet SearchDt(VPermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new VPermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = VPermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = VPermissionConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(VPermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new VPermissionData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = VPermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = VPermissionConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<VPermissionItemInfo> Search(VPermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new VPermissionData();
            var lst = new List<VPermissionEntity>();
            var lstRet = new List<VPermissionItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = VPermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = VPermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (VPermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(VPermissionConvertFunction.ConvertToVPermissionItemInfo(row));

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
        public List<VPermissionUIInfo> Search(VPermissionUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new VPermissionData();
            var lst = new List<VPermissionEntity>();
            var lstRet = new List<VPermissionUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = VPermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = VPermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (VPermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(VPermissionConvertFunction.ConvertToVPermissionUIInfo(row));

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
        public PaginatedList<VPermissionItemInfo> SearchPage(VPermissionFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new VPermissionData();
            var lstRet = new List<VPermissionItemInfo>();
            PaginatedList<VPermissionItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = VPermissionConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = VPermissionConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (VPermissionEntity row in lst)
                    // Convert data
                    lstRet.Add(VPermissionConvertFunction.ConvertToVPermissionItemInfo(row));

                lstResult = new PaginatedList<VPermissionItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
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