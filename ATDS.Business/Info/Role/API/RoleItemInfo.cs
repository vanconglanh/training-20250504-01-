using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class RoleItemInfo : BaseInfo
    {
        //Id
        public int Id = 0;

        //Code
        public string Code = "";

        //Name
        public string Name = "";

        //IsSystem
        public int? IsSystem = 0;

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
