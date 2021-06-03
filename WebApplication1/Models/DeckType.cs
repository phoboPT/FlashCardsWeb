using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("DeckType",Schema = "public")]
    public class DeckType
    {
        [Key]
        public int key { get; set; }
        public string name {get; set; }
    }
}