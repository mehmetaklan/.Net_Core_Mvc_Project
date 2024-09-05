using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Departman_Management.Models
{
    public class Department
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
