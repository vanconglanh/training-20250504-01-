namespace ATDS.API.Info.ResponseInfo.Result
{
    public class ErrorResult : ErrorResultWithMeta<BaseErrorDetail, BaseMeta>
    {
        public ErrorResult(string code = "exception", string message = "internal server error", int statusCode = 500)
            : base(code, message, statusCode)
        {
        }
    }
}
