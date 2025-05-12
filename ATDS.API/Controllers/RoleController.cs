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
    public class RoleController : ControllerBase
    {
        readonly RoleEntryBusiness _roleEntryBusiness;
        readonly RoleSearchBusiness _roleSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RoleController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _roleEntryBusiness = new RoleEntryBusiness();
            _roleSearchBusiness = new RoleSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<RoleController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] RoleFilter filter)
        {
            filter.YukoFlag = filter.YukoFlag ?? (int)YUKO_FLAG.ENABLED;

            bool hasPaging = filter.Page > 0 && filter.Size > 0;

            if (hasPaging)
            {
                var pagedResult = _roleSearchBusiness.SearchPage(filter);
                return new PagingResult<RoleItemInfo>(
                    pagedResult,
                    pagedResult.TotalRecord,
                    filter.Page,
                    filter.Size
                );
            }

            var fullList = _roleSearchBusiness.Search(filter);
            return new PagingResult<RoleItemInfo>(
                fullList,
                fullList.Count,
                1,                
                fullList.Count  
            );
        }

        // GET: api/<RoleController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] RoleFilter filter)
        {
            PaginatedList<RoleItemInfo> result = _roleSearchBusiness.SearchPage(filter);
            return new PagingResult<RoleItemInfo>(result, result.TotalRecord, filter.Page, filter.Size);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            RoleFilter filter = new RoleFilter();
            filter.Id = id;
            RoleItemInfo roleItemInfo =  _roleSearchBusiness.SearchByKey(id);
            var result = await ValidateDetail(roleItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<RoleItemInfo>(roleItemInfo);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string username  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _roleEntryBusiness.Add(insertInfo, username, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] RoleUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string username = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _roleEntryBusiness.Update(updateInfo, username, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string username = string.Empty;
            string deviceID = string.Empty;
            _roleEntryBusiness.Delete(id, username, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(RoleItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Role"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Role"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(RoleInsertInfo input)
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

        private async Task<ErrorResult> ValidateUpdate(RoleUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _roleSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Role"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Role"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _roleSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Role"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Role"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}