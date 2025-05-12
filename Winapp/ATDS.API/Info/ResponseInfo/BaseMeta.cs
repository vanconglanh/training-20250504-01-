using Newtonsoft.Json;
using System.ComponentModel;

namespace ATDS.API.Info.ResponseInfo
{
    public class BaseMeta : IMeta
    {
        [JsonProperty(Order = -10)]
        [DisplayName("phiên xử lý thành công hay thất bại?")]
        public virtual bool Success { get; set; } = true;

    }
}
