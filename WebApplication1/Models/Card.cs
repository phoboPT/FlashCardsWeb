using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Table("Card", Schema = "public")]
    public class Card
    {
        [Key] public int key { get; set; }
        public int deck { get; set; }
        public string question { get; set; }
        public string questionImage { get; set; }
        public string answer { get; set; }
        public string answerImage { get; set; }
        public string commentary { get; set; }
        public int activated { get; set; }
    }
}