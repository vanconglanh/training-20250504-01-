using ATDS.Business.Info.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class PermissionScreenUIFilterInfo : BaseFilterInfo
    {
        //Id
        public int? Id { get; set; } = null;

        //PermissionId
        public int? PermissionId { get; set; } = null;

        //ScreenId
        public int? ScreenId { get; set; } = null;

        //Code
        public string? Code { get; set; } = null;

        //CreatedAt
        public DateTime? CreatedAt { get; set; } = null;

        //UpdatedAt
        public DateTime? UpdatedAt { get; set; } = null;

        //YukoFlag
        public int? YukoFlag { get; set; } = null;

        //CreatedUser
        public int? CreatedUser { get; set; } = null;

        //LastUpdateUser
        public int? LastUpdateUser { get; set; } = null;

        //LastUpdateProgram
        public string? LastUpdateProgram { get; set; } = null;


    }
}
