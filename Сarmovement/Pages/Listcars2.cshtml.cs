using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Сarmovement.Data;

namespace Сarmovement.Pages
{
    public class Listcars2Model : PageModel
    {
        private readonly Сarmovement.Data.ApplicationDbContext _context;

        public Listcars2Model(Сarmovement.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars.ToListAsync();

        }
    }
}
