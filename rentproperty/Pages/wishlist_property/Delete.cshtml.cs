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
    public class DeleteModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public DeleteModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            wishlist = await _context.wishlist.FindAsync(id);

            if (wishlist != null)
            {
                _context.wishlist.Remove(wishlist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
