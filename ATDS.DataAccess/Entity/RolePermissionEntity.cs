using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class RolePermissionEntity : BaseEntity
    {
        //Id
        public int Id = 0;

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

        //Status
        public int? Status = 0;

        //CreatedUser
        public int? CreatedUser = 0;

        //LastUpdateUser
        public int? LastUpdateUser = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram = "";


        //Foreign Table

    }
}
