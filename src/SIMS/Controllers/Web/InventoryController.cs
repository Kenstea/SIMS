using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SIMS.Models;
using Microsoft.AspNet.Authorization;

namespace SIMS.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private ISimsRepository _repository;

        public InventoryController(ISimsRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult InventoryManagment()
        {
            var items = _repository.GetAllItems();

            return View(items);
        }
    }
}
