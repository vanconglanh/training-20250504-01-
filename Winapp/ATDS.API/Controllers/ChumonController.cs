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
    public class ChumonController : ControllerBase
    {
        readonly ChumonEntryBusiness _chumonEntryBusiness;
        readonly ChumonSearchBusiness _chumonSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public ChumonController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _chumonEntryBusiness = new ChumonEntryBusiness();
            _chumonSearchBusiness = new ChumonSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<ChumonController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //_multiLanguageService.GetResource("aaa");
            ChumonFilter filter = new ChumonFilter();
            filter.YukoFlag = (int)YUKO_FLAG.ENABLED;
            List<ChumonItemInfo> result = _chumonSearchBusiness.Search(filter);            
            return new PagingResult<ChumonItemInfo>(result, result.Count, 1, filter.PageSize);
        }

        // GET: api/<ChumonController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] ChumonFilter filter)
        {
            PaginatedList<ChumonItemInfo> result = _chumonSearchBusiness.SearchPage(filter);
            return new PagingResult<ChumonItemInfo>(result, result.TotalRecord, filter.PageIndex, filter.PageSize);
        }

        // GET api/<ChumonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ChumonFilter filter = new ChumonFilter();
            filter.ChumonId = id;

            ChumonItemInfo chumonItemInfo =  _chumonSearchBusiness.SearchByKey(id);
            var result = await ValidateDetail(chumonItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<ChumonItemInfo>(chumonItemInfo);
        }

        // POST api/<ChumonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChumonInsertInfo insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string userName  = string.Empty;
            string deviceID  = string.Empty;

            ReturnInfo insertResultInfo = _chumonEntryBusiness.Add(insertInfo, userName, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<ChumonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ChumonUpdateInfo updateInfo)
        {
            //validate
            var result = await ValidateUpdate(updateInfo);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string userName = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo updateResultInfo = _chumonEntryBusiness.Update(updateInfo, userName, deviceID);

            return Ok(updateResultInfo);
        }

        // DELETE api/<ChumonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string userName = string.Empty;
            string deviceID = string.Empty;
            _chumonEntryBusiness.Delete(id, userName, deviceID);

            return Ok();
        }

        #endregion

        #region Private Function       
        private async Task<ErrorResult> ValidateDetail(ChumonItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Chumon"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message:  string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Chumon"), 
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateInsert(ChumonInsertInfo input)
        {
            // Check Mandatory - NAME 
            if (string.IsNullOrEmpty(input.ChumonNo))
            {
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "ChumonNo"),
                                    statusCode: (int)ResultCode.Success);
            }

            return null;
        }

        private async Task<ErrorResult> ValidateUpdate(ChumonUpdateInfo input)
        {
            // Check Mandatory - NAME 
            if (string.IsNullOrEmpty(input.ChumonNo))
            {
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "ChumonNo"),
                                    statusCode: (int)ResultCode.Success);
            }


            var entity = _chumonSearchBusiness.SearchByKey(input.ChumonId);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Chumon"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Chumon"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _chumonSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Chumon"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Chumon"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }

        #endregion
    }
}