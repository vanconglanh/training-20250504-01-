using ATDS.API.Info.ResponseInfo.Result;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATDS.API.Info.ResponseInfo.Common
{
    public class PagingResult<TItem> : DataResultWithMeta<IList<TItem>, PagingMeta>
    {
        public PagingResult(IList<TItem> data, long total, int page, int? size)
        {
            Meta = new PagingMeta
            {
                Total = total,
                Page = page,
                Size = (size ?? data.Count)
            };
            Data = data;
        }

        public PagingResult(IPagingData<TItem> data)
        {
            Meta = new PagingMeta
            {
                Total = data.Total,
                Page = data.Page,
                Size = data.Size
            };
            Data = data.Items;
        }
    }
}
