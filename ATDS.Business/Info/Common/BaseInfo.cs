using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class BaseInfo
    {
        // 有効フラグ
        // public int Status;

        // 最終更新者
        public int LastUpdateUser = -1;

        // 最終更新日
        public DateTime LastUpdate;

        // 最終プログラム
        public string LastUpdateProgram = string.Empty;

    }
}
