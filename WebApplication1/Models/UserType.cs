using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("UserType",Schema = "public")]
    public class UserType
    {
        [Key]
        public int key { get; set; }
        public string name {get; set; }
    }
}