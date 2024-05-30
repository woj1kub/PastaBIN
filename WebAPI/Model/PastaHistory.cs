using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    
    [Table("PastaHistory")]
    public class PastaHistory : IEntityTypeConfiguration<PastaHistory>
    {
        [Key]
        public int HistoryID { get; set; }
        public int? CookID { get; set; }
        [Required]
        public int PastaBindID { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CookID))]
        public Cook? Cook { get; set; }
        [ForeignKey(nameof(PastaBindID))]
        public PastaBind PastaBind { get; set; }
        public void Configure(EntityTypeBuilder<PastaHistory> builder)
        {
            // Relationships
            builder.HasOne(ph => ph.Cook)
                   .WithMany(c => c.Histories)
                   .HasForeignKey(ph => ph.CookID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ph => ph.PastaBind)
                   .WithMany(pb => pb.Histories)
                   .HasForeignKey(ph => ph.PastaBindID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);


        }

    }
}