using System.Data;
using System;

namespace LibraryAPI.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string PassowrdHash { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
