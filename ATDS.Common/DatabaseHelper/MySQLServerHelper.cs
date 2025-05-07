using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
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
using static ATDS.Common.Constant;
using System.Data.SqlClient;
using Google.Protobuf.WellKnownTypes;

namespace ATDS.Common.DatabaseHelper
{
    /// <summary>
    /// MySQL専用ヘルパークラス（子クラス）
    /// </summary>
    public class MySQLServerHelper : DatabaseHelper
    {
        //private MySqlConnection con = new MySqlConnection();
        //private MySqlTransaction? trans;
        private MySqlCommand SQLCmd = new MySqlCommand();
        private MySqlParameter param;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="connectionString">接続文字列</param>
        public MySQLServerHelper(string connectionString)
            : base(connectionString)
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
            try
            {
                // 処理開始宣言
                if (con == null || con.State != ConnectionState.Open)
                {
                    // 接続ｺﾈｸｼｮﾝ取得
                    con = new MySqlConnection();
                    // DB接続文字列指定
                    // Con.ConnectionString =
                    // "Data Source=    " & My.Settings.DBInstance & ";" &
                    // "User ID=        " & My.Settings.DBUser & ";" &
                    // "Password=       " & My.Settings.DBPassword & ";" &
                    // "DataBase=       " & My.Settings.DBName & ";" &
                    // "Integrated Security = false"
                    con.ConnectionString = "Server=57.155.1.252;Database=training;Uid=training;Pwd=123@56789;port=4306;";
                    //con.ConnectionString = @"Data Source=57.155.1.252;" + "User ID=training;" + "Password=123@56789;" + "DataBase=training;" + "Integrated Security = false";
                    // DB接続（OPEN）
                    con.Open();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理
        }



        public override void Open(string uid, string pwd, string instance, string dbn)
        {
            try
            {// 処理開始宣言
                if (con == null || con.State != ConnectionState.Open)
                {
                    // 接続ｺﾈｸｼｮﾝ取得
                    con = new MySqlConnection();

                    // DB接続文字列指定
                    con.ConnectionString = "Data Source=    " + instance + ";" + "User ID=        " + uid + ";" + "Password=       " + pwd + ";" + "DataBase=       " + dbn + ";" + "Integrated Security = false";

                    // DB接続（OPEN）
                    con.Open();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理
        }



        //public override void Close()
        //{
        //    try
        //    {
        //        // 処理開始宣言
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


        //public override void ExecuteSQL(string sqlquery)
        //{
        //    // MySQLServerｺﾏﾝﾄﾞ 宣言
        //    MySqlCommand cmd = new MySqlCommand(sqlquery);

        //    // ｺﾈｸｼｮﾝ      取得
        //    cmd.Connection = con;
        //    // ｺﾏﾝﾄﾞTYPE   指定
        //    cmd.CommandType = CommandType.Text;
        //    if (trans == null == false)
        //        cmd.Transaction = trans;

        //    try
        //    {
        //        // 処理開始宣言- ｺﾏﾝﾄﾞ 発行
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }// ｺﾏﾝﾄﾞ 削除
        //}

        //public int ExecuteSQLWithParams(string sqlquery, List<MySqlParameter> sqlParams)
        //{
        //    // MySQLServerｺﾏﾝﾄﾞ 宣言
        //    MySqlCommand cmd = new MySqlCommand(sqlquery);

        //    // ｺﾈｸｼｮﾝ      取得
        //    cmd.Connection = con;
        //    // ｺﾏﾝﾄﾞTYPE   指定
        //    cmd.CommandType = CommandType.Text;
        //    if (trans == null == false)
        //        cmd.Transaction = trans;

        //    try
        //    {
        //        // 処理開始宣言
        //        //cmd.Parameters.AddRange(sqlParams.ToArray());
        //        cmd.Parameters.Clear();
        //        if (sqlParams != null && sqlParams.Count > 0)
        //        {
        //            foreach (MySqlParameter spp in sqlParams)
        //            {
        //                object value = spp.Value;

        //                // Kiểm tra và sửa giá trị nếu là DateTime nhỏ hơn SqlDateTime.MinValue
        //                if (value is DateTime dt)
        //                {
        //                    if (dt < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
        //                    {
        //                        value = DBNull.Value;
        //                    }
        //                }

        //                MySqlParameter nameParam = new MySqlParameter(spp.ParameterName, value ?? DBNull.Value);
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

        /// <summary>
        /// 指定されたSQL文を実行し、MySqlDataReaderで結果を取得する
        /// </summary>
        /// <param name="sqlquery">実行するSQL文</param>
        /// <returns>MySqlDataReader：読み取り専用の結果セット</returns>
        public override MySqlDataReader SelectSQL(string sqlquery)
        {
            // MySQLコマンドを生成
            var cmd = new MySqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (MySqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (MySqlTransaction)trans;

            try
            {
                // SQLコマンドを実行し、結果を返却
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                // 例外をそのままスロー
                throw;
            }
        }

        public IDataReader SelectSQLWithParams(string sqlquery, List<MySqlParameter> sqlParams)
        {
            // MySQLコマンドを生成
            var cmd = new MySqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (MySqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (MySqlTransaction)trans;

            try
            {
                cmd.Parameters.Clear();
                //cmd.Parameters.AddRange(sqlParams.ToArray());
                if (sqlParams != null && sqlParams.Count > 0)
                {
                    foreach (MySqlParameter spp in sqlParams)
                    {
                        MySqlParameter nameParam = new MySqlParameter(spp.ParameterName, spp.Value);

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



        public MySqlDataReader SelectSQL()
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
            MySqlDataAdapter adp = new MySqlDataAdapter();                      // DataAdapter 宣言
            DataSet dst = new DataSet();                                        // DataSet     宣言

            // MySQLコマンドを生成
            var cmd = new MySqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (MySqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (MySqlTransaction)trans;
            adp.SelectCommand = cmd;                                                 // ｺﾏﾝﾄﾞ       設定

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
            MySqlDataAdapter adp = new MySqlDataAdapter();                          // DataAdapter 宣言
            DataSet dst = new DataSet();                                        // DataSet     宣言

            // MySQLコマンドを生成
            var cmd = new MySqlCommand(sqlquery);
            // 接続オブジェクトを設定（親クラスのconをMySqlConnection型にキャスト）
            cmd.Connection = (MySqlConnection)con;
            // コマンドの種類をテキストとして指定
            cmd.CommandType = CommandType.Text;
            // タイムアウトを無制限に設定
            cmd.CommandTimeout = 0;
            // トランザクションが存在する場合は設定
            if (trans != null)
                cmd.Transaction = (MySqlTransaction)trans;

            try                                                                     // 処理開始宣言
            {
                cmd.Parameters.Clear();
                //cmd.Parameters.AddRange(sqlParams.ToArray());
                if (sqlParams != null && sqlParams.Count > 0)
                {
                    foreach (MySqlParameter spp in sqlParams)
                    {
                        MySqlParameter nameParam = new MySqlParameter(spp.ParameterName, spp.Value);

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
            MySqlDataAdapter adp = new MySqlDataAdapter();                          // DataAdapter 宣言
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



        //public override void BeginTrans()
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



        //public override void Commit()
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
                SQLCmd = new MySqlCommand();                                              // MySQLServerｺﾏﾝﾄﾞ 取得

                SQLCmd.Connection = (MySqlConnection)con;
                SQLCmd.Transaction = (MySqlTransaction)trans;
                SQLCmd.CommandType = CommandType.StoredProcedure;                                 // ｺﾏﾝﾄﾞType   指定
                SQLCmd.CommandTimeout = 0;
                SQLCmd.CommandText = sql;                                             // SQL         指定
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
                param = new MySqlParameter();                                            // MySQLServerﾊﾟﾗﾒｰﾀ取得
                param.ParameterName = pname;
                param.MySqlDbType = (MySqlDbType)dbtype;
                param.Direction = direction;

                if (param.MySqlDbType == MySqlDbType.VarChar |
                    param.MySqlDbType == MySqlDbType.TinyText |
                    param.MySqlDbType == MySqlDbType.VarString |
                    param.MySqlDbType == MySqlDbType.LongText |
                    param.MySqlDbType == MySqlDbType.MediumText |
                    param.MySqlDbType == MySqlDbType.String |
                    param.MySqlDbType == MySqlDbType.Text)

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
                param = new MySqlParameter(pname, dbtype);                             // SQLServerﾊﾟﾗﾒｰﾀ取得
                param.Direction = direction;

                // 引渡しﾊﾟﾗﾒｰﾀ属性（Clob,Blob,Varchar2）より、返却ﾊﾟﾗﾒｰﾀ属性の指定を行う。
                if(param.MySqlDbType == MySqlDbType.VarChar |
                    param.MySqlDbType == MySqlDbType.TinyText |
                    param.MySqlDbType == MySqlDbType.VarString |
                    param.MySqlDbType == MySqlDbType.LongText |
                    param.MySqlDbType == MySqlDbType.MediumText |
                    param.MySqlDbType == MySqlDbType.String |
                    param.MySqlDbType == MySqlDbType.Text) 
                {
                    param.DbType = DbType.String;                        // 返却ﾊﾟﾗﾒｰﾀ属性をString属性

                    param.Size = 4000;                                   // 固定でｻｲｽﾞにVarCharの最大を指定
                }

                SQLCmd.Parameters.Add(param);                            // ﾊﾟﾗﾒｰﾀ      追加
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }// 処理終了処理                                              // 処理終了
        }

        ~MySQLServerHelper()
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