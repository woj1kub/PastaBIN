using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Model
{
    [Table("Cook")]
    public class Cook : IEntityTypeConfiguration<Cook>
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public ICollection<PastaInfo> PastaInfos { get; set; }
        public ICollection<PastaHistory> PastaHistories { get; set; }
        public ICollection<PastaSharingSettings> PastaSharingSettings { get; set; }

        public void Configure(EntityTypeBuilder<Cook> builder)
        {
            builder.HasMany(p => p.PastaInfos)
                   .WithOne(p => p.Cook)
                   .HasForeignKey(p => p.IDUser);

            builder.HasMany(p => p.PastaHistories)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.IDUser);

            builder.HasMany(p => p.PastaSharingSettings)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.IDUser);
        }
    }
}
