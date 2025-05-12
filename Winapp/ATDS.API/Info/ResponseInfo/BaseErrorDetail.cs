using Newtonsoft.Json;

namespace ATDS.API.Info.ResponseInfo
{
    public class BaseErrorDetail : IErrorDetail
    {
        [JsonProperty(Order = -10)]
        public virtual string Code { get; set; }

        [JsonProperty(Order = -10)]
        public virtual string Message { get; set; }
    }
}
