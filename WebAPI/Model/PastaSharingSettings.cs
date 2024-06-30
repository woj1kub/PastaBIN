using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("PastaSharingSettings")]
    public class PastaSharingSettings : IEntityTypeConfiguration<PastaSharingSettings>
    {
        [Key]
        public int SharingSettingsID { get; set; }
        [Required]
        public int CookID { get; set; }
        [Required]
        public int PastaBindID { get; set; }
        public DateTime? EndSharingDate { get; set; }
        public DateTime CreationDate { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CookID))]
        public Cook Cook { get; set; }
        [ForeignKey(nameof(PastaBindID))]
        public PastaBind PastaBind { get; set; }

        public void Configure(EntityTypeBuilder<PastaSharingSettings> builder)
        {
            builder.HasOne(ss => ss.Cook)
                   .WithMany(c => c.SharingSettings)
                   .HasForeignKey(ss => ss.CookID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ph => ph.PastaBind)
                  .WithMany(pb => pb.SharingSettings)
                  .HasForeignKey(ph => ph.PastaBindID)
                  .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.Restrict depending on your needs
        }
    }
}
