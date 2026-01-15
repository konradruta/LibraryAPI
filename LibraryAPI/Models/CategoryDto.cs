using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Books { get; set; }
    }
}
