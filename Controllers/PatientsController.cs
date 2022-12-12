using LFIDentalClinic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace LFIDentalClinic.Controllers
{
    public class PatientsController : Controller
    {
        private DBContext dbContext = new DBContext();

        // GET: Patients/Login
        public ActionResult Login()
        {
            if (Session["isAuthenticated"] != null)
                return RedirectToAction("List");

            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (Session["isAuthenticated"] != null)
                return RedirectToAction("List");

            var query = from u in dbContext.Users
                        where u.Username == user.Username
                        && u.Password == user.Password
                        select u;

            var userFound = query.FirstOrDefault();

            if (userFound != null)
            {
                Session["isAuthenticated"] = true;
                return RedirectToAction("List");
            }

            ModelState.AddModelError(String.Empty, "Invalid username or password.");
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["isAuthenticated"] = null;
            return RedirectToAction("Login");
        }

        // GET: Patients
        public ActionResult List(string q)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patients = dbContext.Patients.ToList();
            if (string.IsNullOrEmpty(q))
            {
                return View(patients);
            }

            patients = patients.Where(patient => patient.FullName.ToLower().Contains(q.ToLower())).ToList();
            return View(patients);
        }

        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = dbContext.Patients.Find(id);
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = new Patient
            {
                FullName = "",
                Email = "",
                Gender = "",
                BirthDate = "",
                MaritalStatus = "",
                MobileNumber = "",
                TelephoneNumber = "",
                Palate = false,
                BadBreath = false,
                BleedingInMouth = false,
                GumsColorChange = false,
                LumpsInMouth = false,
                TeethColorChange = false,
                SensitiveTeeth = false,
                ClickingSound = false,
                PastDentalCareOrTreatments = "",
                HeartAilmentOrDisease = "",
                HospitalAdmission = "",
                SelfMedication = "",
                Allergies = "",
                Operation = "",
                TumorsOrGrowth = "",
                Diabetes = false,
                Sinusitis = false,
                BleedingGums = false,
                Hypertension = false,
                StomachDisease = false,
                BloodDisease = false,
                Headache = false,
                LiverDisease = false,
                Pregnant = "",
                Cold = false,
                Kidney = false,
                FamilyHistryOnAny = "",
            };

            return View(patient);
        }

        // POST: Patients/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add insert logic here
                dbContext.Patients.Add(patient);
                dbContext.SaveChanges();

                return RedirectToAction("List");
            }
            catch
            {
                return View(patient);
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = dbContext.Patients.Find(id);
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient patient)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add update logic here
                dbContext.Entry(patient).State = EntityState.Modified;
                dbContext.SaveChanges();

                return RedirectToAction("Details", new { Id = id });
            }
            catch
            {
                return View(patient);
            }
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = dbContext.Patients.Find(id);
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add delete logic here
                var patient = dbContext.Patients.Find(id);
                dbContext.Patients.Remove(patient);
                dbContext.SaveChanges();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Treatments(int id)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = dbContext.Patients.Find(id);
            var dentalTreatments = patient.DentalTreatments.ToList();

            return View(dentalTreatments);
        }

        public ActionResult CreateTreatment(int id)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var dentalTreatment = new DentalTreatment
            {
                PatientId = id
            };

            return View(dentalTreatment);
        }

        [HttpPost]
        public ActionResult CreateTreatment(int id, DentalTreatment dentalTreatment)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add insert logic here
                var patient = dbContext.Patients.Find(id);
                patient.DentalTreatments.Add(dentalTreatment);
                dbContext.SaveChanges();

                return RedirectToAction("Treatments", new { id = id });
            }
            catch
            {
                return View(dentalTreatment);
            }
        }

        public ActionResult DeleteTreatment(int id, int treatmentId)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var patient = dbContext.Patients.Find(id);
            var dentalTreatment = dbContext.DentalTreatments.Find(treatmentId);
            patient.DentalTreatments.Remove(dentalTreatment);
            return View(dentalTreatment);
        }

        [HttpPost]
        public ActionResult DeleteTreatment(int id, int treatmentId, FormCollection collection)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add delete logic here
                var dentalTreatment = dbContext.DentalTreatments.Find(treatmentId);
                dbContext.DentalTreatments.Remove(dentalTreatment);
                dbContext.SaveChanges();

                return RedirectToAction("Treatments", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditTreatment(int id, int treatmentId)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var dentalTreatment = dbContext.DentalTreatments.Find(treatmentId);
            return View(dentalTreatment);
        }

        [HttpPost]
        public ActionResult EditTreatment(int id, int treatmentId, DentalTreatment dentalTreatment)
        {
            dentalTreatment.Id = treatmentId;
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            try
            {
                // TODO: Add update logic here
                dbContext.Entry(dentalTreatment).State = EntityState.Modified;
                dbContext.SaveChanges();

                return RedirectToAction("ViewTreatment", new { id = id, treatmentId = treatmentId });
            }
            catch
            {
                return View(dentalTreatment);
            }
        }

        public ActionResult ViewTreatment(int id, int treatmentId)
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("Login");

            var dentalTreatment = dbContext.DentalTreatments.Find(treatmentId);
            return View(dentalTreatment);
        }
    }
}
