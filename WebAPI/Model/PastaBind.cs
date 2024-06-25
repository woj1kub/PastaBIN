using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class PastaBind : IEntityTypeConfiguration<PastaBind>
    {
        [Key]
        public int PastaBindID { get; set; }
        public int? TxtID { get; set; }
        public int? ImgID { get; set; }
        public int? CookID { get; set; }
        [Required]
        public string GlobalKey { get; set; }

        // Navigation properties
        public Cook? Cook { get; set; }
        public PastaTxt? Txt { get; set; }
        public PastaImage? Image { get; set; }

        public ICollection<PastaSharingSettings>? SharingSettings { get; set; }
        public ICollection<PastaHistory>? Histories { get; set; }
        public ICollection<PastaGroupSharing>? GroupSharing { get; set; }

        public void Configure(EntityTypeBuilder<PastaBind> builder)
        {
            builder.HasIndex(pb => pb.GlobalKey)
                .IsUnique();

            builder.HasMany(pb => pb.SharingSettings)
               .WithOne(pss => pss.PastaBind)
               .HasForeignKey(pss => pss.PastaBindID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pb => pb.Histories)
                .WithOne(ph => ph.PastaBind)
                .HasForeignKey(ph => ph.PastaBindID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pb => pb.GroupSharing)
                .WithOne(pgs => pgs.PastaBind)
                .HasForeignKey(pgs => pgs.PastaBindID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
