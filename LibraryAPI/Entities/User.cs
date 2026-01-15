using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        // Relacja jeden do wielu (one-to-many) z `Borrowing`
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
