using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public string Description { get; set; }

        // Relacja wiele do wielu (many-to-many) z `Category`
        public ICollection<BookCategory> BookCategories { get; set; }

        public bool IsBorrowed { get; set; }
    }
}
