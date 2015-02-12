using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroThermPatients.Models
{
    public class InMemoryRepository : EuroThermPatients.Models.IRepository
    {
        public List<Patient> GetPatients(Doctor doctor)
        {
            return GetList();
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            var list = GetList();
            list.Add(patient);
            SaveList(list);
        }

        private List<Patient> GetList()
        {
            var list = HttpContext.Current.Application["patients"] as List<Patient>;

            if (list == null)
            {
                list = new List<Patient>();
                list.Add(new Patient { BirthDate = DateTime.Now.AddDays(-1), Name = "Babe", Surname = "Ruth", Note = "" });
                list.Add(new Patient { BirthDate = DateTime.Now.AddYears(-30), Name = "Greg", Surname = "Peters", Note = "" });
                list.Add(new Patient { BirthDate = DateTime.Now.AddYears(-65), Name = "Sue", Surname = "Rutherford", Note = "See further action points" });
                HttpContext.Current.Application["patients"] = list;
            }

            return list;
        }

        private void SaveList(List<Patient> list)
        {
            HttpContext.Current.Application["patients"] = list;
        }
    }
}

