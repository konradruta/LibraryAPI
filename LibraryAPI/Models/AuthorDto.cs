using LibraryAPI.Entities;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public List<string> Books { get; set; }
    }
}
