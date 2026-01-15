using System.ComponentModel.DataAnnotations;
using System;

namespace LibraryAPI.Entities
{
    public class Borrowing
    {
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }
    }
}
