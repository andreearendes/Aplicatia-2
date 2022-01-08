using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatia_2.Data;
using Aplicatia_2.Models;

namespace Aplicatia_2.Pages.Patients
{
    public class EditModel : PatientTreatmentsPageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public EditModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient = await _context.Patient
 .Include(p => p.Doctor)
 .Include(p => p.PatientTreatments).ThenInclude(p => p.Treatment)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.PatientID == id);

            //Patient = await _context.Patient.FirstOrDefaultAsync(m => m.PatientID == id);

            if (Patient == null)
            {
                return NotFound();
            }
            PopulateAssignedTreatmentData(_context, Patient);
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "DoctorID", "DoctorFirstName", "DoctorLastName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedTreatments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patientToUpdate = await _context.Patient
            .Include(i => i.Doctor)
            .Include(i => i.PatientTreatments)
            .ThenInclude(i => i.Treatment)
            .FirstOrDefaultAsync(s => s.PatientID == id);
            if (patientToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Patient>(
           patientToUpdate,
            "Patient",
            i => i.PatientFirstName, i => i.PatientLastName,
            i => i.Disease, i => i.Doctor))
            {
                UpdatePatientTreatments(_context, selectedTreatments, patientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePatientTreatments(_context, selectedTreatments, patientToUpdate);
            PopulateAssignedTreatmentData(_context, patientToUpdate);
            return Page();
        }
    }
}