using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICook
    {
        public IEnumerable<CookResponceDTO> GetCooks();
        public CookResponceDTO GetCook(int id);
        public void DeleteCook(int id);
        public void PutCook(int id , CookRequestDTO cookRequest);
        public void PostCook(CookRequestDTO cookRequest);
    }
}
