using System;
using System.Collections.Generic;
using System.Text;

namespace ATDS.Business
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderName { get; set; }
        public string Prefix { get; set; }
    }
}
