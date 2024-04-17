using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Model
{
    [Table("PastaInfo")]
    public class PastaInfo : IEntityTypeConfiguration<PastaInfo>
    {
        [Key]
        public int ID { get; set; }

        [Column("UserID")]
        public int IDUser { get; set; }

        [MaxLength(255)]
        public string Key { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? DeleteTime { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey(nameof(IDUser))]
        public Cook Cook { get; set; }
        public ICollection<PastaText> PastaTexts { get; set; }
        public ICollection<PastaImg> PastaImgs { get; set; }
        public ICollection<PastaHistory> PastaHistories { get; set; }
        public ICollection<PastaSharingSettings> PastaSharingSettings { get; set; }

        public void Configure(EntityTypeBuilder<PastaInfo> builder)
        {
            builder.HasOne(pi => pi.Cook)
                   .WithMany(c => c.PastaInfos)
                   .HasForeignKey(pi => pi.IDUser)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pi => pi.PastaTexts)
                   .WithOne(pt => pt.PastaInfo)
                   .HasForeignKey(pt => pt.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pi => pi.PastaImgs)
                   .WithOne(pi => pi.PastaInfo)
                   .HasForeignKey(pi => pi.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pi => pi.PastaHistories)
                   .WithOne(ph => ph.PastaInfo)
                   .HasForeignKey(ph => ph.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pi => pi.PastaSharingSettings)
                   .WithOne(pss => pss.PastaInfo)
                   .HasForeignKey(pss => pss.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
