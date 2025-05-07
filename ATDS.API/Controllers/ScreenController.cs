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
    public class ScreenController : ControllerBase
    {
        readonly ScreenEntryBusiness _screenEntryBusiness;
        readonly ScreenSearchBusiness _screenSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ScreenController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _screenEntryBusiness = new ScreenEntryBusiness();
            _screenSearchBusiness = new ScreenSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<ScreenController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            ScreenFilter filter = new ScreenFilter();
            filter.YukoFlag = YUKO_FLAG.ENABLED.ToString();
            List<ScreenItemInfo> result = _screenSearchBusiness.Search(filter);            
            return new PagingResult<ScreenItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<ScreenController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] ScreenFilter filter)
        {
            PaginatedList<ScreenItemInfo> result = _screenSearchBusiness.SearchPage(filter);
            return new PagingResult<ScreenItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<ScreenController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int piId)
        {
            ScreenFilter filter = new ScreenFilter();
            filter.Id = piId;

            ScreenItemInfo screenItemInfo =  _screenSearchBusiness.SearchByKey(piId);
            var result = await ValidateDetail(screenItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<ScreenItemInfo>(screenItemInfo);
        }

        // POST api/<ScreenController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScreenInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _screenEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<ScreenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ScreenUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _screenEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<ScreenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int piId)
        {
            var result = await ValidateDelete(piId);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _screenEntryBusiness.Delete(piId, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(ScreenItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Screen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Screen"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(ScreenInsertInfo input)
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

        private async Task<ErrorResult> ValidateUpdate(ScreenUpdateInfo input)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _screenSearchBusiness.SearchByKey(input.Id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Screen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Screen"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int piId)
        {
            var entity = _screenSearchBusiness.SearchByKey(piId);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Screen"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == YUKO_FLAG.DISABLED.ToString())
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Screen"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}