using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("PastaImage")]
    public class PastaImage : IEntityTypeConfiguration<PastaImage>
    {
        [Key]
        public int ImageID { get; set; }
        public int PastaBindID { get; set; }
        public byte[] ImageData { get; set; }
        public string GlobalKey { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }


        // Navigation property
        public PastaBind PastaBind { get; set; }
        public void Configure(EntityTypeBuilder<PastaImage> builder)
        {
            // Relationships
            builder.HasOne(pi => pi.PastaBind)
                   .WithOne(pb => pb.Image)
                   .HasForeignKey<PastaBind>(pi => pi.PastaBindID);
        }
    }

}