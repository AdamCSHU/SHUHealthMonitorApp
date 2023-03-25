using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUHealthApp.Shared
{
    public class UserSession
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public int ExpireTime { get; set; }
        public DateTime SessionEndStamp { get; set; }
    }
}
