using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Relacja wiele do wielu (many-to-many) z `Book`
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
