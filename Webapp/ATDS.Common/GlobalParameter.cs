using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATDS.Common.Constant;

namespace ATDS.Common
{
    public static class GlobalParameter
    {
        public static string ConnectionString = "Server=57.155.1.252;Database=training;Uid=training;Pwd=123@56789;port=4306;";
        public static DatabaseType MainDatabaseType = DatabaseType.MySQL;
    }
}
