using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class RoleUIInfo : BaseInfo
    {
        //Id
        public int Id { get; set; } = 0;

        //Code
        public string Code { get; set; } = "";

        //Name
        public string Name { get; set; } = "";

        //IsSystem
        public int? IsSystem { get; set; } = 0;

        //CreatedAt
        public DateTime? CreatedAt { get; set; } = null;

        //UpdatedAt
        public DateTime? UpdatedAt { get; set; } = null;

        //YukoFlag
        public int YukoFlag { get; set; } = 0;

        //CreatedUser
        public int? CreatedUser { get; set; } = 0;

        //LastUpdateUser
        public int? LastUpdateUser { get; set; } = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram { get; set; } = "";


        //Foreign Table
        public List<UserUIInfo> UserList { get; set; } = new List<UserUIInfo>();

    }
}
