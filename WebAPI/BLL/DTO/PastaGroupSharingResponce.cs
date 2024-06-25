namespace BLL.DTO
{
    public class PastaGroupSharingResponse
    {
        public int GroupSharingID { get; set; }
        public string GroupKey { get; set; }
        public DateTime? EndSharingDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
