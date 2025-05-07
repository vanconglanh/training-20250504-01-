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
    public class RolePermissionController : ControllerBase
    {
        readonly RolePermissionEntryBusiness _rolePermissionEntryBusiness;
        readonly RolePermissionSearchBusiness _rolePermissionSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RolePermissionController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _rolePermissionEntryBusiness = new RolePermissionEntryBusiness();
            _rolePermissionSearchBusiness = new RolePermissionSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<RolePermissionController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            RolePermissionFilter filter = new RolePermissionFilter();
            filter.YukoFlag = YUKO_FLAG.ENABLED.ToString();
            List<RolePermissionItemInfo> result = _rolePermissionSearchBusiness.Search(filter);            
            return new PagingResult<RolePermissionItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<RolePermissionController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] RolePermissionFilter filter)
        {
            PaginatedList<RolePermissionItemInfo> result = _rolePermissionSearchBusiness.SearchPage(filter);
            return new PagingResult<RolePermissionItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<RolePermissionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int piRoleId, int piPermissionScreenId)
        {
            RolePermissionFilter filter = new RolePermissionFilter();
            filter.RoleId = piRoleId;
            filter.PermissionScreenId = piPermissionScreenId;

            RolePermissionItemInfo rolePermissionItemInfo =  _rolePermissionSearchBusiness.SearchByKey(piRoleId,piPermissionScreenId);
            var result = await ValidateDetail(rolePermissionItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<RolePermissionItemInfo>(rolePermissionItemInfo);
        }

        // POST api/<RolePermissionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolePermissionInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _rolePermissionEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<RolePermissionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] RolePermissionUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _rolePermissionEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<RolePermissionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int piRoleId, int piPermissionScreenId)
        {
            var result = await ValidateDelete(piRoleId,piPermissionScreenId);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _rolePermissionEntryBusiness.Delete(piRoleId,piPermissionScreenId, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(RolePermissionItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "RolePermission"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(RolePermissionInsertInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}

            return null;
        }

        private async Task<ErrorResult> ValidateUpdate(RolePermissionUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _rolePermissionSearchBusiness.SearchByKey(input.RoleId,input.PermissionScreenId);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int piRoleId, int piPermissionScreenId)
        {
            var entity = _rolePermissionSearchBusiness.SearchByKey(piRoleId,piPermissionScreenId);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}