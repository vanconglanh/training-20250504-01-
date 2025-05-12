
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ATDS.API.Helpers
{
    /// <summary>
    /// <see cref="https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#Dependency injection"/>
    /// </summary>
    public class AutoLogAttribute : TypeFilterAttribute
    {


        public AutoLogAttribute() : base(typeof(AutoLogActionFilterImpl))
        {

        }

        private class AutoLogActionFilterImpl : IActionFilter
        {
            private DateTime dtStartRequestDate = DateTime.Now;

            private string strProcessId = "";
            public AutoLogActionFilterImpl(ILogger<AutoLogActionFilterImpl> logger)
            {
                LogHelper.logger = logger;
                strProcessId = dtStartRequestDate.ToString("yyyyMMddHHmmssfffff");
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                // perform some business logic work
                //NLogHelper.logger.Debug($"path: {context.HttpContext.Request.Path}");
                var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
                LogHelper.LogClientInfo(strProcessId, claimsIdentity);
                LogHelper.LogRequestInfo(strProcessId, context);

            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                string strResponseTime = (DateTime.Now - dtStartRequestDate).ToString();
                LogHelper.LogResponseInfo(strProcessId, strResponseTime, context);
            }
        }
    }
}
