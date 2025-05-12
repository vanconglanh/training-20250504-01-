using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class PermissionScreenEntity : BaseEntity
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
        public int? YukoFlag = 0;

        //CreatedUser
        public int? CreatedUser = 0;

        //LastUpdateUser
        public int? LastUpdateUser = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram = "";


        //Foreign Table
        public List<RolePermissionEntity> RolePermissionList = new List<RolePermissionEntity>();

    }
}
