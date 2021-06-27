using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Base;
using System.Text.Json.Serialization;


namespace Core.Entities
{
    public class Suit : Entity
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? ActionStartDate { get; set; }

        [Column("LimitationPeriod")]
        public int LimitationPeriod { get; set; }  // TODO: is this number of days or a date?

        public SuitStatus Status { get; set; }

        public int AuthorizedPersonId { get; set; }

        [JsonIgnore]
        public AuthorizedPerson AuthorizedPerson { get; set; }
    }
}