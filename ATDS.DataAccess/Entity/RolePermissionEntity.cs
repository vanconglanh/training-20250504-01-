using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class RolePermissionEntity : BaseEntity
    {
        //RoleId
        public int RoleId = 0;

        //PermissionScreenId
        public int PermissionScreenId = 0;

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


        //Foreign Table

    }
}
