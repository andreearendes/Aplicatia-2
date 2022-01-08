using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplicatia_2.Data;
using Aplicatia_2.Models;

namespace Aplicatia_2.Pages.Patients
{
    public class CreateModel : PatientTreatmentsPageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public CreateModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "DoctorID", "DoctorFirstName", "DoctorLastName");
            var patient = new Patient();
            patient.PatientTreatments = new List<PatientTreatment>();
            PopulateAssignedTreatmentData(_context, patient);
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedTreatments)
        {
            var newPatient = new Patient();
            if (selectedTreatments != null)
            {
                newPatient.PatientTreatments = new List<PatientTreatment>();
                foreach (var tre in selectedTreatments)
                {
                    var treToAdd = new PatientTreatment
                    {
                        TreatmentID = int.Parse(tre)
                    };
                    newPatient.PatientTreatments.Add(treToAdd);
                }
            }
            if (await TryUpdateModelAsync<Patient>(
            newPatient,
            "Patient",
            i => i.PatientFirstName, i => i.PatientLastName,
            i => i.Disease,  i => i.DoctorID))
            {
                _context.Patient.Add(newPatient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedTreatmentData(_context, newPatient);
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
       
    }
}
