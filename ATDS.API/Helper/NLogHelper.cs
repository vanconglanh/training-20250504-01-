
using ATDS.API.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ATDS.API.Helpers
{
    public static class LogHelper
    {
        public static ILogger logger;

        internal static String BodyContent { get; set; }
        public static object JwtClaimTypes { get; private set; }

        public static void LogClientInfo(string strProcessID, ClaimsIdentity claimsIdentity)
        {

            string outputFormat = "ProcessID: {0} | Username: {1} --- Client Info: {2} |";
            if (claimsIdentity != null)
            {
                LogHelper.logger.LogInformation(String.Format(outputFormat,
                                            strProcessID,
                                            claimsIdentity.FindFirst(ClaimConstant.Username),
                                            claimsIdentity.FindFirst(ClaimConstant.Email)));

            }
        }

        public static void LogRequestInfo(string strProcessID, ActionExecutingContext context)
        {
            string outputFormat = "ProcessID: {0} | PatientId: {1}  --- Request Info: {2} | {3}| {4} ";

            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            LogHelper.logger.LogInformation(String.Format(outputFormat,
                                                          strProcessID,
                                                          context.HttpContext.Request.Path,
                                                          context.HttpContext.Request.Method,
                                                          context.HttpContext.Request.QueryString,
                                                          claimsIdentity.FindFirst(ClaimConstant.Username)));


        }

        public static void LogResponseInfo(string strProcessID, string strResponseTime, ActionExecutedContext context)
        {
            var result = context.Result;
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            string outputFormat = "ProcessID: {0} | PatientId: {1}  | Processed Time: {2}  --- Responese Info: {3}";
            LogHelper.logger.LogInformation(String.Format(outputFormat,
                                       strProcessID,
                                       claimsIdentity.FindFirst(ClaimConstant.Username),
                                       strResponseTime,
                                       JsonConvert.SerializeObject(result).ToString()));
        }

        public static Task WritePostRequestLog(Object obj, ClaimsIdentity claimsIdentity)
        {
            //WriteLog($"{claimsIdentity.FindFirst(ClaimConstant.PatientId)} | Request: ", obj, LogLevel.Warning);

            return Task.CompletedTask;
        }

        public static void WriteLog(String strPrefix, Object obj, LogLevel loglevel)
        {
            switch (loglevel)
            {
                case LogLevel.Debug:
                    LogHelper.logger.LogDebug($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
                case LogLevel.Information:
                    LogHelper.logger.LogInformation($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
                case LogLevel.Warning:
                    LogHelper.logger.LogWarning($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
                case LogLevel.Error:
                    LogHelper.logger.LogError($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
                case LogLevel.Critical:
                    LogHelper.logger.LogCritical($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
                default:
                    LogHelper.logger.LogDebug($"{strPrefix} : {JsonConvert.SerializeObject(obj)}");
                    break;
            }
        }
    }
}
