using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> BorrowedBooks { get; set; }
    }
}
