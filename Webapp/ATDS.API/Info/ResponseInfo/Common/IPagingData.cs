namespace ATDS.API.Info.ResponseInfo.Common
{
    public interface IPagingData<TItem>
    {
        long Total { get; set; }

        int Page { get; set; }

        int Size { get; set; }

        TItem[] Items { get; set; }
    }
}
