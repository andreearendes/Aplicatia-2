using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatia_2.Data;
using Aplicatia_2.Models;

namespace Aplicatia_2.Pages.Treatments
{
    public class DeleteModel : PageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public DeleteModel(Aplicatia_2.Data.Aplicatia_2Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Treatment = await _context.Treatment.FindAsync(id);

            if (Treatment != null)
            {
                _context.Treatment.Remove(Treatment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
