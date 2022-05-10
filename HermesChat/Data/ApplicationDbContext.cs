using HermesChat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HermesChat.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<UsersModel> User { get; set; }
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(b =>
            {
                b.HasKey(u => u.Id);
                b.ToTable("AspNetUsers");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
              optionsBuilder
                  .UseSqlServer(
                      @"Server=tcp:hermeschatdbserver.database.windows.net,1433;Initial Catalog=HermesChat_db;Persist Security Info=False;User ID=admindb;Password=chatApp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                      options => options.EnableRetryOnFailure());
    }
}