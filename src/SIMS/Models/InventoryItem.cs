using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int EndangeredQuantity { get; set; }
        public bool Endangered { get; set; }
        public int Expected { get; set; }
        public int Actual { get; set; }
        public int Atp { get; set; }
        public int Promised { get; set; }
    }
}
