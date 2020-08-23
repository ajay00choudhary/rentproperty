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
    public class IndexModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public IndexModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public IList<user_details> user_details { get;set; }

        public async Task OnGetAsync()
        {
            user_details = await _context.user_details.ToListAsync();
        }
    }
}
