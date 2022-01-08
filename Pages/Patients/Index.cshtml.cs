using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatia_2.Data;
using Aplicatia_2.Models;

namespace Aplicatia_2.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public IndexModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }
        public PatientData PatientD { get; set; }
        public int PatientID { get; set; }
        public int TreatmentID { get; set; }
        public async Task OnGetAsync(int? id, int? treatmentID)
        {
            PatientD = new PatientData();

            PatientD.Patients = await _context.Patient
            .Include(p => p.Doctor)
            .Include(p => p.PatientTreatments)
            .ThenInclude(p => p.Treatment)
            .AsNoTracking()
            .OrderBy(p => p.PatientFirstName)
            .ToListAsync();
            if (id != null)
            {
                PatientID = id.Value;
                Patient patient = PatientD.Patients
                .Where(i => i.PatientID == id.Value).Single();
                PatientD.Treatments = patient.PatientTreatments.Select(s => s.Treatment);
            }
        }


    }
}
