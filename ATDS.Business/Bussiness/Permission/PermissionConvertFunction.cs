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
    public static class PermissionConvertFunction
    {
        #region Convert Object (Entry)
        public static PermissionUIInfo ConvertToPermissionUIInfo(PermissionEntity vCls)
        {
            PermissionUIInfo clsRet;

            try
            {
                clsRet = new PermissionUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

        public static List<PermissionEntity> ConvertToPermissionEntityList(List<PermissionUIInfo> source)
        {
            var result = new List<PermissionEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToPermissionEntity(item));
            }
            return result;
        }

        public static PermissionEntity ConvertToPermissionEntity(PermissionUIInfo vCls)
        {
            PermissionEntity clsRet;

            try
            {
                clsRet = new PermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

    

        public static PermissionEntity ConvertToPermissionEntity(PermissionInsertInfo vCls)
        {
            PermissionEntity clsRet;

            try
            {
                clsRet = new PermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

        public static PermissionEntity ConvertToPermissionEntity(PermissionUpdateInfo vCls)
        {
            PermissionEntity clsRet;

            try
            {
                clsRet = new PermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

        public static PermissionEntity ConvertToPermissionEntity(PermissionItemInfo vCls)
        {
            PermissionEntity clsRet;

            try
            {
                clsRet = new PermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

        public static List<IDbDataParameter> ConvertPermissionEntityToParams(PermissionEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@Id", vCls.Id));//Id
                    lstParameter.Add(DBUtils.CreateParam("@Code", vCls.Code));//Code
                    lstParameter.Add(DBUtils.CreateParam("@Name", vCls.Name));//Name
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
        public static PermissionItemInfo ConvertToPermissionItemInfo(PermissionEntity vCls)
        {
            PermissionItemInfo clsRet;

            try
            {
                clsRet = new PermissionItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.Id = vCls.Id; //Id
                    withBlock.Code = vCls.Code; //Code
                    withBlock.Name = vCls.Name; //Name
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

        public static List<PermissionItemInfo> ConvertToPermissionItemInfoList(List<PermissionEntity> source)
        {
            return source.Select(ConvertToPermissionItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(PermissionFilter filter)
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

        public static  string ConvertFilterToWhereCondition(PermissionUIFilterInfo filter)
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

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(PermissionFilter filter)
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

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(PermissionUIFilterInfo filter)
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