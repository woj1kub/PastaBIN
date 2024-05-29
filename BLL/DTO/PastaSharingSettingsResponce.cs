using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PastaSharingSettingsResponce
    {
        public int PastaSharingID;
        public string CookLogin {  get; set; }
        public DateTime EndSharingDate { get; set; }
    }
}
