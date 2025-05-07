using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Info
{
    [BindProperties]
    public class UserUpdateInfo : BaseInfo
    {
        //Id
        public int Id  { get; set; } = 0;

        //Code
        public string? Code  { get; set; } = "";

        //Name
        public string Name  { get; set; } = "";

        //Email
        public string Email  { get; set; } = "";

        //UserName
        public string UserName  { get; set; } = "";

        //Language
        public string? Language  { get; set; } = "";

        //Password
        public string Password  { get; set; } = "";

        //PasswordHash
        public string PasswordHash  { get; set; } = "";

        //RoleId
        public int? RoleId  { get; set; } = 0;

        //CreatedAt
        public DateTime? CreatedAt  { get; set; } = null;

        //UpdatedAt
        public DateTime? UpdatedAt  { get; set; } = null;

        //YukoFlag
        public string? YukoFlag  { get; set; } = "";

        //CreatedUser
        public int? CreatedUser  { get; set; } = 0;


        //Foreign Table
    }
}
