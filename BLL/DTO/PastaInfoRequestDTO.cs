namespace BLL
{
    public class PastaInfoRequestDTO
    {
        public int IDUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsActive { get; set; }
    }

}
