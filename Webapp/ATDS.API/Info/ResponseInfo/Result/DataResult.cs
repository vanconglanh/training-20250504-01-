using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATDS.API.Info.ResponseInfo.Result
{
    public class DataResult<TData> : DataResultWithMeta<TData, BaseMeta>
    {
        public DataResult(TData data)
        {
            Data = data;
        }
    }
}
