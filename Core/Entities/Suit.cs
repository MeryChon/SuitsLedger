using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Suit : Entity
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? ActionStartDate { get; set; }
        
        public int LimitationPerion { get; set; }  // TODO: is this number of days or a date?
        
        public SuitStatus Status { get; set; } // TODO: make this an enum

        public int AuthorizedPersonId { get; set; }
        
        public AuthorizedPerson AuthorizedPerson { get; set; }
    }
}