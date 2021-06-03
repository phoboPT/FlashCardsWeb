using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("DeckDiscipline",Schema = "public")]
    public class DeckDiscipline
    {
        [Key]
        public int key { get; set; }
        public int deck {get; set; }
        public int discipline { get; set; }
    }
}