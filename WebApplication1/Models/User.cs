using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("User", Schema = "public")]
    public class User
    {
        [Key] public int key { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }
}