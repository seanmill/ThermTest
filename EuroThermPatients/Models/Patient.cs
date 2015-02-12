using System;
using System.ComponentModel.DataAnnotations;

namespace EuroThermPatients.Models
{
    public class Patient
    {
        [Required, MinLength(2)]
        public string Name { get; set; }

        [Required, MinLength(3)]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Note { get; set; }

        public string BirthDateDisplay
        {
            get
            {
                return BirthDate.ToString("d");
            }
        }

    }
}