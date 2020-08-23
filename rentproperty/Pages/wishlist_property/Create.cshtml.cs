﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.wishlist_property
{
    public class CreateModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public CreateModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public wishlist wishlist { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.wishlist.Add(wishlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
