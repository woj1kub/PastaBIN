using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface ICook
    {
        IEnumerable<CookResponceDTO> GetCooks();
        CookResponceDTO GetCook(int id);
        void DeleteCook();
        void PutCook(int id , CookRequestDTO cookRequest);
        void PostCook(CookRequestDTO cookRequest);
    }
}
