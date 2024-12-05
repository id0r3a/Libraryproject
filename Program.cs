using System;
using System.IO;
using System.Text.Json;
using Spectre.Console;
using Figgle;

namespace Inlämning_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string dataJSONfilePath = "LibraryData.json";
            string allDataAsJSONType = File.ReadAllText(dataJSONfilePath);

            MyDataBase myDataBase = JsonSerializer.Deserialize<MyDataBase>(allDataAsJSONType)!;

            Library library = new Library
            {
                Books = myDataBase.AllBooksFromDB,
                Authors = myDataBase.AllAuthorsFromDB
            };

            bool keepRunning = true;

            // Skriv ut välkomstmeddelande med Figgle och Spectre.Console
            var title = FiggleFonts.Standard.Render("Dorsas Library");
            AnsiConsole.Markup("[bold yellow]" + title + "[/]");

            while (keepRunning)
            {
                AnsiConsole.Markup("[bold cyan]Please choose an option:[/]\n");
                var userChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .AddChoices("Add new book", "Add new author", "Update book details", "Update author details",
                                    "Delete book", "Delete author", "Rate a book", "Search and filter books",
                                    "Sort books", "List all books and authors", "Close the program")
                );

                switch (userChoice)
                {
                    case "Add new book":
                        library.AddNewBook();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Add new author":
                        library.AddNewAuthor();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Update book details":
                        library.UpdateBookDetails();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Update author details":
                        library.UpdateAuthorDetails();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Delete book":
                        library.RemoveBook();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Delete author":
                        library.RemoveAuthor();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Rate a book":
                        library.AddRatingToBook();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Search and filter books":
                        var filterChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("[cyan]Choose filter:[/]")
                                .AddChoices("Filter by genre", "Filter by author", "Filter by year of publication")
                        );

                        switch (filterChoice)
                        {
                            case "Filter by genre":
                                library.FilterBooksByGenre();
                                break;
                            case "Filter by author":
                                library.FilterBooksByAuthor();
                                break;
                            case "Filter by year of publication":
                                library.FilterBooksByPublicationYear();
                                break;
                            default:
                                AnsiConsole.Markup("[red]Invalid choice. Please enter a number between 1 and 3.[/]\n");
                                break;
                        }
                        ConsoleHelper.Pause();
                        break;

                    case "Sort books":
                        var sortChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("[cyan]Sort by:[/]")
                                .AddChoices("Sort by publication year", "Sort by title")
                        );

                        switch (sortChoice)
                        {
                            case "Sort by publication year":
                                library.SortBooksByPublicationYear();
                                break;
                            case "Sort by title":
                                library.SortBooksByTitle();
                                break;
                        }
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "List all books and authors":
                        library.ListAllBooks();
                        library.ListAllAuthors();
                        library.SaveData(dataJSONfilePath, myDataBase);
                        ConsoleHelper.Pause();
                        break;

                    case "Close the program":
                        AnsiConsole.Markup("[bold red]Program closes[/]\n");
                        keepRunning = false;
                        break;

                    default:
                        AnsiConsole.Markup("[red]Invalid choice, please try again.[/]\n");
                        break;
                }
            }
        }
    }
}
