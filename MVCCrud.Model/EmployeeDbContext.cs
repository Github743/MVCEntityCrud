using System.Data.Entity;

namespace MVCCrud.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("Employee_Entities")
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
