using BingoDefinitivo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BingoDefinitivo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BingoCViewModel> BingoTable { get; set; }
        public DbSet<BolilleroViewModel> Bolilla { get; set; }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-613UFOO;Database=BingoWEBDB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}