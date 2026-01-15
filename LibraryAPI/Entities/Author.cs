using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }

        // Relacja jeden do wielu (one-to-many) z `Book`
        public ICollection<Book> Books { get; set; }
    }
}
