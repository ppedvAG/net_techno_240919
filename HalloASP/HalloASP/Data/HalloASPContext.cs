using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HalloASP.Models
{
    public class HalloASPContext : DbContext
    {
        public HalloASPContext (DbContextOptions<HalloASPContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<HalloASP.Models.Pille> Pille { get; set; }
    }
}
