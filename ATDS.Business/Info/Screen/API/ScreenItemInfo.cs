using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class ScreenItemInfo : BaseInfo
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
        public int? YukoFlag = 0;

        //CreatedUser
        public int? CreatedUser = 0;

        //LastUpdateUser
        public int? LastUpdateUser = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram = "";


    }
}
