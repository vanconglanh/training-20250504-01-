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
    public class ScreenSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public ScreenItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var lst = new List<ScreenEntity>();
            // var lstRet = new List<ScreenSearchListInfo>();
            var ret = new ScreenItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (ScreenEntity row in lst){
                    // lstRet.Add(ConvertToScreenItemInfo(row));
                    ret = ScreenConvertFunction.ConvertToScreenItemInfo(row);
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
        public System.Data.DataSet SearchDt(ScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ScreenConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(ScreenUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ScreenConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<ScreenItemInfo> Search(ScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var lst = new List<ScreenEntity>();
            var lstRet = new List<ScreenItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(ScreenConvertFunction.ConvertToScreenItemInfo(row));

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
        public List<ScreenUIInfo> Search(ScreenUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var lst = new List<ScreenEntity>();
            var lstRet = new List<ScreenUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(ScreenConvertFunction.ConvertToScreenUIInfo(row));

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
        public PaginatedList<ScreenItemInfo> SearchPage(ScreenFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new ScreenData();
            var lstRet = new List<ScreenItemInfo>();
            PaginatedList<ScreenItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = ScreenConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ScreenConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (ScreenEntity row in lst)
                    // Convert data
                    lstRet.Add(ScreenConvertFunction.ConvertToScreenItemInfo(row));

                lstResult = new PaginatedList<ScreenItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
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