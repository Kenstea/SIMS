using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public class SimsRepository : ISimsRepository
    {
        private SimsDbContext _context;
        private ILogger<SimsRepository> _logger;

        public SimsRepository(SimsDbContext context, ILogger<SimsRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public void AddItem(InventoryItem newItem)
        {
            _context.Add(newItem);
        }

        public void EditItem(int id, string itemName, int itemQuantity, bool itemEndangeredValue, int itemEndangeredQuantity, int itemExpected, int itemActual, int itemPromised)
        {
            var oldItem = _context.Items.Where(i => i.Id == id).Single();
            if (oldItem != null)
            {
                oldItem.Name = itemName;
                oldItem.Quantity = itemQuantity;
                oldItem.Endangered = itemEndangeredValue;
                oldItem.EndangeredQuantity = itemEndangeredQuantity;
                oldItem.Expected = itemExpected;
                oldItem.Actual = itemActual;
                oldItem.Promised = itemPromised;
            }
        }



        public IEnumerable<InventoryItem> GetAllEndangeredItems()
        {
            try
            {
                return _context.Items.Where(i => i.Endangered == true).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("No endangered items found from database", ex);
                return null;
            }
        }

        public IEnumerable<InventoryItem> GetAllItems()
        {
            try
            {
                return _context.Items.OrderBy(i => i.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("No items found from database", ex);
                return null;
            }
        }

        public InventoryItem GetItemByName(string itemName)
        {
            try
            {
                return _context.Items
                           .Where(i => i.Name == itemName)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Item not found in database", ex);
                return null;
            }
        }

        public bool InventoryContains(string itemName)
        {
            var item = _context.Items.Where(i => i.Name == itemName).SingleOrDefault();
            if (item == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveItem(int itemId)
        {
            var item = _context.Items.Where(i => i.Id == itemId).Single();
            if (item != null)
            {
                _context.Items.Remove(item);
            }
        }


        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void SetAllItemAtp()
        {
            try
            {
                var items = _context.Items.OrderBy(i => i.Name).ToList();
                foreach (var item in items)
                {
                    item.Atp = (item.Quantity + item.Actual) - item.Promised;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("No items found from database", ex);
            }
        }
    }
}
