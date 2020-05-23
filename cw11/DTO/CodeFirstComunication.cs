using cw11.ComunicationModels;
using cw11.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DTO
{
    public class CodeFirstComunication : IDatabaseComunication
    {
        DoctorsDbContext _dbc;
        public CodeFirstComunication(DoctorsDbContext dbc)
        {
            _dbc = dbc;
        }

        public void AddDoctor(AddDoctor dr)
        {
            _dbc.Doctors.Add(new Doctor
            {
                Email = dr.Email,
                FirstName = dr.FirstName,
                LastName = dr.LastName,
                //IdDoctor = 1
            });
            _dbc.SaveChanges();

        }

        public void DatabaseExampleData()
        {

            _dbc.Doctors.Add(new Doctor
            {
                Email = "0d@pjatk.edu.pl",
                FirstName = "Maciejewski",
                LastName = "Maciej",
                //IdDoctor = 1
            });

            _dbc.Doctors.Add(new Doctor
            {
                Email = "1d@pjatk.edu.pl",
                FirstName = "Wojtkowski",
                LastName = "Wojtek",
                //IdDoctor = 2

            });

            _dbc.Doctors.Add(new Doctor
            {
                Email = "2d@pjatk.edu.pl",
                FirstName = "Ryszardowski",
                LastName = "Ryszard",
                //IdDoctor = 3

            });

            _dbc.Patient.Add(new Patient
            {
                //IdPatient = 1,
                Birthday = DateTime.Now,//nie chce mi się wymyślać dat
                FirstName="Kajetan",
                LastName="Kajatanowicz"
            }) ;

            _dbc.Patient.Add(new Patient
            {
                //IdPatient = 2,
                Birthday = DateTime.Now,
                FirstName = "michal",
                LastName = "michalowicz"
            });
            _dbc.SaveChanges();
            int D = _dbc.Doctors.Min(e => e.IdDoctor);
            int P = _dbc.Patient.Min(e => e.IdPatient);
            int P2 = _dbc.Patient.Where(e=>e.IdPatient!=P).Min(e => e.IdPatient);
            _dbc.Prescription.Add(new Prescription
            {
                IdPatient = P,
                IdDoctor = D,
                //IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
            });

            _dbc.Prescription.Add(new Prescription
            {
                IdPatient = P2,
                IdDoctor = D,
                //IdPrescription = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now,
            });

            _dbc.Medicament.Add(new Medicament
            {
                //IdMedicament = 1,
                Name="APAP",
                Descryprion="Bardzo niebezpieczny lek",
                Type="TRUCIZNA!!!"
            }) ;
            _dbc.Medicament.Add(new Medicament
            {
                //IdMedicament = 2,
                Name = "Ibuprofen",
                Descryprion = "Leczy raka",
                Type = "Ambrozja"
            });
            _dbc.SaveChanges();
            int Pre = _dbc.Prescription.Min(e => e.IdPrescription);
            int Pre2 = _dbc.Prescription.Where(e => e.IdPrescription != Pre).Min(e => e.IdPrescription);
            int Med = _dbc.Medicament.Min(e => e.IdMedicament);
            int Med2 = _dbc.Medicament.Where(e => e.IdMedicament != Med).Min(e => e.IdMedicament);

            _dbc.Prescription_Medicament.Add(new Prescription_Medicament
            {
                Details = "ZABIĆ",
                Dose = 9999,
                IdMedicament = Med,
                IdPrescription = Pre,
                
            });

            _dbc.Prescription_Medicament.Add(new Prescription_Medicament
            {
                Details = "ZABIĆ",
                Dose = 9999,
                IdMedicament = Med,
                IdPrescription = Pre2,

            });

            _dbc.Prescription_Medicament.Add(new Prescription_Medicament
            {
                Details = "Ale wyleczyć z raka",
                Dose = 3,
                IdMedicament = Med2,
                IdPrescription = Pre2,

            });
            _dbc.SaveChanges();

            //throw new NotImplementedException();
        }

        public void DeleteDoctor(int dr)
        {
            
            var rem = _dbc.Doctors.Where(e => e.IdDoctor == dr).First();

            _dbc.Remove(rem);

            _dbc.SaveChanges();

        }

        public object GetDoctors()
        {
            return _dbc.Doctors.ToList();
        }

        public void ModDoctor(ModyfyDoctor dr)
        {

            var doc = _dbc.Doctors.Where(e => e.IdDoctor == dr.IdDoctor).First();

            doc.FirstName = dr.FirstName != null ? dr.FirstName : doc.FirstName;
            doc.Email = dr.Email != null ? dr.Email : doc.Email;
            doc.LastName = dr.LastName != null ? dr.LastName : doc.LastName;
            _dbc.SaveChanges();


        }
    }
}
