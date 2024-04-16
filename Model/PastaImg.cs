using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model
{
    [Table("PastaImg")]
    public class PastaImg : IEntityTypeConfiguration<PastaImg>
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("PastaInfo")]
        public int IDPastaInfo { get; set; }

        public required byte[] Img { get; set; }

        public PastaInfo PastaInfo { get; set; }

        public void Configure(EntityTypeBuilder<PastaImg> builder)
        {
            builder.HasOne(p => p.PastaInfo)
                   .WithMany(p => p.PastaImgs)
                   .HasForeignKey(p => p.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
