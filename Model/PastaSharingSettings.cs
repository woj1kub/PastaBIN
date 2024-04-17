using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Model
{
    [Table("PastaSharingSettings")]
    public class PastaSharingSettings : IEntityTypeConfiguration<PastaSharingSettings>
    {
        [Key]
        public int ID { get; set; }

        [Column("UserID")]
        public int IDUser { get; set; }

        [Column("PastaInfoID")]
        public int IDPastaInfo { get; set; }

        public DateTime? EndSharingDate { get; set; }
        [ForeignKey(nameof(IDUser))]
        public Cook User { get; set; }
        [ForeignKey(nameof(IDPastaInfo))]
        public PastaInfo PastaInfo { get; set; }

        public void Configure(EntityTypeBuilder<PastaSharingSettings> builder)
        {
            builder.HasOne(p => p.User)
                   .WithMany(p => p.PastaSharingSettings)
                   .HasForeignKey(p => p.IDUser)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PastaInfo)
                   .WithMany(p => p.PastaSharingSettings)
                   .HasForeignKey(p => p.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
