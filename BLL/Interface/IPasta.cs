using BLL.DTO;

namespace BLL.Interface
{
    public interface IPasta
    {
        //Dla past textowych
        public void AddTxtPasta(PastaTextRequst pastaTextRequst);
        public IEnumerable<PastaTextResponce> GetPastaTxtByUser(int BindID);
        public PastaTextResponce GetPastaTxtByKey(string Key);
        //Dla past img
        public void AddImgPasta(PastaImageRequst pastaImageRequst);
        public IEnumerable<PastaImageResponce> GetPastaImgByUser(int BindID);
        public PastaImageResponce GetPastaImgByKey(string Key);
        // Razem
        public void DeletePasta(int BindID);
        public IEnumerable<PastaHistoryResponce> PastaHistoryByKey(int BindID);
    }
}
