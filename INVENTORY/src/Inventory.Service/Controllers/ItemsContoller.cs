using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Service.Clients;
using Inventory.Service.Dtos;
using Inventory.Service.Entities;
using Microservices.Common;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsContoller : ControllerBase
    {
        private readonly IRepository<InventoryItem> itemsRepository;

        private readonly CatalogClient catalogClient;

        public ItemsContoller(IRepository<InventoryItem> itemsRepository, CatalogClient catalogClient)
        {
            this.itemsRepository = itemsRepository;
            this.catalogClient = catalogClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }

            var catalogItems = await catalogClient.GetCatalogItemDtosAsync();
            var inventoryItemEntities = await itemsRepository.GetAllAsync(item => item.UserId == userId);
            var InventoryItemDtos = inventoryItemEntities.Select(inventoryItem => 
            {
                var catalogItem = catalogItems.Single(catalogItem => catalogItem.id == inventoryItem.CatalogItemId);
                return inventoryItem.AsDto(catalogItem.Name ,catalogItem.Description);
            });

            return Ok(InventoryItemDtos);

        }

        [HttpPost]
        public async Task<ActionResult> PostAsyn(GrantItemsDto grantItemsDto)
        {
            var inventoryItem = await itemsRepository.GetAsync(item => item.UserId == grantItemsDto.UserId && item.CatalogItemId == grantItemsDto.CatalogItemId);

            if(inventoryItem == null)
            {
                inventoryItem = new InventoryItem
                {
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    UserId = grantItemsDto.UserId,
                    Quantity = grantItemsDto.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                    
                };
                await itemsRepository.CreateAsync(inventoryItem);
            }
            else
            {
                inventoryItem.Quantity += grantItemsDto.Quantity;
                await itemsRepository.UpdateAsync(inventoryItem);

            }

            return Ok();
        }
        
    }
}