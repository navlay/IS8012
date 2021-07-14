using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homes365.Data;
using Homes365.Models;

namespace Homes365.Pages.Housings
{
    public class EditModel : PageModel
    {
        private readonly Homes365.Data.Homes365Context _context;

        public EditModel(Homes365.Data.Homes365Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Housing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingExists(Housing.Id))
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

        private bool HousingExists(int id)
        {
            return _context.Housing.Any(e => e.Id == id);
        }
    }
}
