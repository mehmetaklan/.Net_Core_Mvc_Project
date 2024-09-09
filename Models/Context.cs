using Microsoft.EntityFrameworkCore;

namespace Departman_Management.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9HDFLL4;Database=Department_Management;Integrated Security = true;");
        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Admin> admins { get; set; }

    }
}
