using EuroThermPatients.Models;
using EuroThermPatients.ViewModels;
using System.Web.Mvc;
using System.Linq;

namespace EuroThermPatients.Controllers
{
    public class PatientListController : Controller
    {
        IRepository patientRepository;
        Doctor doctor;

        public PatientListController()
        {
            patientRepository = new ValidatingDuplicateRepository(new PatientComparar(), new InMemoryRepository());
            doctor = new Doctor { Name = "Dr Jones" };
        }

        public ActionResult Index()
        {
            var model = new PatientListViewModel
            {
                Doctor = doctor,
                Patients = patientRepository.GetPatients(doctor).OrderBy(x => x.Surname).ToList()
            };
            return View(model);
        }

        public ActionResult AddPatient()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            var success = false;

            if (ModelState.IsValid)
            {
                try
                {
                    patientRepository.AddPatient(doctor, patient);
                    success = true;
                }
                catch (PatientAlreadyAddedException ex)
                {
                    ModelState.AddModelError("", "Patient Already Exists");
                }
            }

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}