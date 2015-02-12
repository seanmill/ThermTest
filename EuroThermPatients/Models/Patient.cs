using System;
using System.ComponentModel.DataAnnotations;

namespace EuroThermPatients.Models
{
    public class Patient
    {
        string name, surname;

        [Required, MinLength(2)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                }
                name = value;
            }
        }

        [Required, MinLength(3)]
        public string Surname {
            get
            {
                return surname;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                }
                surname = value;
            }
        }

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