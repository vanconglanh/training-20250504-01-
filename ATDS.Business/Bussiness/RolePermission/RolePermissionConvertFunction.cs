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
    public static class RolePermissionConvertFunction
    {
        #region Convert Object (Entry)
        public static RolePermissionUIInfo ConvertToRolePermissionUIInfo(RolePermissionEntity vCls)
        {
            RolePermissionUIInfo clsRet;

            try
            {
                clsRet = new RolePermissionUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
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

        public static List<RolePermissionEntity> ConvertToRolePermissionEntityList(List<RolePermissionUIInfo> source)
        {
            var result = new List<RolePermissionEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToRolePermissionEntity(item));
            }
            return result;
        }

        public static RolePermissionEntity ConvertToRolePermissionEntity(RolePermissionUIInfo vCls)
        {
            RolePermissionEntity clsRet;

            try
            {
                clsRet = new RolePermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
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

    
        public static List<RolePermissionUIInfo> ConvertToRolePermissionUIInfo(List<RolePermissionEntity> vlstRolePermissionEntity)
        {
            RolePermissionUIInfo clsRet;
            List<RolePermissionUIInfo> RolePermissionUIInfoList = new List<RolePermissionUIInfo>();

            try
            {
                foreach(RolePermissionEntity rolePermissionEntity in vlstRolePermissionEntity)
                {
                    clsRet = new RolePermissionUIInfo();
                    {
                        var withBlock = clsRet;
                        withBlock.RoleId = rolePermissionEntity.RoleId; //RoleId
                        withBlock.PermissionScreenId = rolePermissionEntity.PermissionScreenId; //PermissionScreenId
                        withBlock.Code = rolePermissionEntity.Code; //Code
                        withBlock.CreatedAt = rolePermissionEntity.CreatedAt; //CreatedAt
                        withBlock.UpdatedAt = rolePermissionEntity.UpdatedAt; //UpdatedAt
                        withBlock.YukoFlag = rolePermissionEntity.YukoFlag; //YukoFlag
                        withBlock.CreatedUser = rolePermissionEntity.CreatedUser; //CreatedUser
                        withBlock.LastUpdateUser = rolePermissionEntity.LastUpdateUser; //LastUpdateUser
                        withBlock.LastUpdateProgram = rolePermissionEntity.LastUpdateProgram; //LastUpdateProgram
                        RolePermissionUIInfoList.Add(withBlock);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RolePermissionUIInfoList;
        }


        public static RolePermissionEntity ConvertToRolePermissionEntity(RolePermissionInsertInfo vCls)
        {
            RolePermissionEntity clsRet;

            try
            {
                clsRet = new RolePermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
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

        public static RolePermissionEntity ConvertToRolePermissionEntity(RolePermissionUpdateInfo vCls)
        {
            RolePermissionEntity clsRet;

            try
            {
                clsRet = new RolePermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
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

        public static RolePermissionEntity ConvertToRolePermissionEntity(RolePermissionItemInfo vCls)
        {
            RolePermissionEntity clsRet;

            try
            {
                clsRet = new RolePermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
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

        public static List<IDbDataParameter> ConvertRolePermissionEntityToParams(RolePermissionEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@RoleId", vCls.RoleId));//RoleId
                    lstParameter.Add(DBUtils.CreateParam("@PermissionScreenId", vCls.PermissionScreenId));//PermissionScreenId
                    lstParameter.Add(DBUtils.CreateParam("@Code", vCls.Code));//Code
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
        public static RolePermissionItemInfo ConvertToRolePermissionItemInfo(RolePermissionEntity vCls)
        {
            RolePermissionItemInfo clsRet;

            try
            {
                clsRet = new RolePermissionItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.PermissionScreenId = vCls.PermissionScreenId; //PermissionScreenId
                    withBlock.Code = vCls.Code; //Code
                    withBlock.CreatedAt = vCls.CreatedAt; //CreatedAt
                    withBlock.UpdatedAt = vCls.UpdatedAt; //UpdatedAt
                    withBlock.YukoFlag = vCls.YukoFlag; //YukoFlag
                    withBlock.CreatedUser = vCls.CreatedUser; //CreatedUser
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<RolePermissionItemInfo> ConvertToRolePermissionItemInfoList(List<RolePermissionEntity> source)
        {
            return source.Select(ConvertToRolePermissionItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(RolePermissionFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.RoleId != null){
                        where += " AND ROLE_ID = @RoleId";
                }
                if (filter.PermissionScreenId != null){
                        where += " AND PERMISSION_SCREEN_ID = @PermissionScreenId";
                }
                if (filter.Code != null){
                        where += " AND CODE = @Code";
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

        public static  string ConvertFilterToWhereCondition(RolePermissionUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.RoleId != null){
                    where += " AND ROLE_ID = @RoleId";
                }
                if (filter.PermissionScreenId != null){
                    where += " AND PERMISSION_SCREEN_ID = @PermissionScreenId";
                }
                if (filter.Code != null){
                    where += " AND CODE = @Code";
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

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(RolePermissionFilter filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.PermissionScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionScreenId", filter.PermissionScreenId));
            }
            if( filter.Code != null ){
                lstParameter.Add(DBUtils.CreateParam("@Code", filter.Code));
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

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(RolePermissionUIFilterInfo filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.PermissionScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionScreenId", filter.PermissionScreenId));
            }
            if( filter.Code != null ){
                lstParameter.Add(DBUtils.CreateParam("@Code", filter.Code));
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