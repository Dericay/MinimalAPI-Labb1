using System.ComponentModel.DataAnnotations;

namespace MinimalAPI_Labb1.Models
{
    public class Books
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? Updated { get; set; }



    }
}
