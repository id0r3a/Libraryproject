namespace Inlämning_3
{
    public class Author
    {
        // Attributer för författare
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        

        // Konstruktor
        public Author(int id, string name, string nationality)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
           
        }
    }
}
