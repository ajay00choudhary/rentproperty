using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rentproperty.Data;
using rentproperty.business;

namespace rentproperty.Pages.user_info
{
    public class DetailsModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public DetailsModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public user_details user_details { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user_details = await _context.user_details.FirstOrDefaultAsync(m => m.user_id == id);

            if (user_details == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
