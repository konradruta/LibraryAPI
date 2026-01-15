using LibraryAPI.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        // Relacja jeden do wielu (one-to-many) z `Borrowing`
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
