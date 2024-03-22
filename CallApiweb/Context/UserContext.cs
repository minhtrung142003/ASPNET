using CallApiweb.Entitites;
using Microsoft.EntityFrameworkCore;

namespace CallApiweb.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}   