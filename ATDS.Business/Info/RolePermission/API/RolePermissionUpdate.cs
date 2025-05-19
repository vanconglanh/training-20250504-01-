using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Info
{
    [BindProperties]
    public class RolePermissionUpdateInfo : BaseInfo
    {
        //Id
        public int Id  { get; set; } = 0;

        //RoleId
        public int RoleId  { get; set; } = 0;

        //PermissionScreenId
        public int PermissionScreenId  { get; set; } = 0;

        //Code
        public string? Code  { get; set; } = "";

        //CreatedAt
        public DateTime? CreatedAt  { get; set; } = null;

        //UpdatedAt
        public DateTime? UpdatedAt  { get; set; } = null;

        //Status
        public int? Status  { get; set; } = 0;

        //CreatedUser
        public int? CreatedUser  { get; set; } = 0;

        //LastUpdateUser
        public int? LastUpdateUser  { get; set; } = 0;

        //LastUpdateProgram
        public string? LastUpdateProgram  { get; set; } = "";


        //Foreign Table
    }
}
