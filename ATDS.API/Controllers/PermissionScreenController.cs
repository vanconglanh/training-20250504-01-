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
    public class PermissionScreenController : ControllerBase
    {
        readonly PermissionScreenEntryBusiness _permissionScreenEntryBusiness;
        readonly PermissionScreenSearchBusiness _permissionScreenSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public PermissionScreenController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _permissionScreenEntryBusiness = new PermissionScreenEntryBusiness();
            _permissionScreenSearchBusiness = new PermissionScreenSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<PermissionScreenController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] PermissionScreenFilter filter)
        {
            filter.Status = filter.Status ?? (int)STATUS.ENABLED;

            bool hasPaging = filter.Page > 0 && filter.Size > 0;

            if (hasPaging)
            {
                var pagedResult = _permissionScreenSearchBusiness.SearchPage(filter);
                return new PagingResult<PermissionScreenItemInfo>(
                    pagedResult,
                    pagedResult.TotalRecord,
                    filter.Page,
                    filter.Size
                );
            }

            var fullList = _permissionScreenSearchBusiness.Search(filter);
            return new PagingResult<PermissionScreenItemInfo>(
                fullList,
                fullList.Count,
                1,                
                fullList.Count  
            );
        }

        // GET: api/<PermissionScreenController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] PermissionScreenFilter filter)
        {
            PaginatedList<PermissionScreenItemInfo> result = _permissionScreenSearchBusiness.SearchPage(filter);
            return new PagingResult<PermissionScreenItemInfo>(result, result.TotalRecord, filter.Page, filter.Size);
        }

        // GET api/<PermissionScreenController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PermissionScreenFilter filter = new PermissionScreenFilter();
            filter.Id = id;
            PermissionScreenItemInfo permissionScreenItemInfo =  _permissionScreenSearchBusiness.SearchByKey(id);
            var result = await ValidateDetail(permissionScreenItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<PermissionScreenItemInfo>(permissionScreenItemInfo);
        }

        // POST api/<PermissionScreenController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionScreenInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string username  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _permissionScreenEntryBusiness.Add(insertInfo, username, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<PermissionScreenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PermissionScreenUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string username = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _permissionScreenEntryBusiness.Update(updateInfo, username, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<PermissionScreenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string username = string.Empty;
            string deviceID = string.Empty;
            _permissionScreenEntryBusiness.Delete(id, username, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(PermissionScreenItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "PermissionScreen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "PermissionScreen"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(PermissionScreenInsertInfo input)
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

        private async Task<ErrorResult> ValidateUpdate(PermissionScreenUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _permissionScreenSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "PermissionScreen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "PermissionScreen"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _permissionScreenSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "PermissionScreen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.Status == (int)STATUS.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "PermissionScreen"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}