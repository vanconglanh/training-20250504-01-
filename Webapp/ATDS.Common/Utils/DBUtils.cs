using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Common.Utils
{
    public class DBUtils
    {
        public static IDbDataParameter CreateParam(string name, object value)
        {
            DbProviderFactory factory = null;
            switch ( GlobalParameter.MainDatabaseType)
            {
                case Constant.DatabaseType.MySQL:
                    factory = MySqlClientFactory.Instance;
                    break;
                case Constant.DatabaseType.SQLServer:
                    factory = SqlClientFactory.Instance;
                    break;
                //case Constant.DatabaseType.Oracle:
                //    factory = SqlClientFactory.Instance;
                //    break;
                default:
                    throw new NotSupportedException("Unsupported database type");
            }
            var param = factory.CreateParameter();
            param.ParameterName = name;
            param.Value = value ?? DBNull.Value;
            return param;
        }
    }
}
