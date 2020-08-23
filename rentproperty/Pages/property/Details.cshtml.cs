using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.property
{
    public class DetailsModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public DetailsModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public property_details property_details { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            property_details = await _context.property_details.FirstOrDefaultAsync(m => m.property_id == id);

            if (property_details == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
