using Inventory.Service.Dtos;
using Inventory.Service.Entities;

namespace Inventory.Service
{
    public static class Extensions
    {
        public static InventoryItemDto AsDto(this InventoryItem item)
        {
            return new InventoryItemDto(item.CatalogItemId , item.Quantity , item.AcquiredDate);
        }
    }
}