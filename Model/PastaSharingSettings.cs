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
        public int CookID { get; set; }
        public int PastaBindID { get; set; }
        public DateTime? EndSharingDate { get; set; }

        // Navigation properties
        public Cook Cook { get; set; }
        public PastaBind PastaBind { get; set; }
        public void Configure(EntityTypeBuilder<PastaSharingSettings> builder)
        {
            builder.HasOne(pss => pss.Cook)
                   .WithMany(c => c.SharingSettings) // Ensure this matches the configuration in Cook
                   .HasForeignKey(pss => pss.CookID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pss => pss.PastaBind)
                   .WithOne(pb => pb.SharingSettings)
                   .HasForeignKey<PastaSharingSettings>(pss => pss.PastaBindID) // Specify the foreign key in PastaSharingSettings
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}