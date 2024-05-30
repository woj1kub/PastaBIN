using BLL.DTO;

namespace BLL.Interface
{
    public interface IPastaTxt
    {
        //Dla past textowych
        public bool AddTxtPasta(PastaTextRequest pastaTextRequest);
        public IEnumerable<PastaTextResponse> GetPastaTxtByUser(int CookID);
        public PastaTextResponse GetPastaTxtByKey(string Key, int CookID);
    }
}
