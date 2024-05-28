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
        public string GroupKey { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeleteTime { get; set; }
        public int PastaBindID { get; set; }
        // Navigation property
        public PastaBind PastaBind { get; set; }

        public void Configure(EntityTypeBuilder<PastaGroupSharing> builder)
        {
            builder.HasOne(pgs => pgs.PastaBind)
                   .WithMany(pb => pb.GroupSharing)
                   .HasForeignKey(pb => pb.GroupSharingID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}