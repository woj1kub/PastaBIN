using BLL.DTO;

namespace BLL.Interface
{
    public interface IPasta
    {
        
        
        // Razem
        public bool DeletePasta(int BindID);
        public IEnumerable<PastaHistoryResponse> PastaHistoryByKey(int BindID);
    }
}
