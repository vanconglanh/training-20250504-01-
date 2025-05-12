using ATDS.Common;
using ATDS.DataAccess;
using ATDS.Business.Entity;
using ATDS.DataAccess.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ATDS.Business
{
    public class ChumonMeisaiSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public ChumonMeisaiItemInfo SearchByKey(int piChumonMeisaiId)
        {
            SQLServerHelper Con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var lst = new List<ChumonMeisaiInfo>();
            // var lstRet = new List<ChumonMeisaiSearchListInfo>();
            var ret = new ChumonMeisaiItemInfo();

            try
            {
                Con.Open();

                // --- Search data
                lst = da.SearchByKey(Con ,piChumonMeisaiId);

                // --- Convert data
                foreach (ChumonMeisaiInfo row in lst){
                    // lstRet.Add(ConvertToChumonMeisaiItemInfo(row));
                    ret = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiItemInfo(row);
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
        public System.Data.DataSet SearchDt(ChumonMeisaiFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ChumonMeisaiConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonMeisaiConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(ChumonMeisaiUIFilterInfo filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = ChumonMeisaiConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonMeisaiConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<ChumonMeisaiItemInfo> Search(ChumonMeisaiFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var lst = new List<ChumonMeisaiInfo>();
            var lstRet = new List<ChumonMeisaiItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ChumonMeisaiConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonMeisaiConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ChumonMeisaiInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonMeisaiConvertFunction.ConvertToChumonMeisaiItemInfo(row));

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
        public List<ChumonMeisaiUIInfo> Search(ChumonMeisaiUIFilterInfo filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var lst = new List<ChumonMeisaiInfo>();
            var lstRet = new List<ChumonMeisaiUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = ChumonMeisaiConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonMeisaiConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (ChumonMeisaiInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonMeisaiConvertFunction.ConvertToChumonMeisaiUIInfo(row));

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
        public PaginatedList<ChumonMeisaiItemInfo> SearchPage(ChumonMeisaiFilter filter)
        {
            SQLServerHelper con = new SQLServerHelper();
            var da = new ChumonMeisaiData();
            var lstRet = new List<ChumonMeisaiItemInfo>();
            PaginatedList<ChumonMeisaiItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = ChumonMeisaiConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = ChumonMeisaiConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.PageIndex;
                var iPageSize = filter.PageSize;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iPageSize);

                // --- Convert data
                foreach (ChumonMeisaiInfo row in lst)
                    // Convert data
                    lstRet.Add(ChumonMeisaiConvertFunction.ConvertToChumonMeisaiItemInfo(row));

                lstResult = new PaginatedList<ChumonMeisaiItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iPageSize);
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