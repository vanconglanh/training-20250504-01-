using ATDS.API.Info.ResponseInfo.Common;
using ATDS.Business.Info;
using ATDS.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ATDS.Common.Constant;
using ATDS.Business.Bussiness.Order;
using ATDS.API.Info.ResponseInfo.Result;
using ATDS.Common;
using ATDS.API.Info.ResponseInfo.Enum;
using ATDS.API.Resources;
using Microsoft.Extensions.Localization;

namespace ATDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        readonly OrderEntryBusiness _orderEntryBusiness;
        readonly OrderSearchBusiness _orderSearchBusiness;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public OrderController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _orderEntryBusiness = new OrderEntryBusiness();
            _orderSearchBusiness = new OrderSearchBusiness();
            _sharedLocalizer = sharedLocalizer;
        }

        #region API Function
        // GET: api/<OrderController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] OrderFilter filter)
        {
            filter.YukoFlag = filter.YukoFlag ?? (int)YUKO_FLAG.ENABLED;

            bool hasPaging = filter.Page > 0 && filter.Size > 0;

            if (hasPaging)
            {
                var pagedResult = _orderSearchBusiness.SearchPage(filter);
                return new PagingResult<OrderItemInfo>(
                pagedResult,
                pagedResult.TotalRecord,
                    filter.Page,
                    filter.Size
                );
            }

            var fullList = _orderSearchBusiness.Search(filter);
            return new PagingResult<OrderItemInfo>(
                fullList,
                fullList.Count,
                1,
                fullList.Count
            );
        }

        // GET: api/<OrderController>
        [HttpGet("GetPage")]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] OrderFilter filter)
        {
            PaginatedList<OrderItemInfo> result = _orderSearchBusiness.SearchPage(filter);
            return new PagingResult<OrderItemInfo>(result, result.TotalRecord, filter.Page, filter.Size);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            OrderFilter filter = new OrderFilter();
            filter.Id = id;
            OrderItemInfo orderItemInfo = _orderSearchBusiness.SearchByKey(id);
            var result = await ValidateDetail(orderItemInfo);

            if (result != null)
                return BadRequest(result);

            return new DataResult<OrderItemInfo>(orderItemInfo);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInsert insertInfo)
        {
            //Validate Insert
            var result = await ValidateInsert(insertInfo);
            if (result != null)
                return BadRequest(result);

            //TODO
            string username = string.Empty;
            string deviceID = string.Empty;

            ReturnInfo insertResultInfo = _orderEntryBusiness.Add(insertInfo, username, deviceID);

            return new DataResult<string>(insertResultInfo.Code.ToString());
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderUpdate updateInfo)
        {
            if(updateInfo == null)
            {
                return BadRequest("updateInfo null");
            }
            //validate
            var result = await ValidateUpdate(updateInfo, id);
            if (result != null)
                return BadRequest(result);

            //Set user infomation
            string username = string.Empty;
            string deviceID = string.Empty;
            ReturnInfo updateResultInfo = _orderEntryBusiness.Update(updateInfo, username, deviceID, id);

            return Ok(updateResultInfo);
        }

       

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ValidateDelete(id);
            if (result != null)
                return BadRequest(result);

            string username = string.Empty;
            string deviceID = string.Empty;
            _orderEntryBusiness.Delete(id, username, deviceID);

            return Ok();
        }
        #endregion

        #region Private Function

        private async Task<ErrorResult> ValidateDetail(OrderItemInfo entity)
        {
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "User"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "User"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }
        private async Task<ErrorResult> ValidateInsert(OrderInsert input)
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
        private async Task<ErrorResult> ValidateUpdate(OrderUpdate input, int id)
        {
            // Check Mandatory - NAME 
            // TODO
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ITEM_MANTATORY].Value, "Name"),
            //                        statusCode: (int)ResultCode.Success);
            //}


            var entity = _orderSearchBusiness.SearchByKey(id);
            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Order"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Order"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }
        private async Task<ErrorResult> ValidateDelete(int id)
        {
            var entity = _orderSearchBusiness.SearchByKey(id);

            if (entity == null)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_EXIST].Value, "Order"),
                                    statusCode: (int)ResultCode.Success);
            else if (entity.YukoFlag == (int)YUKO_FLAG.DISABLED)
                return new ErrorResult(message: string.Format(_sharedLocalizer[MessageList.ENTITY_NOT_ACTIVE].Value, "Order"),
                                    statusCode: (int)ResultCode.Success);

            return null;
        }
        #endregion
    }
}
