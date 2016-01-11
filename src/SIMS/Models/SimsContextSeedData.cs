using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class SimsContextSeedData
    {
        private SimsDbContext _context;

        public SimsContextSeedData(SimsDbContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Items.Any())
            {
                var itemOne = new InventoryItem()
                {
                    Name = "HDMI Cable",
                    Quantity = 200,
                    EndangeredQuantity = 45,
                    Expected = 250,
                    Actual = 250,
                    Promised = 150,
                    Endangered = false
                };

                _context.Add(itemOne);

                var itemTwo = new InventoryItem()
                {
                    Name = "Mouse",
                    Quantity = 250,
                    EndangeredQuantity = 45,
                    Expected = 150,
                    Actual = 150,
                    Promised = 200,
                    Endangered = false
                };

                _context.Add(itemTwo);

                var itemThree = new InventoryItem()
                {
                    Name = "Universal Laptop Charger",
                    Quantity = 300,
                    EndangeredQuantity = 45,
                    Expected = 200,
                    Actual = 200,
                    Promised = 400,
                    Endangered = false
                };

                _context.Add(itemThree);

                var itemFour = new InventoryItem()
                {
                    Name = "Chainsaw",
                    Quantity = 200,
                    EndangeredQuantity = 85,
                    Expected = 125,
                    Actual = 125,
                    Promised = 185,
                    Endangered = false
                };

                _context.Add(itemFour);

                var itemFive = new InventoryItem()
                {
                    Name = "Headphones",
                    Quantity = 200,
                    EndangeredQuantity = 65,
                    Expected = 175,
                    Actual = 175,
                    Promised = 200,
                    Endangered = false
                };

                _context.Add(itemFive);

                _context.SaveChanges();
            }
        }
    }
}
