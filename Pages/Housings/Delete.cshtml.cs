using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Homes365.Data;
using Homes365.Models;

namespace Homes365.Pages.Housings
{
    public class DeleteModel : PageModel
    {
        private readonly Homes365.Data.Homes365Context _context;

        public DeleteModel(Homes365.Data.Homes365Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Housing Housing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Housing = await _context.Housing.FirstOrDefaultAsync(m => m.Id == id);

            if (Housing == null)
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

            Housing = await _context.Housing.FindAsync(id);

            if (Housing != null)
            {
                _context.Housing.Remove(Housing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
