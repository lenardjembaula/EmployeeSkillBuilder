using Microsoft.EntityFrameworkCore;
using EmployeeSkillBuilder.Models;

namespace EmployeeSkillBuilder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
