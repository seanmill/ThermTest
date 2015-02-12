using System.Collections.Generic;

namespace EuroThermPatients.Models
{
    public class ValidatingDuplicateRepository : IRepository
    {
        private PatientComparar comparer;
        private IRepository repository;

        public ValidatingDuplicateRepository(PatientComparar comparer, IRepository repository)
        {
            this.comparer = comparer;
            this.repository = repository;
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            var registeredPatients = GetPatients(doctor);

            if (comparer.PatientIsRegisteredAlready(registeredPatients, patient))
            {
                throw new PatientAlreadyAddedException();
            }
            else
            {
                repository.AddPatient(doctor, patient);
            }
        }

        public List<Patient> GetPatients(Doctor doctor)
        {
            return repository.GetPatients(doctor);
        }
    }
}