using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.Enquiry
{
    public class DeleteModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public DeleteModel(rentproperty.Data.rentpropertyContext_DB context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            inquiry = await _context.inquiry.FindAsync(id);

            if (inquiry != null)
            {
                _context.inquiry.Remove(inquiry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
