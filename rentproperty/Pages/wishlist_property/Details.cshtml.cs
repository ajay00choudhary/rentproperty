using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.wishlist_property
{
    public class DetailsModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public DetailsModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public wishlist wishlist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            wishlist = await _context.wishlist.FirstOrDefaultAsync(m => m.wishlist_id == id);

            if (wishlist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
