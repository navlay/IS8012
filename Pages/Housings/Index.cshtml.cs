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
    public class IndexModel : PageModel
    {
        private readonly Homes365.Data.Homes365Context _context;

        public IndexModel(Homes365.Data.Homes365Context context)
        {
            _context = context;
        }

        public IList<Housing> Housing { get;set; }

        public async Task OnGetAsync()
        {
            Housing = await _context.Housing.ToListAsync();
        }
    }
}
