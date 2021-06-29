using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Base;

namespace Core.Entities
{
    public class AuthorizedPerson : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                if (this.Type == PersonType.PHYSICAL)
                {
                    return this.Name;
                }
                return this.FirstName + " " + this.LastName;
            }
        }

        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Phone { get; set; } // comma-separated

        public PersonType Type { get; set; }

        public ICollection<Suit> Suits { get; set; }
    }
}