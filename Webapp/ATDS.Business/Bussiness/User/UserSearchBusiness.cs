using ATDS.Common;
using ATDS.DataAccess;
using ATDS.Business.Info;
using ATDS.DataAccess.Entity;
using ATDS.Common.DatabaseHelper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace ATDS.Business
{
    public class UserSearchBusiness
    {

#region 【メソッド】 SearchByKey
        public UserItemInfo SearchByKey(int piId)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var lst = new List<UserEntity>();
            // var lstRet = new List<UserSearchListInfo>();
            var ret = new UserItemInfo();

            try
            {
                con.Open();

                // --- Search data
                lst = da.SearchByKey(con ,piId);

                // --- Convert data
                foreach (UserEntity row in lst){
                    // lstRet.Add(ConvertToUserItemInfo(row));
                    ret = UserConvertFunction.ConvertToUserItemInfo(row);
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

#region 【メソッド】 SearchDt(API)
        public System.Data.DataSet SearchDt(UserFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public System.Data.DataSet SearchDt(UserUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var ret = new System.Data.DataSet();

            try
            {
                // --- Convert filter to Condition
                var whereCondition  = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
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
        public List<UserItemInfo> Search(UserFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var lst = new List<UserEntity>();
            var lstRet = new List<UserItemInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (UserEntity row in lst)
                    // Convert data
                    lstRet.Add(UserConvertFunction.ConvertToUserItemInfo(row));

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
        public List<UserUIInfo> Search(UserUIFilterInfo filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var lst = new List<UserEntity>();
            var lstRet = new List<UserUIInfo>();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition  = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = "";

                // --- Search data
                lst = da.Search(con, whereCondition, lstParameter, order);

                // --- Convert data
                foreach (UserEntity row in lst)
                    // Convert data
                    lstRet.Add(UserConvertFunction.ConvertToUserUIInfo(row));

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
        public PaginatedList<UserItemInfo> SearchPage(UserFilter filter)
        {
            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var da = new UserData();
            var lstRet = new List<UserItemInfo>();
            PaginatedList<UserItemInfo> lstResult;
            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;
                var iCurrentPage = filter.Page;
                var iSize = filter.Size;

                // --- Search data
                var lst = da.SearchPage(con, whereCondition, lstParameter, order, iCurrentPage, iSize);

                // --- Convert data
                foreach (UserEntity row in lst)
                    // Convert data
                    lstRet.Add(UserConvertFunction.ConvertToUserItemInfo(row));

                lstResult = new PaginatedList<UserItemInfo>(lstRet, lst.TotalRecord, iCurrentPage, iSize);
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

#region 【メソッド】 GetLoginInfo(UserFilter filter)

        public UserLoginInfo GetLoginInfo(UserFilter filter)
        {
            UserLoginInfo userLoginInfo = null;

            MySQLServerHelper con = new MySQLServerHelper(GlobalParameter.ConnectionString);
            var userDA = new UserData();
            var vPermissionDA = new VPermissionData();

            try
            {
                con.Open();

                // --- Convert filter to Condition
                var whereCondition = UserConvertFunction.ConvertFilterToWhereCondition(filter);
                var lstParameter = UserConvertFunction.ConvertFilterToParamsCondition(filter);
                var order = filter.OrderBy;

                // --- Search data
                var userInfo = userDA.Search(con, whereCondition, lstParameter, order).FirstOrDefault();
                if (userInfo != null)
                {
                    userLoginInfo = new UserLoginInfo(UserConvertFunction.ConvertToUserItemInfo(userInfo));
                    // --- Get user permission
                    VPermissionFilter permissionFilter = new VPermissionFilter();
                    permissionFilter.RoleId = userLoginInfo.RoleId;
                    var whereConditionPermission = VPermissionConvertFunction.ConvertFilterToWhereCondition(permissionFilter);
                    var lstParameterPermission = VPermissionConvertFunction.ConvertFilterToParamsCondition(permissionFilter);
                    //Search data
                    var lstPermission = VPermissionConvertFunction.ConvertToVPermissionItemInfoList(vPermissionDA.Search(con, whereConditionPermission, lstParameterPermission, String.Empty));
                    userLoginInfo.Permissions = lstPermission.GroupBy(x => x.ScreenName)
                                                                        .Select(g => new UserPermissonAction
                                                                        {
                                                                            ScreenName = g.Key,
                                                                            ActionName = g.Select(x => x.PermissionName).Distinct().ToList()
                                                                        })
                                                                        .ToList();
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

            return userLoginInfo;
        }
        #endregion
    }
}