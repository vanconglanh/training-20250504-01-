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
    public class UserController : ControllerBase
    {
        readonly UserEntryBusiness _userEntryBusiness;
        readonly UserSearchBusiness _userSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public UserController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _userEntryBusiness = new UserEntryBusiness();
            _userSearchBusiness = new UserSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            UserFilter filter = new UserFilter();
            filter.YukoFlag = YUKO_FLAG.ENABLED.ToString();
            List<UserItemInfo> result = _userSearchBusiness.Search(filter);            
            return new PagingResult<UserItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<UserController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] UserFilter filter)
        {
            PaginatedList<UserItemInfo> result = _userSearchBusiness.SearchPage(filter);
            return new PagingResult<UserItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int piId)
        {
            UserFilter filter = new UserFilter();
            filter.Id = piId;

            UserItemInfo userItemInfo =  _userSearchBusiness.SearchByKey(piId);
            var result = await ValidateDetail(userItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<UserItemInfo>(userItemInfo);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _userEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UserUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _userEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int piId)
        {
            var result = await ValidateDelete(piId);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _userEntryBusiness.Delete(piId, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(UserItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "User"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "User"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(UserInsertInfo input)
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

        private async Task<ErrorResult> ValidateUpdate(UserUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _userSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "User"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "User"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int piId)
        {
            var entity = _userSearchBusiness.SearchByKey(piId);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "User"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "User"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}