using System;
using System.Collections.Generic;

namespace EuroThermPatients.Models
{
    public class PatientComparar
    {
        public bool AreSame(Patient x, Patient y)
        {
            if (x.BirthDate.Date == y.BirthDate.Date)
            {
                if (string.Compare(x.Name,y.Name, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    if (string.Compare(x.Surname, y.Surname, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PatientIsRegisteredAlready(List<Patient> list, Patient newPatient)
        {
            foreach (var registeredPatient in list)
            {
                if (AreSame(registeredPatient, newPatient))
                {
                    return true;
                }
            }
            return false;
        }
    }
}