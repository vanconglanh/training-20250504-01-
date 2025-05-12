using ATDS.API.Info;
using ATDS.API.Info.ResponseInfo.Common;
using ATDS.API.Info.ResponseInfo.Enum;
using ATDS.API.Info.ResponseInfo.Result;
using ATDS.API.Resources;
using ATDS.API.Utils;
using ATDS.Business;
using ATDS.Business.Entity;
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
    public class ChumonMeisaiController : ControllerBase
    {
        readonly ChumonMeisaiEntryBusiness _chumonMeisaiEntryBusiness;
        readonly ChumonMeisaiSearchBusiness _chumonMeisaiSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ChumonMeisaiController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _chumonMeisaiEntryBusiness = new ChumonMeisaiEntryBusiness();
            _chumonMeisaiSearchBusiness = new ChumonMeisaiSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<ChumonMeisaiController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            ChumonMeisaiFilter filter = new ChumonMeisaiFilter();
            filter.YukoFlag = (int)YUKO_FLAG.ENABLED;
            List<ChumonMeisaiItemInfo> result = _chumonMeisaiSearchBusiness.Search(filter);            
            return new PagingResult<ChumonMeisaiItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<ChumonMeisaiController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] ChumonMeisaiFilter filter)
        {
            PaginatedList<ChumonMeisaiItemInfo> result = _chumonMeisaiSearchBusiness.SearchPage(filter);
            return new PagingResult<ChumonMeisaiItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<ChumonMeisaiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ChumonMeisaiFilter filter = new ChumonMeisaiFilter();
            filter.ChumonMeisaiId = id;

            ChumonMeisaiItemInfo chumonMeisaiItemInfo =  _chumonMeisaiSearchBusiness.SearchByKey(id);
            var result = await ValidateDetail(chumonMeisaiItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<ChumonMeisaiItemInfo>(chumonMeisaiItemInfo);
        }

        // POST api/<ChumonMeisaiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChumonMeisaiInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _chumonMeisaiEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<ChumonMeisaiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ChumonMeisaiUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _chumonMeisaiEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<ChumonMeisaiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _chumonMeisaiEntryBusiness.Delete(id, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(ChumonMeisaiItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "ChumonMeisai"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "ChumonMeisai"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(ChumonMeisaiInsertInfo input)
        {
            // Check Mandatory - NAME 
            if (string.IsNullOrEmpty(input.ChumonMeisaiNo))
            {
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "ChumonMeisaiNo"),
                                    statusCode: (int)ResultCode.Success);
            }

            return null;
        }

        private async Task<ErrorResult> ValidateUpdate(ChumonMeisaiUpdateInfo input)
        {
            // Check Mandatory - NAME 
            if (string.IsNullOrEmpty(input.ChumonMeisaiNo))
            {
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "ChumonMeisaiNo"),
                                    statusCode: (int)ResultCode.Success);
            }


            var entity = _chumonMeisaiSearchBusiness.SearchByKey(input.ChumonMeisaiId);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "ChumonMeisai"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "ChumonMeisai"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _chumonMeisaiSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "ChumonMeisai"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "ChumonMeisai"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}