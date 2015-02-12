using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EuroThermPatients.Models;

namespace EuroThermPatients.ViewModels
{
    public class PatientListViewModel
    {
        public List<Patient> Patients { get; set; }
        public Doctor Doctor { get; set; }
    }
}