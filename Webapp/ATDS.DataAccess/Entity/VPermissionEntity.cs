using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class VPermissionEntity : BaseEntity
    {
        //RoleId
        public int RoleId;

        //RoleCode
        public string RoleCode;

        //RoleName
        public string RoleName;

        //ScreenId
        public int ScreenId;

        //ScreenCode
        public string? ScreenCode;

        //ScreenName
        public string ScreenName;

        //PermissionId
        public int PermissionId;

        //PermissionCode
        public string? PermissionCode;

        //PermissionName
        public string PermissionName;

    }
}
