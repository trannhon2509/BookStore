﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly BookStore.Data.ApplicationDbContext _context;

        public DetailsModel(BookStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Models.OrderDetails OrderDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderdetails = await _context.OrderDetails.FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetails = orderdetails;
            }
            return Page();
        }
    }
}
