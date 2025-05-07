using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATDS.Common.Constant;

namespace ATDS.Common.DatabaseHelper
{
    /// <summary>
    /// 汎用データベースヘルパークラス
    /// </summary>
    public abstract class DatabaseHelper : IDatabaseHelper
    {
        protected IDbConnection con;
        protected IDbTransaction trans;

        protected readonly string connectionString;

        protected DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// DB接続オープン（具象クラスで実装）
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 指定された接続情報を使用してデータベース接続を開く（ユーザーID、パスワード、インスタンス、DB名）
        /// </summary>
        public abstract void Open(string uid, string pwd, string instance, string dbn);

        /// <summary>
        /// DB接続クローズ
        /// </summary>
        public virtual void Close()
        {
            if (con != null && con.State != ConnectionState.Closed)
            {
                // DB切断（CLOSE）
                con.Close();
            }
        }

        /// <summary>
        /// パラメータなしでSQL文を実行する（非クエリ）
        /// </summary>
        /// <param name="sqlquery">実行するSQL文</param>
        public virtual void ExecuteSQL(string sqlquery)
        {
            try
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    // ｺﾈｸｼｮﾝ      取得
                    cmd.Connection = con;
                    // ｺﾏﾝﾄﾞTYPE   指定
                    cmd.CommandText = sqlquery;
                    cmd.CommandType = CommandType.Text;
                    if (trans == null == false)
                        cmd.Transaction = trans;

                    // 処理開始宣言- ｺﾏﾝﾄﾞ 発行
                    cmd.ExecuteNonQuery();
                }          

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// SQL実行（パラメータあり）
        /// </summary>
        public virtual int ExecuteSQLWithParams(string sqlquery, List<IDbDataParameter> sqlParams)
        {
            using (IDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = sqlquery;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = trans;

                if (sqlParams != null && sqlParams.Count > 0)
                {
                    foreach (IDbDataParameter param in sqlParams)
                    {
                        if (param.Value is DateTime dt && dt < (DateTime)SqlDateTime.MinValue)
                        {
                            param.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(param);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// SQL SELECT文を実行し、MySqlDataReaderで結果を取得する
        /// </summary>
        /// <param name="sqlquery">実行するSQL文</param>
        /// <returns>MySqlDataReader（読み取り専用結果セット）</returns>
        public abstract IDataReader SelectSQL(string sqlquery);

        /// <summary>
        /// SQL SELECT文を実行し、DataSetで結果を取得する
        /// </summary>
        /// <param name="sqlquery">実行するSQL文</param>
        /// <returns>DataSet（結果セット）</returns>
        public abstract DataSet SelectSqlDs(string sqlquery);

        /// <summary>
        /// SELECT実行（パラメータあり）
        /// </summary>
        public virtual IDataReader SelectSQLWithParams(string sqlquery, List<IDbDataParameter> sqlParams)
        {
            IDbCommand cmd = con.CreateCommand();
            cmd.CommandText = sqlquery;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = trans;

            if (sqlParams != null && sqlParams.Count > 0)
            {
                foreach (IDbDataParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }
            }

            return cmd.ExecuteReader();
        }

        /// <summary>
        /// SQL SELECT文を実行し、DataSetで結果を取得する
        /// </summary>
        /// <returns>DataSet（結果セット）</returns>
        public abstract DataSet SelectSqlDs();
        /// <summary>
        /// SELECT実行しDataSetで返す（パラメータあり）
        /// </summary>
        public abstract DataSet SelectSqlDsWithParams(string sqlquery, List<IDbDataParameter> sqlParams);

        /// <summary>
        /// トランザクション開始
        /// </summary>
        public virtual void BeginTrans()
        {
            if (trans != null) trans.Rollback();
            trans = con.BeginTransaction();
        }

        /// <summary>
        /// トランザクションコミット
        /// </summary>
        public virtual void Commit()
        {
            trans?.Commit();
            trans?.Dispose();
            trans = null;
        }

        /// <summary>
        /// トランザクションロールバック
        /// </summary>
        public virtual void Rollback()
        {
            trans?.Rollback();
            trans?.Dispose();
            trans = null;
        }

        /// <summary>
        /// ストアドプロシージャのSQL文を設定する
        /// </summary>
        /// <param name="sql">ストアドプロシージャ名</param>
        public abstract void SettingSql(string sql);

        /// <summary>
        /// パラメータを作成してSQLコマンドに追加（MySQL用、値あり）
        /// </summary>
        /// <param name="pname">パラメータ名</param>
        /// <param name="dbtype">MySQLのデータ型</param>
        /// <param name="direction">パラメータの入出力方向</param>
        /// <param name="value">パラメータの値</param>
        public abstract void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction, object value);

        /// <summary>
        /// パラメータを作成してSQLコマンドに追加（SQL Server用、値なし）
        /// </summary>
        /// <param name="pname">パラメータ名</param>
        /// <param name="dbtype">SQL Serverのデータ型</param>
        /// <param name="direction">パラメータの入出力方向</param>
        public abstract void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction);

        /// <summary>
        /// 設定されたSQLコマンドを実行する（非クエリ）
        /// </summary>
        /// <returns>影響を受けた行数</returns>

    }
}
