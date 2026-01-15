using LibraryAPI.Entities;
using System;

namespace LibraryAPI.Models
{
    public class UpdateBorrowingDto
    {
        public int BookId { get; set; }
        public Book book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}