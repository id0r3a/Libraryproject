using System.Text.Json.Serialization;

namespace Inlämning_3
{
    public class MyDataBase
    {
        [JsonPropertyName("Books")]
        public List<Book> AllBooksFromDB { get; set; }

        [JsonPropertyName("Authors")]
        public List <Author> AllAuthorsFromDB { get; set; }

    }
}
