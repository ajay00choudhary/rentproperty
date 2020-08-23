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
    public class IndexModel : PageModel
    {
        private readonly rentproperty.Data.rentpropertyContext_DB _context;

        public IndexModel(rentproperty.Data.rentpropertyContext_DB context)
        {
            _context = context;
        }

        public IList<wishlist> wishlist { get;set; }

        public async Task OnGetAsync()
        {
            wishlist = await _context.wishlist.ToListAsync();
        }
    }
}
