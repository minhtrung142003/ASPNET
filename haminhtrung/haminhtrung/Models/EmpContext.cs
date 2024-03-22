using Microsoft.EntityFrameworkCore;

namespace haminhtrung.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options) { }
        DbSet<Product> Product
        {
            get;
            set;
        }
    }
}
