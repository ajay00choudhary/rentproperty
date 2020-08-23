using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.wishlist_property
{
    public class EditModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public EditModel(rentproperty.Data.rentpropertyContext_DB context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wishlistExists(wishlist.wishlist_id))
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

        private bool wishlistExists(int id)
        {
            return _context.wishlist.Any(e => e.wishlist_id == id);
        }
    }
}
