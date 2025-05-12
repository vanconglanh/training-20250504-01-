using System.ComponentModel;

namespace ATDS.API.Info.ResponseInfo.Common
{
    public class PagingMeta : BaseMeta
    {
        [DisplayName("tổng số item")]
        public virtual long Total { get; set; }

        [DisplayName("tổng số trang")]
        public virtual long PageCount => (long)Math.Ceiling((decimal)Total / (decimal)Size);

        [DisplayName("vị trí trang hiện tại")]
        public virtual long Page { get; set; }

        [DisplayName("kích thước một trang dữ liệu")]
        public virtual int Size { get; set; }

        [DisplayName("còn trang kế tiếp?")]
        public virtual bool CanNext => Page < PageCount;

        [DisplayName("có trang trước?")]
        public virtual bool CanPrev => Page > 1;
    }
}