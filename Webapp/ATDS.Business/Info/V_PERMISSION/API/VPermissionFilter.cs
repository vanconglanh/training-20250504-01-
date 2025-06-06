﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Business.Info.Common;
using Microsoft.AspNetCore.Mvc;

namespace ATDS.Business.Info
{
    [BindProperties]
    public class VPermissionFilter : BaseFilterInfo
    {
        //RoleId
        public int? RoleId { get; set; } = null;

        //RoleCode
        public string? RoleCode { get; set; } = null;

        //RoleName
        public string? RoleName { get; set; } = null;

        //ScreenId
        public int? ScreenId { get; set; } = null;

        //ScreenCode
        public string? ScreenCode { get; set; } = null;

        //ScreenName
        public string? ScreenName { get; set; } = null;

        //PermissionId
        public int? PermissionId { get; set; } = null;

        //PermissionCode
        public string? PermissionCode { get; set; } = null;

        //PermissionName
        public string? PermissionName { get; set; } = null;


    }
}
