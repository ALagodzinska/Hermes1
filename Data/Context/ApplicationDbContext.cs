using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Group> Group { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
              optionsBuilder
                  .UseSqlServer(
                      @"Server=tcp:hermeschatdbserver.database.windows.net,1433;Initial Catalog=HermesChat_db;Persist Security Info=False;User ID=admindb;Password=chatApp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                      options => options.EnableRetryOnFailure());
    }
}