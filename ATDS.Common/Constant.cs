namespace ATDS.Common
{
    public class Constant
    {

        // --- 有効フラグ
        public enum YUKO_FLAG
        {
            ENABLED = 1,
            DISABLED = 0
        }

        // --- 有効フラグデータベース種別列挙型
        public enum DatabaseType
        {
            MySQL,      // MySQLデータベース
            SQLServer,  // SQL Serverデータベース
            Oracle      // Oracleデータベース
        }


        public const string DATE_MIN = "1753-01-01";        

    }
}
