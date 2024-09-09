using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Departman_Management.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="Varchar(20)")]
        public string Username { get; set; }
        [Column(TypeName ="Varchar(10)")]
        public string Password { get; set; }
    }
}
