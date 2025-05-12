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
    public class PermissionScreenEntryBusiness
    {
        public PermissionScreenUIInfo GetData(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            // TODO
            RolePermissionData daRolePermission = new RolePermissionData();
            // Dim daRolePermission As New RolePermissionData
            PermissionScreenEntity cls;
            PermissionScreenUIInfo clsRet = new PermissionScreenUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piId);

                // --- Get foreign key table
                // TODO
                //cls.RolePermissionList = daRolePermission.GetDataByForeignKey(ID ,ID ,ID , con);  

                // Convert data
                if (cls != null)
                {
                    // TODO
                    //clsRet = PermissionScreenConvertFunction.ConvertToPermissionScreenUIInfo(cls);
                    //clsRet.PermissionScreenMeisaiList = PermissionScreenMeisaiEntryBusiness.ConvertToPermissionScreenMeisaiEntryInfo(cls.PermissionScreenMeisaiList);
                    //clsRet.RolePermissionList = RolePermissionConvertFunction.ConvertToRolePermissionUIInfo(cls.RolePermissionList);  
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
        public ReturnInfo Add(PermissionScreenUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            //PermissionScreenMeisaiData daPermissionScreenMeisai = new PermissionScreenMeisaiData();
            //PermissionScreenMeisaiInfo PermissionScreenMeisaiInfo;
            RolePermissionData daRolePermission = new RolePermissionData();
            RolePermissionEntity rolePermissionEntity;

            PermissionScreenEntity cls = new PermissionScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(vCls);
                var lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(cls);

                // --- Insert data (PermissionScreen)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (PermissionScreenMeisai)
                //TODO    
                //foreach (var detail in vCls.RolePermissionList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //   lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //   daPermissionScreenMeisai.Insert(con, ref permissionScreenMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Add(PermissionScreenInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            //PermissionScreenMeisaiData daPermissionScreenMeisai = new PermissionScreenMeisaiData();
            //PermissionScreenMeisaiInfo PermissionScreenMeisaiInfo;
            RolePermissionData daRolePermission = new RolePermissionData();
            RolePermissionEntity rolePermissionEntity;

            PermissionScreenEntity cls = new PermissionScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(vCls);
                var lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(cls);

                // --- Insert data (PermissionScreen)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (PermissionScreenMeisai)
                //TODO    
                //foreach (var detail in vCls.RolePermissionList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //   lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //   daPermissionScreenMeisai.Insert(con, ref permissionScreenMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(PermissionScreenUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            //PermissionScreenMeisaiData daPermissionScreenMeisai = new PermissionScreenMeisaiData();
            //PermissionScreenMeisaiInfo PermissionScreenMeisaiInfo;
            RolePermissionData daRolePermission = new RolePermissionData();
            RolePermissionEntity rolePermissionEntity;
            PermissionScreenEntity cls = new PermissionScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(vCls);
                var lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (RolePermissionMeisai)
                //   List<RolePermissionEntity> RolePermissionListDB = daRolePermission.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.RolePermissionList)
                //   {
                //       // Update Meisai
                //       if (RolePermissionListDB.Exists(x => x.RolePermissionId == detail.RolePermissionId))
                //       {
                //           rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //           lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //           ret = daRolePermission.Update(con, ref rolePermissionEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //           lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //           ret = daRolePermission.Insert(con, ref rolePermissionEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in RolePermissionListDB)
                //   {
                //       if (cls.RolePermissionList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daRolePermission.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
                //   }
                //}                

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
        public ReturnInfo Update(PermissionScreenUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            //PermissionScreenMeisaiData daPermissionScreenMeisai = new PermissionScreenMeisaiData();
            //PermissionScreenMeisaiInfo PermissionScreenMeisaiInfo;
            RolePermissionData daRolePermission = new RolePermissionData();
            RolePermissionEntity rolePermissionEntity;
            PermissionScreenEntity cls = new PermissionScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(vCls);
                var lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (RolePermissionMeisai)
                //   List<RolePermissionEntity> RolePermissionListDB = daRolePermission.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.RolePermissionList)
                //   {
                //       // Update Meisai
                //       if (RolePermissionListDB.Exists(x => x.RolePermissionId == detail.RolePermissionId))
                //       {
                //           rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //           lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //           ret = daRolePermission.Update(con, ref rolePermissionEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           rolePermissionEntity = RolePermissionConvertFunction.ConvertToRolePermissionEntity(detail);
                //           lstParams = RolePermissionConvertFunction.ConvertRolePermissionEntityToParams(rolePermissionEntity);
                //           ret = daRolePermission.Insert(con, ref rolePermissionEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in RolePermissionListDB)
                //   {
                //       if (cls.RolePermissionList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daRolePermission.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
                //   }
                //}                

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

        public ReturnInfo Delete(int piId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionScreenData da = new PermissionScreenData();
            //PermissionScreenMeisaiData daPermissionScreenMeisai = new PermissionScreenMeisaiData();
            RolePermissionData daRolePermission = new RolePermissionData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(PermissionScreen)
                ret = da.Delete(con ,piId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (PermissionScreenMeisai)
                //daPermissionScreenMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);                
                //--- Delete & Insert List (RolePermission)
                // TODO
                //daRolePermission.DeleteByForeignKey(con ,piId, vstrUpdateUser, vstrUpdateProgram);


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
