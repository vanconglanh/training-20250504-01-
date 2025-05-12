using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ATDS.API.Info.ResponseInfo
{
    public abstract class BaseResult<TMeta> : IActionResult where TMeta : IMeta, new()
    {
        [JsonIgnore]
        public virtual int StatusCode { get; protected set; }

        [JsonProperty(Order = -10)]
        public virtual TMeta Meta { get; protected set; }

        protected BaseResult(int statusCode)
        {
            StatusCode = statusCode;
            Meta = new TMeta
            {
                Success = statusCode >= 200 && statusCode < 300
            };
        }

        public virtual async Task ExecuteResultAsync(ActionContext context)
        {
            ObjectResult result = new ObjectResult(this)
            {
                StatusCode = StatusCode
            };
            await result.ExecuteResultAsync(context);
        }
    }
}
