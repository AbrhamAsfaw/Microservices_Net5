using System;

namespace Inventory.Service.Dtos
{
    public record GrantItemsDto(Guid UserId , Guid CatalogItemDto , int Quantity);

    public record InventoryItemDto(Guid CatalogItemDto ,int Quantity , DateTimeOffset AcquiredDate );
}
