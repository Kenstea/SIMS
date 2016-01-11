using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using SIMS.Models;
using SIMS.ViewModels.Item;

namespace SIMS.Controllers.Api
{
    //[Authorize]
    public class InventoryApiController : Controller
    {
        private ILogger<InventoryApiController> _logger;
        private ISimsRepository _repository;

        public InventoryApiController(ISimsRepository repository, ILogger<InventoryApiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("api/items")]
        public JsonResult Get()
        {
            var items = _repository.GetAllItems();
            var results = Mapper.Map<IEnumerable<ReadInventoryViewModel>>(items);

            return Json(results);
        }

        [HttpPost("api/items")]
        public JsonResult Post([FromBody]AddInventoryViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_repository.InventoryContains(vm.Name))
                    {
                        var newItem = Mapper.Map<InventoryItem>(vm);
                        newItem.Atp = (newItem.Quantity + newItem.Actual) - newItem.Promised;


                        // Save to the Database
                        _logger.LogInformation("Attempting to save a new item");
                        _repository.AddItem(newItem);
                        if (_repository.SaveAll())
                        {
                            Response.StatusCode = (int)HttpStatusCode.Created;
                            return Json(Mapper.Map<ReadInventoryViewModel>(newItem));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new item", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpPut("api/items")]
        public JsonResult Put([FromBody]UpdateInventoryViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_repository.InventoryContains(vm.OldName))
                    {
                        var oldItemId = _repository.GetItemByName(vm.OldName).Id;

                        // Edit in the Database
                        _logger.LogInformation("Attempting to save a new item");
                        _repository.EditItem(oldItemId, vm.Name, vm.Quantity, vm.Endangered, vm.EndangeredQuantity, vm.Expected, vm.Actual, vm.Promised);
                        _repository.SetAllItemAtp();
                    }

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(_repository.GetItemByName(vm.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to edit item", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpPut("api/items/delete")]
        public JsonResult Put([FromBody]DeleteInventoryViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = _repository.GetItemByName(vm.Name).Id;



                    // Save to the Database
                    _logger.LogInformation("Attempting to delete the item");
                    _repository.RemoveItem(item);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json("Item Delete Succesfully");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete the item", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
