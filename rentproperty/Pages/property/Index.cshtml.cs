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
    public class IndexModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public IndexModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public IList<property_details> property_details { get;set; }

        public async Task OnGetAsync()
        {
            property_details = await _context.property_details.ToListAsync();
        }
    }
}
