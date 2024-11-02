namespace Inlämning_3
{
    public class Book
    {
        // Egenskaper för en bok
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int YearOfPublication { get; set; }
        public int ISBN { get; set; }
        public List<int> Reviews { get; set; } = new List<int>();

        // Konstruktor
        public Book(int id, string title, string author, string genre, int yearOfPublication, int isbn)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            YearOfPublication = yearOfPublication;
            ISBN = isbn;
            Reviews = new List<int>();
        }
        public double GetAverageRating()
        {
            if (Reviews.Count == 0)
            {
                return 0;
            }
            return Reviews.Average();
        }

    }
}
