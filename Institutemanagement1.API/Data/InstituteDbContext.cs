using Institutemanagement1.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Institutemanagement1.API.Data
{
    public class InstituteDbContext : DbContext
    {
        public InstituteDbContext(DbContextOptions<InstituteDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
