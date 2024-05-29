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
        [Required]
        public int PastaBindID { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }


        // Navigation property
        [ForeignKey(nameof(PastaBindID))]
        public PastaBind PastaBind { get; set; }
        public void Configure(EntityTypeBuilder<PastaImage> builder)
        {
            // Relationships
            builder.HasOne(pi => pi.PastaBind)
                   .WithOne(pb => pb.Image)
                   .HasForeignKey<PastaBind>(pi => pi.PastaBindID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}