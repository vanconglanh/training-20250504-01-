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
        public async Task<IActionResult> GetAll([FromQuery] RolePermissionFilter filter)
        {
            filter.Status = filter.Status ?? (int)STATUS.ENABLED;

            bool hasPaging = filter.Page > 0 && filter.Size > 0;

            if (hasPaging)
            {
                var pagedResult = _rolePermissionSearchBusiness.SearchPage(filter);
                return new PagingResult<RolePermissionItemInfo>(
                    pagedResult,
                    pagedResult.TotalRecord,
                    filter.Page,
                    filter.Size
                );
            }

            var fullList = _rolePermissionSearchBusiness.Search(filter);
            return new PagingResult<RolePermissionItemInfo>(
                fullList,
                fullList.Count,
                1,                
                fullList.Count  
            );
        }

        // GET: api/<RolePermissionController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] RolePermissionFilter filter)
        {
            PaginatedList<RolePermissionItemInfo> result = _rolePermissionSearchBusiness.SearchPage(filter);
            return new PagingResult<RolePermissionItemInfo>(result, result.TotalRecord, filter.Page, filter.Size);
        }

        // GET api/<RolePermissionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            RolePermissionFilter filter = new RolePermissionFilter();
            filter.Id = id;
            RolePermissionItemInfo rolePermissionItemInfo =  _rolePermissionSearchBusiness.SearchByKey(id);
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
            string username  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _rolePermissionEntryBusiness.Add(insertInfo, username, deviceID);

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
            string username = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _rolePermissionEntryBusiness.Update(updateInfo, username, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<RolePermissionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string username = string.Empty;
            string deviceID = string.Empty;
            _rolePermissionEntryBusiness.Delete(id, username, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(RolePermissionItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
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


            var entity = _rolePermissionSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _rolePermissionSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "RolePermission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}