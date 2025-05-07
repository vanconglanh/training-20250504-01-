using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.DataAccess.Entity
{
    public class ScreenEntity : BaseEntity
    {
        //Id
        public int Id = 0;

        //Code
        public string? Code = "";

        //Name
        public string Name = "";

        //CreatedAt
        public DateTime? CreatedAt = null;

        //UpdatedAt
        public DateTime? UpdatedAt = null;

        //YukoFlag
        public string? YukoFlag = "";

        //CreatedUser
        public int? CreatedUser = 0;


        //Foreign Table
        public List<PermissionScreenEntity> PermissionScreenList = new List<PermissionScreenEntity>();

    }
}
