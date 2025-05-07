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
    public class PermissionController : ControllerBase
    {
        readonly PermissionEntryBusiness _permissionEntryBusiness;
        readonly PermissionSearchBusiness _permissionSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public PermissionController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _permissionEntryBusiness = new PermissionEntryBusiness();
            _permissionSearchBusiness = new PermissionSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<PermissionController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            PermissionFilter filter = new PermissionFilter();
            filter.YukoFlag = YUKO_FLAG.ENABLED.ToString();
            List<PermissionItemInfo> result = _permissionSearchBusiness.Search(filter);            
            return new PagingResult<PermissionItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<PermissionController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] PermissionFilter filter)
        {
            PaginatedList<PermissionItemInfo> result = _permissionSearchBusiness.SearchPage(filter);
            return new PagingResult<PermissionItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int piId)
        {
            PermissionFilter filter = new PermissionFilter();
            filter.Id = piId;

            PermissionItemInfo permissionItemInfo =  _permissionSearchBusiness.SearchByKey(piId);
            var result = await ValidateDetail(permissionItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<PermissionItemInfo>(permissionItemInfo);
        }

        // POST api/<PermissionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _permissionEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<PermissionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PermissionUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _permissionEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<PermissionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int piId)
        {
            var result = await ValidateDelete(piId);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _permissionEntryBusiness.Delete(piId, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(PermissionItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Permission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Permission"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(PermissionInsertInfo input)
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

        private async Task<ErrorResult> ValidateUpdate(PermissionUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _permissionSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Permission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Permission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int piId)
        {
            var entity = _permissionSearchBusiness.SearchByKey(piId);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Permission"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Permission"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}