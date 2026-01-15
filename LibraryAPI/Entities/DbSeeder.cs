using System.Collections.Generic;
using System;
using System.Linq;

namespace LibraryAPI.Entities
{
    public static class DbSeeder
    {
        public static void Seed(LibraryDbContext context)
        {
            // Upewnij się, że baza danych została utworzona
            context.Database.EnsureCreated();

            // Sprawdź, czy baza danych jest pusta
            if (!context.Books.Any())
            {
                // Dodaj autorów
                var authors = new List<Author>
            {
                new Author { Name = "George Orwell", Biography = "English novelist and essayist." },
                new Author { Name = "J.K. Rowling", Biography = "British author, best known for Harry Potter." }
            };

                context.Authors.AddRange(authors);
                context.SaveChanges();

                // Dodaj kategorie
                var categories = new List<Category>
            {
                new Category { Name = "Fiction", Description = "Fictional books" },
                new Category { Name = "Fantasy", Description = "Fantasy books" },
                new Category { Name = "Science Fiction", Description = "Sci-Fi books" }
            };

                context.Categories.AddRange(categories);
                context.SaveChanges();

                // Dodaj książki
                var books = new List<Book>
            {
                new Book
                {
                    Title = "1984",
                    AuthorId = authors[0].Id,
                    Description = "Dystopian social science fiction novel.",
                    IsBorrowed = false,
                    BookCategories = new List<BookCategory>
                    {
                        new BookCategory { CategoryId = categories[0].Id },
                        new BookCategory { CategoryId = categories[2].Id }
                    }
                },
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    AuthorId = authors[1].Id,
                    Description = "Fantasy novel about a young wizard.",
                    IsBorrowed = false,
                    BookCategories = new List<BookCategory>
                    {
                        new BookCategory { CategoryId = categories[1].Id }
                    }
                }
            };

                context.Books.AddRange(books);
                context.SaveChanges();

                // Dodaj użytkowników
                var users = new List<User>
            {
                new User { Name = "John Doe", Email = "john.doe@example.com" },
                new User { Name = "Jane Smith", Email = "jane.smith@example.com" }
            };

                context.Users.AddRange(users);
                context.SaveChanges();

                // Dodaj wypożyczenia
                var borrowings = new List<Borrowing>
            {
                new Borrowing
                {
                    BookId = books[0].Id,
                    UserId = users[0].Id,
                    BorrowedDate = DateTime.Now.AddDays(-10),
                    ReturnedDate = null // Jeszcze nie zwrócona
                },
                new Borrowing
                {
                    BookId = books[1].Id,
                    UserId = users[1].Id,
                    BorrowedDate = DateTime.Now.AddDays(-5),
                    ReturnedDate = DateTime.Now.AddDays(-1) // Zwrócona
                }
            };

                context.Borrowings.AddRange(borrowings);
                context.SaveChanges();
            }
        }
    }

}
