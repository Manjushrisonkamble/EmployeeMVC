using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Models
{
    public class EmployeeMVCDbContext: DbContext
    {
        public EmployeeMVCDbContext()
        {

        }

        public EmployeeMVCDbContext(DbContextOptions<EmployeeMVCDbContext>options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9KFF9BK;Database=EmployeeMVC;User Id=sa;password=user;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
