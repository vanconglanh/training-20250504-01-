namespace ATDS.API.Info.ResponseInfo.Result
{
    public class ErrorResultWithMeta<TErrorDetail, TMeta> : BaseResult<TMeta> where TErrorDetail : IErrorDetail, new() where TMeta : IMeta, new()
    {
        public virtual TErrorDetail Error { get; protected set; }

        public ErrorResultWithMeta(string code = "exception", string message = "internal server error", int statusCode = 500)
            : base(statusCode)
        {
            Meta = new TMeta
            {
                Success = false
            };
            Error = new TErrorDetail
            {
                Code = code,
                Message = message
            };
        }
    }
}