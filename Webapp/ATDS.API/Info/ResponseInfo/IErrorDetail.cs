namespace ATDS.API.Info.ResponseInfo
{
    public interface IErrorDetail
    {
        string Code { get; set; }

        string Message { get; set; }
    }
}
