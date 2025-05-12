using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class UserItemInfo : BaseInfo
    {
        //Id
        public int Id = 0;

        //Code
        public string? Code = "";

        //Name
        public string Name = "";

        //Email
        public string Email = "";

        //Username
        public string Username = "";

        //Language
        public string? Language = "";

        //Password
        public string Password = "";

        //PasswordHash
        public string PasswordHash = "";

        //RoleId
        public int? RoleId = 0;

        //CreatedAt
        public DateTime? CreatedAt = null;

        //UpdatedAt
        public DateTime? UpdatedAt = null;

        //YukoFlag
        public int YukoFlag = 0;

        //CreatedUser
        public int? CreatedUser = 0;

        //LastUpdateUser
        public int? LastUpdateUser = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram = "";


    }
}
