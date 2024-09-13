namespace MinimalAPI_Labb1.Models.DTOs
{
    public class BooksUpdateDTO
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
