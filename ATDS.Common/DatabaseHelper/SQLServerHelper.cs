using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace ATDS.Common.DatabaseHelper
{
    public class SQLServerHelper : DatabaseHelper
    {
        //private SqlConnection con = new SqlConnection();
        //private SqlTransaction? trans;
        private SqlCommand SQLCmd = new SqlCommand();
        private SqlParameter param;


        public SQLServerHelper(string connectionString) : base(connectionString)
        {

        }



        public IDbConnection Connection
        {
            get
            {
                return con;
            }
        }


        public ConnectionState Status
        {
            get
            {
                return con.State;
            }
        }



        public override void Open()
        {
            try                                                                     // 処理開始宣言
            {
                if (con == null || con.State != ConnectionState.Open)
                {
                    con = new SqlConnection();                                         // 接続ｺﾈｸｼｮﾝ取得

                    // DB接続文字列指定
                    // Con.ConnectionString =
                    // "Data Source=    " & My.Settings.DBInstance & ";" &
                    // "User ID=        " & My.Settings.DBUser & ";" &
                    // "Password=       " & My.Settings.DBPassword & ";" &
                    // "DataBase=       " & My.Settings.DBName & ";" &
                    // "Integrated Security = false"
                    con.ConnectionString = @"Data Source=57.155.1.252;" + "User ID=training;" + "Password=123@56789;" + "DataBase=training;" + "Integrated Security = false";

                    con.Open();                                                      // DB接続（OPEN）
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public override void Open(string uid, string pwd, string instance, string dbn)
        {
            try                                                                     // 処理開始宣言
            {
                if (con == null || con.State != ConnectionState.Open)
                {
                    con = new SqlConnection();                                         // 接続ｺﾈｸｼｮﾝ取得

                    // DB接続文字列指定
                    con.ConnectionString = "Data Source=    " + instance + ";" + "User ID=        " + uid + ";" + "Password=       " + pwd + ";" + "DataBase=       " + dbn + ";" + "Integrated Security = false";


                    con.Open();                                                      // DB接続（OPEN）
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        //public void Close()
        //{
        //    try                                                                     // 処理開始宣言
        //    {
        //        if (con != null)
        //        {
        //            if (con.State != ConnectionState.Closed)
        //                con.Close();// DB切断（CLOSE）
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    finally
        //    {
        //    }// ｺﾈｸｼｮﾝ      削除
        //}



        //public void ExecuteSQL(string sqlquery)
        //{
        //    SqlCommand cmd = new SqlCommand(sqlquery);                        // SQLServerｺﾏﾝﾄﾞ 宣言

        //    cmd.Connection = con;                                                    // ｺﾈｸｼｮﾝ      取得
        //    cmd.CommandType = CommandType.Text;                                      // ｺﾏﾝﾄﾞTYPE   指定
        //    if (trans == null == false)
        //        cmd.Transaction = trans;

        //    try                                                                     // 処理開始宣言
        //    {
        //        cmd.ExecuteNonQuery();                                               // ｺﾏﾝﾄﾞ       発行
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }// ｺﾏﾝﾄﾞ       削除
        //}

        //public int ExecuteSQLWithParams(string sqlquery, List<SqlParameter> sqlParams)
        //{
        //    SqlCommand cmd = new SqlCommand(sqlquery);                        // SQLServerｺﾏﾝﾄﾞ 宣言

        //    cmd.Connection = con;                                                    // ｺﾈｸｼｮﾝ      取得
        //    cmd.CommandType = CommandType.Text;                                      // ｺﾏﾝﾄﾞTYPE   指定
        //    if (trans == null == false)
        //        cmd.Transaction = trans;

        //    try                                                                     // 処理開始宣言
        //    {
        //        //cmd.Parameters.AddRange(sqlParams.ToArray());
        //        cmd.Parameters.Clear();
        //        if (sqlParams != null && sqlParams.Count > 0)
        //        {
        //            foreach (SqlParameter spp in sqlParams)
        //            {
        //                object value = spp.SqlValue;

        //                // Kiểm tra và sửa giá trị nếu là DateTime nhỏ hơn SqlDateTime.MinValue
        //                if (value is DateTime dt)
        //                {
        //                    if (dt < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
        //                    {
        //                        value = DBNull.Value;
        //                    }
        //                }

        //                SqlParameter nameParam = new SqlParameter(spp.ParameterName, value ?? DBNull.Value);
        //                cmd.Parameters.Add(nameParam);
        //            }

        //        }
        //        return cmd.ExecuteNonQuery();                                               // ｺﾏﾝﾄﾞ       発行
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }// ｺﾏﾝﾄﾞ       削除
        //}

        public override SqlDataReader SelectSQL(string sqlquery)
        {
            // MySQLコマンドを生成
            var cmd = new SqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (SqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (SqlTransaction)trans;

            try
            {
                return cmd.ExecuteReader();                                          // ｺﾏﾝﾄﾞ       発行
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// ｺﾏﾝﾄﾞ       削除
        }

        public IDataReader SelectSQLWithParams(string sqlquery, List<SqlParameter> sqlParams)
        {
            // MySQLコマンドを生成
            var cmd = new SqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (SqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (SqlTransaction)trans;

            try
            {
                cmd.Parameters.Clear();
                //cmd.Parameters.AddRange(sqlParams.ToArray());
                if (sqlParams != null && sqlParams.Count > 0)
                {
                    foreach (SqlParameter spp in sqlParams)
                    {
                        SqlParameter nameParam = new SqlParameter(spp.ParameterName, spp.SqlValue);

                        cmd.Parameters.Add(nameParam);
                    }
                }
                return cmd.ExecuteReader();                                          // ｺﾏﾝﾄﾞ       発行
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// ｺﾏﾝﾄﾞ       削除
        }



        public SqlDataReader SelectSQL()
        {
            try
            {
                return SQLCmd.ExecuteReader();                                        // ｺﾏﾝﾄﾞ       発行
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理
        }



        public override DataSet SelectSqlDs(string sqlquery)
        {
            SqlDataAdapter adp = new SqlDataAdapter();                          // DataAdapter 宣言
            DataSet dst = new DataSet();                                        // DataSet     宣言

            // MySQLコマンドを生成
            var cmd = new SqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (SqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (SqlTransaction)trans;

            try                                                                     // 処理開始宣言
            {
                adp.Fill(dst);                                                       // ｺﾏﾝﾄﾞ       発行
                return dst;                                                          // 取得DataSet 返却
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adp.Dispose();                                                       // DataAdapterﾘｿｰｽ 削除 
                dst.Dispose();                                                       // DataSetﾘｿｰｽ     削除
            }// DataSet         削除
        }

        public override DataSet SelectSqlDsWithParams(string sqlquery, List<IDbDataParameter> sqlParams)
        {
            SqlDataAdapter adp = new SqlDataAdapter();                          // DataAdapter 宣言
            DataSet dst = new DataSet();                                        // DataSet     宣言

            // MySQLコマンドを生成
            var cmd = new SqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (SqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (SqlTransaction)trans;

            try                                                                     // 処理開始宣言
            {
                cmd.Parameters.Clear();
                //cmd.Parameters.AddRange(sqlParams.ToArray());
                if (sqlParams != null && sqlParams.Count > 0)
                {
                    foreach (SqlParameter spp in sqlParams)
                    {
                        SqlParameter nameParam = new SqlParameter(spp.ParameterName, spp.SqlValue);

                        cmd.Parameters.Add(nameParam);
                    }
                }
                adp.Fill(dst);                                                       // ｺﾏﾝﾄﾞ       発行
                return dst;                                                          // 取得DataSet 返却
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adp.Dispose();                                                       // DataAdapterﾘｿｰｽ 削除 
                dst.Dispose();                                                       // DataSetﾘｿｰｽ     削除
            }// DataSet         削除
        }



        public override DataSet SelectSqlDs()
        {
            SqlDataAdapter adp = new SqlDataAdapter();                          // DataAdapter 宣言
            DataSet dst = new DataSet();                                        // DataSet     宣言

            try                                                                     // 処理開始宣言
            {
                adp.SelectCommand = SQLCmd;                                           // ｺﾏﾝﾄﾞ       設定

                adp.Fill(dst);                                                       // ｺﾏﾝﾄﾞ       発行
                return dst;                                                          // 取得DataSet 返却
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adp.Dispose();                                                       // DataAdapterﾘｿｰｽ 削除 
                dst.Dispose();                                                       // DataSetﾘｿｰｽ     削除
            }// DataSet         削除
        }



        //public void BeginTrans()
        //{
        //    try                                                                     // 処理開始宣言
        //    {

        //        // Transaction宣言済みの場合は一旦RollBack
        //        if (trans != null)
        //            trans.Rollback();// RollBack    宣言

        //        trans = con.BeginTransaction();                                      // Transaction 宣言
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }// 処理終了処理                                                                 // 処理終了
        //}



        //public void Commit()
        //{
        //    try                                                                     // 処理開始宣言
        //    {

        //        // Transaction未宣言の場合はSessionCommit
        //        if (trans != null)
        //            trans.Commit();// Commit          宣言
        //        else
        //            con.BeginTransaction().Commit();                                   // SessionCommit   
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (trans != null)
        //        {
        //            trans.Dispose();                                              // ﾄﾗﾝｻﾞｸｼｮﾝﾘｿｰｽ   削除
        //            trans = null;                                                 // ﾄﾗﾝｻﾞｸｼｮﾝ       削除
        //        }
        //    }                                                                 // 処理終了
        //}



        //public void Rollback()
        //{
        //    try                                                                     // 処理開始宣言
        //    {

        //        // Transaction未宣言の場合はSessionRollBack
        //        if (trans == null)
        //            con.BeginTransaction().Rollback();                                 // SessionRollback 宣言
        //        else
        //            trans.Rollback();// RollBack        宣言
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (trans != null)
        //        {
        //            trans.Dispose();                                                 // ﾄﾗﾝｻﾞｸｼｮﾝﾘｿｰｽ   削除
        //            trans = null;                                                 // ﾄﾗﾝｻﾞｸｼｮﾝ       削除
        //        }
        //    }                                                                 // 処理終了
        //}



        public override void SettingSql(string sql)
        {
            try                                                                     // 処理開始宣言
            {
                SQLCmd = new SqlCommand();                                          // SQLServerｺﾏﾝﾄﾞ 取得

                SQLCmd.Connection = (SqlConnection)con;                             // ｺﾈｸｼｮﾝ      取得
                SQLCmd.Transaction = (SqlTransaction)trans;
                SQLCmd.CommandType = CommandType.StoredProcedure;                   // ｺﾏﾝﾄﾞType   指定
                SQLCmd.CommandTimeout = 0;
                SQLCmd.CommandText = sql;                                           // SQL         指定
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public override void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction, object value)
        {
            try                                                                     // 処理開始宣言
            {
                param = new SqlParameter();                                            // SQLServerﾊﾟﾗﾒｰﾀ取得
                param.ParameterName = pname;
                param.SqlDbType = (SqlDbType)dbtype;
                param.Direction = direction;

                if (param.SqlDbType == SqlDbType.NVarChar |
                    param.SqlDbType == SqlDbType.VarChar | 
                    param.SqlDbType == SqlDbType.NChar | 
                    param.SqlDbType == SqlDbType.NText | 
                    param.SqlDbType == SqlDbType.Char |
                    param.SqlDbType == SqlDbType.Text)
                    param.Size = Strings.Len(value) + 1;// ｶﾗﾑのｻｲｽﾞをｶﾗﾑｻｲｽﾞ+1を指定

                param.Value = value;                                                 // ﾊﾟﾗﾒｰﾀ値    設定

                SQLCmd.Parameters.Add(param);                                         // ﾊﾟﾗﾒｰﾀ      追加
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public override void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction)
        {
            try                                                                     // 処理開始宣言
            {
                param = new SqlParameter(pname, dbtype);                             // SQLServerﾊﾟﾗﾒｰﾀ取得
                param.Direction = direction;

                // 引渡しﾊﾟﾗﾒｰﾀ属性（Clob,Blob,Varchar2）より、返却ﾊﾟﾗﾒｰﾀ属性の指定を行う。
                if (param.SqlDbType == SqlDbType.NVarChar | 
                    param.SqlDbType == SqlDbType.VarChar |
                    param.SqlDbType == SqlDbType.NChar |
                    param.SqlDbType == SqlDbType.NText | 
                    param.SqlDbType == SqlDbType.Char | 
                    param.SqlDbType == SqlDbType.Text)
                {
                    param.DbType = DbType.String;                        // 返却ﾊﾟﾗﾒｰﾀ属性をString属性

                    param.Size = 4000;                                               // 固定でｻｲｽﾞにVarCharの最大を指定
                }

                SQLCmd.Parameters.Add(param);                                         // ﾊﾟﾗﾒｰﾀ      追加
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public int ExecuteTSql()
        {
            try                                                                     // 処理開始宣言
            {
                return SQLCmd.ExecuteNonQuery();                                      // SQL 発行
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public object PramaterGet(string name)
        {
            try                                                                     // 処理開始宣言
            {
                return SQLCmd.Parameters[name].Value;                            // 返却ﾊﾟﾗﾒｰﾀ返却
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                                                 // 処理終了
        }



        public void TSqlClear()
        {
            try                                                                     // 処理開始宣言
            {
                SqlParameterCollection opc;                                   // SQLServerﾊﾟﾗﾒｰﾀｺﾚｸｼｮﾝ宣言

                opc = SQLCmd.Parameters;                                              // SQLServerﾊﾟﾗﾒｰﾀｺﾚｸｼｮﾝ取得
                opc.Clear();                                                         // ﾊﾟﾗﾒｰﾀ開放
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// ｺﾏﾝﾄﾞ       削除                                                                 // 処理終了
        }

        ~SQLServerHelper()
        {
            try
            {
                Close();                     // データベースの切断

                if (trans != null)
                    trans.Dispose();// 開放

                if (con != null)
                    con.Dispose();// 開放
            }
            catch (Exception)
            {
            }

            finally
            {
                trans = null;
            }
        }
    }
}