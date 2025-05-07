using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class ScreenUIInfo : BaseInfo
    {
        //Id
        public int Id { get; set; } = 0;

        //Code
        public string? Code { get; set; } = "";

        //Name
        public string Name { get; set; } = "";

        //CreatedAt
        public DateTime? CreatedAt { get; set; } = null;

        //UpdatedAt
        public DateTime? UpdatedAt { get; set; } = null;

        //YukoFlag
        public string? YukoFlag { get; set; } = "";

        //CreatedUser
        public int? CreatedUser { get; set; } = 0;


        //Foreign Table
        public List<PermissionScreenUIInfo> PermissionScreenList { get; set; } = new List<PermissionScreenUIInfo>();

    }
}
