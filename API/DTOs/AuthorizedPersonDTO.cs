using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.DTOs
{
    public class AuthorizedPersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public PersonType Type { get; set; }
    }
}