using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("PastaHistory")]
    public class PastaHistory : IEntityTypeConfiguration<PastaHistory>
    {
        [Key]
        public int HistoryID { get; set; }

        public int? CookID { get; set; } // Allow null values

        [Required]
        public int PastaBindID { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CookID))]
        public Cook? Cook { get; set; }

        [ForeignKey(nameof(PastaBindID))]
        public PastaBind PastaBind { get; set; }

        public void Configure(EntityTypeBuilder<PastaHistory> builder)
        {
            builder.HasKey(ph => ph.HistoryID);

            //builder.HasOne(ph => ph.Cook).WithMany(c => c.Histories).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ph => ph.PastaBind).WithMany(c => c.Histories).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
