using ATDS.Business.Entity;
using ATDS.Common;
using ATDS.DataAccess;
using ATDS.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business
{
    public class ChumonMeisaiEntryBusiness
    {
        public ChumonMeisaiUIInfo GetData(int piChumonMeisaiId)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            ChumonMeisaiInfo cls;
            ChumonMeisaiUIInfo clsRet = new ChumonMeisaiUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piChumonMeisaiId);

                // --- Get foreign key table  

                // Convert data
                if (cls != null)
                {
                    clsRet = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiUIInfo(cls);
                    //clsRet.ChumonMeisaiMeisaiList = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiEntryInfo(cls.ChumonMeisaiMeisaiList);  
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
        public ReturnInfo Add(ChumonMeisaiUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            //ChumonMeisaiMeisaiData daChumonMeisaiMeisai = new ChumonMeisaiMeisaiData();
            //ChumonMeisaiMeisaiInfo ChumonMeisaiMeisaiInfo;

            ChumonMeisaiInfo cls = new ChumonMeisaiInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(vCls);
                var lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(cls);

                // --- Insert data (ChumonMeisai)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ChumonMeisaiMeisai)
                //foreach (var detail in vCls.ChumonMeisaiMeisaiList)
                //{
                //    // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //    detail.ChumonId = ret.Code;
                //    ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //    daChumonMeisaiMeisai.Insert(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Add(ChumonMeisaiInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            //ChumonMeisaiMeisaiData daChumonMeisaiMeisai = new ChumonMeisaiMeisaiData();
            //ChumonMeisaiMeisaiInfo ChumonMeisaiMeisaiInfo;

            ChumonMeisaiInfo cls = new ChumonMeisaiInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(vCls);
                var lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(cls);

                // --- Insert data (ChumonMeisai)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ChumonMeisaiMeisai)
                //foreach (var detail in vCls.ChumonMeisaiMeisaiList)
                //{
                //    // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //    detail.ChumonId = ret.Code;
                //    ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //    daChumonMeisaiMeisai.Insert(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
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
        public ReturnInfo Update(ChumonMeisaiUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            //ChumonMeisaiMeisaiData daChumonMeisaiMeisai = new ChumonMeisaiMeisaiData();
            //ChumonMeisaiMeisaiInfo ChumonMeisaiMeisaiInfo;
            ChumonMeisaiInfo cls = new ChumonMeisaiInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(vCls);
                var lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //if (ret.State == true)
                //{
                //    // --- Delete & Insert foreign List (ChumonMeisaiMeisai)
                //    List<ChumonMeisaiMeisaiInfo> ChumonMeisaiMeisaiListDB = daChumonMeisaiMeisai.GetDataByForeignKey(vCls.ChumonId, Con);

                //    foreach (var detail in vCls.ChumonMeisaiMeisaiList)
                //    {
                //        // Update Meisai
                //        if (ChumonMeisaiMeisaiListDB.Exists(x => x.ChumonMeisaiMeisaiId == detail.ChumonMeisaiMeisaiId))
                //        {
                //            ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //            ret = daChumonMeisaiMeisai.Update(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //        else
                //        {
                //            detail.ChumonId = cls.ChumonId;
                //            ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //            ret = daChumonMeisaiMeisai.Insert(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //    }

                //    // DELETE Meisai
                //    foreach (var mesaiDB in ChumonMeisaiMeisaiListDB)
                //    {
                //        if (cls.ChumonMeisaiMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                //            ret = daChumonMeisaiMeisai.Delete(Con, mesaiDB.ChumonMeisaiMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                //    }
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
        public ReturnInfo Update(ChumonMeisaiUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            //ChumonMeisaiMeisaiData daChumonMeisaiMeisai = new ChumonMeisaiMeisaiData();
            //ChumonMeisaiMeisaiInfo ChumonMeisaiMeisaiInfo;
            ChumonMeisaiInfo cls = new ChumonMeisaiInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(vCls);
                var lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //if (ret.State == true)
                //{
                //    // --- Delete & Insert foreign List (ChumonMeisaiMeisai)
                //    List<ChumonMeisaiMeisaiInfo> ChumonMeisaiMeisaiListDB = daChumonMeisaiMeisai.GetDataByForeignKey(vCls.ChumonId, Con);

                //    foreach (var detail in vCls.ChumonMeisaiMeisaiList)
                //    {
                //        // Update Meisai
                //        if (ChumonMeisaiMeisaiListDB.Exists(x => x.ChumonMeisaiMeisaiId == detail.ChumonMeisaiMeisaiId))
                //        {
                //            ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //            ret = daChumonMeisaiMeisai.Update(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //        else
                //        {
                //            detail.ChumonId = cls.ChumonId;
                //            ChumonMeisaiMeisaiInfo = ChumonMeisaiMeisaiEntryBusiness.ConvertToChumonMeisaiMeisaiInfo(detail);
                //            ret = daChumonMeisaiMeisai.Insert(Con, ChumonMeisaiMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //    }

                //    // DELETE Meisai
                //    foreach (var mesaiDB in ChumonMeisaiMeisaiListDB)
                //    {
                //        if (cls.ChumonMeisaiMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                //            ret = daChumonMeisaiMeisai.Delete(Con, mesaiDB.ChumonMeisaiMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                //    }
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

        public ReturnInfo Delete(int piChumonMeisaiId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonMeisaiData da = new ChumonMeisaiData();
            //ChumonMeisaiMeisaiData daChumonMeisaiMeisai = new ChumonMeisaiMeisaiData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(ChumonMeisai)
                ret = da.Delete(con ,piChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (ChumonMeisaiMeisai)
                //daChumonMeisaiMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);

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
