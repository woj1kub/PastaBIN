namespace BLL.DTO
{
    public class PastaSharingSettingsRequest
    {
        public int CookID { get; set; }
        public int PastaBindID { get; set; }
        public string CookLogin { get; set; }
        public DateTime? EndSharingDate { get; set; }
    }
}
