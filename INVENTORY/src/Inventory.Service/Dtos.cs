using System;

namespace Inventory.Service.Dtos
{
    public record GrantItemsDto(Guid UserId , Guid CatalogItemId , int Quantity);

    public record InventoryItemDto(Guid CatalogItemDto ,int Quantity , DateTimeOffset AcquiredDate );
}
