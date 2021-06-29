using System;
using Core;

namespace API.DTOs
{
    public class SuitToReturnDTO
    {
        public string Description { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime ActionStartDate { get; set; }

        public int LimitationPeriod { get; set; }

        public SuitStatus Status { get; set; }

        public int AuthorizedPersonId { get; set; }

        public string AuthorizedPerson { get; set; }


    }
}