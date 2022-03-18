using MegaKit.EL.DBMegaKit.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MegaKit.DAL.Contexts
{
    public class ContextMegaKit : DbContext
    {
        private readonly IConfiguration _configuration;

        public ContextMegaKit(DbContextOptions<ContextMegaKit> options) : base(options) { }

        #region DB Tables
        public DbSet<About> About { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Team> Team { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(EL.DBConnection.SQLServer.ConnectionString, x => x.MigrationsAssembly("MegaKit.DAL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
