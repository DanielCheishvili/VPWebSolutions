using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data
{
    public class PizzaBrosContext : DbContext
    {
        public PizzaBrosContext(DbContextOptions<PizzaBrosContext> options)
            : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
