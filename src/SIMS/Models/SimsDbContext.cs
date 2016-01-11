using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class SimsDbContext : DbContext
    {
        public SimsDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<InventoryItem> Items { get; set; }
    }
}
