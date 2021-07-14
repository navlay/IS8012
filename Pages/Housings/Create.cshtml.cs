using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Homes365.Data;
using Homes365.Models;

namespace Homes365.Pages.Housings
{
    public class CreateModel : PageModel
    {
        private readonly Homes365.Data.Homes365Context _context;

        public CreateModel(Homes365.Data.Homes365Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Housing Housing { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Housing.Add(Housing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
