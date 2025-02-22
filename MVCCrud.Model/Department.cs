using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Model
{
    public class Department
    {
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
        

    }
}
