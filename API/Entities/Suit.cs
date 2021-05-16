using System;

namespace API.Entities
{
    public class Suit
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ActionStartDate { get; set; }
        public int LimitationPerion { get; set; }  // TODO: is this number of days or a date?
        public string Status { get; set; } // TODO: make this an enum
        public AuthorizedPerson AuthorizedPerson { get; set; }
    }
}