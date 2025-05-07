using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    public class UserPermissonAction
    {
        public string ScreenName { get; set; }
        public List<string> ActionName { get; set; } = new List<string>();
    }
}
