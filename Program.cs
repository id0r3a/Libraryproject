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
                    Console.WriteLine("..........................");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("Press 1 to add new book");
                    Console.WriteLine("Press 2 to add a new author");
                    Console.WriteLine("Press 3 to update book details");
                    Console.WriteLine("Press 4 to update author details");
                    Console.WriteLine("Press 5 to delete book");
                    Console.WriteLine("Press 6 to delete author");
                    Console.WriteLine("Press 7 to rate a book");
                    Console.WriteLine("Press 8 to search and filter books");
                    Console.WriteLine("Press 9 to sort books");
                    Console.WriteLine("Press 10 to list all books and authors");
                    Console.WriteLine("Press 11 to close the program!");
                    
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
                            library.SaveData(DataJSONfilePath, myDataBase);
                            library.Pausa();
                            break;

                        case "6":
                            library.RemoveAuthor();
                            library.SaveData(DataJSONfilePath, myDataBase);
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
                            Console.WriteLine("Program closes");
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