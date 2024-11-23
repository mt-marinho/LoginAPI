using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Login.Models;

namespace Login.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
