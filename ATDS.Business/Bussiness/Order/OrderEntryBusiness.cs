using ATDS.Business.Info;
using ATDS.Common;
using ATDS.Common.DatabaseHelper;
using ATDS.DataAccess;
using ATDS.DataAccess.Entity;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATDS.Business.Bussiness.Order
{
    public class OrderEntryBusiness
    {
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Add(OrderInsert vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            OrderData da = new OrderData();
            //OrderMeisaiData daOrderMeisai = new OrderMeisaiData();
            //OrderMeisaiInfo OrderMeisaiInfo;
            RolePermissionData daRolePermission = new RolePermissionData();
            RolePermissionEntity rolePermissionEntity;

            OrderEntity cls = new OrderEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = OrderConvertFunction.ConvertToOrderEntity(vCls);
                var lstParams = OrderConvertFunction.ConvertOrderEntityToParams(cls);

                // --- Insert data (Order)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (OrderMeisai)
                //TODO    
                //foreach (var detail in vCls.RolePermissionList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //   lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //   daOrderMeisai.Insert(con, ref OrderMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //}                


                // -- End Transation
                con.Commit();
            }
            catch (Exception)
            {
                con.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }

            return ret;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Update(OrderUpdate vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            OrderData da = new OrderData();
            OrderEntity cls = new OrderEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = OrderConvertFunction.ConvertToOrderEntity(vCls);
                var lstParams = OrderConvertFunction.ConvertOrderEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO


                // -- End Transation
                con.Commit();
            }
            catch (Exception ex)
            {
                con.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }

            return ret;
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Delete(int piId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            OrderData da = new OrderData();
            RolePermissionData daRolePermission = new RolePermissionData();

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(Order)
                ret = da.Delete(con, piId, vstrUpdateUser, vstrUpdateProgram);
                // -- End Transation
                con.Commit();
            }
            catch (Exception ex)
            {
                con.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }

            return ret;
        }
    }
}
