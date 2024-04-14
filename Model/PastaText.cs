using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("PastaText")]
    public class PastaText : IEntityTypeConfiguration<PastaText>
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("PastaInfo")]
        public int IDPastaInfo { get; set; }

        [Required]
        public string Pasta { get; set; }

        public PastaInfo PastaInfo { get; set; }

        public void Configure(EntityTypeBuilder<PastaText> builder)
        {
            builder.HasOne(p => p.PastaInfo)
                   .WithMany(p => p.PastaTexts)
                   .HasForeignKey(p => p.IDPastaInfo)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
