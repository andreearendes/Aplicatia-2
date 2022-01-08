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
    public class IndexModel : PageModel
    {
        private readonly Aplicatia_2.Data.Aplicatia_2Context _context;

        public IndexModel(Aplicatia_2.Data.Aplicatia_2Context context)
        {
            _context = context;
        }

        public IList<Treatment> Treatment { get;set; }

        public async Task OnGetAsync()
        {
            Treatment = await _context.Treatment.ToListAsync();
        }
    }
}
