using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Cooks")]
    public class Cook : IEntityTypeConfiguration<Cook>
    {
        [Key]
        public int CookID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        // Navigation properties
        public ICollection<PastaBind>? PastaBinds { get; set; }
        public ICollection<PastaSharingSettings>? SharingSettings { get; set; }
        public ICollection<PastaHistory>? Histories { get; set; }

        public void Configure(EntityTypeBuilder<Cook> builder)
        {
            builder.HasIndex(c => c.Login).IsUnique();

            builder.HasMany(c => c.PastaBinds)
                   .WithOne(pb => pb.Cook)
                   .HasForeignKey(pb => pb.CookID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.SharingSettings)
                   .WithOne(ss => ss.Cook)
                   .HasForeignKey(ss => ss.CookID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Histories)
                   .WithOne(h => h.Cook)
                   .HasForeignKey(h => h.CookID)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
