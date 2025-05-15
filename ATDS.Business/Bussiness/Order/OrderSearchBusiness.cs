using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Business.Info;
using ATDS.Common.DatabaseHelper;
using ATDS.Common;
using ATDS.DataAccess.Entity;
using ATDS.DataAccess;

namespace ATDS.Business.Bussiness.Order
{
    public class OrderSearchBusiness
    {
        #region 【メソッド】 SearchByKey
        public OrderItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new OrderData();
            var lst = new List<OrderEntity>();
            // var lstRet = new List<OrderSearchListInfo>();
            var ret = new OrderItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con, piId);

                // --- Convert data
                foreach (OrderEntity row in lst)
                {
                    // lstRet.Add(ConvertToPermissionScreenItemInfo(row));
                    ret = OrderConvertFunction.ConvertToOrderItemInfo(row);
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
        #region 【メソッド】 Search（all item）(API)
        public List<OrderItemInfo> Search(OrderFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new OrderData();
            var lst = new List<OrderEntity>();
            var lstRet = new List<OrderItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = OrderConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = OrderConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (OrderEntity row in lst)
                    // Convert data
                    lstRet.Add(OrderConvertFunction.ConvertToOrderItemInfo(row));

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
        public PaginatedList<OrderItemInfo> SearchPage(OrderFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new OrderData();
            var lstRet = new List<OrderItemInfo>();
            PaginatedList<OrderItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = OrderConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = OrderConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (OrderEntity row in lst)
                    // Convert data
                    lstRet.Add(OrderConvertFunction.ConvertToOrderItemInfo(row));

                lstResult = new PaginatedList<OrderItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
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
