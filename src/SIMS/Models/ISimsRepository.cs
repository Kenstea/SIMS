using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Models
{
    public interface ISimsRepository
    {
        IEnumerable<InventoryItem> GetAllItems();
        IEnumerable<InventoryItem> GetAllEndangeredItems();
        bool InventoryContains(string itemName);
        void AddItem(InventoryItem newItem);
        bool SaveAll();
        InventoryItem GetItemByName(string itemName);
        void RemoveItem(int id);
        void SetAllItemAtp();
        void EditItem(int id, string itemName, int itemQuantity, bool itemEndangeredValue, int itemEndangeredQuantity, int itemExpected, int itemActual, int itemPromised);
    }
}

