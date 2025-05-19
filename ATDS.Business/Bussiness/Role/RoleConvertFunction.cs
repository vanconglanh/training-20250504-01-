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
    public static class RoleConvertFunction
    {
        #region Convert Object (Entry)
        public static RoleUIInfo ConvertToRoleUIInfo(RoleEntity vCls)
        {
            RoleUIInfo clsRet;

            try
            {
                clsRet = new RoleUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

        public static List<RoleEntity> ConvertToRoleEntityList(List<RoleUIInfo> source)
        {
            var result = new List<RoleEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToRoleEntity(item));
            }
            return result;
        }

        public static RoleEntity ConvertToRoleEntity(RoleUIInfo vCls)
        {
            RoleEntity clsRet;

            try
            {
                clsRet = new RoleEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

    

        public static RoleEntity ConvertToRoleEntity(RoleInsertInfo vCls)
        {
            RoleEntity clsRet;

            try
            {
                clsRet = new RoleEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

        public static RoleEntity ConvertToRoleEntity(RoleUpdateInfo vCls)
        {
            RoleEntity clsRet;

            try
            {
                clsRet = new RoleEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

        public static RoleEntity ConvertToRoleEntity(RoleItemInfo vCls)
        {
            RoleEntity clsRet;

            try
            {
                clsRet = new RoleEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

        public static List<IDbDataParameter> ConvertRoleEntityToParams(RoleEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@Id", vCls.Id));//Id
                    lstParameter.Add(DBUtils.CreateParam("@Code", vCls.Code));//Code
                    lstParameter.Add(DBUtils.CreateParam("@Name", vCls.Name));//Name
                    lstParameter.Add(DBUtils.CreateParam("@IsSystem", vCls.IsSystem));//IsSystem
                    lstParameter.Add(DBUtils.CreateParam("@CreatedAt", vCls.CreatedAt));//CreatedAt
                    lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", vCls.UpdatedAt));//UpdatedAt
                    lstParameter.Add(DBUtils.CreateParam("@Status", vCls.Status));//Status
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
        public static RoleItemInfo ConvertToRoleItemInfo(RoleEntity vCls)
        {
            RoleItemInfo clsRet;

            try
            {
                clsRet = new RoleItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
                    withBlock.IsSystem = vCls.IsSystem; //IsSystem
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.Status = vCls.Status; //Status
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

        public static List<RoleItemInfo> ConvertToRoleItemInfoList(List<RoleEntity> source)
        {
            return source.Select(ConvertToRoleItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(RoleFilter filter)
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
                if (filter.IsSystem != null){
                        where += " AND IS_SYSTEM = @IsSystem";
                }
                if (filter.CreatedAt != null){
                        where += " AND CREATED_AT = @CreatedAt";
                }
                if (filter.UpdatedAt != null){
                        where += " AND UPDATED_AT = @UpdatedAt";
                }
                if (filter.Status != null){
                        where += " AND STATUS = @Status";
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

        public static  string ConvertFilterToWhereCondition(RoleUIFilterInfo filter)
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
                if (filter.IsSystem != null){
                    where += " AND IS_SYSTEM = @IsSystem";
                }
                if (filter.CreatedAt != null){
                    where += " AND CREATED_AT = @CreatedAt";
                }
                if (filter.UpdatedAt != null){
                    where += " AND UPDATED_AT = @UpdatedAt";
                }
                if (filter.Status != null){
                    where += " AND STATUS = @Status";
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

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(RoleFilter filter)
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
            if( filter.IsSystem != null ){
                lstParameter.Add(DBUtils.CreateParam("@IsSystem", filter.IsSystem));
            }
            if( filter.CreatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedAt", filter.CreatedAt));
            }
            if( filter.UpdatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", filter.UpdatedAt));
            }
            if( filter.Status != null ){
                lstParameter.Add(DBUtils.CreateParam("@Status", filter.Status));
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

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(RoleUIFilterInfo filter)
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
            if( filter.IsSystem != null ){
                lstParameter.Add(DBUtils.CreateParam("@IsSystem", filter.IsSystem));
            }
            if( filter.CreatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@CreatedAt", filter.CreatedAt));
            }
            if( filter.UpdatedAt != null ){
                lstParameter.Add(DBUtils.CreateParam("@UpdatedAt", filter.UpdatedAt));
            }
            if( filter.Status != null ){
                lstParameter.Add(DBUtils.CreateParam("@Status", filter.Status));
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