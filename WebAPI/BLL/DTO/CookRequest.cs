using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CookRequest
    {
        public string Login { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
