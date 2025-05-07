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
    public class RoleSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public RoleItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var lst = new List<RoleEntity>();
            // var lstRet = new List<RoleSearchListInfo>();
            var ret = new RoleItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (RoleEntity row in lst){
                    // lstRet.Add(ConvertToRoleItemInfo(row));
                    ret = RoleConvertFunction.ConvertToRoleItemInfo(row);
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
        public System.Data.DataSet SearchDt(RoleFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = RoleConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RoleConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(RoleUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = RoleConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RoleConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<RoleItemInfo> Search(RoleFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var lst = new List<RoleEntity>();
            var lstRet = new List<RoleItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = RoleConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RoleConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (RoleEntity row in lst)
                    // Convert data
                    lstRet.Add(RoleConvertFunction.ConvertToRoleItemInfo(row));

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
        public List<RoleUIInfo> Search(RoleUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var lst = new List<RoleEntity>();
            var lstRet = new List<RoleUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = RoleConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RoleConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (RoleEntity row in lst)
                    // Convert data
                    lstRet.Add(RoleConvertFunction.ConvertToRoleUIInfo(row));

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
        public PaginatedList<RoleItemInfo> SearchPage(RoleFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new RoleData();
            var lstRet = new List<RoleItemInfo>();
            PaginatedList<RoleItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = RoleConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = RoleConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.PageIndex;
                var iPageSize = filter.PageSize;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iPageSize);

                // --- Convert data
                foreach (RoleEntity row in lst)
                    // Convert data
                    lstRet.Add(RoleConvertFunction.ConvertToRoleItemInfo(row));

                lstResult = new PaginatedList<RoleItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iPageSize);
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