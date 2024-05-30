using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("PastaTxt")]
    public class PastaTxt : IEntityTypeConfiguration<PastaTxt>
    {
        [Key]
        public int PastaTxtID { get; set; }
        [Required]
        public int PastaBindID { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        // Navigation properties
        public PastaBind PastaBind { get; set; }

        public void Configure(EntityTypeBuilder<PastaTxt> builder)
        {
            // Relationships
            builder.HasOne(pt => pt.PastaBind)
                   .WithOne(pb => pb.Txt)
                   .HasForeignKey<PastaTxt>(pt => pt.PastaBindID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
