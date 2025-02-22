using System.Data.Entity;

namespace MVCCrud.Model
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("Employee_Entities")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");// Maps to existing table
            base.OnModelCreating(modelBuilder);
        }
    }
}
