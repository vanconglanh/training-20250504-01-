using ATDS.Common;
using ATDS.DataAccess;
using ATDS.Business.Entity;
using ATDS.DataAccess.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ATDS.Business
{
    public class ChumonSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public ChumonItemInfo SearchByKey(int piChumonId)
        {
            SQLServerHelper Con = new SQLServerHelper();
            var da = new ChumonData();
            var lst = new List<ChumonInfo>();
            // var lstRet = new List<ChumonSearchListInfo>();
            var ret = new ChumonItemInfo();

            try
            {
                Con.Open();

                // --- Search data
                lst = da.SearchByKey(Con ,piChumonId);

                // --- Convert data
                foreach (ChumonInfo row in lst){
                    // lstRet.Add(ConvertToChumonItemInfo(row));
                    ret = ChumonConvertFunction.ConvertToChumonItemInfo(row);
                    break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }

            return ret;
        }            
#endregion

#region 【メソッド】 SearchDt(API)
        public System.Data.DataSet SearchDt(ChumonFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ChumonConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(ChumonUIFilterInfo filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ChumonConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<ChumonItemInfo> Search(ChumonFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonData();
            var lst = new List<ChumonInfo>();
            var lstRet = new List<ChumonItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ChumonConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ChumonInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonConvertFunction.ConvertToChumonItemInfo(row));

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
        public List<ChumonUIInfo> Search(ChumonUIFilterInfo filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonData();
            var lst = new List<ChumonInfo>();
            var lstRet = new List<ChumonUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ChumonConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ChumonInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonConvertFunction.ConvertToChumonUIInfo(row));

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
        public PaginatedList<ChumonItemInfo> SearchPage(ChumonFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonData();
            var lstRet = new List<ChumonItemInfo>();
            PaginatedList<ChumonItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = ChumonConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.PageIndex;
                var iPageSize = filter.PageSize;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iPageSize);

                // --- Convert data
                foreach (ChumonInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonConvertFunction.ConvertToChumonItemInfo(row));

                lstResult = new PaginatedList<ChumonItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iPageSize);
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