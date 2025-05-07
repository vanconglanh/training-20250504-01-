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
    public class ScreenEntryBusiness
    {
        public ScreenUIInfo GetData(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            ScreenData da = new ScreenData();
            // TODO
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            // Dim daPermissionScreen As New PermissionScreenData
            ScreenEntity cls;
            ScreenUIInfo clsRet = new ScreenUIInfo();

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
                    //clsRet = ScreenConvertFunction.ConvertToScreenUIInfo(cls);
                    //clsRet.ScreenMeisaiList = ScreenMeisaiEntryBusiness.ConvertToScreenMeisaiEntryInfo(cls.ScreenMeisaiList);
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
        public ReturnInfo Add(ScreenUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            ScreenData da = new ScreenData();
            //ScreenMeisaiData daScreenMeisai = new ScreenMeisaiData();
            //ScreenMeisaiInfo ScreenMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;

            ScreenEntity cls = new ScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ScreenConvertFunction.ConvertToScreenEntity(vCls);
                var lstParams = ScreenConvertFunction.ConvertScreenEntityToParams(cls);

                // --- Insert data (Screen)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ScreenMeisai)
                //TODO    
                //foreach (var detail in vCls.PermissionScreenList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //   lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //   daScreenMeisai.Insert(con, ref screenMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Add(ScreenInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            ScreenData da = new ScreenData();
            //ScreenMeisaiData daScreenMeisai = new ScreenMeisaiData();
            //ScreenMeisaiInfo ScreenMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;

            ScreenEntity cls = new ScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ScreenConvertFunction.ConvertToScreenEntity(vCls);
                var lstParams = ScreenConvertFunction.ConvertScreenEntityToParams(cls);

                // --- Insert data (Screen)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ScreenMeisai)
                //TODO    
                //foreach (var detail in vCls.PermissionScreenList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   permissionScreenEntity = PermissionScreenConvertFunction.ConvertToPermissionScreenEntity(detail);
                //   lstParams = PermissionScreenConvertFunction.ConvertPermissionScreenEntityToParams(permissionScreenEntity);
                //   daScreenMeisai.Insert(con, ref screenMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(ScreenUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            ScreenData da = new ScreenData();
            //ScreenMeisaiData daScreenMeisai = new ScreenMeisaiData();
            //ScreenMeisaiInfo ScreenMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;
            ScreenEntity cls = new ScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ScreenConvertFunction.ConvertToScreenEntity(vCls);
                var lstParams = ScreenConvertFunction.ConvertScreenEntityToParams(cls);

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
        public ReturnInfo Update(ScreenUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            ScreenData da = new ScreenData();
            //ScreenMeisaiData daScreenMeisai = new ScreenMeisaiData();
            //ScreenMeisaiInfo ScreenMeisaiInfo;
            PermissionScreenData daPermissionScreen = new PermissionScreenData();
            PermissionScreenEntity permissionScreenEntity;
            ScreenEntity cls = new ScreenEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ScreenConvertFunction.ConvertToScreenEntity(vCls);
                var lstParams = ScreenConvertFunction.ConvertScreenEntityToParams(cls);

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
            ScreenData da = new ScreenData();
            //ScreenMeisaiData daScreenMeisai = new ScreenMeisaiData();
            PermissionScreenData daPermissionScreen = new PermissionScreenData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(Screen)
                ret = da.Delete(con ,piId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (ScreenMeisai)
                //daScreenMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);                
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
