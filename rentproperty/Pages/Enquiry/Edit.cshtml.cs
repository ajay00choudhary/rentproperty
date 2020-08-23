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

namespace rentproperty.Pages.Enquiry
{
    public class EditModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public EditModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        [BindProperty]
        public inquiry inquiry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            inquiry = await _context.inquiry.FirstOrDefaultAsync(m => m.inquiry_id == id);

            if (inquiry == null)
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

            _context.Attach(inquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inquiryExists(inquiry.inquiry_id))
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

        private bool inquiryExists(int id)
        {
            return _context.inquiry.Any(e => e.inquiry_id == id);
        }
    }
}
