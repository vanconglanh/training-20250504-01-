using ATDS.API.Info;
using ATDS.API.Info.ResponseInfo.Common;
using ATDS.API.Info.ResponseInfo.Enum;
using ATDS.API.Info.ResponseInfo.Result;
using ATDS.API.Resources;
using ATDS.API.Utils;
using ATDS.Business;
using ATDS.Business.Info;
using ATDS.Common;
using ATDS.DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Nest;
using Optivem.Framework.Core.Domain;
using System.Security.Claims;
using System.Threading.Tasks;
using static ATDS.Common.Constant;
using static Azure.Core.HttpHeader;

namespace ATDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VPermissionController : ControllerBase
    {
        readonly VPermissionSearchBusiness _vPermissionSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public VPermissionController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _vPermissionSearchBusiness = new VPermissionSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<VPermissionController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            VPermissionFilter filter = new VPermissionFilter();
            List<VPermissionItemInfo> result = _vPermissionSearchBusiness.Search(filter);            
            return new PagingResult<VPermissionItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<VPermissionController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] VPermissionFilter filter)
        {
            PaginatedList<VPermissionItemInfo> result = _vPermissionSearchBusiness.SearchPage(filter);
            return new PagingResult<VPermissionItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }        

        #endregion
    }
}