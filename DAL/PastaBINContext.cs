using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class PastaBINContext : DbContext
    {
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<PastaInfo> PastaInfos { get; set; }
        public DbSet<PastaText> PastaTexts { get; set; }
        public DbSet<PastaImg> PastaImgs { get; set; }
        public DbSet<PastaHistory> PastaHistories { get; set; }
        public DbSet<PastaSharingSettings> PastaSharingSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaiibProjekt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSqlServer("Data Source=MACIEJ;Initial Catalog=PastaBin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Cook());
            modelBuilder.ApplyConfiguration(new PastaText());
            modelBuilder.ApplyConfiguration(new PastaImg());
            modelBuilder.ApplyConfiguration(new PastaHistory());
            modelBuilder.ApplyConfiguration(new PastaSharingSettings());
            modelBuilder.ApplyConfiguration(new PastaInfo());
        }
    }
}
