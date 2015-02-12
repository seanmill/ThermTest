using System;
namespace EuroThermPatients.Models
{
    public interface IRepository
    {
        void AddPatient(Doctor doctor, Patient patient);
        System.Collections.Generic.List<Patient> GetPatients(Doctor doctor);
    }
}
