namespace BooksLibrary
{
    public class StaticDetails
    {
        public static string BooksApiBase { get; set; }

        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
