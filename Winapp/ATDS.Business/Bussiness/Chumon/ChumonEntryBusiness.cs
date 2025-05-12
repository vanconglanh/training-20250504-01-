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
    public class ChumonEntryBusiness
    {
        public ChumonUIInfo GetData(int piChumonId)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            // Dim daChumonMeisai As New ChumonMeisaiData
            ChumonInfo cls;
            ChumonUIInfo clsRet = new ChumonUIInfo();

            try
            {
                con.Open();

                // --- Get data
                cls = da.GetData(con ,piChumonId);

                // --- Get foreign key table
                cls.ChumonMeisaiList = daChumonMeisai.GetDataByForeignKey(piChumonId, con);  

                // Convert data
                if (cls != null)
                {
                    clsRet = ChumonConvertFunction.ConvertToChumonUIInfo(cls);
                    //clsRet.ChumonMeisaiList = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiEntryInfo(cls.ChumonMeisaiList);
                    clsRet.ChumonMeisaiList = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiUIInfo(cls.ChumonMeisaiList);  
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
        public ReturnInfo Add(ChumonUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            //ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            //ChumonMeisaiInfo ChumonMeisaiInfo;
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            ChumonMeisaiInfo chumonMeisaiInfo;

            ChumonInfo cls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonConvertFunction.ConvertToChumonInfo(vCls);
                var lstParams = ChumonConvertFunction.ConvertChumonInfoToParams(cls);

                // --- Insert data (Chumon)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ChumonMeisai)
                //foreach (var detail in vCls.ChumonMeisaiList)
                //{
                //    // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //    detail.ChumonId = ret.Code;
                //    ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //    daChumonMeisai.Insert(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //}    
                foreach (var detail in vCls.ChumonMeisaiList)
                {
                   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                   detail.ChumonId = ret.Code;
                   chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                   lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                   daChumonMeisai.Insert(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                }                


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
        public ReturnInfo Add(ChumonInsertInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            //ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            //ChumonMeisaiInfo ChumonMeisaiInfo;
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            ChumonMeisaiInfo chumonMeisaiInfo;

            ChumonInfo cls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonConvertFunction.ConvertToChumonInfo(vCls);
                var lstParams = ChumonConvertFunction.ConvertChumonInfoToParams(cls);

                // --- Insert data (Chumon)
                ret = da.Insert(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);

                // --- Insert Foreign List (ChumonMeisai)
                //foreach (var detail in vCls.ChumonMeisaiList)
                //{
                //    // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                //    detail.ChumonId = ret.Code;
                //    ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //    daChumonMeisai.Insert(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //}    
                foreach (var detail in vCls.ChumonMeisaiList)
                {
                   // 1-1: OK, 1-n: OK, n-n(NG) Need to check
                   detail.ChumonId = ret.Code;
                   chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                   lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                   daChumonMeisai.Insert(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                }                


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
        public ReturnInfo Update(ChumonUIInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            //ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            //ChumonMeisaiInfo ChumonMeisaiInfo;
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            ChumonMeisaiInfo chumonMeisaiInfo;
            ChumonInfo cls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonConvertFunction.ConvertToChumonInfo(vCls);
                var lstParams = ChumonConvertFunction.ConvertChumonInfoToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //if (ret.State == true)
                //{
                //    // --- Delete & Insert foreign List (ChumonMeisai)
                //    List<ChumonMeisaiInfo> ChumonMeisaiListDB = daChumonMeisai.GetDataByForeignKey(vCls.ChumonId, Con);

                //    foreach (var detail in vCls.ChumonMeisaiList)
                //    {
                //        // Update Meisai
                //        if (ChumonMeisaiListDB.Exists(x => x.ChumonMeisaiId == detail.ChumonMeisaiId))
                //        {
                //            ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //            ret = daChumonMeisai.Update(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //        else
                //        {
                //            detail.ChumonId = cls.ChumonId;
                //            ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //            ret = daChumonMeisai.Insert(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //    }

                //    // DELETE Meisai
                //    foreach (var mesaiDB in ChumonMeisaiListDB)
                //    {
                //        if (cls.ChumonMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                //            ret = daChumonMeisai.Delete(Con, mesaiDB.ChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                //    }
                //}
                if (ret.State == true)
                {
                   // --- Delete & Insert foreign List (ChumonMeisaiMeisai)
                   List<ChumonMeisaiInfo> ChumonMeisaiListDB = daChumonMeisai.GetDataByForeignKey(vCls.ChumonId, con);

                   foreach (var detail in vCls.ChumonMeisaiList)
                   {
                       // Update Meisai
                       if (ChumonMeisaiListDB.Exists(x => x.ChumonMeisaiId == detail.ChumonMeisaiId))
                       {
                           chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                           lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                           ret = daChumonMeisai.Update(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                       }
                       else
                       {
                           detail.ChumonId = cls.ChumonId;
                           chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                           lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                           ret = daChumonMeisai.Insert(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                       }
                   }

                   // DELETE Meisai
                   foreach (var mesaiDB in ChumonMeisaiListDB)
                   {
                       if (cls.ChumonMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                           ret = daChumonMeisai.Delete(con, mesaiDB.ChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                   }
                }                

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
        public ReturnInfo Update(ChumonUpdateInfo vCls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            //ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            //ChumonMeisaiInfo ChumonMeisaiInfo;
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            ChumonMeisaiInfo chumonMeisaiInfo;
            ChumonInfo cls = new ChumonInfo();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Convert data
                cls = ChumonConvertFunction.ConvertToChumonInfo(vCls);
                var lstParams = ChumonConvertFunction.ConvertChumonInfoToParams(cls);

                // --- Update DB
                ret = da.Update(con, ref cls, lstParams, vstrUpdateUser, vstrUpdateProgram);
                //if (ret.State == true)
                //{
                //    // --- Delete & Insert foreign List (ChumonMeisai)
                //    List<ChumonMeisaiInfo> ChumonMeisaiListDB = daChumonMeisai.GetDataByForeignKey(vCls.ChumonId, Con);

                //    foreach (var detail in vCls.ChumonMeisaiList)
                //    {
                //        // Update Meisai
                //        if (ChumonMeisaiListDB.Exists(x => x.ChumonMeisaiId == detail.ChumonMeisaiId))
                //        {
                //            ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //            ret = daChumonMeisai.Update(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //        else
                //        {
                //            detail.ChumonId = cls.ChumonId;
                //            ChumonMeisaiInfo = ChumonMeisaiEntryBusiness.ConvertToChumonMeisaiInfo(detail);
                //            ret = daChumonMeisai.Insert(Con, ChumonMeisaiInfo, vstrUpdateUser, vstrUpdateProgram);
                //        }
                //    }

                //    // DELETE Meisai
                //    foreach (var mesaiDB in ChumonMeisaiListDB)
                //    {
                //        if (cls.ChumonMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                //            ret = daChumonMeisai.Delete(Con, mesaiDB.ChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                //    }
                //}
                if (ret.State == true)
                {
                   // --- Delete & Insert foreign List (ChumonMeisaiMeisai)
                   List<ChumonMeisaiInfo> ChumonMeisaiListDB = daChumonMeisai.GetDataByForeignKey(vCls.ChumonId, con);

                   foreach (var detail in vCls.ChumonMeisaiList)
                   {
                       // Update Meisai
                       if (ChumonMeisaiListDB.Exists(x => x.ChumonMeisaiId == detail.ChumonMeisaiId))
                       {
                           chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                           lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                           ret = daChumonMeisai.Update(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                       }
                       else
                       {
                           detail.ChumonId = cls.ChumonId;
                           chumonMeisaiInfo = ChumonMeisaiConvertFunction.ConvertToChumonMeisaiInfo(detail);
                           lstParams = ChumonMeisaiConvertFunction.ConvertChumonMeisaiInfoToParams(chumonMeisaiInfo);
                           ret = daChumonMeisai.Insert(con, ref chumonMeisaiInfo, lstParams, vstrUpdateUser, vstrUpdateProgram);
                       }
                   }

                   // DELETE Meisai
                   foreach (var mesaiDB in ChumonMeisaiListDB)
                   {
                       if (cls.ChumonMeisaiList.Exists(x => x.ChumonMeisaiId == mesaiDB.ChumonMeisaiId))
                           ret = daChumonMeisai.Delete(con, mesaiDB.ChumonMeisaiId, vstrUpdateUser, vstrUpdateProgram);
                   }
                }                

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

        public ReturnInfo Delete(int piChumonId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            SQLServerHelper con = new SQLServerHelper();
            ChumonData da = new ChumonData();
            //ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();
            ChumonMeisaiData daChumonMeisai = new ChumonMeisaiData();            

            ReturnInfo ret = new ReturnInfo();

            try
            {
                con.Open();

                // --- Start Transation
                con.BeginTrans();

                // --- Delete data(Chumon)
                ret = da.Delete(con ,piChumonId, vstrUpdateUser, vstrUpdateProgram);

                // --- Delete & Insert List (ChumonMeisai)
                //daChumonMeisai.DeleteByForeignKey(Con, pstrChumonId, vstrUpdateUser, vstrUpdateProgram);                
                //--- Delete & Insert List (ChumonMeisai)
                daChumonMeisai.DeleteByForeignKey(con ,piChumonId, vstrUpdateUser, vstrUpdateProgram);


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
