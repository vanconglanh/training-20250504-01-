namespace ATDS.API.Info.ResponseInfo.Result
{
    public class DataResultWithMeta<TData, TMeta> : BaseResultWithData<TData, TMeta> where TMeta : IMeta, new()
    {
        public DataResultWithMeta()
            : base(200)
        {
        }
    }
}