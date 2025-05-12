
namespace ATDS.Business.Interfaces
{
    public interface ISmsService 
    {
        Task SendMessage(string phoneNumber);
    }
}
