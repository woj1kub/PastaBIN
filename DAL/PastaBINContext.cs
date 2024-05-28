using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class PastaBINContext : DbContext
    {
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<PastaGroupSharing> PastaGroupSharing { get; set; }
        public DbSet<PastaTxt> Pastas { get; set; }
        public DbSet<PastaBind> PastaBinds { get; set; }
        public DbSet<PastaSharingSettings> PastaSharingSettings { get; set; }
        public DbSet<PastaImage> PastaImages { get; set; }
        public DbSet<PastaHistory> PastaHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaiibProjekt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSqlServer("Data Source=MACIEJ;Initial Catalog=PastaBin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Cook());
            modelBuilder.ApplyConfiguration(new PastaGroupSharing());
            modelBuilder.ApplyConfiguration(new PastaTxt());
            modelBuilder.ApplyConfiguration(new PastaBind());
            modelBuilder.ApplyConfiguration(new PastaSharingSettings());
            modelBuilder.ApplyConfiguration(new PastaImage());
            modelBuilder.ApplyConfiguration(new PastaHistory());
        }
    }
}