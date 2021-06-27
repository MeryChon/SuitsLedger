using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class AuthorizedPerson : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        public string City { get; set; }
        public string Phone { get; set; } // comma-separated
        public PersonType Type { get; set; }
        
        public ICollection<Suit> Suits {get; set;}
    }
}