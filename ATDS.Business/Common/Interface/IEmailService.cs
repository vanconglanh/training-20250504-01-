using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Interfaces
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string html);
    }
}
