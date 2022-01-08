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

namespace Aplicatia_2.Pages.Treatments
{
    public class EditModel : PageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public EditModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Treatment Treatment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Treatment = await _context.Treatment.FirstOrDefaultAsync(m => m.TreatmentID == id);

            if (Treatment == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Treatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(Treatment.TreatmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatment.Any(e => e.TreatmentID == id);
        }
    }
}
