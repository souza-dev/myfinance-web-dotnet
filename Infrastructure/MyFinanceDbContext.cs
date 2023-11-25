using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=LOCALHOST,1433\\Catalog=myfinanceweb;Database=myfinanceweb;User=sa;Password=MyPass@word;TrustServerCertificate=True;"; ;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}