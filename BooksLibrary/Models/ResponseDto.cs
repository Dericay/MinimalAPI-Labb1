namespace BooksLibrary.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }

        public Object Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessage { get; set; }
    }
}
