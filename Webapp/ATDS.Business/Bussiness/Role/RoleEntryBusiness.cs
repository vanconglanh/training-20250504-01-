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
    public class RoleEntryBusiness
    {
        public RoleUIInfo GetData(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RoleData da = new RoleData();
            // TODO
            UserData daUser = new UserData();
            // Dim daUser As New UserData
            RoleEntity cls;
            RoleUIInfo clsRet = new RoleUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piId);

                // --- Get foreign key table
                // TODO
                //cls.UserList = daUser.GetDataByForeignKey(ID , con);  

                // Convert data
                if (cls != null)
                {
                    // TODO
                    //clsRet = RoleConvertFunction.ConvertToRoleUIInfo(cls);
                    //clsRet.RoleMeisaiList = RoleMeisaiEntryBusiness.ConvertToRoleMeisaiEntryInfo(cls.RoleMeisaiList);
                    //clsRet.UserList = UserConvertFunction.ConvertToUserUIInfo(cls.UserList);  
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
        public ReturnInfo Add(RoleUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RoleData da = new RoleData();
            //RoleMeisaiData daRoleMeisai = new RoleMeisaiData();
            //RoleMeisaiInfo RoleMeisaiInfo;
            UserData daUser = new UserData();
            UserEntity userEntity;

            RoleEntity cls = new RoleEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RoleConvertFunction.ConvertToRoleEntity(vCls);
                var lstParams = RoleConvertFunction.ConvertRoleEntityToParams(cls);

                // --- Insert data (Role)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (RoleMeisai)
                //TODO    
                //foreach (var detail in vCls.UserList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //   lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //   daRoleMeisai.Insert(con, ref roleMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Add(RoleInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RoleData da = new RoleData();
            //RoleMeisaiData daRoleMeisai = new RoleMeisaiData();
            //RoleMeisaiInfo RoleMeisaiInfo;
            UserData daUser = new UserData();
            UserEntity userEntity;

            RoleEntity cls = new RoleEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RoleConvertFunction.ConvertToRoleEntity(vCls);
                var lstParams = RoleConvertFunction.ConvertRoleEntityToParams(cls);

                // --- Insert data (Role)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (RoleMeisai)
                //TODO    
                //foreach (var detail in vCls.UserList)
                //{
                //   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //   detail.Id = ret.Code;
                //   userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //   lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //   daRoleMeisai.Insert(con, ref roleMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(RoleUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RoleData da = new RoleData();
            //RoleMeisaiData daRoleMeisai = new RoleMeisaiData();
            //RoleMeisaiInfo RoleMeisaiInfo;
            UserData daUser = new UserData();
            UserEntity userEntity;
            RoleEntity cls = new RoleEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RoleConvertFunction.ConvertToRoleEntity(vCls);
                var lstParams = RoleConvertFunction.ConvertRoleEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (UserMeisai)
                //   List<UserEntity> UserListDB = daUser.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.UserList)
                //   {
                //       // Update Meisai
                //       if (UserListDB.Exists(x => x.UserId == detail.UserId))
                //       {
                //           userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //           lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //           ret = daUser.Update(con, ref userEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //           lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //           ret = daUser.Insert(con, ref userEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in UserListDB)
                //   {
                //       if (cls.UserList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daUser.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(RoleUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            RoleData da = new RoleData();
            //RoleMeisaiData daRoleMeisai = new RoleMeisaiData();
            //RoleMeisaiInfo RoleMeisaiInfo;
            UserData daUser = new UserData();
            UserEntity userEntity;
            RoleEntity cls = new RoleEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = RoleConvertFunction.ConvertToRoleEntity(vCls);
                var lstParams = RoleConvertFunction.ConvertRoleEntityToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //TODO
                
                //if (ret.State == true)
                //{
                //   // --- Delete & Insert foreign List (UserMeisai)
                //   List<UserEntity> UserListDB = daUser.GetDataByForeignKey(vCls.Id, con);

                //   foreach (var detail in vCls.UserList)
                //   {
                //       // Update Meisai
                //       if (UserListDB.Exists(x => x.UserId == detail.UserId))
                //       {
                //           userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //           lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //           ret = daUser.Update(con, ref userEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //       else
                //       {
                //           detail.Id = cls.Id;
                //           userEntity = UserConvertFunction.ConvertToUserEntity(detail);
                //           lstParams = UserConvertFunction.ConvertUserEntityToParams(userEntity);
                //           ret = daUser.Insert(con, ref userEntity, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //       }
                //   }

                //   // DELETE Meisai
                //   foreach (var mesaiDB in UserListDB)
                //   {
                //       if (cls.UserList.Exists(x => x.Id == mesaiDB.Id))
                //           ret = daUser.Delete(con, mesaiDB.Id, vstrUpdateUser, vstrUpdateProgram);
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
            RoleData da = new RoleData();
            //RoleMeisaiData daRoleMeisai = new RoleMeisaiData();
            UserData daUser = new UserData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(Role)
                ret = da.Delete(con ,piId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (RoleMeisai)
                //daRoleMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);                
                //--- Delete & Insert List (User)
                // TODO
                //daUser.DeleteByForeignKey(con ,piId, vstrUpdateUser, vstrUpdateProgram);


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
