using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatia_2.Data;
using Aplicatia_2.Models;

namespace Aplicatia_2.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public DetailsModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.DoctorID == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
