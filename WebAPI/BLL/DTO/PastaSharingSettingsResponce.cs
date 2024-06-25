using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PastaSharingSettingsResponse
    {
        public int PastaSharingID { get; set; }
        public string CookLogin {  get; set; }
        public DateTime? EndSharingDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
