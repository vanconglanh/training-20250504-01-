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
    public class UserEntryBusiness
    {
        public UserUIInfo GetData(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            // TODO
            UserEntity cls;
            UserUIInfo clsRet = new UserUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piId);

                // --- Get foreign key table
                // TODO  

                // Convert data
                if (cls != null)
                {
                    // TODO
                    //clsRet = UserConvertFunction.ConvertToUserUIInfo(cls);
                    //clsRet.UserMeisaiList = UserMeisaiEntryBusiness.ConvertToUserMeisaiEntryInfo(cls.UserMeisaiList);  
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
        public ReturnInfo Add(UserUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            //UserMeisaiData daUserMeisai = new UserMeisaiData();
            //UserMeisaiInfo UserMeisaiInfo;

            UserEntity cls = new UserEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = UserConvertFunction.ConvertToUserEntity(vCls);
                var lstParams = UserConvertFunction.ConvertUserEntityToParams(cls);

                // --- Insert data (User)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (UserMeisai)
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
        public ReturnInfo Add(UserInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            //UserMeisaiData daUserMeisai = new UserMeisaiData();
            //UserMeisaiInfo UserMeisaiInfo;

            UserEntity cls = new UserEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = UserConvertFunction.ConvertToUserEntity(vCls);
                var lstParams = UserConvertFunction.ConvertUserEntityToParams(cls);

                // --- Insert data (User)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (UserMeisai)
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
        public ReturnInfo Update(UserUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            //UserMeisaiData daUserMeisai = new UserMeisaiData();
            //UserMeisaiInfo UserMeisaiInfo;
            UserEntity cls = new UserEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = UserConvertFunction.ConvertToUserEntity(vCls);
                var lstParams = UserConvertFunction.ConvertUserEntityToParams(cls);

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
        public ReturnInfo Update(UserUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            //UserMeisaiData daUserMeisai = new UserMeisaiData();
            //UserMeisaiInfo UserMeisaiInfo;
            UserEntity cls = new UserEntity();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = UserConvertFunction.ConvertToUserEntity(vCls);
                var lstParams = UserConvertFunction.ConvertUserEntityToParams(cls);

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

        public ReturnInfo Delete(int piId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            UserData da = new UserData();
            //UserMeisaiData daUserMeisai = new UserMeisaiData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(User)
                ret = da.Delete(con ,piId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (UserMeisai)
                //daUserMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);

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
