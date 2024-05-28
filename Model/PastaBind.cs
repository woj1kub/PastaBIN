using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations;

public class PastaBind : IEntityTypeConfiguration<PastaBind>
{
    [Key]
    public int PastaBindID { get; set; }
    public int PastaID { get; set; }
    public int CookID { get; set; }
    public int SharingSettingsID { get; set; }

    // Navigation properties
    public Cook Cook { get; set; }
    public PastaTxt Pasta { get; set; }
    public PastaImage Image { get; set; }
    public PastaSharingSettings SharingSettings { get; set; }
    public ICollection<PastaHistory> Histories { get; set; }
    public ICollection<PastaGroupSharing> GroupSharing { get; set; }

    public void Configure(EntityTypeBuilder<PastaBind> builder)
    {
        builder.HasOne(pb => pb.Cook)
            .WithMany(c => c.PastaBinds)
            .HasForeignKey(pb => pb.CookID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pb => pb.SharingSettings)
               .WithOne(pss => pss.PastaBind)
               .HasForeignKey<PastaSharingSettings>(pss => pss.PastaBindID) // Specify the foreign key in PastaSharingSettings
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(pb => pb.Histories)
               .WithOne(ph => ph.PastaBind)
               .HasForeignKey(ph => ph.PastaBindID)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(pb => pb.GroupSharing)
               .WithOne(pgs => pgs.PastaBind) // Ensure the correct name is used here
               .HasForeignKey(pgs => pgs.PastaBindID) // Ensure the correct FK property is used here
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
