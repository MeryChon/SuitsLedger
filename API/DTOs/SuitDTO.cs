using System;
using System.ComponentModel.DataAnnotations;
using Core;

namespace API.DTOs
{
    public class SuitDTO
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? ActionStartDate { get; set; }

        public int LimitationPeriod { get; set; }

        [Required]
        public SuitStatus Status { get; set; }

        [Required]
        public int AuthorizedPersonId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}