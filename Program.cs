using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Inlämning_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            {

                string DataJSONfilePath = "LibraryData.json";
                string AllDataAsJSONType = File.ReadAllText(DataJSONfilePath);

                MyDataBase myDataBase = JsonSerializer.Deserialize<MyDataBase>(AllDataAsJSONType)!;

                Library library = new Library();
                library.Books = myDataBase.AllBooksFromDB;
                library.Authors = myDataBase.AllAuthorsFromDB;


                bool keepRunning = true;

                while (keepRunning)
                {
                    Console.WriteLine("Welcome to Dorsas Library!");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("Press 1 to add new book.");
                    Console.WriteLine("Press 2 to add a new author.");
                    Console.WriteLine("Press 3 to update book details.");
                    Console.WriteLine("Press 4 to update author details.");
                    Console.WriteLine("Press 5 to delete book.");
                    Console.WriteLine("Press 6 to delete author.");
                    Console.WriteLine("Press 7 to rate a book");
                    Console.WriteLine("Press 8 to search and filter books");
                    Console.WriteLine("Press 9 to sort books");
                    Console.WriteLine("Press 10 to list all books and authors");
                    Console.WriteLine("Press 11 to save data & exit!");
                    
                    string userChoice = Console.ReadLine()!;
                    switch (userChoice)
                    {
                        case "1":
                            library.AddNewBook();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "2":
                            library.AddNewAuthor();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "3":
                            library.UpdateBookDetails();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "4":
                            library.UpdateAuthorDetails();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "5":
                            library.RemoveBook();
                            library.Pausa();
                            break;

                        case "6":
                            library.RemoveAuthor();
                            library.Pausa();
                            break;

                        case "7":
                            library.AddRatingToBook();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "8":
                            Console.WriteLine("Choose filter:");
                            Console.WriteLine("Press (1) to filter books by genre.");
                            Console.WriteLine("Press (2) to filter books by author.");
                            Console.WriteLine("Press (3) to filter books by year of publication.");
                            string filterChoice = Console.ReadLine()!;

                            switch (filterChoice)
                            {
                                case "1":
                                    library.FilterBooksByGenre();
                                    break;
                                case "2":
                                    library.FilterBooksByAuthor();
                                    break;
                                case "3":
                                    library.FilterBooksByPublicationYear();
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                                    library.SaveData(DataJSONfilePath, myDataBase);
                                    break;

                            }
                            library.Pausa();
                            break;

                        case "9":
                            Console.WriteLine("Sort by:");
                            Console.WriteLine("Press (1) to sort books by publication year.");
                            Console.WriteLine("Press (2) to sort books by title.");
                            string sortChoice = Console.ReadLine()!;

                            switch (sortChoice)
                            {
                                case "1":
                                    library.FilterBooksByPublicationYear();
                                    break;
                                case "2":
                                    library.SortBooksByTitle();
                                    library.SaveData(DataJSONfilePath, myDataBase);
                                    break;
                            }
                            library.Pausa();
                            break;

                        case "10":
                            library.ListOutAllBooksAndAuthors();
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;
                        

                        case "11":
                            library.SaveData(DataJSONfilePath, myDataBase);
                            Console.WriteLine("Data saved, program closes");
                            keepRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }        
            }
        }
    }
}


















                    //    {
                    //        
                    //    }

                    //}
                    ////Filtrera böckerna enligt genre
                    //var genres = allBooks.Select(book => book.Genre).Distinct();

                    //foreach (var genre in genres)
                    //{
                    //    var booksByGenre = allBooks.Where(book => book.Genre == genre).ToList();
                    //    Console.WriteLine($"Genre: {genre}");
                    //    foreach (var book in booksByGenre)
                    //    {
                    //        Console.WriteLine($" - {book.Title} by {book.Author}");
                    //    }
                    //}
                    ////Filtrera böckerna enligt författare
                    //var authors = allBooks.Select(book => book.Author).Distinct();

                    //foreach (var author in authors)
                    //{
                    //    var booksByAuthor = allBooks.Where(book => book.Author == author).ToList();
                    //    Console.WriteLine($"Author: {author}");
                    //    foreach (var book in booksByAuthor)
                    //    {
                    //        Console.WriteLine(book.Title);
                    //    }
                    //}
                    ////Fiktrera böckerna enligt publiceringsår
                    //var years = allBooks.Select(book => book.YearOfPublication).Distinct();

                    //foreach (var year in years)
                    //{
                    //    var booksByYear = allBooks.Where(book => book.YearOfPublication == year).ToList();
                    //    Console.WriteLine($"Year: {year}");
                    //    foreach (var book in booksByYear)
                    //    {
                    //        Console.WriteLine($" - {book.Title} by {book.Author}");
                    //    }
                    //}
                    ////Sortera böcker efter publiceringsår
                    //var booksSortedByYear = allBooks.OrderBy(book => book.YearOfPublication).ToList();

                    //Console.WriteLine("Books sorted by publication year:");
                    //foreach (var book in booksSortedByYear)
                    //{
                    //    Console.WriteLine($"{book.YearOfPublication}: {book.Title} by {book.Author}");
                    //}
                    ////Sortera böcker efter titel
                    //var booksSortedByTitle = allBooks.OrderBy(book => book.Title).ToList();

                    //Console.WriteLine("Books sorted by title:");
                    //foreach (var book in booksSortedByTitle)
                    //{
                    //    Console.WriteLine($"{book.Title} by {book.Author}");
                    //}

                    //// Hitta och ta bort bok
                    //int bookIdToDelete = 1; // Ange ID för den bok som ska tas bort
                    //Book bookToDelete = allBooks.FirstOrDefault(book => book.Id == bookIdToDelete)!;

                    //if (bookToDelete != null)
                    //{
                    //    allBooks.Remove(bookToDelete);
                    //    Console.WriteLine("Book removed successfully.");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Book not found.");
                    //}

                    //// Hitta och ta bort författaren
                    //int authorIdToDelete = 1; // Ange ID för den författare som ska tas bort
                    //Author authorToDelete = allAuthors.FirstOrDefault(author => author.Id == authorIdToDelete)!;

                    //if (authorToDelete != null)
                    //{
                    //    allAuthors.Remove(authorToDelete);
                    //    Console.WriteLine("Author removed successfully.");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Author not found.");
                    //}

                    ////Lägga till en bok

                    //allBooks.Add(new Book(10, "OOP", "Nemo", "Educational", 2023, 456));

                    //// Spara den uppdaterade listan tillbaka till JSON-filen
                    //myDataBase.AllBooksFromDB = allBooks;
                    //string updatedDataBase = JsonSerializer.Serialize(myDataBase, new JsonSerializerOptions { WriteIndented = true });
                    //File.WriteAllText(DataJSONfilePath, updatedDataBase);

                    ////Att lista alla böcker och författare.


                    //Console.WriteLine("\nAuthors:");
                    //foreach (var author in allAuthors)
                    //{
                    //    Console.WriteLine($"{author.Id}: {author.Name} ({author.Nationality})");
                    //}


    