using ATDS.Business.Info;
using ATDS.DataAccess.Entity;
using ATDS.Common.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business
{
    public static class UserConvertFunction
    {
        #region Convert Object (Entry)
        public static UserUIInfo ConvertToUserUIInfo(UserEntity vCls)
        {
            UserUIInfo clsRet;

            try
            {
                clsRet = new UserUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

        public static List<UserEntity> ConvertToUserEntityList(List<UserUIInfo> source)
        {
            var result = new List<UserEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToUserEntity(item));
            }
            return result;
        }

        public static UserEntity ConvertToUserEntity(UserUIInfo vCls)
        {
            UserEntity clsRet;

            try
            {
                clsRet = new UserEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

    
        public static List<UserUIInfo> ConvertToUserUIInfo(List<UserEntity> vlstUserEntity)
        {
            UserUIInfo clsRet;
            List<UserUIInfo> UserUIInfoList = new List<UserUIInfo>();

            try
            {
                foreach(UserEntity userEntity in vlstUserEntity)
                {
                    clsRet = new UserUIInfo();
                    {
                        var withBlock = clsRet;
                        withBlock.Id = userEntity.Id; //Id
                        withBlock.Code = userEntity.Code; //Code
                        withBlock.Name = userEntity.Name; //Name
                        withBlock.Email = userEntity.Email; //Email
                        withBlock.Username = userEntity.Username; //Username
                        withBlock.Language = userEntity.Language; //Language
                        withBlock.Password = userEntity.Password; //Password
                        withBlock.PasswordHash = userEntity.PasswordHash; //PasswordHash
                        withBlock.RoleId = userEntity.RoleId; //RoleId
                        withBlock.CreatedAt = userEntity.CreatedAt; //CreatedAt
                        withBlock.UpdatedAt = userEntity.UpdatedAt; //UpdatedAt
                        withBlock.YukoFlag = userEntity.YukoFlag; //YukoFlag
                        withBlock.CreatedUser = userEntity.CreatedUser; //CreatedUser
                        withBlock.LastUpdateUser = userEntity.LastUpdateUser; //LastUpdateUser
                        withBlock.LastUpdateProgram = userEntity.LastUpdateProgram; //LastUpdateProgram
                        UserUIInfoList.Add(withBlock);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return UserUIInfoList;
        }


        public static UserEntity ConvertToUserEntity(UserInsertInfo vCls)
        {
            UserEntity clsRet;

            try
            {
                clsRet = new UserEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static UserEntity ConvertToUserEntity(UserUpdateInfo vCls)
        {
            UserEntity clsRet;

            try
            {
                clsRet = new UserEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static UserEntity ConvertToUserEntity(UserItemInfo vCls)
        {
            UserEntity clsRet;

            try
            {
                clsRet = new UserEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<IDbDataParameter> ConvertUserEntityToParams(UserEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@Id", vCls.Id));//Id
                    lstParameter.Add(DBUtils.CreateParam("@Code", vCls.Code));//Code
                    lstParameter.Add(DBUtils.CreateParam("@Name", vCls.Name));//Name
                    lstParameter.Add(DBUtils.CreateParam("@Email", vCls.Email));//Email
                    lstParameter.Add(DBUtils.CreateParam("@Username", vCls.Username));//Username
                    lstParameter.Add(DBUtils.CreateParam("@Language", vCls.Language));//Language
                    lstParameter.Add(DBUtils.CreateParam("@Password", vCls.Password));//Password
                    lstParameter.Add(DBUtils.CreateParam("@PasswordHash", vCls.PasswordHash));//PasswordHash
                    lstParameter.Add(DBUtils.CreateParam("@RoleId", vCls.RoleId));//RoleId
                    lstParameter.Add(DBUtils.CreateParam("@CreatedAt", vCls.CreatedAt));//CreatedAt
                    lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", vCls.UpdatedAt));//UpdatedAt
                    lstParameter.Add(DBUtils.CreateParam("@YukoFlag", vCls.YukoFlag));//YukoFlag
                    lstParameter.Add(DBUtils.CreateParam("@CreatedUser", vCls.CreatedUser));//CreatedUser
                    lstParameter.Add(DBUtils.CreateParam("@LastUpdateUser", vCls.LastUpdateUser));//LastUpdateUser
                    lstParameter.Add(DBUtils.CreateParam("@LastUpdateProgram", vCls.LastUpdateProgram));//LastUpdateProgram
                
            }
            catch (Exception)
            {
                throw;
            }

            return lstParameter;
         }
        #endregion


        #region 【メソッド】 Convert Object (Search)
        public static UserItemInfo ConvertToUserItemInfo(UserEntity vCls)
        {
            UserItemInfo clsRet;

            try
            {
                clsRet = new UserItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.Email = vCls.Email; //Email
                    withBlock.Username = vCls.Username; //Username
                    withBlock.Language = vCls.Language; //Language
                    withBlock.Password = vCls.Password; //Password
                    withBlock.PasswordHash = vCls.PasswordHash; //PasswordHash
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                    withBlock.LastUpdateUser = vCls.LastUpdateUser; //LastUpdateUser
                    withBlock.LastUpdateProgram = vCls.LastUpdateProgram; //LastUpdateProgram
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<UserItemInfo> ConvertToUserItemInfoList(List<UserEntity> source)
        {
            return source.Select(ConvertToUserItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(UserFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.Id != null){
                        where += " AND ID = @Id";
                }
                if (filter.Code != null){
                        where += " AND CODE = @Code";
                }
                if (filter.Name != null){
                        where += " AND NAME = @Name";
                }
                if (filter.Email != null){
                        where += " AND EMAIL = @Email";
                }
                if (filter.Username != null){
                        where += " AND USERNAME = @Username";
                }
                if (filter.Language != null){
                        where += " AND LANGUAGE = @Language";
                }
                if (filter.Password != null){
                        where += " AND PASSWORD = @Password";
                }
                if (filter.PasswordHash != null){
                        where += " AND PASSWORD_HASH = @PasswordHash";
                }
                if (filter.RoleId != null){
                        where += " AND ROLE_ID = @RoleId";
                }
                if (filter.CreatedAt != null){
                        where += " AND CREATED_AT = @CreatedAt";
                }
                if (filter.UpdatedAt != null){
                        where += " AND UPDATED_AT = @UpdatedAt";
                }
                if (filter.YukoFlag != null){
                        where += " AND YUKO_FLAG = @YukoFlag";
                }
                if (filter.CreatedUser != null){
                        where += " AND CREATED_USER = @CreatedUser";
                }
                if (filter.LastUpdateUser != null){
                        where += " AND LAST_UPDATE_USER = @LastUpdateUser";
                }
                if (filter.LastUpdateProgram != null){
                        where += " AND LAST_UPDATE_PROGRAM = @LastUpdateProgram";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  string ConvertFilterToWhereCondition(UserUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.Id != null){
                    where += " AND ID = @Id";
                }
                if (filter.Code != null){
                    where += " AND CODE = @Code";
                }
                if (filter.Name != null){
                    where += " AND NAME = @Name";
                }
                if (filter.Email != null){
                    where += " AND EMAIL = @Email";
                }
                if (filter.Username != null){
                    where += " AND USERNAME = @Username";
                }
                if (filter.Language != null){
                    where += " AND LANGUAGE = @Language";
                }
                if (filter.Password != null){
                    where += " AND PASSWORD = @Password";
                }
                if (filter.PasswordHash != null){
                    where += " AND PASSWORD_HASH = @PasswordHash";
                }
                if (filter.RoleId != null){
                    where += " AND ROLE_ID = @RoleId";
                }
                if (filter.CreatedAt != null){
                    where += " AND CREATED_AT = @CreatedAt";
                }
                if (filter.UpdatedAt != null){
                    where += " AND UPDATED_AT = @UpdatedAt";
                }
                if (filter.YukoFlag != null){
                    where += " AND YUKO_FLAG = @YukoFlag";
                }
                if (filter.CreatedUser != null){
                    where += " AND CREATED_USER = @CreatedUser";
                }
                if (filter.LastUpdateUser != null){
                    where += " AND LAST_UPDATE_USER = @LastUpdateUser";
                }
                if (filter.LastUpdateProgram != null){
                    where += " AND LAST_UPDATE_PROGRAM = @LastUpdateProgram";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(UserFilter filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.Id != null ){
                lstParameter.Add(DBUtils.CreateParam("@Id", filter.Id));
            }
            if( filter.Code != null ){
                lstParameter.Add(DBUtils.CreateParam("@Code", filter.Code));
            }
            if( filter.Name != null ){
                lstParameter.Add(DBUtils.CreateParam("@Name", filter.Name));
            }
            if( filter.Email != null ){
                lstParameter.Add(DBUtils.CreateParam("@Email", filter.Email));
            }
            if( filter.Username != null ){
                lstParameter.Add(DBUtils.CreateParam("@Username", filter.Username));
            }
            if( filter.Language != null ){
                lstParameter.Add(DBUtils.CreateParam("@Language", filter.Language));
            }
            if( filter.Password != null ){
                lstParameter.Add(DBUtils.CreateParam("@Password", filter.Password));
            }
            if( filter.PasswordHash != null ){
                lstParameter.Add(DBUtils.CreateParam("@PasswordHash", filter.PasswordHash));
            }
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.CreatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedAt", filter.CreatedAt));
            }
            if( filter.UpdatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", filter.UpdatedAt));
            }
            if( filter.YukoFlag != null ){
                lstParameter.Add(DBUtils.CreateParam("@YukoFlag", filter.YukoFlag));
            }
            if( filter.CreatedUser != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedUser", filter.CreatedUser));
            }
            if( filter.LastUpdateUser != null ){
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateUser", filter.LastUpdateUser));
            }
            if( filter.LastUpdateProgram != null ){
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateProgram", filter.LastUpdateProgram));
            } 
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(UserUIFilterInfo filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.Id != null ){
                lstParameter.Add(DBUtils.CreateParam("@Id", filter.Id));
            }
            if( filter.Code != null ){
                lstParameter.Add(DBUtils.CreateParam("@Code", filter.Code));
            }
            if( filter.Name != null ){
                lstParameter.Add(DBUtils.CreateParam("@Name", filter.Name));
            }
            if( filter.Email != null ){
                lstParameter.Add(DBUtils.CreateParam("@Email", filter.Email));
            }
            if( filter.Username != null ){
                lstParameter.Add(DBUtils.CreateParam("@Username", filter.Username));
            }
            if( filter.Language != null ){
                lstParameter.Add(DBUtils.CreateParam("@Language", filter.Language));
            }
            if( filter.Password != null ){
                lstParameter.Add(DBUtils.CreateParam("@Password", filter.Password));
            }
            if( filter.PasswordHash != null ){
                lstParameter.Add(DBUtils.CreateParam("@PasswordHash", filter.PasswordHash));
            }
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.CreatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedAt", filter.CreatedAt));
            }
            if( filter.UpdatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", filter.UpdatedAt));
            }
            if( filter.YukoFlag != null ){
                lstParameter.Add(DBUtils.CreateParam("@YukoFlag", filter.YukoFlag));
            }
            if( filter.CreatedUser != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedUser", filter.CreatedUser));
            }
            if( filter.LastUpdateUser != null ){
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateUser", filter.LastUpdateUser));
            }
            if( filter.LastUpdateProgram != null ){
                lstParameter.Add(DBUtils.CreateParam("@LastUpdateProgram", filter.LastUpdateProgram));
            }    
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }


        #endregion
    }
}