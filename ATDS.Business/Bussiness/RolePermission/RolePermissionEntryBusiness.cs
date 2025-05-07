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


namespace ATDS.Business
{
    public class RolePermissionEntryBusiness
    {
        public RolePermissionUIInfo GetData(int piRoleId, int piPermissionScreenId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            // TODO
            RolePermissionEntity cls;
            RolePermissionUIInfo clsRet = new RolePermissionUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piRoleId,piPermissionScreenId);

                // --- Get foreign key table
                // TODO  

                // Convert data
                if (cls != null)
                {
                    // TODO
                    //clsRet = RolePermissionConvertFunction.ConvertToRolePermissionUIInfo(cls);
                    //clsRet.RolePermissionMeisaiList = RolePermissionMeisaiEntryBusiness.ConvertToRolePermissionMeisaiEntryInfo(cls.RolePermissionMeisaiList);  
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return clsRet;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Add(RolePermissionUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            //RolePermissionMeisaiData daRolePermissionMeisai = new RolePermissionMeisaiData();
            //RolePermissionMeisaiInfo RolePermissionMeisaiInfo;

            RolePermissionEntity cls = new RolePermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RolePermissionConvertFunction.ConvertToRolePermissionEntity(vCls);
                var lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(cls);

                // --- Insert data (RolePermission)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (RolePermissionMeisai)
                //TODO 


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
        public ReturnInfo Add(RolePermissionInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            //RolePermissionMeisaiData daRolePermissionMeisai = new RolePermissionMeisaiData();
            //RolePermissionMeisaiInfo RolePermissionMeisaiInfo;

            RolePermissionEntity cls = new RolePermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RolePermissionConvertFunction.ConvertToRolePermissionEntity(vCls);
                var lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(cls);

                // --- Insert data (RolePermission)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (RolePermissionMeisai)
                //TODO 


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
        public ReturnInfo Update(RolePermissionUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            //RolePermissionMeisaiData daRolePermissionMeisai = new RolePermissionMeisaiData();
            //RolePermissionMeisaiInfo RolePermissionMeisaiInfo;
            RolePermissionEntity cls = new RolePermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RolePermissionConvertFunction.ConvertToRolePermissionEntity(vCls);
                var lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(cls);

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
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Update(RolePermissionUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            //RolePermissionMeisaiData daRolePermissionMeisai = new RolePermissionMeisaiData();
            //RolePermissionMeisaiInfo RolePermissionMeisaiInfo;
            RolePermissionEntity cls = new RolePermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RolePermissionConvertFunction.ConvertToRolePermissionEntity(vCls);
                var lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(cls);

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

        public ReturnInfo Delete(int piRoleId, int piPermissionScreenId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RolePermissionData da = new RolePermissionData();
            //RolePermissionMeisaiData daRolePermissionMeisai = new RolePermissionMeisaiData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(RolePermission)
                ret = da.Delete(con ,piRoleId,piPermissionScreenId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (RolePermissionMeisai)
                //daRolePermissionMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);

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
