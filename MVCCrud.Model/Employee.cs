using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCrud.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EMP_ID { get; set; }
        public string EMP_Name { get; set; }
        public decimal EMP_Salary { get; set; }
    }
}
