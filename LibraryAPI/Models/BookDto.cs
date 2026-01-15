using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
