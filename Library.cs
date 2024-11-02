using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Inlämning_3
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Author> Authors { get; set; } = new List<Author>();

        // Lägg till en ny bok
        public void AddNewBook()
        {
            
            Console.WriteLine("Please enter book´s information...");
            Console.Write("Enter book ID: ");
            int bookToAddNewID = int.Parse(Console.ReadLine()!); 
            Console.Write("Enter book´s title: ");
            string bookToAddNewTitle = Console.ReadLine()!;
            Console.Write("Enter book´s author: ");
            string bookToAddNewAuthor = Console.ReadLine()!;
            Console.Write("Enter book´s genre: ");
            string bookToAddNewGenre = Console.ReadLine()!;
            Console.Write("Enter book´s year of publication: ");
            int bookToAddNewYear = int.Parse(Console.ReadLine()!);
            Console.Write("Enter book´s ISBN: ");
            int bookToAddNewISBN = int.Parse(Console.ReadLine()!);
           

            Book newBok = new Book(bookToAddNewID, bookToAddNewTitle, bookToAddNewAuthor, bookToAddNewGenre, bookToAddNewISBN, bookToAddNewISBN);
            Books.Add(newBok);
            Console.WriteLine($"{bookToAddNewTitle} added to library´s books");
            Pausa();
        }

        // Lägg till en ny författare
        public void AddNewAuthor()
        {
            Console.WriteLine("Please enter author´s information...");
            Console.Write("Enter author´s ID: ");
            int authorToAddId = int.Parse(Console.ReadLine()!); authorToAddId++;
            Console.Write("Enter author´s name: ");
            string authorToAddName = Console.ReadLine()!;
            Console.Write("Enter author´s nationality: ");
            string authorToAddNationality = Console.ReadLine()!.ToLower();

            Author newAuthor = new Author(authorToAddId, authorToAddName, authorToAddNationality);
            Authors.Add(newAuthor);
            Console.WriteLine($"{authorToAddName} added to librarys´ authors");
            Pausa();
        }

        // Uppdatera bok
        public void UpdateBookDetails()
        {
            Console.Write("Enter the ID of the book you want to update: ");
            int bookIdToUpdate = int.Parse(Console.ReadLine()!);
            Book bookToUpdate = Books.FirstOrDefault(book => book.Id == bookIdToUpdate)!;
            if (bookToUpdate != null)
            {
                Console.Write("Enter new title: ");
                bookToUpdate.Title = Console.ReadLine()!;
                Console.Write("Enter new author: ");
                bookToUpdate.Author = Console.ReadLine()!;
                Console.Write("Enter new genre: ");
                bookToUpdate.Genre = Console.ReadLine()!;
                Console.Write("Enter new year of publication: ");
                bookToUpdate.YearOfPublication = int.Parse(Console.ReadLine()!);
                Console.Write("Enter new ISBN: ");
                bookToUpdate.ISBN = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Book details updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Uppdatera författare
        public void UpdateAuthorDetails()
        {
            Console.Write("Enter the ID of the author you want to update: ");
            if (int.TryParse(Console.ReadLine(), out int authorId))
            {
                var authorToUpdate = Authors.FirstOrDefault(author => author.Id == authorId);
                if (authorToUpdate != null)
                {
                    Console.Write("Enter new name: ");
                    authorToUpdate.Name = Console.ReadLine()!;
                    Console.Write("Enter new nationality: ");
                    authorToUpdate.Nationality = Console.ReadLine()!;
                    Console.WriteLine("Author details updated successfully.");
                }
                else
                {
                    Console.WriteLine("Author not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }


        // Hitta och ta bort bok
        public void DeleteBook()
        {
            int bookIdToDelete = 1;
            Book bookToDelete = Books.FirstOrDefault(book => book.Id == bookIdToDelete)!;
            if (bookToDelete != null)
            {
                Books.Remove(bookToDelete);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Hitta och ta bort författare
        public void DeleteAuthor()
        {
            int authorIdToDelete = 1;
            Author authorToDelete = Authors.FirstOrDefault(author => author.Id == authorIdToDelete)!;
            if (authorToDelete != null)
            {
                Authors.Remove(authorToDelete);
                Console.WriteLine("Author removed successfully.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        // Lista ut alla böcker och författare
        public void ListOutAllBooksAndAuthors()
        {
            Console.WriteLine("\nBooks:");
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} ({book.Genre}, {book.YearOfPublication}) ISBN: {book.ISBN}");
            }

            Console.WriteLine("\nAuthors:");
            foreach (var author in Authors)
            {
                Console.WriteLine($"{author.Id}: {author.Name} ({author.Nationality})");
            }
        }
        //Filtrera böcker
        public void FilterBooksByGenre()
        {
            var genres = Books.Select(book => book.Genre).Distinct();
            foreach (var genre in genres)
            {
                var booksByGenre = Books.Where(book => book.Genre == genre).ToList();
                Console.WriteLine($"Genre: {genre}");
                foreach (var book in booksByGenre)
                {
                    Console.WriteLine($" - {book.Title} by {book.Author}");
                }
            }
        }
        //Filtrera böcker enligt författare
        public void FilterBooksByAuthor()
        {
            var authors = Books.Select(book => book.Author).Distinct();
            foreach (var author in authors)
            {
                var booksByAuthor = Books.Where(book => book.Author == author).ToList();
                Console.WriteLine($"Author: {author}");
                foreach (var book in booksByAuthor)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
        //Filtrera böcker enligt publiceringsår
        public void FilterBooksByPublicationYear()
        {
            var years = Books.Select(book => book.YearOfPublication).Distinct();
            foreach (var year in years)
            {
                var booksByYear = Books.Where(book => book.YearOfPublication == year).ToList();
                Console.WriteLine($"Year: {year}");
                foreach (var book in booksByYear)
                {
                    Console.WriteLine($" - {book.Title} by {book.Author}");
                }
            }
        }
        //Sortera böcker efter publiceringsår
        public void SortBooksByPublicationYear()
        {
            var booksSortedByYear = Books.OrderBy(book => book.YearOfPublication).ToList();
            Console.WriteLine("Books sorted by publication year:");
            foreach (var book in booksSortedByYear)
            {
                Console.WriteLine($"{book.YearOfPublication}: {book.Title} by {book.Author}");
            }
        }
        //Sortera böcker efter title
        public void SortBooksByTitle()
        {
            var booksSortedByTitle = Books.OrderBy(book => book.Title).ToList();
            Console.WriteLine("Books sorted by title:");
            foreach (var book in booksSortedByTitle)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }

        //Recension


        //spara data
        public void SaveData(string dataJSONfilPath, MyDataBase myDataBase)
        {
            string updatedDataBase = JsonSerializer.Serialize(myDataBase, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(dataJSONfilPath, updatedDataBase);
        }
        
        public void Pausa()
        {
            Console.WriteLine("Press any key for MENU");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
