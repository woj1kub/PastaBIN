using BLL.DTO;

namespace BLL.Interface
{
    public interface IPastaTxt
    {
        //Dla past textowych
        public string AddTxtPasta(int? CookID,PastaTextRequest pastaTextRequest);
        public IEnumerable<PastaTextResponse> GetPastaTxtByUser(int CookID);
        public IEnumerable<PastaTextResponse> GetPastaTxtByUserFromSharing(int CookID);
        public PastaTextResponse GetPastaTxtByKey(string Key, int CookID);
    }
}
