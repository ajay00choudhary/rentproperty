using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rentproperty.business;

namespace rentproperty.Data
{
    public class rentpropertyContext_DB : DbContext
    {
        public rentpropertyContext_DB (DbContextOptions<rentpropertyContext_DB> options)
            : base(options)
        {
        }

        public DbSet<rentproperty.business.user_details> user_details { get; set; }

        public DbSet<rentproperty.business.inquiry> inquiry { get; set; }

        public DbSet<rentproperty.business.wishlist> wishlist { get; set; }

        public DbSet<rentproperty.business.property_details> property_details { get; set; }
    }
}
