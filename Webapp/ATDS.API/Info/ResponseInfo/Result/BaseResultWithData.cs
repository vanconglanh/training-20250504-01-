using Newtonsoft.Json;

namespace ATDS.API.Info.ResponseInfo.Result
{
    public abstract class BaseResultWithData<TData, TMeta> : BaseResult<TMeta> where TMeta : IMeta, new()
    {
        [JsonProperty(Order = -9)]
        public virtual TData Data { get; protected set; }

        protected BaseResultWithData(int statusCode)
            : base(statusCode)
        {
            Data = default(TData);
        }
    }
}