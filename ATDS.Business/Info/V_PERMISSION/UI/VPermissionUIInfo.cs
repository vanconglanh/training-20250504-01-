using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class VPermissionUIInfo : BaseInfo
    {
        //RoleId
        public int RoleId { get; set; }

        //RoleCode
        public string RoleCode { get; set; }

        //RoleName
        public string RoleName { get; set; }

        //ScreenId
        public int ScreenId { get; set; }

        //ScreenCode
        public string? ScreenCode { get; set; }

        //ScreenName
        public string ScreenName { get; set; }

        //PermissionId
        public int PermissionId { get; set; }

        //PermissionCode
        public string? PermissionCode { get; set; }

        //PermissionName
        public string PermissionName { get; set; }


        //Foreign Table

    }
}
