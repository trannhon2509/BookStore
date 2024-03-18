using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Areas.Admin.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Data.ApplicationDbContext _context;

        public IndexModel(BookStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.OrderDetails> OrderDetails { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrderDetails != null)
            {
                OrderDetails = await _context.OrderDetails
                .Include(o => o.Book)
                .Include(o => o.Order).ToListAsync();
            }
        }
    }
}
