using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Model
{
    [Table("PastaHistory")]
    public class PastaHistory : IEntityTypeConfiguration<PastaHistory>
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int IDUser { get; set; }

        [ForeignKey("PastaInfo")]
        public int IDPastaInfo { get; set; }

        public DateTime VisitDate { get; set; }

        public Cook User { get; set; }
        public PastaInfo PastaInfo { get; set; }

        public void Configure(EntityTypeBuilder<PastaHistory> builder)
        {
            builder.HasOne(p => p.User)
                   .WithMany(p => p.PastaHistories)
                   .HasForeignKey(p => p.IDUser)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PastaInfo)
                   .WithMany(p => p.PastaHistories)
                   .HasForeignKey(p => p.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
