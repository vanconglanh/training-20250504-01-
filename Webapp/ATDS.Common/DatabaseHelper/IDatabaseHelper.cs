using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Common.DatabaseHelper
{
    /// <summary>
    /// データベース操作用インターフェース
    /// </summary>
    public interface IDatabaseHelper

    {
        /// <summary>
        /// データベース接続を開く
        /// </summary>
        void Open();

        /// <summary>
        /// 接続を開く（指定情報から）
        /// </summary>
        /// <param name="uid">ユーザーID</param>
        /// <param name="pwd">パスワード</param>
        /// <param name="instance">DBインスタンス</param>
        /// <param name="dbn">データベース名</param>
        void Open(string uid, string pwd, string instance, string dbn);

        /// <summary>
        /// 接続を閉じる
        /// </summary>
        void Close();


        /// <summary>
        /// トランザクション開始
        /// </summary>
        void BeginTrans();

        /// <summary>
        /// トランザクションコミット
        /// </summary>
        void Commit();

        /// <summary>
        /// トランザクションロールバック
        /// </summary>
        void Rollback();

        /// <summary>
        /// ストアドプロシージャSQL設定
        /// </summary>
        /// <param name="sql">SQL文</param>
        void SettingSql(string sql);

        /// <summary>
        /// SQL文を実行する（パラメータなし）
        /// </summary>
        /// <param name="sqlquery">SQL文</param>
        void ExecuteSQL(string sqlquery);

        /// <summary>
        /// SQL文を実行する（パラメータあり）
        /// </summary>
        /// <param name="sqlquery">SQL文</param>
        /// <param name="sqlParams">パラメータ</param>
        int ExecuteSQLWithParams(string sqlquery, List<IDbDataParameter> sqlParams);

        /// <summary>
        /// SELECT文を実行する（パラメータなし）
        /// </summary>
        /// <param name="sqlquery">SQL文</param>
        IDataReader SelectSQL(string sqlquery);

        /// <summary>
        /// SELECT文を実行する（パラメータあり）
        /// </summary>
        /// <param name="sqlquery">SQL文</param>
        /// <param name="sqlParams">パラメータ</param>
        IDataReader SelectSQLWithParams(string sqlquery, List<IDbDataParameter> sqlParams);

        /// <summary>
        /// DataSetで結果を取得する
        /// </summary>
        /// <param name="sqlquery">SQL文</param>
        DataSet SelectSqlDs(string sqlquery);

        DataSet SelectSqlDsWithParams(string sqlquery, List<IDbDataParameter> sqlParams);

        /// <summary>
        /// パラメータ作成（値あり）
        /// </summary>
        /// <param name="pname">パラメータ名</param>
        /// <param name="dbtype">型</param>
        /// <param name="direction">入出力方向</param>
        /// <param name="value">値</param>
        void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction, object value);

        /// <summary>
        /// パラメータ作成（値なし）
        /// </summary>
        /// <param name="pname">パラメータ名</param>
        /// <param name="dbtype">型</param>
        /// <param name="direction">入出力方向</param>
        void PramaterCreate(string pname, DbType dbtype, ParameterDirection direction);

    }
}
