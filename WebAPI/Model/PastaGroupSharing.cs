using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("PastaGroupSharing")]
    public class PastaGroupSharing : IEntityTypeConfiguration<PastaGroupSharing>
    {
        [Key]
        public int GroupSharingID { get; set; }
        [Required]
        public string GroupKey { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? EndSharingDate { get; set; }
        [Required]
        public int PastaBindID { get; set; }

        // Navigation property
        public PastaBind PastaBind { get; set; }

        public void Configure(EntityTypeBuilder<PastaGroupSharing> builder)
        {
            builder.HasIndex(pb => pb.GroupKey)
                .IsUnique();

            builder.HasOne(pgs => pgs.PastaBind)
                   .WithMany(pb => pb.GroupSharing)
                   .HasForeignKey(pgs => pgs.PastaBindID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
