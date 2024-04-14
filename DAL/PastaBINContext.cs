using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            optionsBuilder.UseSqlServer("your_connection_string");
        }
    }
}
