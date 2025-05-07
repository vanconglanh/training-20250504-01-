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
    public static class PermissionScreenConvertFunction
    {
        #region Convert Object (Entry)
        public static PermissionScreenUIInfo ConvertToPermissionScreenUIInfo(PermissionScreenEntity vCls)
        {
            PermissionScreenUIInfo clsRet;

            try
            {
                clsRet = new PermissionScreenUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

        public static List<PermissionScreenEntity> ConvertToPermissionScreenEntityList(List<PermissionScreenUIInfo> source)
        {
            var result = new List<PermissionScreenEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToPermissionScreenEntity(item));
            }
            return result;
        }

        public static PermissionScreenEntity ConvertToPermissionScreenEntity(PermissionScreenUIInfo vCls)
        {
            PermissionScreenEntity clsRet;

            try
            {
                clsRet = new PermissionScreenEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

    
        public static List<PermissionScreenUIInfo> ConvertToPermissionScreenUIInfo(List<PermissionScreenEntity> vlstPermissionScreenEntity)
        {
            PermissionScreenUIInfo clsRet;
            List<PermissionScreenUIInfo> PermissionScreenUIInfoList = new List<PermissionScreenUIInfo>();

            try
            {
                foreach(PermissionScreenEntity permissionScreenEntity in vlstPermissionScreenEntity)
                {
                    clsRet = new PermissionScreenUIInfo();
                    {
                        var withBlock = clsRet;
                        withBlock.Id = permissionScreenEntity.Id; //Id
                        withBlock.PermissionId = permissionScreenEntity.PermissionId; //PermissionId
                        withBlock.ScreenId = permissionScreenEntity.ScreenId; //ScreenId
                        withBlock.Code = permissionScreenEntity.Code; //Code
                        withBlock.CreatedAt = permissionScreenEntity.CreatedAt; //CreatedAt
                        withBlock.UpdatedAt = permissionScreenEntity.UpdatedAt; //UpdatedAt
                        withBlock.YukoFlag = permissionScreenEntity.YukoFlag; //YukoFlag
                        withBlock.CreatedUser = permissionScreenEntity.CreatedUser; //CreatedUser
                        withBlock.LastUpdateUser = permissionScreenEntity.LastUpdateUser; //LastUpdateUser
                        withBlock.LastUpdateProgram = permissionScreenEntity.LastUpdateProgram; //LastUpdateProgram
                        PermissionScreenUIInfoList.Add(withBlock);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return PermissionScreenUIInfoList;
        }


        public static PermissionScreenEntity ConvertToPermissionScreenEntity(PermissionScreenInsertInfo vCls)
        {
            PermissionScreenEntity clsRet;

            try
            {
                clsRet = new PermissionScreenEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

        public static PermissionScreenEntity ConvertToPermissionScreenEntity(PermissionScreenUpdateInfo vCls)
        {
            PermissionScreenEntity clsRet;

            try
            {
                clsRet = new PermissionScreenEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

        public static PermissionScreenEntity ConvertToPermissionScreenEntity(PermissionScreenItemInfo vCls)
        {
            PermissionScreenEntity clsRet;

            try
            {
                clsRet = new PermissionScreenEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

        public static List<IDbDataParameter> ConvertPermissionScreenEntityToParams(PermissionScreenEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@Id", vCls.Id));//Id
                    lstParameter.Add(DBUtils.CreateParam("@PermissionId", vCls.PermissionId));//PermissionId
                    lstParameter.Add(DBUtils.CreateParam("@ScreenId", vCls.ScreenId));//ScreenId
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
        public static PermissionScreenItemInfo ConvertToPermissionScreenItemInfo(PermissionScreenEntity vCls)
        {
            PermissionScreenItemInfo clsRet;

            try
            {
                clsRet = new PermissionScreenItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
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

        public static List<PermissionScreenItemInfo> ConvertToPermissionScreenItemInfoList(List<PermissionScreenEntity> source)
        {
            return source.Select(ConvertToPermissionScreenItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(PermissionScreenFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.Id != null){
                        where += " AND ID = @Id";
                }
                if (filter.PermissionId != null){
                        where += " AND PERMISSION_ID = @PermissionId";
                }
                if (filter.ScreenId != null){
                        where += " AND SCREEN_ID = @ScreenId";
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

        public static  string ConvertFilterToWhereCondition(PermissionScreenUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.Id != null){
                    where += " AND ID = @Id";
                }
                if (filter.PermissionId != null){
                    where += " AND PERMISSION_ID = @PermissionId";
                }
                if (filter.ScreenId != null){
                    where += " AND SCREEN_ID = @ScreenId";
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

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(PermissionScreenFilter filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.Id != null ){
                lstParameter.Add(DBUtils.CreateParam("@Id", filter.Id));
            }
            if( filter.PermissionId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionId", filter.PermissionId));
            }
            if( filter.ScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenId", filter.ScreenId));
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

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(PermissionScreenUIFilterInfo filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.Id != null ){
                lstParameter.Add(DBUtils.CreateParam("@Id", filter.Id));
            }
            if( filter.PermissionId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionId", filter.PermissionId));
            }
            if( filter.ScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenId", filter.ScreenId));
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