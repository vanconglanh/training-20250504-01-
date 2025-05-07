using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class PermissionScreenItemInfo : BaseInfo
    {
        //Id
        public int Id = 0;

        //PermissionId
        public int PermissionId = 0;

        //ScreenId
        public int ScreenId = 0;

        //Code
        public string? Code = "";

        //CreatedAt
        public DateTime? CreatedAt = null;

        //UpdatedAt
        public DateTime? UpdatedAt = null;

        //YukoFlag
        public string? YukoFlag = "";

        //CreatedUser
        public int? CreatedUser = 0;


    }
}
