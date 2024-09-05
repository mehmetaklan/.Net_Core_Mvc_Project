using System.ComponentModel.DataAnnotations;

namespace Departman_Management.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public Department Department{ get; set; }

    }
}
