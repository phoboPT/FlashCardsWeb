using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Deck",Schema = "public")]
    public class Deck
    {
        [Key]
        public int key { get; set; }
        public string description { get; set; }
        public string name {get; set; }
        public int type { get; set; }
        public int userCreator { get; set; }
    }
}