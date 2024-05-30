namespace BLL.DTO
{
    public class PastaGroupSharingResponse
    {
        public int PastaGroupID;
        public string GroupKey { get; set; }
        public DateTime? EndSharingDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
