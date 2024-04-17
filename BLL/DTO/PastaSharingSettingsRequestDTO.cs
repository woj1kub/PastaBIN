namespace BLL
{
    public class PastaSharingSettingsRequestDTO
    {
        public int IDUser { get; set; }
        public int IDPastaInfo { get; set; }
        public DateTime? EndSharingDate { get; set; }
    }

}
