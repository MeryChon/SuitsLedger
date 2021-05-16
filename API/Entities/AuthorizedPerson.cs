using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AuthorizedPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        public string City {get; set;}
        public string Phone { get; set; } // comma-separated
        public string Type {get; set;} // TODO: make an enum
    }
}