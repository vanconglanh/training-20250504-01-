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
    public static class VPermissionConvertFunction
    {
        #region Convert Object (Entry)
        public static VPermissionUIInfo ConvertToVPermissionUIInfo(VPermissionEntity vCls)
        {
            VPermissionUIInfo clsRet;

            try
            {
                clsRet = new VPermissionUIInfo();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.RoleCode = vCls.RoleCode; //RoleCode
                    withBlock.RoleName = vCls.RoleName; //RoleName
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
                    withBlock.ScreenCode = vCls.ScreenCode; //ScreenCode
                    withBlock.ScreenName = vCls.ScreenName; //ScreenName
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.PermissionCode = vCls.PermissionCode; //PermissionCode
                    withBlock.PermissionName = vCls.PermissionName; //PermissionName
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

        public static List<VPermissionUIInfo> ConvertToVPermissionUIInfoList(List<VPermissionEntity> source)
        {
            var result = new List<VPermissionUIInfo>();
            foreach (var item in source)
            {
                result.Add(ConvertToVPermissionUIInfo(item));
            }
            return result;
        }
        public static VPermissionEntity ConvertToVPermissionEntity(VPermissionUIInfo vCls)
        {
            VPermissionEntity clsRet;

            try
            {
                clsRet = new VPermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.RoleCode = vCls.RoleCode; //RoleCode
                    withBlock.RoleName = vCls.RoleName; //RoleName
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
                    withBlock.ScreenCode = vCls.ScreenCode; //ScreenCode
                    withBlock.ScreenName = vCls.ScreenName; //ScreenName
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.PermissionCode = vCls.PermissionCode; //PermissionCode
                    withBlock.PermissionName = vCls.PermissionName; //PermissionName
                }
            }
            catch (Exception)
            {
                throw;
            }

            return clsRet;
        }

        public static List<VPermissionEntity> ConvertToVPermissionEntityList(List<VPermissionUIInfo> source)
        {
            var result = new List<VPermissionEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToVPermissionEntity(item));
            }
            return result;
        }

        public static VPermissionEntity ConvertToVPermissionEntity(VPermissionItemInfo vCls)
        {
            VPermissionEntity clsRet;

            try
            {
                clsRet = new VPermissionEntity();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.RoleCode = vCls.RoleCode; //RoleCode
                    withBlock.RoleName = vCls.RoleName; //RoleName
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
                    withBlock.ScreenCode = vCls.ScreenCode; //ScreenCode
                    withBlock.ScreenName = vCls.ScreenName; //ScreenName
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.PermissionCode = vCls.PermissionCode; //PermissionCode
                    withBlock.PermissionName = vCls.PermissionName; //PermissionName
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<VPermissionEntity> ConvertItemInfoToEntityList(List<VPermissionItemInfo> source)
        {
            var result = new List<VPermissionEntity>();
            foreach (var item in source)
            {
                result.Add(ConvertToVPermissionEntity(item));
            }
            return result;
        }

        public static List<IDbDataParameter> ConvertVPermissionEntityToParams(VPermissionEntity vCls)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                    lstParameter.Add(DBUtils.CreateParam("@RoleId", vCls.RoleId));//RoleId
                    lstParameter.Add(DBUtils.CreateParam("@RoleCode", vCls.RoleCode));//RoleCode
                    lstParameter.Add(DBUtils.CreateParam("@RoleName", vCls.RoleName));//RoleName
                    lstParameter.Add(DBUtils.CreateParam("@ScreenId", vCls.ScreenId));//ScreenId
                    lstParameter.Add(DBUtils.CreateParam("@ScreenCode", vCls.ScreenCode));//ScreenCode
                    lstParameter.Add(DBUtils.CreateParam("@ScreenName", vCls.ScreenName));//ScreenName
                    lstParameter.Add(DBUtils.CreateParam("@PermissionId", vCls.PermissionId));//PermissionId
                    lstParameter.Add(DBUtils.CreateParam("@PermissionCode", vCls.PermissionCode));//PermissionCode
                    lstParameter.Add(DBUtils.CreateParam("@PermissionName", vCls.PermissionName));//PermissionName
                
            }
            catch (Exception)
            {
                throw;
            }

            return lstParameter;
         }
        #endregion


        #region 【メソッド】 Convert Object (Search)
        public static VPermissionItemInfo ConvertToVPermissionItemInfo(VPermissionEntity vCls)
        {
            VPermissionItemInfo clsRet;

            try
            {
                clsRet = new VPermissionItemInfo();
                {
                    var withBlock = clsRet;
                    withBlock.RoleId = vCls.RoleId; //RoleId
                    withBlock.RoleCode = vCls.RoleCode; //RoleCode
                    withBlock.RoleName = vCls.RoleName; //RoleName
                    withBlock.ScreenId = vCls.ScreenId; //ScreenId
                    withBlock.ScreenCode = vCls.ScreenCode; //ScreenCode
                    withBlock.ScreenName = vCls.ScreenName; //ScreenName
                    withBlock.PermissionId = vCls.PermissionId; //PermissionId
                    withBlock.PermissionCode = vCls.PermissionCode; //PermissionCode
                    withBlock.PermissionName = vCls.PermissionName; //PermissionName
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clsRet;
        }

        public static List<VPermissionItemInfo> ConvertToVPermissionItemInfoList(List<VPermissionEntity> source)
        {
            return source.Select(ConvertToVPermissionItemInfo).ToList();
        }

        public static  string ConvertFilterToWhereCondition(VPermissionFilter filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                if (filter.RoleId != null){
                        where += " AND ROLE_ID = @RoleId";
                }
                if (filter.RoleCode != null){
                        where += " AND ROLE_CODE = @RoleCode";
                }
                if (filter.RoleName != null){
                        where += " AND ROLE_NAME = @RoleName";
                }
                if (filter.ScreenId != null){
                        where += " AND SCREEN_ID = @ScreenId";
                }
                if (filter.ScreenCode != null){
                        where += " AND SCREEN_CODE = @ScreenCode";
                }
                if (filter.ScreenName != null){
                        where += " AND SCREEN_NAME = @ScreenName";
                }
                if (filter.PermissionId != null){
                        where += " AND PERMISSION_ID = @PermissionId";
                }
                if (filter.PermissionCode != null){
                        where += " AND PERMISSION_CODE = @PermissionCode";
                }
                if (filter.PermissionName != null){
                        where += " AND PERMISSION_NAME = @PermissionName";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  string ConvertFilterToWhereCondition(VPermissionUIFilterInfo filter)
        {
            string where = "";

            try
            {
                if (filter == null) return "";

                //--- 条件設定
                
                if (filter.RoleId != null){
                    where += " AND ROLE_ID = @RoleId";
                }
                if (filter.RoleCode != null){
                    where += " AND ROLE_CODE = @RoleCode";
                }
                if (filter.RoleName != null){
                    where += " AND ROLE_NAME = @RoleName";
                }
                if (filter.ScreenId != null){
                    where += " AND SCREEN_ID = @ScreenId";
                }
                if (filter.ScreenCode != null){
                    where += " AND SCREEN_CODE = @ScreenCode";
                }
                if (filter.ScreenName != null){
                    where += " AND SCREEN_NAME = @ScreenName";
                }
                if (filter.PermissionId != null){
                    where += " AND PERMISSION_ID = @PermissionId";
                }
                if (filter.PermissionCode != null){
                    where += " AND PERMISSION_CODE = @PermissionCode";
                }
                if (filter.PermissionName != null){
                    where += " AND PERMISSION_NAME = @PermissionName";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return where;
        }

        public static  List<IDbDataParameter> ConvertFilterToParamsCondition(VPermissionFilter filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
                
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.RoleCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleCode", filter.RoleCode));
            }
            if( filter.RoleName != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleName", filter.RoleName));
            }
            if( filter.ScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenId", filter.ScreenId));
            }
            if( filter.ScreenCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenCode", filter.ScreenCode));
            }
            if( filter.ScreenName != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenName", filter.ScreenName));
            }
            if( filter.PermissionId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionId", filter.PermissionId));
            }
            if( filter.PermissionCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionCode", filter.PermissionCode));
            }
            if( filter.PermissionName != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionName", filter.PermissionName));
            } 
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstParameter;
        }

        public static List<IDbDataParameter> ConvertFilterToParamsCondition(VPermissionUIFilterInfo filter)
        {
            List<IDbDataParameter> lstParameter = new List<IDbDataParameter>();

            try
            {
                if (filter == null) return lstParameter;

                //--- SQL Params
            if( filter.RoleId != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleId", filter.RoleId));
            }
            if( filter.RoleCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleCode", filter.RoleCode));
            }
            if( filter.RoleName != null ){
                lstParameter.Add(DBUtils.CreateParam("@RoleName", filter.RoleName));
            }
            if( filter.ScreenId != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenId", filter.ScreenId));
            }
            if( filter.ScreenCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenCode", filter.ScreenCode));
            }
            if( filter.ScreenName != null ){
                lstParameter.Add(DBUtils.CreateParam("@ScreenName", filter.ScreenName));
            }
            if( filter.PermissionId != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionId", filter.PermissionId));
            }
            if( filter.PermissionCode != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionCode", filter.PermissionCode));
            }
            if( filter.PermissionName != null ){
                lstParameter.Add(DBUtils.CreateParam("@PermissionName", filter.PermissionName));
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