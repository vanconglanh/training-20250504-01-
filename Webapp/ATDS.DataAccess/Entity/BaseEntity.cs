﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class BaseEntity
    {
        // 有効フラグ
        // public int YukoFlag;

        // 最終更新者
        public int LastUpdateUser = -1;

        // 最終更新日
        public DateTime LastUpdate;

        // 最終プログラム
        public string LastUpdateProgram = string.Empty;

    }
}
