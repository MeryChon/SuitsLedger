using Core.Entities;

namespace API.DTOs
{
    public class AuthorizedPersonToReturnDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string IdentificationNumber { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public PersonType Type { get; set; }

    }
}