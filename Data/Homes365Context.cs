using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Homes365.Models;

namespace Homes365.Data
{
    public class Homes365Context : DbContext
    {
        public Homes365Context (DbContextOptions<Homes365Context> options)
            : base(options)
        {
        }

        public DbSet<Homes365.Models.Housing> Housing { get; set; }
    }
}
