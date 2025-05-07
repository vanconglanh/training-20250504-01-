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
    public class PermissionScreenSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public PermissionScreenItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var lst = new List<PermissionScreenEntity>();
            // var lstRet = new List<PermissionScreenSearchListInfo>();
            var ret = new PermissionScreenItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (PermissionScreenEntity row in lst){
                    // lstRet.Add(ConvertToPermissionScreenItemInfo(row));
                    ret = PermissionScreenConvertFunction.ConvertToPermissionScreenItemInfo(row);
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
        public System.Data.DataSet SearchDt(PermissionScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = PermissionScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionScreenConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(PermissionScreenUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = PermissionScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionScreenConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<PermissionScreenItemInfo> Search(PermissionScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var lst = new List<PermissionScreenEntity>();
            var lstRet = new List<PermissionScreenItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = PermissionScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (PermissionScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionScreenConvertFunction.ConvertToPermissionScreenItemInfo(row));

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
        public List<PermissionScreenUIInfo> Search(PermissionScreenUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var lst = new List<PermissionScreenEntity>();
            var lstRet = new List<PermissionScreenUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = PermissionScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (PermissionScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionScreenConvertFunction.ConvertToPermissionScreenUIInfo(row));

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
        public PaginatedList<PermissionScreenItemInfo> SearchPage(PermissionScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new PermissionScreenData();
            var lstRet = new List<PermissionScreenItemInfo>();
            PaginatedList<PermissionScreenItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = PermissionScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = PermissionScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.PageIndex;
                var iPageSize = filter.PageSize;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iPageSize);

                // --- Convert data
                foreach (PermissionScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(PermissionScreenConvertFunction.ConvertToPermissionScreenItemInfo(row));

                lstResult = new PaginatedList<PermissionScreenItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iPageSize);
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