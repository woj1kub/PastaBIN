namespace BLL.DTO
{
    public class PastaGroupSharingResponce
    {
        public int PastaGroupID;
        public string CookLogin { get; set; }
        public string GroupKey { get; set; }
        public DateTime EndSharingDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
