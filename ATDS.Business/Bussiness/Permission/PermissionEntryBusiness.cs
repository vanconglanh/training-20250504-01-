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
    public class PermissionEntryBusiness
    {
        public PermissionUIInfo GetData(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionData da = new PermissionData();
            // TODO
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            // Dim daPermissionScreen As New PermissionScreenData
            PermissionEntity cls;
            PermissionUIInfo clsRet = new PermissionUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piId);

                // --- Get foreign key table
                // TODO
                //cls.PermissionScreenList = daPermissionScreen.GetDataByForeignKey(ID , con);  

                // Convert data
                if (cls != null)
                {
                    // TODO
                    //clsRet = PermissionConvertFunction.ConvertToPermissionUIInfo(cls);
                    //clsRet.PermissionMeisaiList = PermissionMeisaiEntryBusiness.ConvertToPermissionMeisaiEntryInfo(cls.PermissionMeisaiList);
                    //clsRet.PermissionScreenList = PermissionScreenConvertFunction.ConvertToPermissionScreenUIInfo(cls.PermissionScreenList);  
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
        public ReturnInfo Add(PermissionUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionData da = new PermissionData();
            //PermissionMeisaiData daPermissionMeisai = new PermissionMeisaiData();
            //PermissionMeisaiInfo PermissionMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;

            PermissionEntity cls = new PermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionConvertFunction.ConvertToPermissionEntity(vCls);
                var lstParams = PermissionConvertFunction.ConvertPermissionEntityToParams(cls);

                // --- Insert data (Permission)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (PermissionMeisai)
                //TODO    
                //foreach (var detail in vCls.PermissionScreenList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //   lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //   daPermissionMeisai.Insert(con, ref permissionMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Add(PermissionInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionData da = new PermissionData();
            //PermissionMeisaiData daPermissionMeisai = new PermissionMeisaiData();
            //PermissionMeisaiInfo PermissionMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;

            PermissionEntity cls = new PermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionConvertFunction.ConvertToPermissionEntity(vCls);
                var lstParams = PermissionConvertFunction.ConvertPermissionEntityToParams(cls);

                // --- Insert data (Permission)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (PermissionMeisai)
                //TODO    
                //foreach (var detail in vCls.PermissionScreenList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //   lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //   daPermissionMeisai.Insert(con, ref permissionMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(PermissionUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionData da = new PermissionData();
            //PermissionMeisaiData daPermissionMeisai = new PermissionMeisaiData();
            //PermissionMeisaiInfo PermissionMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;
            PermissionEntity cls = new PermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionConvertFunction.ConvertToPermissionEntity(vCls);
                var lstParams = PermissionConvertFunction.ConvertPermissionEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (PermissionScreenMeisai)
                //   List<PermissionScreenEntity> PermissionScreenListDB = daPermissionScreen.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.PermissionScreenList)
                //   {
                //       // Update Meisai
                //       if (PermissionScreenListDB.Exists(x => x.PermissionScreenId == detail.PermissionScreenId))
                //       {
                //           permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //           lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //           ret = daPermissionScreen.Update(con, ref permissionScreenEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //           lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //           ret = daPermissionScreen.Insert(con, ref permissionScreenEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in PermissionScreenListDB)
                //   {
                //       if (cls.PermissionScreenList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daPermissionScreen.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(PermissionUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            PermissionData da = new PermissionData();
            //PermissionMeisaiData daPermissionMeisai = new PermissionMeisaiData();
            //PermissionMeisaiInfo PermissionMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;
            PermissionEntity cls = new PermissionEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = PermissionConvertFunction.ConvertToPermissionEntity(vCls);
                var lstParams = PermissionConvertFunction.ConvertPermissionEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (PermissionScreenMeisai)
                //   List<PermissionScreenEntity> PermissionScreenListDB = daPermissionScreen.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.PermissionScreenList)
                //   {
                //       // Update Meisai
                //       if (PermissionScreenListDB.Exists(x => x.PermissionScreenId == detail.PermissionScreenId))
                //       {
                //           permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //           lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //           ret = daPermissionScreen.Update(con, ref permissionScreenEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //           lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //           ret = daPermissionScreen.Insert(con, ref permissionScreenEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in PermissionScreenListDB)
                //   {
                //       if (cls.PermissionScreenList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daPermissionScreen.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
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
            PermissionData da = new PermissionData();
            //PermissionMeisaiData daPermissionMeisai = new PermissionMeisaiData();
            PermissionScreenData daPermissionScreen = new PermissionScreenData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(Permission)
                ret = da.Delete(con ,piId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (PermissionMeisai)
                //daPermissionMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);                
                //--- Delete & Insert List (PermissionScreen)
                // TODO
                //daPermissionScreen.DeleteByForeignKey(con ,piId, vstrUpdateUser, vstrUpdateProgram);


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
